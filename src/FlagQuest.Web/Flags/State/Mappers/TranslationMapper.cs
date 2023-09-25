// Copyright (c) Alexandre Beauchamp. All rights reserved.
// The source code is licensed under MIT License.

namespace FlagQuest.Web.Flags.State.Mappers;

internal static class TranslationMapper
{
    internal static Models.Translations ToTranslations(this Api.Resources.Translations translations)
        => new(translations.English.ToTranslation(), translations.French.ToTranslation());

    private static Models.Translation ToTranslation(this Api.Resources.Translation translation)
        => new(translation.Name, translation.OfficialName);
}
