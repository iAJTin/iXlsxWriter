
using System.Linq;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxSheetsSettingsCollection : ICombinable<XlsxSheetsSettingsCollection>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxSheetsSettingsCollection>.Combine(XlsxSheetsSettingsCollection reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxSheetsSettingsCollection reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referenceSheet in reference)
            {
                var sheet = referenceSheet.Clone();
                sheet.SetOwner(this);
                Add(sheet);
            }
        }
        else
        {
            foreach (var sheet in this)
            {
                var refSheet = reference.GetBy(sheet.SheetName);
                if (refSheet != null)
                {
                    sheet.Combine(refSheet);
                }
            }

            foreach (var referenceSheet in reference)
            {
                var sheet = GetBy(referenceSheet.SheetName);
                if (sheet != null)
                {
                    continue;
                }

                var newSheet = referenceSheet.Clone();
                newSheet.SetOwner(this);
                Add(newSheet);
            }
        }
    }
}
