using Domain.Entities;

namespace JsonData.Context;

public class CollectionsDataContext
{

    // I've used something from here, regarding json and private constructors. I apparently found it important to save the link.
    // And this should probably be in the JsonCollectionDataManager class. Someday.
    // https://stackoverflow.com/questions/58147552/can-i-deserialize-json-with-private-constructor-using-system-text-json

    private ViaLabData? viaLabData;
    private readonly ICollectionDataManager dataMgr;
    
    public ICollection<Teacher> Teachers => ViaLabData.Teachers;
    public ICollection<Category> Categories => ViaLabData.Teachers.SelectMany(teacher => teacher.Categories).ToList();
    public ICollection<ExternalResource> ExternalResources => Categories.SelectMany(category => category.ExternalResources).ToList();
    public ICollection<Guide> Guides => Categories.SelectMany(category => category.Guides).ToList();
    public ICollection<Slide> Slides => Guides.SelectMany(guide => guide.Slides).ToList();

    private ViaLabData ViaLabData
    {
        get
        {
            if (viaLabData is null)
            {
                LoadData();
            }

            return viaLabData!;
        }
    }

    public CollectionsDataContext(ICollectionDataManager dataMgr)
    {
        this.dataMgr = dataMgr;
    }

    private void LoadData()
    {
        viaLabData = dataMgr.LoadData();
    }

    public void SaveChanges()
    {
        dataMgr.SaveData(viaLabData!);
        viaLabData = null;
    }
}

