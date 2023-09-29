// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Api;

/// <summary>
/// All the paths used in the application.
/// </summary>
public static class CountryFilePath
{
    /// <summary>
    /// Gets the path of the data folder.
    /// </summary>
    public const string DataFolder = "_data";

    /// <summary>
    /// Gets the json file name containing all the countries.
    /// </summary>
    public const string JsonFileName = "countries.json";

    /// <summary>
    /// Gets the full path of the JSON file containing all the countries.
    /// </summary>
    public const string FullJsonPath = $"{DataFolder}/{JsonFileName}";
}
