using System.Text.Json;
using System.Text.Json.Serialization;
using JsonData.Context;

namespace JsonData;

public class ViaDataJsonConverter : JsonConverter<ViaLabData>
{
    public override ViaLabData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ViaLabData value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}