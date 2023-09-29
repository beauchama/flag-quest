// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.AspNetCore.Components;

namespace FlagQuest.Web.Components.Icons;

public abstract class IconComponentBase : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public required string Name { get; init; }

    [Parameter]
    public IconSize Size { get; init; } = IconSize.Medium;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> UnmatchedAttributes { get; init; } = new Dictionary<string, object>();

    protected string Classes { get; private set; } = string.Empty;

    protected IReadOnlyDictionary<string, object>? Attributes { get; private set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        string classes = UnmatchedAttributes.GetValueOrDefault("class")?.ToString() ?? string.Empty;

        Classes = $"{classes} {GetIconSizeCss(Size)}";
        Attributes = UnmatchedAttributes.Where(x => x.Key != "class").ToDictionary(k => k.Key, v => v.Value);

        static string GetIconSizeCss(IconSize size) => size switch
        {
            IconSize.XSmall => "icon-xs",
            IconSize.Small => "icon-sm",
            IconSize.Medium => "icon-md",
            IconSize.Large => "icon-lg",
            IconSize.ExtraLarge => "icon-xl",
            _ => string.Empty,
        };
    }
}
