
namespace iTin.Core.Models.Design;

public partial class BaseContent
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Target referencer</param>
    void ICombinable<IContent>.Combine(IContent reference) => Combine((BaseContent)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Target referencer</param>
    public virtual void Combine(BaseContent reference)
    {
        if (reference == null)
        {
            return;
        }

        if (AlternateColor.Equals(DefaultColor))
        {
            AlternateColor = reference.AlternateColor;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }
    }
}