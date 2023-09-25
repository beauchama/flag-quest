// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using CommandLine;
using FlagQuest.Api;
using FlagQuest.Migrator;
using FlagQuest.Migrator.Clients;
using FlagQuest.Migrator.Configurations;
using FlagQuest.Migrator.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<ICountryHttpClient, CountryHttpClient>();

builder.Services
    .AddTransient<IJsonWriter, JsonWriter>()
    .AddTransient<IMigrator, CountryMigrator>()
    .Configure<DataSourceOptions>(builder.Configuration.GetSection(DataSourceOptions.Section))
    .Configure<JsonOptions>(builder.Configuration.GetSection(JsonOptions.Section));

IHost app = builder.Build();

IMigrator migrator = app.Services.GetRequiredService<IMigrator>();
IHostEnvironment environment = app.Services.GetRequiredService<IHostEnvironment>();

await Parser.Default.ParseArguments<Arguments>(args).WithParsedAsync(async (o) =>
{
    if (!string.IsNullOrEmpty(o.OutputPath))
    {
        await migrator.MigrateAsync(o.OutputPath).ConfigureAwait(false);
    }
    else
    {
        await migrator.MigrateAsync(Path.Combine(environment.ContentRootPath, $"../../../../{CountryFilePath.JsonFileName}")).ConfigureAwait(false);
    }
}).ConfigureAwait(false);
