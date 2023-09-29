// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.Configurations;

internal sealed record JsonOptions
{
    public const string Section = "json";

    public bool CaseInsensitive { get; set; }

    public bool Minify { get; set; }
}
