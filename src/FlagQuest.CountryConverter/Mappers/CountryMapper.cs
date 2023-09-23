// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.CountryConverter.Resources;

namespace FlagQuest.CountryConverter.Mappers;

internal static class CountryMapper
{
    public static Shared.Country ToCountry(this Country country) => new()
    {
        Code = country.Code,
        Capitals = country.Capitals,
        Location = new(country.Region, country.SubRegion),
        Languages = country.Languages,
        Translations = new Shared.Translations
        {
            English = new Shared.Translation(country.Name.Common, country.Name.Official),
            French = new Shared.Translation(country.Translations.French.Common, country.Translations.French.Official),
        },
        Coordinate = new(country.Coordinate.Latitude, country.Coordinate.Longitude),
        LandLocked = country.LandLocked,
        Borders = country.Borders,
        Area = country.Area
    };
}
