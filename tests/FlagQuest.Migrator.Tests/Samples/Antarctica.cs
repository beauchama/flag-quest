// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Samples;

public sealed record Antarctica : ICountryData
{
    public string Common { get; } = "Antarctica";

    public string Official { get; } = "Antarctica";

    public string CountryCode3 { get; } = "ATA";

    public IEnumerable<string> Capitals { get; } = [];

    public string Region { get; } = "Antarctic";

    public string SubRegion { get; } = string.Empty;

    public IEnumerable<string> Languages { get; } = [];

    public string FrenchCommon { get; } = "Antarctique";

    public string FrenchOfficial { get; } = "Antarctique";

    public double Latitude { get; } = -90;

    public double Longitude { get; }

    public bool Landlocked { get; }

    public IEnumerable<string> Borders { get; } = [];

    public double Area { get; } = 14000000;
}
