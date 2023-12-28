
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxOuterShadow : ICombinable<XlsxOuterShadow>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxOuterShadow>.Combine(XlsxOuterShadow reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxOuterShadow reference)
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
