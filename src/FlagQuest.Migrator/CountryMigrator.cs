// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Clients;
using FlagQuest.Migrator.Entities;
using FlagQuest.Migrator.Entities.Mappers;
using FlagQuest.Migrator.IO;

namespace FlagQuest.Migrator;

internal sealed class CountryMigrator(IJsonWriter jsonWriter, ICountryHttpClient client) : IMigrator
{
    public async Task MigrateAsync(string path)
    {
        IReadOnlyCollection<Country> countries = await client.GetAsync().ConfigureAwait(false);

        await jsonWriter.WriteAsync(path, countries.ToApiResources()).ConfigureAwait(false);
    }
}
