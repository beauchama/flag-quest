// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api.Endpoints;
using FlagQuest.Api.Resources;
using FlagQuest.Web.Flags.State.Mappers;
using Fluxor;

namespace FlagQuest.Web.Flags.State;

public class FlagsEffects(ICountryEndpoint countryEndpoint)
{
    [EffectMethod(typeof(FlagsActions.Get))]
    public async Task GetAllCountriesAsync(IDispatcher dispatcher)
    {
        IReadOnlyCollection<Country> countries = await countryEndpoint.GetAsync().ConfigureAwait(false);

        dispatcher.Dispatch(new FlagsActions.GetResult(countries.ToFlags()));
    }
}
