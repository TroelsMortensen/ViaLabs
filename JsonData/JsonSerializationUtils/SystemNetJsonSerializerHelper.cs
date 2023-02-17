using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace JsonData.JsonSerializationUtils;

public class SystemNetJsonSerializerHelper : IJsonHelper
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        TypeInfoResolver = new PrivateConstructorContractResolver()
        {
            Modifiers =
            {
                // AddPrivateFieldsModifier,
                AddPrivatePropertiesModifier
            }
        },
        // IncludeFields = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        // PropertyNameCaseInsensitive = true
    };

    public string Serialize<T>(T obj)
    {
        string asJson = JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        return asJson;
    }

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, jsonOptions)!;
    }

    static void AddPrivateFieldsModifier(JsonTypeInfo jsonTypeInfo)
    {
        if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        // if (!jsonTypeInfo.Type.IsDefined(typeof(JsonIncludePrivateFieldsAttribute), inherit: false))
        //     return;

        foreach (FieldInfo field in jsonTypeInfo.Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            JsonPropertyInfo jsonPropertyInfo = jsonTypeInfo.CreateJsonPropertyInfo(field.FieldType, field.Name);
            jsonPropertyInfo.Get = field.GetValue;
            jsonPropertyInfo.Set = field.SetValue;

            jsonTypeInfo.Properties.Add(jsonPropertyInfo);
        }
    }

    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/custom-contracts
    // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability?pivots=dotnet-7-0
    // https://stackoverflow.com/questions/69448540/net-core-the-json-property-name-for-collides-with-another-property
    static void AddPrivatePropertiesModifier(JsonTypeInfo jsonTypeInfo)
    {
        if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        // if (!jsonTypeInfo.Type.IsDefined(typeof(JsonIncludePrivateFieldsAttribute), inherit: false))
        //     return;

        foreach (PropertyInfo property in jsonTypeInfo.Type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                                                                          BindingFlags.Public |
                                                                          BindingFlags.SetProperty))
        {
            JsonPropertyInfo jsonPropertyInfo = jsonTypeInfo.CreateJsonPropertyInfo(property.PropertyType, property.Name);
            jsonPropertyInfo.Get = property.GetValue;
            jsonPropertyInfo.Set = property.SetValue;

            jsonTypeInfo.Properties.Add(jsonPropertyInfo);
        }
    }
}