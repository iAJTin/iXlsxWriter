
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> shape effects.
/// </summary>
public partial class XlsxShapeEffects : IOptions<XlsxShapeEffectsOptions>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void IOptions<XlsxShapeEffectsOptions>.ApplyOptions(XlsxShapeEffectsOptions reference) => ApplyOptions(reference);


    /// <summary>
    /// Apply specified options to this shadow.
    /// </summary>
    public virtual void ApplyOptions(XlsxShapeEffectsOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        Illumination.ApplyOptions(options.Illumination);
        Reflection.ApplyOptions(options.Reflection);
        Shadow.ApplyOptions(options.Shadow);
        SoftEdge.ApplyOptions(options.SoftEdge);
    }
}
