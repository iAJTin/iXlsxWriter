
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxSheetSettings : ICombinable<XlsxSheetSettings>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxSheetSettings>.Combine(XlsxSheetSettings reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxSheetSettings reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Orientation.Equals(DefaultOrientation))
        {
            Orientation = reference.Orientation;
        }

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }

        if (View.Equals(DefaultView))
        {
            View = reference.View;
        }

        reference.Footer.Combine(reference.Footer);
        reference.Header.Combine(reference.Header);
        reference.Margins.Combine(reference.Margins);
        reference.FreezePanesPoint.Combine(reference.FreezePanesPoint);
    }
}
