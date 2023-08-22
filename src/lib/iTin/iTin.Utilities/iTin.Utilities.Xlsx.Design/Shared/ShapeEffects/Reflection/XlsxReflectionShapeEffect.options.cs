
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxReflectionShapeEffect : IOptions<XlsxReflectionShapeEffectOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxReflectionShapeEffectOptions>.ApplyOptions(XlsxReflectionShapeEffectOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxReflectionShapeEffectOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Blur
        float? blurOption = options.Blur;
        bool blurHasValue = blurOption.HasValue;
        if (blurHasValue)
        {
            Blur = blurOption.Value;
        }
        #endregion

        #region Offset
        float? offsetOption = options.Offset;
        bool offsetHasValue = offsetOption.HasValue;
        if (offsetHasValue)
        {
            Offset = offsetOption.Value;
        }
        #endregion

        #region Size
        float? sizeOption = options.Size;
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
