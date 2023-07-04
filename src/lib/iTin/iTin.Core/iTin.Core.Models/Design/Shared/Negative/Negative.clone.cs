
using System;

namespace iTin.Core.Models.Design;

public partial class Negative : ICloneable
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
    public Negative Clone()
    {
        var negativeCloned =(Negative)MemberwiseClone();
        negativeCloned.Properties = Properties.Clone();

        return negativeCloned;
    }
}
