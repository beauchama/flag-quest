// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Web.Flags.Models;

public sealed record GuessedFlag(string Code, string Name, bool IsBigger, bool SameContinent, GuessedCoordinate Coordinate);
