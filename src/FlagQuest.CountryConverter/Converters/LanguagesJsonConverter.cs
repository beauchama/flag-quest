// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Converters;

internal sealed class LanguagesJsonConverter : JsonConverter<IEnumerable<string>>
{
    public override IEnumerable<string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<string> languages = [];

        if (reader.TokenType != JsonTokenType.StartObject)
            return languages;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
                languages.Add(reader.GetString()!);
        }

        return languages;
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<string> value, JsonSerializerOptions options) => throw new NotSupportedException();
}
