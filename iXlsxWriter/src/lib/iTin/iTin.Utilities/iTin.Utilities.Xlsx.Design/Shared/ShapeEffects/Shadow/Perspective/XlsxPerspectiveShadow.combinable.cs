
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPerspectiveShadow : ICombinable<XlsxPerspectiveShadow>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxPerspectiveShadow>.Combine(XlsxPerspectiveShadow reference) => Combine(reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxPerspectiveShadow reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }
    }
}
