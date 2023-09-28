// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Components.Icons;
using FlagQuest.Web.Configurations;
using FlagQuest.Web.Flags.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace FlagQuest.Web.Flags.Components;

public partial class FlagRow
{
    [Parameter]
    [EditorRequired]
    public required GuessedFlag Flag { get; init; }

    [Inject]
    private IOptions<GitHubOptions> GitHubOptions { get; set; } = default!;

    private Uri GetFlag() => new($"{GitHubOptions.Value.Assets}/flags/{Flag.Code}.svg");

    private string GetAreaIcon() => Flag.IsBigger ? BootstrapIcon.ArrowUpSquare : BootstrapIcon.ArrowDownSquare;

    private string GetContinentIcon() => Flag.SameContinent
        ? $"{BootstrapIcon.CheckCircle} text-success"
        : $"{BootstrapIcon.XCircle} text-danger";
}
