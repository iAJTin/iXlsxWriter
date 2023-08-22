
using System;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> shape.
/// </summary>
public partial class XlsxShape : ICloneable
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
    public XlsxShape Clone()
    {
        var cloned = (XlsxShape)MemberwiseClone();
        cloned.Size = Size.Clone();
        cloned.Border = Border.Clone();
        cloned.Content = Content.Clone();
        cloned.ShapeEffects = ShapeEffects.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
