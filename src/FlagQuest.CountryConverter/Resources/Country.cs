// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.CountryConverter.Converters;
using System.Text.Json.Serialization;

namespace FlagQuest.CountryConverter.Resources;

internal sealed record Country
{
    public required Translation Name { get; init; }

    [JsonPropertyName("cca3")]
    public required string Code { get; init; }

    [JsonPropertyName("capital")]
    public required string[] Capitals { get; init; }

    public required string Region { get; init; }

    public required string SubRegion { get; init; }

    [JsonConverter(typeof(LanguagesJsonConverter))]
    public required string[] Languages { get; init; }

    public required Translations Translations { get; init; }

    [JsonPropertyName("latlng")]
    [JsonConverter(typeof(LatLngJsonConverter))]
    public required GeographicCoordinate Coordinate { get; init; }

    public required bool LandLocked { get; init; }

    public required string[] Borders { get; init; } = [];

    public required double Area { get; init; }
}
