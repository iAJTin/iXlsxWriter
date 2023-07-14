
using System;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentHeaderFooter : ICloneable
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
    public XlsxDocumentHeaderFooter Clone()
    {
        var cloned = (XlsxDocumentHeaderFooter) MemberwiseClone();
        cloned.Sections = Sections.Clone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }
}
