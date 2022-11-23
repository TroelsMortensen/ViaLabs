using Newtonsoft.Json;

namespace JsonData.JsonSerializationUtils;

public class NewtonsoftSerializerHelper : IJsonHelper
{
    public string Serialize<T>(T obj)
    {
        string asJson = JsonConvert.SerializeObject(obj);
        return asJson;
    }

    public T Deserialize<T>(string json)
    {
        JsonSerializerSettings settings = new () { ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor };
        return JsonConvert.DeserializeObject<T>(json, settings)!;
    }
}