using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    public struct AustralianFloorAddressComponent/*Kind*/ : IRegionSpecific
    {
        private AustralianFloorAddressComponent(string s, string basement)
        {
            throw new NotImplementedException();
        }

        public static AustralianFloorAddressComponent Unspecified { get; } = new AustralianFloorAddressComponent("", "");

        public static AustralianFloorAddressComponent Basement { get; } = new AustralianFloorAddressComponent("B", "Basement");

        public static AustralianFloorAddressComponent Floor { get; } = new AustralianFloorAddressComponent("FL", "Floor");

        public static AustralianFloorAddressComponent GoundLevel { get; } = new AustralianFloorAddressComponent("G", "Gound Level");

        public static AustralianFloorAddressComponent Level { get; } = new AustralianFloorAddressComponent("L", "Level");

        public static AustralianFloorAddressComponent LowerGroundFloor { get; } = new AustralianFloorAddressComponent("LG", "Lower Ground Floor");

        public static AustralianFloorAddressComponent Mezzanine { get; } = new AustralianFloorAddressComponent("M", "Mezzanine");

        public static AustralianFloorAddressComponent UpperGroundFloor { get; } = new AustralianFloorAddressComponent("UG", "Upper Ground Floor");

        RegionInfo IRegionSpecific.Region => SupportedCountries.Australia;
    }
}