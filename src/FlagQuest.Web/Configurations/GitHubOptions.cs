// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Web.Configurations;

public sealed record GitHubOptions
{
    public const string Section = "github";

    public required Uri Assets { get; set; }

    public required Uri Repository { get; set; }
}
