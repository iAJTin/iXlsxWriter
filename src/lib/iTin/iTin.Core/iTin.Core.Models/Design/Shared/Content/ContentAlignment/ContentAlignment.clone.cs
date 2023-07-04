
using System;

namespace iTin.Core.Models.Design.Content;

public partial class ContentAlignment : ICloneable
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
    public ContentAlignment Clone()
    {
        var cloned = (ContentAlignment)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
