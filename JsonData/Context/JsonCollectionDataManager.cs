using System.Text.Json;
using Domain.Models;
using JsonData.JsonSerializationUtils;

namespace JsonData.Context;

public class JsonCollectionDataManager : ICollectionDataManager
{
    private readonly IJsonHelper jsonHelper;
    private readonly string path = "vialabs.json";

    public JsonCollectionDataManager(IJsonHelper jsonHelper)
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
            string vldAsJson = jsonHelper.Serialize(vld);
            File.WriteAllText(path, vldAsJson);
        }
    }

    public ViaLabData LoadData()
    {
        string vldAsJson = File.ReadAllText(path);
        ViaLabData data = jsonHelper.Deserialize<ViaLabData>(vldAsJson);
        return data;
    }

    public void SaveData(ViaLabData viaLabData)
    {
        if (viaLabData is null) 
            throw new NullReferenceException("You are trying to save non-existing data. Severe server error");
        
        string vldAsJson = jsonHelper.Serialize(viaLabData);
        File.WriteAllText(path, vldAsJson);
    }
}