// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Configurations;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace FlagQuest.Web.Components;

public partial class TopBar
{
    [Inject]
    private IOptions<GitHubOptions> GitHubOptions { get; set; } = default!;

    private static void OnQuestionClick() => Console.WriteLine("Question?");

    private static void OnStatsClick() => Console.WriteLine("Stats");

    private static void OnSettingsClick() => Console.WriteLine("Settings");
}
