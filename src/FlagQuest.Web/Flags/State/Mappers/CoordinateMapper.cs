// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Resources;
using FlagQuest.Web.Flags.Models;

namespace FlagQuest.Web.Flags.State.Mappers;

internal static class CoordinateMapper
{
    internal static Coordinate ToCoordinate(this GeographicCoordinate coordinate)
        => new(coordinate.Latitude, coordinate.Longitude);
}
