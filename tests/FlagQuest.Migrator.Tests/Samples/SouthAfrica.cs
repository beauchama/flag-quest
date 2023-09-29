// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Samples;

public sealed record SouthAfrica : ICountryData
{
    public string Common { get; } = "South Africa";

    public string Official { get; } = "Republic of South Africa";

    public string CountryCode3 { get; } = "ZAF";

    public IEnumerable<string> Capitals { get; } = ["Pretoria", "Bloemfontein", "Cape Town"];

    public string Region { get; } = "Africa";

    public string SubRegion { get; } = "Southern Africa";

    public IEnumerable<string> Languages { get; } = ["afr", "eng", "nbl", "nso", "sot", "ssw", "tsn", "tso", "ven", "xho", "zul"];

    public string FrenchCommon { get; } = "Afrique du Sud";

    public string FrenchOfficial { get; } = "République d'Afrique du Sud";

    public double Latitude { get; } = -29.0;

    public double Longitude { get; } = 24.0;

    public bool Landlocked { get; }

    public IEnumerable<string> Borders { get; } = ["BWA", "LSO", "MOZ", "NAM", "SWZ", "ZWE"];

    public double Area { get; } = 1221037;
}
