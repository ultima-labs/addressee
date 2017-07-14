using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    public sealed class AustralianPostOfficeBox : IAddressee
    {
        private const string DomesticFormat = "{0} {1}, {2} {3} {4}";
        private const string DomesticMultilineFormat = "{0} {1}{5}{2} {3} {4}";
        private const string InternationalFormat = "{0} {1}, {2} {3} {4}, Australia";
        private const string InternationalMultilineFormat = "{0} {1}{5}{2} {3} {4}{5}Australia";

        public AustralianPostOfficeBox(
            AustralianPostOfficeBoxType type, 
            AustralianPostOfficeBoxNumber number, 
            AustralianLocality locality, 
            AustralianPostcode postcode, 
            AustralianState state)
        {
            Type = type;
            Number = number;
            Locality = locality;
            Postcode = postcode;
            State = state;
        }

        public AustralianPostOfficeBoxType Type { get; }

        public AustralianPostOfficeBoxNumber Number { get; }

        public AustralianLocality Locality { get; }

        public AustralianPostcode Postcode { get; }

        public AustralianState State { get; }

        public bool IsSufficient { get; }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;
        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case AddresseeFormats.Domestic:
                    return string.Format(DomesticFormat, Type, Number, Locality, State, Postcode);

                case AddresseeFormats.International:
                    return string.Format(InternationalFormat, Type, Number, Locality, State, Postcode);

                case AddresseeFormats.DomesticMultiline:
                    return string.Format(DomesticMultilineFormat, Type, Number, Locality, State, Postcode, Environment.NewLine);

                case AddresseeFormats.InternationalMultiline:
                    return string.Format(InternationalMultilineFormat, Type, Number, Locality, State, Postcode, Environment.NewLine);

                default:
                    return string.Format(DomesticFormat, Type, Number, Locality, State, Postcode);
            }
        }
    }
}
