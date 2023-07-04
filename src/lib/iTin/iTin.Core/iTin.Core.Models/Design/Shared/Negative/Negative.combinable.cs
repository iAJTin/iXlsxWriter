
namespace iTin.Core.Models.Design;

public partial class Negative : ICombinable<Negative>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<Negative>.Combine(Negative reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public void Combine(Negative reference)
    {
        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Sign.Equals(DefaultSign))
        {
            Sign = reference.Sign;
        }
    }
}
