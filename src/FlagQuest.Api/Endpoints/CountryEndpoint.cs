// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Resources;
using System.Net.Http.Json;
using System.Text.Json;

namespace FlagQuest.Api.Endpoints;

internal sealed class CountryEndpoint(HttpClient httpClient) : ICountryEndpoint
{
    public async Task<IReadOnlyCollection<Country>> GetAsync()
    {
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        using HttpResponseMessage response = await httpClient.GetAsync(CountryFilePath.FullJsonPath).ConfigureAwait(false);

        return (await response.Content.ReadFromJsonAsync<Country[]>(options).ConfigureAwait(false))!;
    }
}
