using System;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public interface IStreetType :
        IRegionSpecific,
        IFormattable
    {
        [NotNull]
        string NativeShortName { get; }

        [NotNull]
        string NativeLongName { get; }

        [NotNull]
        string EnglishShortName { get; }

        [NotNull]
        string EnglishLongName { get; }
    }
}