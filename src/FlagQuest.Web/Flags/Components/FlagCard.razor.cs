// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Configurations;
using FlagQuest.Web.Flags.Algorithms;
using FlagQuest.Web.Flags.Models;
using FlagQuest.Web.Flags.State;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace FlagQuest.Web.Flags.Components;

public partial class FlagCard
{
    private readonly Stack<GuessedFlag> _guessedFlags = [];
    private string _selectedFlagCode = string.Empty;

    [Parameter]
    [EditorRequired]
    public required Flag Flag { get; init; }

    [Inject]
    private IOptions<GitHubOptions> GitHubOptions { get; set; } = default!;

    [Inject]
    private IGeographicCalculator GeographicCalculator { get; set; } = default!;

    [Inject]
    private IState<FlagsState> FlagsState { get; set; } = default!;

    private Uri GetFlag() => new($"{GitHubOptions.Value.Assets}/flags/{Flag.Code}.svg");

    private void Guess()
    {
        Flag guessedFlag = FlagsState.Value.Flags.First(f => f.Code == _selectedFlagCode);
        _guessedFlags.Push(ToGuessedFlag(guessedFlag, Flag));
    }

    private GuessedFlag ToGuessedFlag(Flag guessedFlag, Flag flag)
    {
        bool isGuessedFlagBigger = guessedFlag.Area > flag.Area;
        bool isSameContinent = guessedFlag.Region == flag.Region;
        double distance = GeographicCalculator.CalculateDistance(guessedFlag.Coordinate, flag.Coordinate);

        GuessedCoordinate coordinate = new(distance, guessedFlag.Coordinate.Latitude, guessedFlag.Coordinate.Longitude);
        return new(guessedFlag.Code, guessedFlag.Translations.English.Name, !isGuessedFlagBigger, isSameContinent, coordinate);
    }
}
