
using System.Linq;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Defines the <b>xlsx</b> header or footer sections.
/// </summary>
public partial class XlsxStyleBorders : ICombinable<XlsxStyleBorders>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    void ICombinable<IBorders>.Combine(IBorders reference) => Combine((XlsxStyleBorders)reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxStyleBorders reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referenceSection in reference)
            {
                var sheet = referenceSection.Clone();
                sheet.SetOwner(this);
                Add(sheet);
            }
        }
        else
        {
            var i = 0;
            foreach (var border in this)
            {
                var refBorder = reference[i];
                if (refBorder != null)
                {
                    border.Combine(refBorder);
                }

                i++;
            }
        }
    }
}
