using System;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public interface IArea :
        IRegionSpecific,
        IFormattable
    {
    }
}