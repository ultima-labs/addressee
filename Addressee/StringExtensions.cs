using JetBrains.Annotations;

namespace Addressee
{
    internal static class StringExtensions
    {
        [NotNull, ContractAnnotation("s:null=>notnull; s:notnull=>notnull")]
        public static string TrimOrEmpty([CanBeNull] this string s) => s?.Trim() ?? string.Empty;

        [CanBeNull]
        public static string ToCamel([CanBeNull] this string s)
        {
            if (ReferenceEquals(s, null)) return s;

            var converted = s.ToCharArray();

            converted[0] = char.ToUpper(converted[0]);

            for (var i = 1; i < converted.Length; ++i)
            {
                if (char.IsWhiteSpace(converted[i - 1]))
                {
                    converted[i] = char.ToUpper(converted[i]);
                }
            }

            return new string(converted);
        }
    }
}
