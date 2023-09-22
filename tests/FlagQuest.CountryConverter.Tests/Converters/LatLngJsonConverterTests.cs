// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.CountryConverter.Resources;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Converters;

public class LatLngJsonConverterTests
{
    private readonly JsonConverter<GeographicCoordinate> _jsonConverter = new LatLngJsonConverter();

    [Fact]
    public void ReadShouldGetTheLatitudeFromJson()
    {
        Utf8JsonReader reader = CreateJsonReader("""{ "latlng": [ 42.83333333, 12.83333333 ] }""");

        reader.Read();

        GeographicCoordinate coordinate = _jsonConverter.Read(ref reader, typeof(GeographicCoordinate), new JsonSerializerOptions())!;

        coordinate.Latitude.Should().BeApproximately(42.83333333, 0.5);
    }

    [Fact]
    public void ReadShouldGetTheLongitudeFromJson()
    {
        Utf8JsonReader reader = CreateJsonReader("""{ "latlng": [ 42.83333333, 12.83333333 ] }""");

        reader.Read();

        GeographicCoordinate coordinate = _jsonConverter.Read(ref reader, typeof(GeographicCoordinate), new JsonSerializerOptions())!;

        coordinate.Longitude.Should().BeApproximately(12.83333333, 0.5);
    }

    [Fact]
    public void WriteShouldThrowNotSupportedException()
    {
        const string json = "{}";
        using MemoryStream stream = new(Encoding.UTF8.GetBytes(json));
        using Utf8JsonWriter writer = new(stream);

        Action act = () => _jsonConverter.Write(writer, new GeographicCoordinate(0, 0), new JsonSerializerOptions());

        act.Should().ThrowExactly<NotSupportedException>();
    }

    private static Utf8JsonReader CreateJsonReader(string json) => new(Encoding.UTF8.GetBytes(json));
}
