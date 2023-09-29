// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Components.Icons;
using FlagQuest.Web.Configurations;
using FlagQuest.Web.Flags.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace FlagQuest.Web.Flags.Components;

public partial class FlagRow
{
    [Parameter]
    [EditorRequired]
    public required GuessedFlag Flag { get; init; }

    [Parameter]
    [EditorRequired]
    public required Coordinate Coordinate { get; init; }

    [Inject]
    private IOptions<GitHubOptions> GitHubOptions { get; set; } = default!;

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        Console.WriteLine(Flag.Code);

        await JsRuntime.InvokeVoidAsync("rotateArrow", Flag.Code, Flag.Coordinate, Coordinate);
    }

    private Uri GetFlag() => new($"{GitHubOptions.Value.Assets}/flags/{Flag.Code}.svg");

    private string GetAreaIcon() => Flag.IsBigger ? BootstrapIcon.ArrowUpSquare : BootstrapIcon.ArrowDownSquare;

    private string GetContinentIcon() => Flag.SameContinent
        ? $"{BootstrapIcon.CheckCircle} text-success"
        : $"{BootstrapIcon.XCircle} text-danger";
}
