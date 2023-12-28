
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> point.
/// </summary>
public partial class XlsxPoint
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultRow = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultColumn = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const AbsoluteStrategy DefaultAbsolute = AbsoluteStrategy.None;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _row;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _column;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private AbsoluteStrategy _absolute;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPoint"/> class.
    /// </summary>
    public XlsxPoint()
    {
        Row = DefaultRow;
        Column = DefaultColumn;
        AbsoluteStrategy = DefaultAbsolute;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default point. Returns <b>A1</b> point.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPoint"/> reference containing the default point.
    /// </value>
    public static XlsxPoint Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred absoute strategy for column and row values. The default value is <see cref="Shared.AbsoluteStrategy.None"/>.
    /// </summary>
    /// <value>
    /// Preferred absoute strategy for column and row values.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("absolute-strategy")]
    [DefaultValue(DefaultAbsolute)]
    public AbsoluteStrategy AbsoluteStrategy
    {
        get => _absolute;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _absolute = value;
        }
    }

    /// <summary>
    /// Gets or sets the column value. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// column
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
    [XmlAttribute]
    [JsonProperty("column")]
    [DefaultValue(DefaultColumn)]
    public int Column
    {
        get => _column;
        set
        {
            SentinelHelper.ArgumentLessThan(nameof(Column), value, 1);
            _column = value;
        }
    }

    /// <summary>
    /// Gets or sets the row value. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Row
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
    [XmlAttribute]
    [JsonProperty("row")]
    [DefaultValue(DefaultRow)]
    public int Row
    {
        get => _row;
        set
        {
            SentinelHelper.ArgumentLessThan(nameof(Row), value, 1);
            _row = value;
        }
    }

    #endregion

    #region public methods

    /// <summary>
    /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
    /// </summary>
    public void Offset(Point p) => Offset(p.X, p.Y);

    /// <summary>
    /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
    /// </summary>
    public void Offset(XlsxPoint p) => Offset(p.Column, p.Row);
        
    /// <summary>
    /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
    /// </summary>
    public void Offset(int dx, int dy)
    {
        unchecked
        {
            Column += dx;
            Row += dy;
        }
    }

    #endregion
}
