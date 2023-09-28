// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Api;
using FlagQuest.Web;
using FlagQuest.Web.Configurations;
using FlagQuest.Web.Extensions;
using FlagQuest.Web.Flags.Algorithms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddTransient<IGeographicCalculator, GeographicCalculator>()
    .Configure<GitHubOptions>(builder.Configuration.GetSection(GitHubOptions.Section))
    .ConfigureFluxor(builder.HostEnvironment)
    .AddEndpoints(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync().ConfigureAwait(false);
