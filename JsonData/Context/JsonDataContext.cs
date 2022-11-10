using System.Text.Json;
using Domain.Models;

namespace JsonData.Context;

public class JsonDataContext
{
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

    public JsonDataContext()
    {
        if (!File.Exists(path))
        {
            ViaLabData vld = new()
            {
                Teachers = new List<Teacher>()
                {
                    new Teacher("VIA\\TRMO")
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
        viaLabData = JsonSerializer.Deserialize<ViaLabData>(vldAsJson);
    }

    public void SaveChanges()
    {
        Console.WriteLine("Saving changes!");
        string vldAsJson = JsonSerializer.Serialize(viaLabData, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(path, vldAsJson);
        viaLabData = null;
    }

    public void Clear()
    {
        viaLabData = null;
    }
}

class ViaLabData
{
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Teacher> UnApprovedTeachers { get; set; } = new List<Teacher>();
}