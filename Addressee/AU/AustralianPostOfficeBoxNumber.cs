using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct AustralianPostOfficeBoxNumber : 
        IPostcode, 
        IEquatable<AustralianPostOfficeBoxNumber>,
        IComparable<AustralianPostOfficeBoxNumber>
    {
        public const ushort MinPostcodeValue = 0;

        public const ushort MaxPostcodeValue = 9944;

        public const ushort EmptyPostcodeValue = default(ushort);

        public static AustralianPostOfficeBoxNumber MinValue { get; } = new AustralianPostOfficeBoxNumber(MinPostcodeValue);

        public static AustralianPostOfficeBoxNumber MaxValue { get; } = new AustralianPostOfficeBoxNumber(MaxPostcodeValue);

        public static AustralianPostOfficeBoxNumber Empty { get; } = new AustralianPostOfficeBoxNumber(EmptyPostcodeValue);

        private readonly ushort _number;

        public AustralianPostOfficeBoxNumber(int number)
        {
            if (number > ushort.MaxValue) throw new ArgumentOutOfRangeException(nameof(number));
            if (number < ushort.MinValue) throw new ArgumentOutOfRangeException(nameof(number));

            _number = Convert.ToUInt16(number);
        }

        public AustralianPostOfficeBoxNumber(ushort number)
        {
            _number = number;
        }

        public ushort Code => _number;

        public void VerifyValid()
        {
            if (!CheckValid(out string reason))
            {
                throw new InvalidOperationException(reason);
            }
        }

        public bool CheckValid() => CheckValid(out string reason);

        public bool CheckValid(out string reason)
        {
            reason = null;
            return false;
        }
        
        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        [Pure]
        public override int GetHashCode() => _number;

        [Pure]
        public override bool Equals(object obj)
        {
            if (!(obj is AustralianPostOfficeBoxNumber))
            {
                return false;
            }

            return Equals((AustralianPostOfficeBoxNumber) obj);
        }

        [Pure]
        public bool Equals(AustralianPostOfficeBoxNumber other) => _number.Equals(other._number);

        [Pure]
        public int CompareTo(AustralianPostOfficeBoxNumber other) => _number.CompareTo(other._number);

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
                    return _number.ToString("D4");

                default:
                    return _number.ToString("D4");
            }
        }

        [Pure]
        public static explicit operator AustralianPostOfficeBoxNumber(int number) => new AustralianPostOfficeBoxNumber(number);

        [Pure]
        public static implicit operator AustralianPostOfficeBoxNumber(ushort number) => new AustralianPostOfficeBoxNumber(number);

        [Pure]
        public static implicit operator int (AustralianPostOfficeBoxNumber postcode) => postcode._number;

        [Pure]
        public static bool operator ==(AustralianPostOfficeBoxNumber l, AustralianPostOfficeBoxNumber r) => l._number == r._number;

        [Pure]
        public static bool operator !=(AustralianPostOfficeBoxNumber l, AustralianPostOfficeBoxNumber r) => l._number != r._number;

        [Pure]
        public static bool operator <(AustralianPostOfficeBoxNumber l, AustralianPostOfficeBoxNumber r) => l._number < r._number;

        [Pure]
        public static bool operator >(AustralianPostOfficeBoxNumber l, AustralianPostOfficeBoxNumber r) => l._number > r._number;
    }
}