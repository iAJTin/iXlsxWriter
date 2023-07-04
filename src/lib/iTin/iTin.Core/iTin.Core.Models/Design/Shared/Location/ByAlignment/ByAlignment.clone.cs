
using System;

namespace iTin.Core.Models.Design;

/// <summary>
/// Represents a font. Defines a particular format for text, including font face, size, and style attributes.
/// </summary>
public partial class ByAlignment : ICloneable
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
    public ByAlignment Clone()
    {
        var cloned = (ByAlignment)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
