// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Converters;

public class LanguagesJsonConverterTests
{
    private readonly JsonConverter<string[]> _jsonConverter = new LanguagesJsonConverter();

    [Fact]
    public void ReadShouldReturnEmptyWhenJsonTokenTypeIsStartObject()
    {
        Utf8JsonReader reader = CreateJsonReader("{}");

        IEnumerable<string> languages = _jsonConverter.Read(ref reader, typeof(string[]), new JsonSerializerOptions())!;

        languages.Should().BeEmpty();
    }

    [Fact]
    public void ReadShouldAddThePropertyName()
    {
        Utf8JsonReader reader = CreateJsonReader("""{ "eng": "English", "fra": "French"}""");

        reader.Read();

        IEnumerable<string> languages = _jsonConverter.Read(ref reader, typeof(string[]), new JsonSerializerOptions())!;

        languages.Should().BeEquivalentTo(["eng", "fra"]);
    }

    [Fact]
    public void WriteShouldThrowNotSupportedException()
    {
        const string json = "{}";
        using MemoryStream stream = new(Encoding.UTF8.GetBytes(json));
        using Utf8JsonWriter writer = new(stream);

        Action act = () => _jsonConverter.Write(writer, [], new JsonSerializerOptions());

        act.Should().ThrowExactly<NotSupportedException>();
    }

    private static Utf8JsonReader CreateJsonReader(string json) => new(Encoding.UTF8.GetBytes(json));
}
