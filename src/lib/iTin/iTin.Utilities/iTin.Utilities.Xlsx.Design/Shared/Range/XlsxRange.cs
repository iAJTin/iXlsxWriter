
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
/// Represents a range of cells by row and column values.
/// </summary>
public partial class XlsxRange : ICloneable
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxPoint _end;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxPoint _start;

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

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool EndSpecified => !End.IsDefault;

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool StartSpecified => !Start.IsDefault;

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig default range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> reference containing default range.
    /// </value>
    public static XlsxRange Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or set a value containing the starting point of a range. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Starting point of a range.
    /// </value>
    [XmlElement]
    [JsonProperty("start")]
    public XlsxPoint Start
    {
        get => _start ??= new XlsxPoint();
        set => _start = value;
    }

    /// <summary>
    /// Gets or set a value containing the endpoint of a range. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Endpoint of a range.
    /// </value>
    [XmlElement]
    [JsonProperty("end")]
    public XlsxPoint End
    {
        get => _end ??= new XlsxPoint();
        set => _end = value;
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
        End.IsDefault &&
        Start.IsDefault;

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxRange Clone()
    {
        var cloned = (XlsxRange) MemberwiseClone();
        cloned.End = End.Clone();
        cloned.Start = Start.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

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

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxRange reference)
    {
        if (reference == null)
        {
            return;
        }

        End.Combine(reference.End);
        Start.Combine(reference.Start);
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> that represents the current object.
    /// </returns>
    public override string ToString()
    {
        var startRowNumber = Start.AbsoluteStrategy is AbsoluteStrategy.Both or AbsoluteStrategy.Row ? $"${Start.Row}" : $"{Start.Row}";
        var startColumnLetter = GetColumnLetter(Start.Column, Start.AbsoluteStrategy is AbsoluteStrategy.Column or AbsoluteStrategy.Both);
        var start = $"{startColumnLetter}{startRowNumber}";

        var endRowNumber = End.AbsoluteStrategy is AbsoluteStrategy.Both or AbsoluteStrategy.Row ? $"${End.Row}" : $"{End.Row}";
        var endColumnLetter = GetColumnLetter(End.Column, End.AbsoluteStrategy is AbsoluteStrategy.Column or AbsoluteStrategy.Both);
        var end = $"{endColumnLetter}{endRowNumber}";

        return $"{start}:{end}";
    }

    #endregion
}
