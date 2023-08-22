
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
/// Represents a Excel cell by row and column values
/// </summary>
public partial class XlsxPointRange
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
    private XlsxPoint _point;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPoint"/> class.
    /// </summary>
    public XlsxPointRange()
    {
        _point = new XlsxPoint
        {
            Row = DefaultRow,
            Column = DefaultColumn,
            AbsoluteStrategy = DefaultAbsolute,
        };
    }

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
        get => _point.AbsoluteStrategy;
        set => _point.AbsoluteStrategy = value;
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
        get => _point.Column;
        set => _point.Column = value;
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
        get => _point.Row;
        set => _point.Row = value;
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
    public void Offset(XlsxPointRange p) => Offset(p.Column, p.Row);

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

///// <summary>
///// Apply specified options to this alignment.
///// </summary>
//public virtual void ApplyOptions(XlsxExcelRangeOptions options)
//{
//    if (options == null)
//    {
//        return;
//    }

//    if (options.IsDefault)
//    {
//        return;
//    }

//    #region HorizontalCells
//    int? horizontalCellsOption = options.HorizontalCells;
//    bool horizontalCellsHasValue = horizontalCellsOption.HasValue;
//    if (horizontalCellsHasValue)
//    {
//        HorizontalCells = horizontalCellsOption.Value;
//    }
//    #endregion

//    #region VerticalCells
//    int? verticalCellsOption = options.HorizontalCells;
//    bool verticalCellsHasValue = verticalCellsOption.HasValue;
//    if (verticalCellsHasValue)
//    {
//        VerticalCells = verticalCellsOption.Value;
//    }
//    #endregion
//}
