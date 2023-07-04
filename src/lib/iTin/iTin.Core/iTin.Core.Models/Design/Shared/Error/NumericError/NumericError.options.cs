
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class NumericError : IOptions<NumericErrorOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<NumericErrorOptions>.ApplyOptions(NumericErrorOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(NumericErrorOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Value

        float? valueOption = options.Value;
        bool valueHasValue = valueOption.HasValue;
        if (valueHasValue)
        {
            Value = valueOption.Value;
        }

        #endregion

        #region BaseError

        base.ApplyOptions(options);

        #endregion
    }
}
