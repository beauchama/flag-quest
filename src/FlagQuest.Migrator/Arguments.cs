// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using CommandLine;

namespace FlagQuest.Migrator;

internal sealed class Arguments
{
    [Option('o', "output", HelpText = "write the json file to the specific path")]
    public string? OutputPath { get; set; }
}
