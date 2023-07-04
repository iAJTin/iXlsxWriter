
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class FontModel : IOptions<FontOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<FontOptions>.ApplyOptions(FontOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this font.
    /// </summary>
    public virtual void ApplyOptions(FontOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Bold
        YesNo? boldOption = options.Bold;
        bool boldHasValue = boldOption.HasValue;
        if (boldHasValue)
        {
            Bold = boldOption.Value;
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

        #region IsScalable
        YesNo? isScalableOption = options.IsScalable;
        bool isScalableHasValue = isScalableOption.HasValue;
        if (isScalableHasValue)
        {
            IsScalable = isScalableOption.Value;
        }
        #endregion

        #region Italic
        YesNo? italicOption = options.Italic;
        bool italicHasValue = italicOption.HasValue;
        if (italicHasValue)
        {
            Italic = italicOption.Value;
        }
        #endregion

        #region Name
        string nameOption = options.Name;
        bool nameHasValue = !nameOption.IsNullValue();
        if (nameHasValue)
        {
            Name = nameOption;
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

        #region Underline
        YesNo? underlineOption = options.Underline;
        bool underlineHasValue = underlineOption.HasValue;
        if (underlineHasValue)
        {
            Underline = underlineOption.Value;
        }
        #endregion
    }
}
