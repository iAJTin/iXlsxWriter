
namespace iTin.Core.Models.Design;

public partial class BaseError : ICombinable<BaseError>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<BaseError>.Combine(BaseError reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(BaseError reference)
    {
        if (reference == null)
        {
            return;
        }

        Comment.Combine(reference.Comment);
    }
}
