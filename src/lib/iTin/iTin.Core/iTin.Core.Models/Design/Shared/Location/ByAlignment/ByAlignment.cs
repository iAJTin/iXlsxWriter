
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// 
/// </summary>
public partial class ByAlignment
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultSkipLines = 0;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownHorizontalAlignment DefaultHorizontal = KnownHorizontalAlignment.Center;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _lines;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownHorizontalAlignment _horizontal;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="ByAlignment"/> class.
    /// </summary>
    public ByAlignment()
    {
        SkipLines = DefaultSkipLines;
        Horizontal = DefaultHorizontal;
    }

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [XmlAttribute]
    [DefaultValue(DefaultHorizontal)]
    public KnownHorizontalAlignment Horizontal
    {
        get => _horizontal;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _horizontal = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    /// <exception cref="InvalidOperationException"><paramref name="value"/> if number of lines less than zero</exception>
    [XmlAttribute]
    [DefaultValue(DefaultSkipLines)]
    public int SkipLines
    {
        get => _lines;
        set
        {
            SentinelHelper.IsTrue(value < 0, "The number of lines cannot be less than zero.");
            _lines = value;
        }
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [Browsable(false)]
    public override bool IsDefault => 
        base.IsDefault &&
        SkipLines.Equals(DefaultSkipLines) && 
        Horizontal.Equals(DefaultHorizontal);

    #endregion
}
