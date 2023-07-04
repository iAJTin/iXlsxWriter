
namespace iTin.Core.Models.Design.Borders;

public partial class BaseBorder 
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference border</param>
    void ICombinable<IBorder>.Combine(IBorder reference) => Combine((BaseBorder)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference border</param>
    public virtual void Combine(BaseBorder reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Style.Equals(DefaultLineStyle))
        {
            Style = reference.Style;
        }

        if (Width.Equals(DefaultWidth))
        {
            Width = reference.Width;
        }
    }
}
