
using System;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

public partial class XlsxColumnHeader
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
    public XlsxColumnHeader Clone()
    {
        var cloned = (XlsxColumnHeader)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
