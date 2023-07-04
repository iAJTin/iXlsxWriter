
using System;

namespace iTin.Core.Models.Design;

public partial class Comment : ICloneable
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
    /// <returns>A new object that is a copy of this instance.</returns>
    public Comment Clone()
    {
        var commentCloned = (Comment)MemberwiseClone();
        commentCloned.Font = Font.Clone();
        commentCloned.Properties = Properties.Clone();

        return commentCloned;
    }
}
