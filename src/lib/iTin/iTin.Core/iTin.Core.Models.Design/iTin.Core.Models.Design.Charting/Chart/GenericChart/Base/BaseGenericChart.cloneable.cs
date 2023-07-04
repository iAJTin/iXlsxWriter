
using System;

namespace iTin.Core.Models.Design.Charting;

public partial class BaseGenericChart
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
    public BaseGenericChart Clone()
    {
        var cloned = (BaseGenericChart)MemberwiseClone();
        //styleCloned.Borders = Borders.Clone();
        //styleCloned.Content = Content.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
