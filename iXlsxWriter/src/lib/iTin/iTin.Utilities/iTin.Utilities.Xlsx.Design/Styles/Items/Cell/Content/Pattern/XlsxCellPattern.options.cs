
using iTin.Core;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellPattern : IOptions<XlsxCellPatternOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference options</param>
    void IOptions<XlsxCellPatternOptions>.ApplyOptions(XlsxCellPatternOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this pattern.
    /// </summary>
    public virtual void ApplyOptions(XlsxCellPatternOptions options)
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

        #region PatternType
        KnownPatternType? patternTypeOption = options.PatternType;
        bool patternTypeHasValue = patternTypeOption.HasValue;
        if (patternTypeHasValue)
        {
            PatternType = patternTypeOption.Value;
        }
        #endregion
    }
}
