// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json.Serialization;

namespace FlagQuest.Migrator.Entities;

internal sealed record Translations
{
    [JsonPropertyName("fra")]
    public required Translation French { get; init; }
}
