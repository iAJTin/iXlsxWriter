
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Content;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="ContentAlignment"/> class.<br/>
/// Defines a <b>xlsx</b> cell content alignment.
/// </summary>
public partial class XlsxCellContentAlignment : IOptions<XlsxCellContentAlignmentOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference alignment</param>
    void IOptions<XlsxCellContentAlignmentOptions>.ApplyOptions(XlsxCellContentAlignmentOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this alignment.
    /// </summary>
    public virtual void ApplyOptions(XlsxCellContentAlignmentOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Horizontal
        KnownHorizontalAlignment? horizontalOption = options.Horizontal;
        bool horizontalHasValue = horizontalOption.HasValue;
        if (horizontalHasValue)
        {
            Horizontal = horizontalOption.Value;
        }
        #endregion

        #region Vertical
        KnownVerticalAlignment? verticalOption = options.Vertical;
        bool verticalHasValue = verticalOption.HasValue;
        if (verticalHasValue)
        {
            Vertical = verticalOption.Value;
        }
        #endregion
    }
}
