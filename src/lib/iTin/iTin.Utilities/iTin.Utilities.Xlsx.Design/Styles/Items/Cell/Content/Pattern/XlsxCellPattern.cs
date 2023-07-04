
using System.Diagnostics;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="IPattern"/> interface.<br/>
/// Defines a generic pattern.
/// </summary>
public partial class XlsxCellPattern
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Transparent";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownPatternType DefaultPatternType = KnownPatternType.Solid;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownPatternType _type;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellPattern"/> class.
    /// </summary>
    public XlsxCellPattern()
    {
        Color = DefaultColor;
        PatternType = DefaultPatternType;
    }

    #endregion
}
