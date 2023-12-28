
using System;

namespace iTin.Utilities.Xlsx.Design.Picture;

public partial class XlsxEffectsCollection : ICloneable
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
    public XlsxEffectsCollection Clone()
    {
        var cloned = new XlsxEffectsCollection()
        {
            Properties = Properties.Clone()
        };

        foreach (var sheet in this)
        {
            cloned.Add(sheet.Clone());
        }

        return cloned;
    }
}
