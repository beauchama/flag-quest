using FlagQuest.CountryConverter.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Converters;

internal sealed class LatLngJsonConverter : JsonConverter<GeographicCoordinate>
{
    public override GeographicCoordinate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        AdvanceToStartArray(ref reader);

        double latitude = GetValue(ref reader);
        double longitude = GetValue(ref reader);

        return new GeographicCoordinate(latitude, longitude);

        static void AdvanceToStartArray(ref Utf8JsonReader reader)
        {
               while (reader.TokenType != JsonTokenType.StartArray)
                _ = reader.Read();
        }

        static double GetValue(ref Utf8JsonReader reader)
        {
            _ = reader.Read();
            return reader.GetDouble();
        }
    }

    public override void Write(Utf8JsonWriter writer, GeographicCoordinate value, JsonSerializerOptions options) => throw new NotSupportedException();
}
