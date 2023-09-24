// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .Configure<DataSourceOptions>(builder.Configuration.GetSection(DataSourceOptions.Section))
    .Configure<JsonOptions>(builder.Configuration.GetSection(JsonOptions.Section));

_ = builder.Build();
