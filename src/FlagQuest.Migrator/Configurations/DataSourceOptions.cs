// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Configurations;

internal sealed class DataSourceOptions
{
    public const string Section = "sources";

    public required Uri Countries { get; set; }
}
