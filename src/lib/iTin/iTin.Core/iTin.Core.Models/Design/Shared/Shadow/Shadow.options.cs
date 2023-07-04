
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class Shadow : IOptions<ShadowOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<ShadowOptions>.ApplyOptions(ShadowOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(ShadowOptions options)
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
    }
}
