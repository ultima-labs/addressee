using System.Globalization;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public static class SupportedCountries
    {
        internal const string AustraliaCode = "AU";

        internal const string RussianCode = "RU";

        [NotNull]
        public static RegionInfo Australia { get; } = new RegionInfo(AustraliaCode);

        [NotNull]
        public static RegionInfo Russia { get; } = new RegionInfo(RussianCode);
    }
}
