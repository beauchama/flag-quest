// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Converters;

internal sealed class LanguagesJsonConverter : JsonConverter<string[]>
{
    public override string[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<string> languages = [];

        if (reader.TokenType != JsonTokenType.StartObject)
            return [];

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType == JsonTokenType.PropertyName)
                languages.Add(reader.GetString()!);
        }

        return languages.ToArray();
    }

    public override void Write(Utf8JsonWriter writer, string[] value, JsonSerializerOptions options) => throw new NotSupportedException();
}
