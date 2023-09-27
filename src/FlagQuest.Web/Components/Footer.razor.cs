// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using FlagQuest.Web.Configurations;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace FlagQuest.Web.Components;

public partial class Footer
{
    [Inject]
    private IOptions<GitHubOptions> GitHubOptions { get; set; } = default!;

    private static string GetCopyrightYears()
    {
        int startYear = DateTime.Now.Year;
        int currentYear = DateTime.Now.Year;

        return startYear == currentYear
            ? startYear.ToString()
            : $"{startYear}-{currentYear}";
    }
}
