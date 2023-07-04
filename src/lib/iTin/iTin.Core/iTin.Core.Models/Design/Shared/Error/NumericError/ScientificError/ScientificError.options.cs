
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class ScientificError : IOptions<ScientificErrorOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<ScientificErrorOptions>.ApplyOptions(ScientificErrorOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(ScientificErrorOptions options)
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
