
using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxIlluminationShapeEffect : IOptions<XlsxIlluminationShapeEffectOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxIlluminationShapeEffectOptions>.ApplyOptions(XlsxIlluminationShapeEffectOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxIlluminationShapeEffectOptions options)
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

        #region Size
        int? sizeOption = options.Size;
        bool sizeHasValue = sizeOption.HasValue;
        if (sizeHasValue)
        {
            Size = sizeOption.Value;
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
