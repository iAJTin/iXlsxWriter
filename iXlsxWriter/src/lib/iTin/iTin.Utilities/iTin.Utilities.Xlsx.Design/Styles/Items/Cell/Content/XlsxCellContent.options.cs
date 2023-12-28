
using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContent : IOptions<XlsxCellContentOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference options</param>
    void IOptions<XlsxCellContentOptions>.ApplyOptions(XlsxCellContentOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this content.
    /// </summary>
    public virtual void ApplyOptions(XlsxCellContentOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Color
        string colorOption = options.Color;
        bool colorHasValue = !colorOption.IsNullValue();
        if (colorHasValue)
        {
            Color = colorOption;
        }
        #endregion

        #region Show
        YesNo? showOption = options.Show;
        bool showHasValue = showOption.HasValue;
        if (showHasValue)
        {
            Show = showOption.Value;
        }
        #endregion

        #region Alignment
        Alignment.ApplyOptions(options.Alignment);
        #endregion

        #region Merge
        Merge.ApplyOptions(options.Merge);
        #endregion

        #region Pattern
        Pattern.ApplyOptions(options.Pattern);
        #endregion
    }
}
