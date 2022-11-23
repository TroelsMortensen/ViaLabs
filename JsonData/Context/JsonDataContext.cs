using System.Text.Json;
using Domain.Models;
using JsonData.JsonSerializationUtils;

namespace JsonData.Context;

public class JsonDataContext
{
    private readonly IJsonHelper jsonHelper;

    // todo jeg har brug for at kunne deserialize med private constructor. 
        // https://stackoverflow.com/questions/58147552/can-i-deserialize-json-with-private-constructor-using-system-text-json
    
    private string path = "vialabs.json";

    private ViaLabData? viaLabData;
    

    

    // todo de her skal returnere select many pga tree structurre
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

    public JsonDataContext(IJsonHelper jsonHelper)
    {
        this.jsonHelper = jsonHelper;
        if (!File.Exists(path))
        {
            ViaLabData vld = new()
            {
                Teachers = new List<Teacher>()
                {
                    Teacher.Create("VIA\\TRMO").Value
                },
                UnApprovedTeachers = new List<Teacher>(),
            };
            string vldAsJson = JsonSerializer.Serialize(vld, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, vldAsJson);
        }
    }

    private void LoadData()
    {
        string vldAsJson = File.ReadAllText(path);
        viaLabData = jsonHelper.Deserialize<ViaLabData>(vldAsJson);
        // int stopher = 0;
    }

    public void SaveChanges()
    {
        Console.WriteLine("Saving changes!");
        string vldAsJson = jsonHelper.Serialize(viaLabData);
        File.WriteAllText(path, vldAsJson);
        viaLabData = null;
    }

    public void Clear()
    {
        viaLabData = null;
    }
}

public class ViaLabData
{
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Teacher> UnApprovedTeachers { get; set; } = new List<Teacher>();
}