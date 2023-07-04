
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Core.Models.Design;

public partial class Comment : IOptions<CommentOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<CommentOptions>.ApplyOptions(CommentOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this instance.
    /// </summary>
    public virtual void ApplyOptions(CommentOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Font
        bool fontHasValue = options.Font != null;
        if (fontHasValue)
        {
            Font = options.Font.Clone();
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

        #region Text
        bool textHasValue = options.Text != null;
        if (textHasValue)
        {
            Text = options.Text;
        }
        #endregion
    }
}
