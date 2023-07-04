
using System;

namespace iTin.Core.Models.Design.Charting;

public partial class BaseChart 
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
    public BaseChart Clone()
    {
        var cloned = (BaseChart)MemberwiseClone();
        //styleCloned.Borders = Borders.Clone();
        //styleCloned.Content = Content.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
