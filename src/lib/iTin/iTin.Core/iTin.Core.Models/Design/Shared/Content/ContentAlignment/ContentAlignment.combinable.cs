
namespace iTin.Core.Models.Design.Content;

public partial class ContentAlignment
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    void ICombinable<IContentAlignment>.Combine(IContentAlignment reference) => Combine((ContentAlignment)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    public virtual void Combine(ContentAlignment reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Horizontal.Equals(DefaultHorizontalAlignment))
        {
            Horizontal = reference.Horizontal;
        }

        if (Vertical.Equals(DefaultVerticalAlignment))
        {
            Vertical = reference.Vertical;
        }
    }
}
