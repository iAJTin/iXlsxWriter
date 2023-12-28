
using System;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellPattern
{
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxCellPattern Clone()
    {
        var patternCloned = (XlsxCellPattern)MemberwiseClone();
        patternCloned.Properties = Properties.Clone();

        return patternCloned;
    }
}
