
namespace iTin.Core.Models.Design.Charting;

public partial class BaseGenericChart
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IChart>.Combine(IChart reference) => Combine((BaseGenericChart)reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    void ICombinable<IGenericChart>.Combine(IGenericChart reference) => Combine((BaseGenericChart)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(BaseGenericChart reference)
    {
        if (reference == null)
        {
            return;
        }

        if (BackColor.Equals(DefaultBackColor))
        {
            BackColor = reference.BackColor;
        }

        //Borders.Combine(reference.Borders);
        //Content.Combine(reference.Content);
    }
}
