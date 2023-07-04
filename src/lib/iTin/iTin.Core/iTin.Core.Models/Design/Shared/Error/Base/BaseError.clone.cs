
using System;

namespace iTin.Core.Models.Design;

public partial class BaseError : ICloneable
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
    public BaseError Clone()
    {
        var baseErrorCloned = (BaseError)MemberwiseClone();
        baseErrorCloned.Comment = Comment?.Clone();
        baseErrorCloned.Properties = Properties?.Clone();

        return baseErrorCloned;
    }
}
