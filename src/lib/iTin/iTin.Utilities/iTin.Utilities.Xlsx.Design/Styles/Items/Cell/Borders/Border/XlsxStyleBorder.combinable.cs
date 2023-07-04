
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxStyleBorder : ICombinable<XlsxStyleBorder>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxStyleBorder>.Combine(XlsxStyleBorder reference) => Combine(reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxStyleBorder reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        if (Style.Equals(DefaultBorderStyle))
        {
            Style = reference.Style;
        }
    }
}
