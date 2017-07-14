using System;
using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public interface IPostcode : 
        IRegionSpecific, 
        IFormattable
    {
    }
}