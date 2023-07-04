
using System;

namespace iTin.Core.Models.Design;

public partial class BaseBasicContent
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
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public BaseBasicContent Clone()
    {
        var cloned = (BaseBasicContent)MemberwiseClone();
        cloned.Alignment = Alignment.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
