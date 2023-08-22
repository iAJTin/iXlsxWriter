
using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

public abstract partial class XlsxBaseShadow : IOptions<XlsxBaseShadowOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxBaseShadowOptions>.ApplyOptions(XlsxBaseShadowOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxBaseShadowOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Angle
        int? angleOption = options.Angle;
        bool angleHasValue = angleOption.HasValue;
        if (angleHasValue)
        {
            Angle = angleOption.Value;
        }
        #endregion

        #region Blur
        int? blurOption = options.Blur;
        bool blurHasValue = blurOption.HasValue;
        if (blurHasValue)
        {
            Blur = blurOption.Value;
        }
        #endregion

        #region Color
        string colorOption = options.Color;
        bool colorHasValue = !colorOption.IsNullValue();
        if (colorHasValue)
        {
            Color = colorOption;
        }
        #endregion

        #region Offset
        int? offsetOption = options.Offset;
        bool offsetHasValue = offsetOption.HasValue;
        if (offsetHasValue)
        {
            Offset = offsetOption.Value;
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

        #region Transparency
        int? transparencyOption = options.Transparency;
        bool transparencyHasValue = transparencyOption.HasValue;
        if (transparencyHasValue)
        {
            Transparency = transparencyOption.Value;
        }
        #endregion
    }
}
