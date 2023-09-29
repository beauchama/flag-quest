// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.Models;
using Fluxor;

namespace FlagQuest.Web.Flags.State;

[FeatureState(Name = "Flags")]
public sealed class FlagsState
{
    private FlagsState()
    {
    }

    private FlagsState(IReadOnlyCollection<Flag> flags, bool isLoading)
    {
        Flags = flags;
        IsLoading = isLoading;
    }

    public IReadOnlyCollection<Flag> Flags { get; } = [];

    public bool IsLoading { get; }

    public static FlagsState MakeLoadingState() => new([], isLoading: true);

    public static FlagsState MakeStateWith(IReadOnlyCollection<Flag> flags) => new(flags, isLoading: false);
}
