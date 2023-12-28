
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxShapeEffects : ICloneable
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
    public XlsxShapeEffects Clone()
    {
        var cloned = (XlsxShapeEffects)MemberwiseClone();
        cloned.Shadow = Shadow.Clone();
        cloned.SoftEdge = SoftEdge.Clone();
        cloned.Reflection = Reflection.Clone();
        cloned.Illumination = Illumination.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
