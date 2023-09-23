// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Shared;

/// <summary>
/// Represents the geographic location of a country.
/// </summary>
/// <param name="Region">Represents the larger geographical area.</param>
/// <param name="SubRegion">Represents a specific part of the region.</param>
public sealed record GeographicLocation(string Region, string SubRegion);
