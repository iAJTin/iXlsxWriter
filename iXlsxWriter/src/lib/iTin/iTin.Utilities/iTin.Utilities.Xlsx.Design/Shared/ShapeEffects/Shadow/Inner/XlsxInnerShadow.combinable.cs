
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxInnerShadow : ICombinable<XlsxInnerShadow>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxInnerShadow>.Combine(XlsxInnerShadow reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxInnerShadow reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);
    }
}
