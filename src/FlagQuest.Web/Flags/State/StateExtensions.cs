// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using Fluxor.DependencyInjection;

namespace FlagQuest.Web.Flags.State;

public static class StateExtensions
{
    public static FluxorOptions AddFlagsState(this FluxorOptions options)
        => options.ScanTypes(typeof(FlagsState), typeof(FlagsEffects), typeof(FlagsReducers));
}
