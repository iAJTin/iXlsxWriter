
using System;

namespace iTin.Utilities.Xlsx.Design.Picture;

public partial class XlsxPicture : ICloneable
{
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxPicture Clone()
    {
        var cloned = (XlsxPicture)MemberwiseClone();
        cloned.Border = Border?.Clone();
        cloned.Content = Content?.Clone();
        cloned.Effects = Effects?.Clone();
        cloned.ShapeEffects = ShapeEffects?.Clone();
        cloned.Properties = Properties?.Clone();
        cloned.Size = Size?.Clone();
        
        return cloned;
    }
}
