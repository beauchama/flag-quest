// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using Fluxor;

namespace FlagQuest.Web.Flags.State;

public static class FlagsReducers
{
    [ReducerMethod(typeof(FlagsActions.Get))]
    public static FlagsState ReduceGet(FlagsState state) => FlagsState.MakeLoadingState();

    [ReducerMethod]
    public static FlagsState ReduceGetResult(FlagsState _, FlagsActions.GetResult action) => FlagsState.MakeStateWith(action.Flags);
}
