// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

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

string basePath = environment.IsDevelopment()
    ? Path.Combine(environment.ContentRootPath, $"../../../../FlagQuest.Web/wwwroot/{CountryFilePath.DataFolder}")
    : Path.Combine(environment.ContentRootPath, $"../../FlagQuest.Web/release/wwwroot/{CountryFilePath.DataFolder}");

DirectoryInfo directory = Directory.CreateDirectory(basePath);
await migrator.MigrateAsync(Path.Combine(directory.FullName, CountryFilePath.JsonFileName)).ConfigureAwait(false);
