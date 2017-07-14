using System;
using System.Globalization;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct AustralianPostcode : 
        IPostcode, 
        IEquatable<AustralianPostcode>,
        IComparable<AustralianPostcode>
    {
        public const ushort MinPostcodeValue = 200;

        public const ushort MaxPostcodeValue = 9944;

        public const ushort EmptyPostcodeValue = default(ushort);

        public static AustralianPostcode MinValue { get; } = new AustralianPostcode(MinPostcodeValue);

        public static AustralianPostcode MaxValue { get; } = new AustralianPostcode(MaxPostcodeValue);

        public static AustralianPostcode Empty { get; } = new AustralianPostcode(EmptyPostcodeValue);

        private readonly ushort _postcode;

        public AustralianPostcode(int postcode)
        {
            if (postcode > ushort.MaxValue) throw new ArgumentOutOfRangeException(nameof(postcode));
            if (postcode < ushort.MinValue) throw new ArgumentOutOfRangeException(nameof(postcode));

            _postcode = Convert.ToUInt16(postcode);
        }

        public AustralianPostcode(ushort postcode)
        {
            _postcode = postcode;
        }

        public ushort Code => _postcode;

        public void VerifyValid()
        {
            if (!CheckValid(out string reason))
            {
                throw new InvalidPostcodeException(reason);
            }
        }

        public bool CheckValid() => CheckValid(out string reason);

        public bool CheckValid(out string reason)
        {
            reason = null;
            return false;
        }

        public AustralianState InferState()
        {
            if (_postcode == 4825) return AustralianState.NT; //// ALPURRURULAM (QLD)
            if (_postcode == 0872) return AustralianState.SA; //// ERNABELLA (NT)
            if (_postcode == 0872) return AustralianState.SA; //// FREGON (NT)
            if (_postcode == 0872) return AustralianState.SA; //// INDULKANA (NT)
            if (_postcode == 0872) return AustralianState.SA; //// MIMILI (NT)
            if (_postcode == 0872) return AustralianState.WA; //// NGAANYATJARRA - GILES (NT)
            if (_postcode == 0872) return AustralianState.WA; //// GIBSON DESERT NORTH (NT)
            if (_postcode == 0872) return AustralianState.WA; //// GIBSON DESERT SOUTH (NT)
            if (_postcode == 2540) return AustralianState.JBT; //// HMAS CRESWELL (NSW)
            if (_postcode == 2540) return AustralianState.JBT; //// JERVIS BAY (NSW)
            if (_postcode == 2611) return AustralianState.NSW; //// BRINDABELLA (ACT)
            if (_postcode == 2611) return AustralianState.NSW; //// URIARRA (ACT)
            if (_postcode == 2620) return AustralianState.ACT; //// HUME (NSW)
            if (_postcode == 2620) return AustralianState.ACT; //// KOWEN FOREST (NSW)
            if (_postcode == 2620) return AustralianState.ACT; //// OAKS ESTATE (NSW)
            if (_postcode == 2620) return AustralianState.ACT; //// THARWA (NSW)
            if (_postcode == 2620) return AustralianState.ACT; //// TOP NAAS (NSW)
            if (_postcode == 3500) return AustralianState.NSW; //// PARINGI (VIC)
            if (_postcode == 3585) return AustralianState.NSW; //// MURRAY DOWNS (VIC)
            if (_postcode == 3586) return AustralianState.NSW; //// MALLAN (VIC)
            if (_postcode == 3644) return AustralianState.NSW; //// BAROOGA (VIC)
            if (_postcode == 3644) return AustralianState.NSW; //// LALALTY (VIC)
            if (_postcode == 3707) return AustralianState.NSW; //// BRINGENBRONG (VIC)

            if (_postcode >= 1000 && _postcode <= 1999) return AustralianState.NSW; //// LVRs and PO Boxes only
            if (_postcode >= 2000 && _postcode <= 2599) return AustralianState.NSW;
            if (_postcode >= 2620 && _postcode <= 2899) return AustralianState.NSW;
            if (_postcode >= 2921 && _postcode <= 2999) return AustralianState.NSW;

            if (_postcode >= 0200 && _postcode <= 0299) return AustralianState.ACT; //// LVRs and PO Boxes only
            if (_postcode >= 2600 && _postcode <= 2619) return AustralianState.ACT;
            if (_postcode >= 2900 && _postcode <= 2920) return AustralianState.ACT;

            if (_postcode >= 3000 && _postcode <= 3999) return AustralianState.VIC;
            if (_postcode >= 8000 && _postcode <= 8999) return AustralianState.VIC; //// LVRs and PO Boxes only

            if (_postcode >= 4000 && _postcode <= 4999) return AustralianState.QLD;
            if (_postcode >= 9000 && _postcode <= 9999) return AustralianState.QLD; //// LVRs and PO Boxes only

            if (_postcode >= 5000 && _postcode <= 5799) return AustralianState.SA;
            if (_postcode >= 5800 && _postcode <= 5999) return AustralianState.SA; //// LVRs and PO Boxes only

            if (_postcode >= 6000 && _postcode <= 6797) return AustralianState.WA;
            if (_postcode >= 6800 && _postcode <= 6999) return AustralianState.WA; //// LVRs and PO Boxes only

            if (_postcode >= 7000 && _postcode <= 7799) return AustralianState.TAS;
            if (_postcode >= 7800 && _postcode <= 7999) return AustralianState.TAS; //// LVRs and PO Boxes only

            if (_postcode >= 0800 && _postcode <= 0899) return AustralianState.NT;
            if (_postcode >= 0900 && _postcode <= 0999) return AustralianState.NT; //// LVRs and PO Boxes only

            return AustralianState.Unknown;
        }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        [Pure]
        public override int GetHashCode() => _postcode;

        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is AustralianPostcode))
            {
                return false;
            }

            return Equals((AustralianPostcode) obj);
        }

        [Pure]
        public bool Equals(AustralianPostcode other) => _postcode.Equals(other._postcode);

        [Pure]
        public int CompareTo(AustralianPostcode other) => _postcode.CompareTo(other._postcode);

        [Pure]
        public override string ToString() => ToString(null, null);

        /// <summary>Formats the value of the current instance using the specified format.</summary>
        /// <returns>The value of the current instance in the specified format.</returns>
        /// <param name="format">The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable" /> implementation. </param>
        /// <param name="formatProvider">The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system. </param>
        /// <filterpriority>2</filterpriority>
        [Pure]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "G":
                    return _postcode.ToString("D4");

                default:
                    return _postcode.ToString("D4");
            }
        }

        [Pure]
        public static explicit operator AustralianPostcode(int postcode) => new AustralianPostcode(postcode);

        [Pure]
        public static implicit operator AustralianPostcode(ushort postcode) => new AustralianPostcode(postcode);

        [Pure]
        public static implicit operator int (AustralianPostcode postcode) => postcode._postcode;

        [Pure]
        public static bool operator ==(AustralianPostcode l, AustralianPostcode r) => l._postcode == r._postcode;

        [Pure]
        public static bool operator !=(AustralianPostcode l, AustralianPostcode r) => l._postcode != r._postcode;

        [Pure]
        public static bool operator <(AustralianPostcode l, AustralianPostcode r) => l._postcode < r._postcode;

        [Pure]
        public static bool operator >(AustralianPostcode l, AustralianPostcode r) => l._postcode > r._postcode;
    }
}