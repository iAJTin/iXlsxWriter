
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class BaseError : IOptions<BaseErrorOptions>
{
    /// <summary>
    /// Apply specified options with this instance.
    /// </summary>
    /// <param name="reference">Reference content alignment options</param>
    void IOptions<BaseErrorOptions>.ApplyOptions(BaseErrorOptions reference) => ApplyOptions(reference);

    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(BaseErrorOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Comment
        bool commentHasValue = options.Comment != null;
        if (commentHasValue)
        {
            Comment = options.Comment;
        }
        #endregion
    }
}
