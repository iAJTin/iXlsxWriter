
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> point.
/// </summary>
public partial class QualifiedPointDefinition : ICloneable
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
    public QualifiedPointDefinition Clone()
    {
        var cloned = (QualifiedPointDefinition) MemberwiseClone();
        cloned.Point = Point?.Clone();

        return cloned;
    }
}
