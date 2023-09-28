// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Extensions;
using FlagQuest.Web.Flags.Models;
using FlagQuest.Web.Flags.State;
using Fluxor;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;

namespace FlagQuest.Web.Pages;

public partial class Index
{
    private Flag? _selectedFlag;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IActionSubscriber ActionSubScriber { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch<FlagsActions.Get>();

        ActionSubScriber.SubscribeToAction<FlagsActions.GetResult>(this, action =>
        {
            //_selectedFlag = RandomNumberGenerator.GetItems<Flag>(action.Flags.ToArray(), 1)[0];
            _selectedFlag = action.Flags.First(f => f.Code == "bmu");
            StateHasChanged();
        });
    }
}
