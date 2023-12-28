
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxBorder : ICombinable<XlsxBorder>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxBorder>.Combine(XlsxBorder reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxBorder reference)
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

        if (Style.Equals(DefaultLineStyle))
        {
            Style = reference.Style;
        }

        if (Transparency.Equals(DefaultTransparency))
        {
            Transparency = reference.Transparency;
        }

        if (Width.Equals(DefaultWidth))
        {
            Width = reference.Width;
        }
    }
}
