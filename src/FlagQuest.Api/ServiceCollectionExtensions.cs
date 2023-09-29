// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace FlagQuest.Api;

/// <summary>
/// Configure the endpoints through injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configure the endpoints.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="baseAddress">The base address for endpoints.</param>
    /// <returns>The services with endpoints.</returns>
    public static IServiceCollection AddEndpoints(this IServiceCollection services, string baseAddress)
    {
        _ = services.AddHttpClient<ICountryEndpoint, CountryEndpoint>(options => options.BaseAddress = new Uri(baseAddress));

        return services;
    }
}
