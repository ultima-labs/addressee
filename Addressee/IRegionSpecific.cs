using System.Globalization;
using JetBrains.Annotations;

namespace Addressee
{
    public interface IRegionSpecific
    {
        [NotNull]
        RegionInfo Region { get; }
    }
}