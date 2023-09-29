// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.AspNetCore.Components;

namespace FlagQuest.Web.Components.Icons;

public partial class IconButton
{
    [Parameter]
    [EditorRequired]
    public EventCallback OnClick { get; set; }
}
