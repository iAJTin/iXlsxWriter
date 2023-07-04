
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
public partial class XlsxPoint : IEquatable<XlsxPoint>, ICloneable
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

    #region interfaces

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #region IEquatable

    #region public methods

    #region [public] (bool) Equals(XlsxPoint): Indicates whether the current object is equal to another object of the same type
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// <b>true</b> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <b>false</b>.
    /// </returns>
    public bool Equals(XlsxPoint other) => other != null && other.Equals((object)this);
    #endregion

    #endregion

    #endregion

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

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Row.Equals(DefaultRow) && 
        Column.Equals(DefaultColumn) &&
        AbsoluteStrategy.Equals(DefaultAbsolute);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxPoint Clone()
    {
        var cloned = (XlsxPoint) MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

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

    #region public override methods

    /// <summary>
    /// Returns a value that represents the hash code for this class.
    /// </summary>
    /// <returns>
    /// Hash code for this class.
    /// </returns>
    public override int GetHashCode() => Column.GetHashCode() ^ Row.GetHashCode() ^ AbsoluteStrategy.GetHashCode();

    /// <summary>
    /// Returns a value that indicates whether this class is equal to another
    /// </summary>
    /// <param name="obj">Class with which to compare.</param>
    /// <returns>
    /// Results equality comparison.
    /// </returns>
    public override bool Equals(object obj)
    {
        if (obj is not XlsxPoint other)
        {
            return false;
        }

        return 
            other.Column == Column &&
            other.Row == Row;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this alignment.
    /// </summary>
    public virtual void ApplyOptions(XlsxPointOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region AbsoluteStrategy
        AbsoluteStrategy? absoluteOption = options.AbsoluteStrategy;
        bool absoluteHasValue = absoluteOption.HasValue;
        if (absoluteHasValue)
        {
            AbsoluteStrategy = absoluteOption.Value;
        }
        #endregion

        #region Column
        int? columnOption = options.Column;
        bool columnHasValue = columnOption.HasValue;
        if (columnHasValue)
        {
            Column = columnOption.Value;
        }
        #endregion

        #region Row
        int? rowOption = options.Row;
        bool rowHasValue = rowOption.HasValue;
        if (rowHasValue)
        {
            Row = rowOption.Value;
        }
        #endregion
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxPoint reference)
    {
        if (reference == null)
        {
            return;
        }

        if (AbsoluteStrategy.Equals(DefaultAbsolute))
        {
            AbsoluteStrategy = reference.AbsoluteStrategy;
        }

        if (Column.Equals(DefaultColumn))
        {
            Column = reference.Column;
        }

        if (Row.Equals(DefaultRow))
        {
            Row = reference.Row;
        }
    }

    #endregion
}
