
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentHeaderFooter : ICombinable<XlsxDocumentHeaderFooter>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxDocumentHeaderFooter>.Combine(XlsxDocumentHeaderFooter reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentHeaderFooter reference)
    {
        if (reference == null)
        {
            return;
        }

        Sections.Combine(reference.Sections);
    }
}
