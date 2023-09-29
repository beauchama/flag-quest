// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Api.Resources;

/// <summary>
/// Represents a translation.
/// </summary>
/// <param name="Name">The common name.</param>
/// <param name="OfficialName">The official name.</param>
public sealed record Translation(string Name, string OfficialName);
