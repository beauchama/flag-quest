// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Entities;

namespace FlagQuest.Migrator.Clients;

internal interface ICountryHttpClient
{
    Task<IReadOnlyCollection<Country>> GetAsync();
}
