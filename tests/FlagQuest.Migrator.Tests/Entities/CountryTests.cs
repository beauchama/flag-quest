// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Fixtures;
using FlagQuest.Migrator.Samples;

namespace FlagQuest.Migrator.Entities;

public class CountryTests(CountryJsonFixture fixture) : IClassFixture<CountryJsonFixture>
{
    public static TheoryData<string, ICountryData> GetCountries() => new()
    {
        { nameof(Italy), new Italy() },
        { nameof(SouthAfrica), new SouthAfrica() },
        { nameof(Antarctica), new Antarctica() }
    };

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldNotBeNull(string countryName, ICountryData _)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheCommonCountryName(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Name.Common.Should().Be(countryData.Common);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheOfficialCountryName(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Name.Official.Should().Be(countryData.Official);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheCountryCode3(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Code.Should().Be(countryData.CountryCode3);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheCapitals(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Capitals.Should().BeEquivalentTo(countryData.Capitals);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheRegion(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Region.Should().Be(countryData.Region);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheSubRegion(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.SubRegion.Should().Be(countryData.SubRegion);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheLanguages(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Languages.Should().BeEquivalentTo(countryData.Languages);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void TranslationsShouldNotBeNull(string countryName, ICountryData _)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Translations.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheFrenchTranslation(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        (string common, string official) = country.Translations.French;

        common.Should().Be(countryData.FrenchCommon);
        official.Should().Be(countryData.FrenchOfficial);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveTheGeographicCoordinate(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        (double latitude, double longitude) = country.Coordinate;

        latitude.Should().BeApproximately(countryData.Latitude, 0.0001);
        longitude.Should().BeApproximately(countryData.Longitude, 0.0001);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveLandlocked(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.LandLocked.Should().Be(countryData.Landlocked);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveBorders(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Borders.Should().BeEquivalentTo(countryData.Borders);
    }

    [Theory]
    [MemberData(nameof(GetCountries))]
    public void CountryShouldHaveArea(string countryName, ICountryData countryData)
    {
        Country country = fixture.Deserialize<Country>(countryName);

        country.Area.Should().BeApproximately(countryData.Area, 0.0001);
    }
}
