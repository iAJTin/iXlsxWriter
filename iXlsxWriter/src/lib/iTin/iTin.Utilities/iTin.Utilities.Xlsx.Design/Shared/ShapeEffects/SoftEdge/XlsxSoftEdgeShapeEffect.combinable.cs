
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> soft edge shape effect.
/// </summary>
public partial class XlsxSoftEdgeShapeEffect : ICombinable<XlsxSoftEdgeShapeEffect>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxSoftEdgeShapeEffect>.Combine(XlsxSoftEdgeShapeEffect reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    public virtual void Combine(XlsxSoftEdgeShapeEffect reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Size.Equals(DefaultSize))
        {
            Size = reference.Size;
        }
    }
}
