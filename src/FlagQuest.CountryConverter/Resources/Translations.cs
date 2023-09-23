// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Resources;

internal sealed record Translations
{
    [JsonPropertyName("fra")]
    public required Translation French { get; init; }
}
