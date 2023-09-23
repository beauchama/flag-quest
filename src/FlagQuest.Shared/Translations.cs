// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json.Serialization;

namespace FlagQuest.Shared;

/// <summary>
/// Represents a list of translations.
/// </summary>
public sealed record Translations
{
    /// <summary>
    /// Gets the French translation.
    /// </summary>
    [JsonPropertyName("fra")]
    public required Translation French { get; init; }

    /// <summary>
    /// Gets the English translation.
    /// </summary>
    [JsonPropertyName("eng")]
    public required Translation English { get; init; }
}
