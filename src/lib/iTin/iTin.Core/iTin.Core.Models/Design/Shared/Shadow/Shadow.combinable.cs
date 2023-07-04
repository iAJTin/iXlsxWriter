
namespace iTin.Core.Models.Design;

public partial class Shadow : ICombinable<Shadow>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<Shadow>.Combine(Shadow reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(Shadow reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Offset.Equals(DefaultOffset))
        {
            Offset = reference.Offset;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }
    }
}
