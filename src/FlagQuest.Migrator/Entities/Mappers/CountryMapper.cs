// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Entities.Mappers;

internal static class CountryMapper
{
    internal static IReadOnlyCollection<Api.Resources.Country> ToApiResources(this IReadOnlyCollection<Country> countries)
        => countries.Select(ToApiResource).ToArray();

    private static Api.Resources.Country ToApiResource(this Country country) => new()
    {
        Code = country.Code,
        Capitals = country.Capitals,
        Location = new(country.Region, country.SubRegion),
        Languages = country.Languages,
        Translations = new Api.Resources.Translations
        {
            English = new Api.Resources.Translation(country.Name.Common, country.Name.Official),
            French = new Api.Resources.Translation(country.Translations.French.Common, country.Translations.French.Official),
        },
        Coordinate = new(country.Coordinate.Latitude, country.Coordinate.Longitude),
        LandLocked = country.LandLocked,
        Borders = country.Borders,
        Area = country.Area
    };
}
