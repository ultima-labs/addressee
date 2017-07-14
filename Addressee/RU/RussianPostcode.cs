using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.RU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct RussianPostcode :
        IPostcode,
        IEquatable<RussianPostcode>,
        IComparable<RussianPostcode>
    {
        public const int MinPostcodeValue = 0;

        public const int MaxPostcodeValue = 999999;

        public const int EmptyPostcodeValue = default(int);

        public static RussianPostcode MinValue { get; } = new RussianPostcode(MinPostcodeValue);

        public static RussianPostcode MaxValue { get; } = new RussianPostcode(MaxPostcodeValue);

        public static RussianPostcode Empty { get; } = new RussianPostcode(EmptyPostcodeValue);

        private readonly int _postcode;

        public RussianPostcode(int postcode)
        {
            _postcode = Convert.ToUInt16(postcode);
        }

        public int Code => _postcode;

        RegionInfo IRegionSpecific.Region => SupportedCountries.Russia;

        [Pure]
        public override int GetHashCode() => _postcode;

        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is RussianPostcode))
            {
                return false;
            }

            return Equals((RussianPostcode)obj);
        }

        [Pure]
        public bool Equals(RussianPostcode other) => _postcode.Equals(other._postcode);

        [Pure]
        public int CompareTo(RussianPostcode other) => _postcode.CompareTo(other._postcode);

        [Pure]
        public override string ToString() => ToString(null, null);

        [Pure]
        public string ToString(string format, IFormatProvider formatProvider) => _postcode.ToString("D6");

        [Pure]
        public static implicit operator RussianPostcode(int postcode) => new RussianPostcode(postcode);

        [Pure]
        public static implicit operator int(RussianPostcode postcode) => postcode._postcode;

        [Pure]
        public static bool operator ==(RussianPostcode l, RussianPostcode r) => l._postcode == r._postcode;

        [Pure]
        public static bool operator !=(RussianPostcode l, RussianPostcode r) => l._postcode != r._postcode;

        [Pure]
        public static bool operator <(RussianPostcode l, RussianPostcode r) => l._postcode < r._postcode;

        [Pure]
        public static bool operator >(RussianPostcode l, RussianPostcode r) => l._postcode > r._postcode;
    }
}
