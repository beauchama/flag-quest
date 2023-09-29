// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Resources;

namespace FlagQuest.Api.Endpoints;

/// <summary>
/// The country endpoint.
/// </summary>
public interface ICountryEndpoint
{
    /// <summary>
    /// Gets all the countries.
    /// </summary>
    /// <returns>All countries.</returns>
    Task<IReadOnlyCollection<Country>> GetAsync();
}
