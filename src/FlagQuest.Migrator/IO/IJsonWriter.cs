// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Migrator.IO;

internal interface IJsonWriter
{
    Task WriteAsync<T>(string path, T value);
}
