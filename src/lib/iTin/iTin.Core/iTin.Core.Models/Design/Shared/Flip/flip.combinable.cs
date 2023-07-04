
namespace iTin.Core.Models.Design;

public partial class Flip : ICombinable<Flip>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<Flip>.Combine(Flip reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(Flip reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Mode.Equals(DefaultMode))
        {
            Mode = reference.Mode;
        }
    }
}
