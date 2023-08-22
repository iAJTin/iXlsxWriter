
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public abstract partial class XlsxBaseShadow : ICombinable<XlsxBaseShadow>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxBaseShadow>.Combine(XlsxBaseShadow reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxBaseShadow reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Angle.Equals(DefaultAngle))
        {
            Angle = reference.Angle;
        }

        if (Blur.Equals(DefaultBlur))
        {
            Blur = reference.Blur;
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

        if (Transparency.Equals(DefaultTransparency))
        {
            Transparency = reference.Transparency;
        }
    }
}
