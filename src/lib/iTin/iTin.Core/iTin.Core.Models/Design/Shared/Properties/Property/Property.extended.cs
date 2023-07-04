
namespace iTin.Core.Models;

public partial class Property
{
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents the current object.
    /// </returns>
    public override string ToString() => $"Name=\"{Name}\"";


    internal void SetOwner(Properties reference) => Owner = reference;
}
