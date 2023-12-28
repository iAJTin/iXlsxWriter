
using System;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Defines the <b>xlsx</b> header or footer sections.
/// </summary>
public partial class XlsxStyleBorders
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
    public XlsxStyleBorders Clone()
    {
        var cloned = new XlsxStyleBorders(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (XlsxStyleBorder border in this)
        {
            cloned.Add(border.Clone());
        }

        return cloned;
    }
}
