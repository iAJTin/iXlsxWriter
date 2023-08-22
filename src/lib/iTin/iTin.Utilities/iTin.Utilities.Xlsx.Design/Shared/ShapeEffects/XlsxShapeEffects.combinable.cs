
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxShapeEffects : ICombinable<XlsxShapeEffects>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxShapeEffects>.Combine(XlsxShapeEffects reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxShapeEffects reference)
    {
        if (reference == null)
        {
            return;
        }

        Illumination.Combine(reference.Illumination);
        Reflection.Combine(reference.Reflection);
        Shadow.Combine(reference.Shadow);
        SoftEdge.Combine(reference.SoftEdge);
    }
}
