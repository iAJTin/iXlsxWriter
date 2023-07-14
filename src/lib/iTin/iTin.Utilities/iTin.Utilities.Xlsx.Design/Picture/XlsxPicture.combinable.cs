
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Picture;

/// <summary>
/// Defines a <b>xlsx</b> picture.
/// </summary>
public partial class XlsxPicture : ICombinable<XlsxPicture>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxPicture>.Combine(XlsxPicture reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxPicture reference)
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

        Border.Combine(reference.Border);
        Content.Combine(reference.Content);
        ShapeEffects.Combine(reference.ShapeEffects);
        //Size.Combine(reference.Size);
        //Effects.Combine(reference.Effects);
    }
}
