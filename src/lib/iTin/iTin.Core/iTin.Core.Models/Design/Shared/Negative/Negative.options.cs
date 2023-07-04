
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;
public partial class Negative : IOptions<NegativeOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<NegativeOptions>.ApplyOptions(NegativeOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(NegativeOptions options)
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
        KnownBasicColor? colorOption = options.Color;
        bool colorHasValue = colorOption.HasValue;
        if (colorHasValue)
        {
            Color = colorOption.Value;
        }
        #endregion

        #region Sign
        KnownNegativeSign? signOption = options.Sign;
        bool signHasValue = signOption.HasValue;
        if (signHasValue)
        {
            Sign = signOption.Value;
        }
        #endregion
    }
}