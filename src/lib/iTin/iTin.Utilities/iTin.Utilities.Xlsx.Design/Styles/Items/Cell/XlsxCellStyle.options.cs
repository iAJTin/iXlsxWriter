
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellStyle : IOptions<XlsxCellStyleOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference options</param>
    void IOptions<XlsxCellStyleOptions>.ApplyOptions(XlsxCellStyleOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this style.
    /// </summary>
    public void ApplyOptions(XlsxCellStyleOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Content
        Content.ApplyOptions(options.Content);
        #endregion

        #region Font
        Font.ApplyOptions(options.Font);
        #endregion
    }
}
