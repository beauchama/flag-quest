// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json;

namespace FlagQuest.CountryConverter.Fixtures;

public class CountryJsonFixture
{
    private readonly Dictionary<string, byte[]> _jsons;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public CountryJsonFixture()
    {
        _jsons = Directory
            .GetFiles("Data")
            .ToDictionary(f => Path.GetFileNameWithoutExtension(f)!, File.ReadAllBytes);
    }

    public T Deserialize<T>(string countryName)
        => JsonSerializer.Deserialize<T>(_jsons[countryName], _options)!;
}
