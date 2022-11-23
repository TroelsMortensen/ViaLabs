using System.Text.Json;
using JsonData.Context;

namespace JsonData.JsonSerializationUtils;

public interface IJsonHelper
{
    string Serialize<T>(T viaLabData);
    T Deserialize<T>(string json);
}