// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Entities.Mappers;

public class CountryMapperTests
{
    private readonly Country _country = new()
    {
        Name = new Translation("Italy", "Italian Republic"),
        Code = "ITA",
        Capitals = ["Rome"],
        Region = "Europe",
        SubRegion = "Southern Europe",
        Languages = ["ita"],
        Translations = new Translations() { French = new Translation("Italie", "République italienne") },
        Coordinate = new GeographicCoordinate(42.83333333, 12.83333333),
        LandLocked = false,
        Borders = ["AUT", "FRA", "SMR", "SVN", "CHE", "VAT"],
        Area = 301336
    };

    [Fact]
    public void ToApiResourceShouldMapCorrectly()
    {
        Api.Resources.Country country = new[] { _country }.ToApiResources().First();

        country.Code.Should().Be(_country.Code);
        country.Capitals.Should().BeEquivalentTo(_country.Capitals);

        country.Location.Region.Should().Be(_country.Region);
        country.Location.SubRegion.Should().Be(_country.SubRegion);

        country.Languages.Should().BeEquivalentTo(_country.Languages);

        country.Translations.English.Name.Should().Be(_country.Name.Common);
        country.Translations.English.OfficialName.Should().Be(_country.Name.Official);

        country.Translations.French.Name.Should().Be(_country.Translations.French.Common);
        country.Translations.French.OfficialName.Should().Be(_country.Translations.French.Official);

        country.Coordinate.Latitude.Should().Be(_country.Coordinate.Latitude);
        country.Coordinate.Longitude.Should().Be(_country.Coordinate.Longitude);

        country.LandLocked.Should().Be(_country.LandLocked);
        country.Borders.Should().BeEquivalentTo(_country.Borders);
        country.Area.Should().Be(_country.Area);
    }

    [Fact]
    public void ToApiResourcesShouldMapCorrectlyAListOfCountry()
    {
        Api.Resources.Country[] countries = new[] { _country, _country with { Code = "CAN" } }.ToApiResources().ToArray();

        countries.Should().HaveCount(2);

        countries[0].Code.Should().Be(_country.Code);
        countries[1].Code.Should().Be("CAN");
    }
}
