
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a qualified <b>xlsx</b> range.
/// </summary>
public partial class QualifiedRangeDefinition : ICloneable
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
    public QualifiedRangeDefinition Clone()
    {
        var cloned = (QualifiedRangeDefinition)MemberwiseClone();
        cloned.Range = Range?.Clone();

        return cloned;
    }
}
