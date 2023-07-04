
using System;

using iTin.Core.Models.Design.Borders;

namespace iTin.Core.Models.Design;

public partial class BordersCollection
{
    /// <inheritdoc />
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
    public BordersCollection Clone()
    {
        var cloned = new BordersCollection(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (BaseBorder border in this)
        {
            cloned.Add(border.Clone());
        }

        return cloned;
    }
}
