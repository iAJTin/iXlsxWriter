
using System;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentHeaderFooterSections : ICloneable
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
    public XlsxDocumentHeaderFooterSections Clone()
    {
        var cloned = new XlsxDocumentHeaderFooterSections(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (XlsxDocumentHeaderFooterSection section in this)
        {
            cloned.Add(section.Clone());
        }

        return cloned;
    }
}
