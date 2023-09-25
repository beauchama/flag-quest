// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api;
using FlagQuest.Web;
using FlagQuest.Web.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .ConfigureFluxor(builder.HostEnvironment)
    .AddEndpoints(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync().ConfigureAwait(false);
