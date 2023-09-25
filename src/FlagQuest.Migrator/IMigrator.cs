// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator;

internal interface IMigrator
{
    Task MigrateAsync(string path);
}
