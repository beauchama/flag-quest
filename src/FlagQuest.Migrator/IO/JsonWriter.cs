// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Migrator.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace FlagQuest.Migrator.IO;

internal sealed class JsonWriter(IHostEnvironment host, IOptions<JsonOptions> jsonOptions) : IJsonWriter
{
    public async Task WriteAsync<T>(string path, T value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = jsonOptions.Value.CaseInsensitive,
            WriteIndented = !jsonOptions.Value.Minify
        });

        string jsonPath = Path.Combine(host.ContentRootPath, "countries.json");

        await File.WriteAllTextAsync(jsonPath, json).ConfigureAwait(false);

        FileInfo file = new(jsonPath);
        _ = file.CopyTo(path, overwrite: true);
    }
}
