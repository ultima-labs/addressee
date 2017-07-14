using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    public sealed class AustralianAddressee : IAddressee
    {
        public AustralianAddressee(AustralianStreetAddress address, AustralianPostcode postcode, AustralianState state)
        {
            Address = address;
            Postcode = postcode;
            State = state;
        }

        public AustralianAddressee(AustralianPostOfficeBox postOfficeBox, AustralianPostcode postcode, AustralianState state)
        {
            PostOfficeBox = postOfficeBox;
            Postcode = postcode;
            State = state;
        }

        public AustralianStreetAddress Address { get; }

        public AustralianPostOfficeBox PostOfficeBox { get; }

        public AustralianPostcode Postcode { get; }

        public AustralianState State { get; }

        public bool IsPostOfficeBox { get; }

        public bool IsStreetAddress { get; }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public bool IsSufficient { get; }
    }
}