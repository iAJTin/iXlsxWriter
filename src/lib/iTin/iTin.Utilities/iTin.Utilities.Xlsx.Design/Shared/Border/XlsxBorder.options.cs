
using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxBorder : IOptions<XlsxBorderOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxBorderOptions>.ApplyOptions(XlsxBorderOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this alignment.
    /// </summary>
    public virtual void ApplyOptions(XlsxBorderOptions options)
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

        #region Style
        KnownLineStyle? styleOption = options.Style;
        bool styleHasValue = styleOption.HasValue;
        if (styleHasValue)
        {
            Style = styleOption.Value;
        }
        #endregion

        #region Transparency
        int? transparencyOption = options.Transparency;
        bool transparencyHasValue = transparencyOption.HasValue;
        if (transparencyHasValue)
        {
            Transparency = transparencyOption.Value;
        }
        #endregion

        #region Width
        int? widthOption = options.Width;
        bool widthHasValue = widthOption.HasValue;
        if (widthHasValue)
        {
            Width = widthOption.Value;
        }
        #endregion
   }
}
