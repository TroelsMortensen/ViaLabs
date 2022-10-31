using System.Text.Json;
using Domain.Models;

namespace JsonData.Context;

public class JsonDataContext 
{
    private string path = "vialabs.json";

    private ViaLabData? viaLabData;

    public ViaLabData ViaLabData
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
                Categories = new List<Category>(),
                Guides = new List<Guide>()
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

    public void SaveChangesAsync()
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
    public ICollection<Category> Categories { get; set; } = new List<Category>();

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();

    public ICollection<ExternalResource> ExternalResources { get; set; } = new List<ExternalResource>();
}