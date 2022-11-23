using System.Text.Json;

namespace JsonData.JsonSerializationUtils;

public class SystemNetJsonSerializerHelper : IJsonHelper
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        TypeInfoResolver = new PrivateConstructorContractResolver(),
        IncludeFields = true
    };
    
    public string Serialize<T>(T obj)
    {
        string asJson = JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        return asJson;
    }
    
    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, jsonOptions)!;
    }
}