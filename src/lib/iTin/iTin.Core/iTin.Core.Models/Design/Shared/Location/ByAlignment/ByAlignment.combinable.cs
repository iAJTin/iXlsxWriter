
namespace iTin.Core.Models.Design;

public partial class ByAlignment : ICombinable<ByAlignment>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<ByAlignment>.Combine(ByAlignment reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(ByAlignment reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Horizontal.Equals(DefaultHorizontal))
        {
            Horizontal = reference.Horizontal;
        }

        if (SkipLines.Equals(DefaultSkipLines))
        {
            SkipLines = reference.SkipLines;
        }
    }
}
