// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Api.Resources;

/// <summary>
/// Represents a geographic coordinate.
/// </summary>
/// <param name="Latitude">
/// The latitude which specifies the north-south position of a point.
/// <list type="bullet">
/// <item>The positive latitude values are north of the equator. The range is [0, 90].</item>
/// <item>The negative latitude values are south of the equator. The range is [-90, 0].</item>
/// </list>
/// </param>
/// <param name="Longitude">
/// The longitude which specifies the east-west position of a point.
/// <list type="bullet">
/// <item>The positive longitude values are east of the prime meridian (Greenwich). The range is [0, 180].</item>
/// <item>The negative longitude values are west of the prime meridian (Greenwich). The range is [-180, 0].</item>
/// </list>
/// </param>
public sealed record GeographicCoordinate(double Latitude, double Longitude);
