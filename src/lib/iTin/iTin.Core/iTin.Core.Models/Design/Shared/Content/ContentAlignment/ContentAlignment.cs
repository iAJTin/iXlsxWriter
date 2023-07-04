
using System.Diagnostics;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Content;

/// <summary>
/// A Specialization of <see cref="IContentAlignment"/> interface.<br/>
/// Which acts as the base class for different content alignment configurations.
/// </summary>
public partial class ContentAlignment
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownHorizontalAlignment DefaultHorizontalAlignment = KnownHorizontalAlignment.Left;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownVerticalAlignment DefaultVerticalAlignment = KnownVerticalAlignment.Center;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownHorizontalAlignment _horizontal;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownVerticalAlignment _vertical;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentAlignment"/> class.
    /// </summary>
    public ContentAlignment()
    {
        Vertical = DefaultVerticalAlignment;
        Horizontal = DefaultHorizontalAlignment;
    }

    #endregion

    #region public static readonly properties

    /// <summary>
    /// Gets a default alignment.
    /// </summary>
    /// <value>
    /// An alignment.
    /// </value>
    public static ContentAlignment Default => new();

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Vertical.Equals(DefaultVerticalAlignment) &&
        Horizontal.Equals(DefaultHorizontalAlignment);

    #endregion
}
