using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct AustralianPostOfficeBoxType :
        IEquatable<AustralianPostOfficeBoxType>,
        IStreetType
    {
        public static AustralianPostOfficeBoxType Unknown { get; } = new AustralianPostOfficeBoxType(ID.Unknown);

        public static AustralianPostOfficeBoxType PO { get; } = new AustralianPostOfficeBoxType(ID.PO);

        public static AustralianPostOfficeBoxType GPO { get; } = new AustralianPostOfficeBoxType(ID.GPO);

        [NotNull]
        public static IReadOnlyList<AustralianPostOfficeBoxType> All { get; } = new List<AustralianPostOfficeBoxType>
        {
            PO,
            GPO
        }.AsReadOnly();

        private readonly ID _id;

        private AustralianPostOfficeBoxType(ID id)
        {
            _id = id;
        }

        public string NativeShortName => EnglishShortName;

        public string NativeLongName => EnglishLongName;

        public string EnglishShortName
        {
            get
            {
                switch (_id)
                {
                    case ID.Unknown: return string.Empty;
                    case ID.PO: return "PO";
                    case ID.GPO: return "GPO";
                    default: throw new NotSupportedException();
                }
            }
        }

        public string EnglishLongName
        {
            get
            {
                switch (_id)
                {
                    case ID.Unknown: return string.Empty;
                    case ID.PO: return "PO";
                    case ID.GPO: return "GPO";
                    default: throw new NotSupportedException();
                }
            }
        }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        public bool TryParse(string s, out AustralianPostOfficeBoxType result)
        {
            s = s?.Trim();

            if (!string.IsNullOrEmpty(s))
            {
                foreach (var known in All)
                {
                    if (s.Equals(known.NativeShortName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = known;
                        return true;
                    }

                    if (s.Equals(known.NativeLongName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = known;
                        return true;
                    }

                    if (s.Equals(known.EnglishShortName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = known;
                        return true;
                    }

                    if (s.Equals(known.EnglishLongName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = known;
                        return true;
                    }
                }
            }

            result = Unknown;
            return false;
        }

        public AustralianPostOfficeBoxType Parse(string s) => TryParse(s, out AustralianPostOfficeBoxType result) ? result : throw new InvalidOperationException();

        [Pure]
        public override int GetHashCode() => (int)_id;

        [Pure]
        public bool Equals(AustralianPostOfficeBoxType other) => _id == other._id;

        [Pure]
        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && obj is AustralianPostOfficeBoxType && Equals((AustralianPostOfficeBoxType) obj);

        [Pure]
        public override string ToString() => ToString(null, null);

        [Pure]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "S": return EnglishShortName;
                case "L": return EnglishLongName;
                default: return EnglishShortName;
            }
        }

        [Pure]
        public static bool operator ==(AustralianPostOfficeBoxType l, AustralianPostOfficeBoxType r) => l._id == r._id;

        [Pure]
        public static bool operator !=(AustralianPostOfficeBoxType l, AustralianPostOfficeBoxType r) => l._id != r._id;

        private enum ID : byte
        {
            Unknown = 0,
            PO = 1,
            GPO = 2
        }
    }
}