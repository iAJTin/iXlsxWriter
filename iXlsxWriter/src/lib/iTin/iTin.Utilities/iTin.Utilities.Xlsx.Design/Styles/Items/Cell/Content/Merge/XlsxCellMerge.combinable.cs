
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellMerge : ICombinable<XlsxCellMerge>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference merge</param>
    void ICombinable<XlsxCellMerge>.Combine(XlsxCellMerge reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxCellMerge reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Orientation.Equals(DefaultMergeOrientation))
        {
            Orientation = reference.Orientation;
        }

        if (Cells.Equals(DefaultMergeCells))
        {
            Cells = reference.Cells;
        }
    }
}
