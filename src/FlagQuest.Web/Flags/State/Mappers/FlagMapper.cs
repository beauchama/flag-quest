// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Resources;
using FlagQuest.Web.Flags.Models;
using System.Globalization;

namespace FlagQuest.Web.Flags.State.Mappers;

internal static class FlagMapper
{
    internal static IReadOnlyCollection<Flag> ToFlags(this IReadOnlyCollection<Country> countries)
        => countries.Select(ToFlag).ToArray();

    private static Flag ToFlag(this Country country)
        => new(country.Code.ToLower(CultureInfo.InvariantCulture), country.Translations.ToTranslations(), country.Location.Region, country.Area, country.Coordinate.ToCoordinate());
}
