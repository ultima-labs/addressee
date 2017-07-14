using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct AustralianStreetType :
        IEquatable<AustralianStreetType>,
        IStreetType
    {
        public static AustralianStreetType Unknown { get; } = new AustralianStreetType(ID.Unknown);

        public static AustralianStreetType Alley { get; } = new AustralianStreetType(ID.Alley);

        public static AustralianStreetType Arcade { get; } = new AustralianStreetType(ID.Arcade);

        public static AustralianStreetType Avenue { get; } = new AustralianStreetType(ID.Avenue);

        public static AustralianStreetType Boulevard { get; } = new AustralianStreetType(ID.Boulevard);

        public static AustralianStreetType Close { get; } = new AustralianStreetType(ID.Close);

        public static AustralianStreetType Crescent { get; } = new AustralianStreetType(ID.Crescent);

        public static AustralianStreetType Court { get; } = new AustralianStreetType(ID.Court);

        public static AustralianStreetType Drive { get; } = new AustralianStreetType(ID.Drive);
        
        public static AustralianStreetType Esplanade { get; } = new AustralianStreetType(ID.Esplanade);

        public static AustralianStreetType Grove { get; } = new AustralianStreetType(ID.Grove);

        public static AustralianStreetType Highway { get; } = new AustralianStreetType(ID.Highway);

        public static AustralianStreetType Lane { get; } = new AustralianStreetType(ID.Lane);

        public static AustralianStreetType Parade { get; } = new AustralianStreetType(ID.Parade);

        public static AustralianStreetType Place { get; } = new AustralianStreetType(ID.Place);

        public static AustralianStreetType Road { get; } = new AustralianStreetType(ID.Road);

        public static AustralianStreetType Square { get; } = new AustralianStreetType(ID.Square);

        public static AustralianStreetType Street { get; } = new AustralianStreetType(ID.Street);

        public static AustralianStreetType Terrace { get; } = new AustralianStreetType(ID.Terrace);

        [NotNull]
        public static IReadOnlyList<AustralianStreetType> All { get; } = new List<AustralianStreetType>
        {
            Alley,
            Arcade,
            Avenue,
            Boulevard,
            Close,
            Crescent,
            Court,
            Drive,
            Esplanade,
            Grove,
            Highway,
            Lane,
            Parade,
            Place,
            Road,
            Square,
            Street,
            Terrace
        }.AsReadOnly();

        private readonly ID _id;

        private AustralianStreetType(ID id)
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
                    case ID.Alley: return "ALLEY";
                    case ID.Arcade: return "ARC";
                    case ID.Avenue: return "AVE";
                    case ID.Boulevard: return "BVD";
                    case ID.Close: return "CL";
                    case ID.Crescent: return "CRES";
                    case ID.Court: return "CT";
                    case ID.Drive: return "DR";
                    case ID.Esplanade: return "ESP";
                    case ID.Grove: return "GR";
                    case ID.Highway: return "HWY";
                    case ID.Lane: return "LANE";
                    case ID.Parade: return "PDE";
                    case ID.Place: return "PL";
                    case ID.Road: return "RD";
                    case ID.Square: return "SQ";
                    case ID.Street: return "ST";
                    case ID.Terrace: return "TCE";
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
                    case ID.Alley: return "Alley";
                    case ID.Arcade: return "Arcade";
                    case ID.Avenue: return "Avenue";
                    case ID.Boulevard: return "Boulevard";
                    case ID.Close: return "Close";
                    case ID.Crescent: return "Crescent";
                    case ID.Court: return "Court";
                    case ID.Drive: return "Drive";
                    case ID.Esplanade: return "Esplanade";
                    case ID.Grove: return "Grove";
                    case ID.Highway: return "Highway";
                    case ID.Lane: return "Lane";
                    case ID.Parade: return "Parade";
                    case ID.Place: return "Place";
                    case ID.Road: return "Road";
                    case ID.Square: return "Square";
                    case ID.Street: return "Street";
                    case ID.Terrace: return "Terrace";
                    default: throw new NotSupportedException();
                }
            }
        }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        public bool TryParse(string s, out AustralianStreetType result)
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

        public AustralianStreetType Parse(string s) => TryParse(s, out AustralianStreetType result) ? result : throw new InvalidOperationException();

        [Pure]
        public override int GetHashCode() => (int)_id;

        [Pure]
        public bool Equals(AustralianStreetType other) => _id == other._id;

        [Pure]
        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && obj is AustralianStreetType && Equals((AustralianStreetType) obj);

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
        public static bool operator ==(AustralianStreetType l, AustralianStreetType r) => l._id == r._id;

        [Pure]
        public static bool operator !=(AustralianStreetType l, AustralianStreetType r) => l._id != r._id;

        private enum ID : byte
        {
            Unknown = 0,
            Alley = 1,
            Arcade = 2,
            Avenue = 3,
            Boulevard = 4,
            Close = 5,
            Crescent = 6,
            Court = 7,
            Drive = 8,
            Esplanade = 9,
            Grove = 10,
            Highway = 11,
            Lane = 12,
            Parade = 13,
            Place = 14,
            Road = 15,
            Square = 16,
            Street = 17,
            Terrace = 18
        }
    }
}