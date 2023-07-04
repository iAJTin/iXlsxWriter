
using System.Linq;

namespace iTin.Core.Models.Design;

public partial class ByCoordenates : ICombinable<ByCoordenates>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<ByCoordenates>.Combine(ByCoordenates reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(ByCoordenates reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Coordenates.SequenceEqual(DefaultCoordenates))
        {
            Coordenates = (int[])reference.Coordenates.Clone();
        }
    }
}
