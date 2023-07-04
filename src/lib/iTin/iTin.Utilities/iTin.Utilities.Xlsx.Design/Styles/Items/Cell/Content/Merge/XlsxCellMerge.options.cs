
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellMerge : IOptions<XlsxCellMergeOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference merge</param>
    void IOptions<XlsxCellMergeOptions>.ApplyOptions(XlsxCellMergeOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this merge.
    /// </summary>
    public virtual void ApplyOptions(XlsxCellMergeOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Cells
        int? cellsOption = options.Cells;
        bool cellsHasValue = cellsOption.HasValue;
        if (cellsHasValue)
        {
            Cells = cellsOption.Value;
        }
        #endregion

        #region Orientation
        KnownMergeOrientation? orientationOption = options.Orientation;
        bool orientationHasValue = orientationOption.HasValue;
        if (orientationHasValue)
        {
            Orientation = orientationOption.Value;
        }
        #endregion
    }
}
