// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.State;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FlagQuest.Web.Extensions;

public static class FluxorExtensions
{
    public static IServiceCollection ConfigureFluxor(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
    {
        return services.AddFluxor(options =>
        {
            _ = options.AddFlagsState();

            if (environment.IsDevelopment())
                _ = options.UseReduxDevTools(r => r.Name = "Flag Quest");
        });
    }

    public static void Dispatch<TAction>(this IDispatcher dispatcher) where TAction : new() => dispatcher.Dispatch(new TAction());
}
