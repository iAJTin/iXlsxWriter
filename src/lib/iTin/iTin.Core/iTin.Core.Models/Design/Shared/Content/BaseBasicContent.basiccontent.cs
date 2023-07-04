
using System.Diagnostics;

namespace iTin.Core.Models.Design;

using Content;

public partial class BaseBasicContent
{
    /// <summary>
    /// Gets or sets the collection of border properties.
    /// </summary>
    /// <value>
    /// Collection of border properties. Each element defines a border.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    ContentAlignment IBasicContent.Alignment
    {
        get => _alignment;
        set => _alignment = value;
    }
}
