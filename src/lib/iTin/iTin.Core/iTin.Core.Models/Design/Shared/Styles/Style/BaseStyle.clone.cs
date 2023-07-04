
using System;

namespace iTin.Core.Models.Design.Styles;

public partial class BaseStyle
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
    public BaseStyle Clone()
    {
        var styleCloned = (BaseStyle)MemberwiseClone();
        styleCloned.Borders = Borders.Clone();
        styleCloned.Content = Content.Clone();
        styleCloned.Properties = Properties.Clone();

        return styleCloned;
    }
}
