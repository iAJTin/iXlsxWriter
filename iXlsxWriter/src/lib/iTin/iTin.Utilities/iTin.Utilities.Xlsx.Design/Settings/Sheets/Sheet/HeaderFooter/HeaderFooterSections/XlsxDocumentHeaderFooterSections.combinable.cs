
using System.Linq;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentHeaderFooterSections : ICombinable<XlsxDocumentHeaderFooterSections>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxDocumentHeaderFooterSections>.Combine(XlsxDocumentHeaderFooterSections reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentHeaderFooterSections reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referenceSection in reference)
            {
                var sheet = referenceSection.Clone();
                sheet.SetOwner(this);
                Add(sheet);
            }
        }
        else
        {
            foreach (var section in this)
            {
                var refSheet = reference.GetBy(section.Name);
                if (refSheet != null)
                {
                    section.Combine(refSheet);
                }
            }

            foreach (var referenceSection in reference)
            {
                var sheet = GetBy(referenceSection.Name);
                if (sheet != null)
                {
                    continue;
                }

                var newSection = referenceSection.Clone();
                newSection.SetOwner(this);
                Add(newSection);
            }
        }
    }
}
