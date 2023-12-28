
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> shape.
/// </summary>
public partial class XlsxShape : ICombinable<XlsxShape>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxShape>.Combine(XlsxShape reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxShape reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

        Name ??= reference.Name;

        if (ShapeType.Equals(DefaultShapeType))
        {
            ShapeType = reference.ShapeType;
        }

        Border.Combine(reference.Border);
        Content.Combine(reference.Content);
        ShapeEffects.Combine(reference.ShapeEffects);
        //Size.Combine(reference.Size);
    }
}
