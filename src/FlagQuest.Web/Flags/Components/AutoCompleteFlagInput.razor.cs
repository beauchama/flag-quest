// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.Models;
using FlagQuest.Web.Flags.State;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FlagQuest.Web.Flags.Components;

public partial class AutoCompleteFlagInput
{
    private ElementReference _inputText;
    private string? _input;
    private IReadOnlyCollection<Flag> _filteredFlags = [];

    [Parameter]
    public string Value { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    [Inject]
    private IState<FlagsState> FlagsState { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _inputText.FocusAsync();
        }
    }

    private void OnClick() => _filteredFlags = FilterFlags(_input);

    private void HandleInput(ChangeEventArgs e)
    {
        _input = e.Value?.ToString();

        if (_input?.Length == 0)
        {
            _filteredFlags = FlagsState.Value.Flags;
        }
        else if (_input?.Length > 2)
        {
            _filteredFlags = FilterFlags(_input);
        }
    }

    private Task OnEnterAsync(KeyboardEventArgs e)
    {
        if (e.Code is "Enter" or "NumpadEnter" && _filteredFlags.Count == 1)
        {
            _input = null;
            return SelectFlagAsync(_filteredFlags.First().Code);
        }

        if (e.Code == "Escape")
        {
            _input = null;
            _filteredFlags = [];
        }

        return Task.CompletedTask;
    }

    private Task SelectFlagAsync(string code)
    {
        _filteredFlags = [];
        return ValueChanged.InvokeAsync(code);
    }

    private void OnFocusOut() => _filteredFlags = [];

    private IReadOnlyCollection<Flag> FilterFlags(string? code)
    {
        if (string.IsNullOrEmpty(code))
            return FlagsState.Value.Flags;

        return FlagsState.Value.Flags.Where(f => f.Translations.English.Name.Contains(code, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
