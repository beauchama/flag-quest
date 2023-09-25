// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Api.Resources;

/// <summary>
/// Represents information about a country.
/// </summary>
public sealed record Country
{
    /// <summary>
    /// Gets the alpha-3 country code.
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// Gets the capital cities of the country.
    /// </summary>
    public required string[] Capitals { get; init; }

    /// <summary>
    /// Gets the geographic location of the country.
    /// </summary>
    public required GeographicLocation Location { get; init; }

    /// <summary>
    /// Gets the languages spoken in the country.
    /// </summary>
    public required string[] Languages { get; init; }

    /// <summary>
    /// Gets the translations for the country's name.
    /// </summary>
    public required Translations Translations { get; init; }

    /// <summary>
    /// Gets the geographic coordinates of the country.
    /// </summary>
    public required GeographicCoordinate Coordinate { get; init; }

    /// <summary>
    /// Gets a value indicating whether the country is landlocked.
    /// </summary>
    public required bool LandLocked { get; init; }

    /// <summary>
    /// Gets the neighboring countries' codes.
    /// </summary>
    public required string[] Borders { get; init; }

    /// <summary>
    /// Gets the land area of the country (in square kilometers).
    /// </summary>
    public required double Area { get; init; }
}
