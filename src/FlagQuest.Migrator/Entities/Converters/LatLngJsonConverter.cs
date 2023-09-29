// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.Migrator.Entities.Converters;

internal sealed class LatLngJsonConverter : JsonConverter<GeographicCoordinate>
{
    public override GeographicCoordinate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        double latitude = GetValue(ref reader);
        double longitude = GetValue(ref reader);

        _ = reader.Read();

        return new GeographicCoordinate(latitude, longitude);

        static double GetValue(ref Utf8JsonReader reader)
        {
            _ = reader.Read();
            return reader.GetDouble();
        }
    }

    public override void Write(Utf8JsonWriter writer, GeographicCoordinate value, JsonSerializerOptions options) => throw new NotSupportedException();
}
