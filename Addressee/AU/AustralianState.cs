using System;
using System.Globalization;
using Addressee.Properties;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public struct AustralianState : IArea
    {
        public static AustralianState Unknown { get; } = new AustralianState(ID.Unknown);

        public static AustralianState ACT { get; } = new AustralianState(ID.ACT);

        public static AustralianState JBT { get; } = new AustralianState(ID.JBT);

        public static AustralianState NSW { get; } = new AustralianState(ID.NSW);

        public static AustralianState QLD { get; } = new AustralianState(ID.QLD);

        public static AustralianState TAS { get; } = new AustralianState(ID.TAS);

        public static AustralianState VIC { get; } = new AustralianState(ID.VIC);

        public static AustralianState NT { get; } = new AustralianState(ID.NT);

        public static AustralianState SA { get; } = new AustralianState(ID.SA);

        public static AustralianState WA { get; } = new AustralianState(ID.WA);

        private static readonly AustralianState[] _wellKnownStates = {
            ACT, JBT, NSW, QLD, TAS, VIC, NT, SA, WA
        };

        private readonly ID _identifier;

        private AustralianState(ID identifier)
        {
            _identifier = identifier;
        }

        public string ShortName
        {
            get
            {
                switch (_identifier)
                {
                    case ID.ACT: return Resources.AustralianState_ACT_Short;
                    case ID.JBT: return Resources.AustralianState_JBT_Short;
                    case ID.NSW: return Resources.AustralianState_NSW_Short;
                    case ID.QLD: return Resources.AustralianState_QLD_Short;
                    case ID.TAS: return Resources.AustralianState_TAS_Short;
                    case ID.VIC: return Resources.AustralianState_VIC_Short;
                    case ID.NT: return Resources.AustralianState_NT_Short;
                    case ID.SA: return Resources.AustralianState_SA_Short;
                    case ID.WA: return Resources.AustralianState_WA_Short;
                    case ID.Unknown: return string.Empty;
                    case ID.Other: return string.Empty;
                    default: throw new NotSupportedException();
                }
            }
        }

        public string LongName
        {
            get
            {
                switch (_identifier)
                {
                    case ID.ACT: return Resources.AustralianState_ACT_Long;
                    case ID.JBT: return Resources.AustralianState_JBT_Long;
                    case ID.NSW: return Resources.AustralianState_NSW_Long;
                    case ID.QLD: return Resources.AustralianState_QLD_Long;
                    case ID.TAS: return Resources.AustralianState_TAS_Long;
                    case ID.VIC: return Resources.AustralianState_VIC_Long;
                    case ID.NT: return Resources.AustralianState_NT_Long;
                    case ID.SA: return Resources.AustralianState_SA_Long;
                    case ID.WA: return Resources.AustralianState_WA_Long;
                    case ID.Unknown: return string.Empty;
                    case ID.Other: return string.Empty;
                    default: throw new NotSupportedException();
                }
            }
        }

        public string NativeShortName
        {
            get
            {
                switch (_identifier)
                {
                    case ID.ACT: return "ACT";
                    case ID.JBT: return "JBT";
                    case ID.NSW: return "NSW";
                    case ID.QLD: return "QLD";
                    case ID.TAS: return "TAS";
                    case ID.VIC: return "VIC";
                    case ID.NT: return "NT";
                    case ID.SA: return "SA";
                    case ID.WA: return "WA";
                    case ID.Unknown: return string.Empty;
                    case ID.Other: return string.Empty;
                    default: throw new NotSupportedException();
                }
            }
        }

        public string NativeLongName
        {
            get
            {
                switch (_identifier)
                {
                    case ID.ACT: return "Australian Capital Territory";
                    case ID.JBT: return "Jervis Bay Territory";
                    case ID.NSW: return "New South Wales";
                    case ID.QLD: return "Queensland";
                    case ID.TAS: return "Tasmania";
                    case ID.VIC: return "Victoria";
                    case ID.NT: return "Northern Territory";
                    case ID.SA: return "South Australia";
                    case ID.WA: return "Western Australia";
                    case ID.Unknown: return string.Empty;
                    case ID.Other: return string.Empty;
                    default: throw new NotSupportedException();
                }
            }
        }

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;

        public bool TryParse(string s, out AustralianState result)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                result = Unknown;
                return false;
            }

            s = s.Trim();

            foreach (var wellKnownState in _wellKnownStates)
            {
                if (StringComparer.OrdinalIgnoreCase.Equals(wellKnownState.ShortName, s))
                {
                    result = wellKnownState;
                    return true;
                }

                if (StringComparer.OrdinalIgnoreCase.Equals(wellKnownState.LongName, s))
                {
                    result = wellKnownState;
                    return true;
                }

                if (StringComparer.CurrentCultureIgnoreCase.Equals(wellKnownState.NativeShortName, s))
                {
                    result = wellKnownState;
                    return true;
                }

                if (StringComparer.OrdinalIgnoreCase.Equals(wellKnownState.NativeLongName, s))
                {
                    result = wellKnownState;
                    return true;
                }
            }

            result = Unknown;
            return false;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        private enum ID : byte
        {
            Unknown = 0,
            ACT = 1,
            JBT = 2,
            NSW = 3,
            QLD = 4,
            TAS = 5,
            VIC = 6,
            NT = 7,
            SA = 8,
            WA = 9,

            Other = byte.MaxValue
        }
    }
}