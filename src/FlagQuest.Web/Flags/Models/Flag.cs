// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Web.Flags.Models;

public sealed record Flag(string Code, Translations Translations, string Region, double Area, Coordinate Coordinate);
