
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentHeaderFooterSection : ICombinable<XlsxDocumentHeaderFooterSection>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxDocumentHeaderFooterSection>.Combine(XlsxDocumentHeaderFooterSection reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentHeaderFooterSection reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Alignment.Equals(DefaultAlignment))
        {
            Alignment = reference.Alignment;
        }

        if (Text.Equals(DefaultText))
        {
            Text = reference.Text;
        }

        if (Type.Equals(DefaultType))
        {
            Type = reference.Type;
        }
    }
}
