// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Samples;

public sealed record Italy : ICountryData
{
    public string Common { get; } = "Italy";

    public string Official { get; } = "Italian Republic";

    public string CountryCode3 { get; } = "ITA";

    public IEnumerable<string> Capitals { get; } = ["Rome"];

    public string Region { get; } = "Europe";

    public string SubRegion { get; } = "Southern Europe";

    public IEnumerable<string> Languages { get; } = ["ita"];

    public string FrenchCommon { get; } = "Italie";

    public string FrenchOfficial { get; } = "République italienne";

    public double Latitude { get; } = 42.83333333;

    public double Longitude { get; } = 12.83333333;

    public bool Landlocked { get; }

    public IEnumerable<string> Borders { get; } = ["AUT", "FRA", "SMR", "SVN", "CHE", "VAT"];

    public double Area { get; } = 301336;
}
