using System;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public interface IAddressee :
        IRegionSpecific,
        IFormattable
    {
        bool IsSufficient { get; }
    }
}