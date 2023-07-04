
using System;

namespace iTin.Core.Models.Design.Charting;

public partial class BaseChart 
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IChart>.Combine(IChart reference) => Combine((BaseChart)reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(BaseChart reference)
    {
        if (reference == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(Name))
        {
            throw new NullReferenceException("You must first name the chart before merging");
        }

        //Borders.Combine(reference.Borders);
        //Content.Combine(reference.Content);
    }
}
