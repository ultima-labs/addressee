using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    public sealed class AustralianStreetAddress : IRegionSpecific
    {
        public AustralianStreetAddress(SanitizedString premise, SanitizedString subPremise, SanitizedString streetNumber, SanitizedString streetName, AustralianStreetType streetType, string sda)
        {
        }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;
    }
}