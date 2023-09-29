// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Flags.Models;

namespace FlagQuest.Web.Flags.State;

public static class FlagsActions
{
    public sealed record Get;

    public sealed record GetResult(IReadOnlyCollection<Flag> Flags);
}
