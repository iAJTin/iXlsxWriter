
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxReflectionShapeEffect : ICombinable<XlsxReflectionShapeEffect>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxReflectionShapeEffect>.Combine(XlsxReflectionShapeEffect reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxReflectionShapeEffect reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Blur.Equals(DefaultBlur))
        {
            Blur = reference.Blur;
        }

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
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
