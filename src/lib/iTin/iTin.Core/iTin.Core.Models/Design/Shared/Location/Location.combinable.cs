
namespace iTin.Core.Models.Design;

using Enums;

public partial class Location : ICombinable<Location>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<Location>.Combine(Location reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(Location reference)
    {
        if (reference == null)
        {
            return;
        }

        Mode = LocationType switch
        {
            KnownElementLocation.ByAlignment => reference.Mode,
            KnownElementLocation.ByCoordenates => reference.Mode,
            _ => Mode
        };
    }
}
