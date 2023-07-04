
namespace iTin.Core.Models.Design;

public partial class Comment : ICombinable<Comment>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<Comment>.Combine(Comment reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(Comment reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        Text ??= reference.Text;

        Font.Combine(reference.Font);
    }
}
