
using System;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="IXlsxStyle"/> interface.<br/>
/// Defines a generic <b>xlsx</b> style.
/// </summary>
public partial class XlsxBaseStyle
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
    public XlsxBaseStyle Clone()
    {
        var styleCloned = (XlsxBaseStyle)MemberwiseClone();
        styleCloned.Borders = Borders.Clone();
        styleCloned.Content = Content.Clone();
        styleCloned.Properties = Properties.Clone();

        return styleCloned;
    }
}
