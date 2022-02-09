using System.Text.Json;
using Entities;

namespace JsonData;

public class JsonDataContext
{
    private string path = "vialabs.json";

    private ViaLabData viaLabData = null!;

    public ViaLabData ViaLabData
    {
        get
        {
            LoadData();
            return viaLabData;
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
                UnApprovedTeachers = new List<Teacher>()
            };
            string vldAsJson = JsonSerializer.Serialize(vld);
            File.WriteAllText(path, vldAsJson);
        }
    }

    private void LoadData()
    {
        string vldAsJson = File.ReadAllText(path);
        viaLabData = JsonSerializer.Deserialize<ViaLabData>(vldAsJson)!;
    }

    public void SaveChanges()
    {
        var vldAsJson = JsonSerializer.Serialize(viaLabData, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(path, vldAsJson);
        viaLabData = null!;
    }
}