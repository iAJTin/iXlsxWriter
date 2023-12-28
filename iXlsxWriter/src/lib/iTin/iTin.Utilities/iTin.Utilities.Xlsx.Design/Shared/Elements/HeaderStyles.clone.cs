
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class HeaderStyles : ICloneable
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
    public HeaderStyles Clone()
    {
        var cloned = (HeaderStyles)MemberwiseClone();
        cloned.Text = Text?.Clone();
        cloned.Decimal = Decimal?.Clone();
        cloned.Numeric = Numeric?.Clone();
        cloned.DateTime = DateTime?.Clone();
        cloned.Currency = Currency?.Clone();

        return cloned;
    }
}
