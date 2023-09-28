// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.Models;

namespace FlagQuest.Web.Flags.Algorithms;

internal sealed class GeographicCalculator : IGeographicCalculator
{
    public double CalculateDistance(Coordinate left, Coordinate right)
    {
        const double earthRadius = 6371;

        double leftLatitude = ToRadians(left.Latitude);
        double leftLongitude = ToRadians(left.Longitude);
        double rightLatitude = ToRadians(right.Latitude);
        double rightLongitude = ToRadians(right.Longitude);

        double deltaLatitude = rightLatitude - leftLatitude;
        double deltaLongitude = rightLongitude - leftLongitude;

        double sinLatitude = Math.Sin(deltaLatitude / 2);
        double sinLongitude = Math.Sin(deltaLongitude / 2);

        double a = Math.Pow(sinLatitude, 2) + Math.Cos(leftLatitude) * Math.Cos(rightLatitude) * Math.Pow(sinLongitude, 2);
        return 2 * earthRadius * Math.Asin(Math.Sqrt(a));

        static double ToRadians(double degrees) => degrees * Math.PI / 180.0;
    }
}
