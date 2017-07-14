using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public static class SupportedLanguage
    {
        [NotNull]
        public static CultureInfo Invariant { get; } = CultureInfo.InvariantCulture;

        [NotNull]
        public static CultureInfo Default => English;

        [NotNull]
        public static CultureInfo English { get; } = new CultureInfo("en");

        [NotNull, ItemNotNull]
        public static IReadOnlyList<CultureInfo> All { get; } = new List<CultureInfo>
        {
            Invariant,
            English
        }.AsReadOnly();

        [NotNull]
        public static CultureInfo PickLanguageFromCurrentCulture() => PickLanguage(CultureInfo.CurrentCulture);

        [NotNull]
        public static CultureInfo PickLanguageFromCurrentUICulture() => PickLanguage(CultureInfo.CurrentUICulture);

        public static CultureInfo PickLanguage(CultureInfo culture)
        {
            while (true)
            {
                if (All.Contains(culture))
                {
                    return culture;
                }

                culture = culture.Parent;
            }
        }
    }
}