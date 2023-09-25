// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Configurations;
using FlagQuest.Migrator.Entities;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace FlagQuest.Migrator.Clients;

internal sealed class CountryHttpClient(IOptions<DataSourceOptions> dataSourceOptions, IOptions<JsonOptions> jsonOptions, HttpClient client) : ICountryHttpClient
{
    public async Task<IReadOnlyCollection<Country>> GetAsync()
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = jsonOptions.Value.CaseInsensitive,
            WriteIndented = jsonOptions.Value.Minify
        };

        using HttpResponseMessage response = await client.GetAsync(dataSourceOptions.Value.Countries).ConfigureAwait(false);

        return (await response.Content.ReadFromJsonAsync<Country[]>(options).ConfigureAwait(false))!;
    }
}
