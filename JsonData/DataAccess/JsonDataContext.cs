using System.Text.Json;
using Application.RepositoryContracts;
using Domain.Models;

namespace JsonData.DataAccess;

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

    public Task SaveChangesAsync()
    {
        Console.WriteLine("Saving changes!");
        string vldAsJson = JsonSerializer.Serialize(viaLabData, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(path, vldAsJson);
        viaLabData = null;
        return Task.CompletedTask;
    }

    public void Clear()
    {
        viaLabData = null;
    }
}