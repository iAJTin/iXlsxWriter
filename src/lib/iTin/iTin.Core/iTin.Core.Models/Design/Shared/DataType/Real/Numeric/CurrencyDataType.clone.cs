
using System;

namespace iTin.Core.Models.Design;

public partial class CurrencyDataType : ICloneable
{
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public new CurrencyDataType Clone()
    {
        var cloned = (CurrencyDataType)MemberwiseClone();
        cloned.Error = Error?.Clone();
        cloned.Negative = Negative?.Clone();
        cloned.Properties = Properties?.Clone();

        return cloned;
    }
}
