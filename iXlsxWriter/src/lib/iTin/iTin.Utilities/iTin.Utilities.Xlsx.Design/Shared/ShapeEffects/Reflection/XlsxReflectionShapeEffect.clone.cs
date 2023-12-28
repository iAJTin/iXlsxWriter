
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxReflectionShapeEffect : ICloneable
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
    public XlsxReflectionShapeEffect Clone()
    {
        var cloned = (XlsxReflectionShapeEffect)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
