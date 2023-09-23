// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.CountryConverter.Data;

public interface ICountryData
{
    string Common { get; }

    string Official { get; }

    string CountryCode3 { get; }

    IEnumerable<string> Capitals { get; }

    string Region { get; }

    string SubRegion { get; }

    IEnumerable<string> Languages { get; }

    string FrenchCommon { get; }

    string FrenchOfficial { get; }

    double Latitude { get; }

    double Longitude { get; }

    bool Landlocked { get; }

    IEnumerable<string> Borders { get; }

    double Area { get; }
}
