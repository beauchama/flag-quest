// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.Models;

namespace FlagQuest.Web.Flags.Algorithms;

internal interface IGeographicCalculator
{
    double CalculateDistance(Coordinate left, Coordinate right);
}
