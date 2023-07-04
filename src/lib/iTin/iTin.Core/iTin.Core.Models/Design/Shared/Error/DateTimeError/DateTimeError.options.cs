
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class DateTimeError : IOptions<DateTimeErrorOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<DateTimeErrorOptions>.ApplyOptions(DateTimeErrorOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(DateTimeErrorOptions options)
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

        string valueOption = options.Value;
        bool valueHasValue = !valueOption.IsNullValue();
        if (valueHasValue)
        {
            Value = valueOption;
        }

        #endregion

        #region BaseError

        base.ApplyOptions(options);

        #endregion
    }
}
