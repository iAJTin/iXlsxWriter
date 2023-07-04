
namespace iTin.Core.Models.Design;

public partial class BaseBasicContent
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    void ICombinable<IBasicContent>.Combine(IBasicContent reference) => Combine((BaseBasicContent)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content alignment</param>
    public virtual void Combine(BaseBasicContent reference)
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

        Alignment.Combine(reference.Alignment);
    }
}
