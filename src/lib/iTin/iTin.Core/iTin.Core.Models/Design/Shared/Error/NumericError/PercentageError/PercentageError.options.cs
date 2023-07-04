
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class PercentageError : IOptions<PercentageErrorOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<PercentageErrorOptions>.ApplyOptions(PercentageErrorOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(PercentageErrorOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region BaseError

        base.ApplyOptions(options);

        #endregion
    }
}
