// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.CountryConverter.Mappers;
using FlagQuest.CountryConverter.Resources;
using System.Net.Http.Json;
using System.Text.Json;

Uri countryJsonUri = new("https://raw.githubusercontent.com/mledoze/countries/master/countries.json");

using HttpClient client = new();

Country[] countries = (await client.GetFromJsonAsync<Country[]>(countryJsonUri).ConfigureAwait(false))!;

JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
string json = JsonSerializer.Serialize(countries.Select(c => c.ToCountry()), options);

await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}/{FlagQuest.Shared.CountryFilePath.JsonFileName}", json).ConfigureAwait(false);
