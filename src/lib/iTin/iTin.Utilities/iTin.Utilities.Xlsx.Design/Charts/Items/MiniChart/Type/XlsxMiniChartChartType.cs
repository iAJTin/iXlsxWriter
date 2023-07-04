﻿
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartChartType : ICombinable<XlsxMiniChartChartType>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const MiniChartType DefaultMiniChartType = MiniChartType.Column;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private MiniChartType _active;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartLineChartType _line;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartColumnChartType _column;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartWinLossChartType _winLoss;

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

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartChartType>.Combine(XlsxMiniChartChartType reference) => Combine(reference);

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default visual setting of minichart types.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChart"/> reference containing the default visual setting of minichart types.
    /// </value>
    public static XlsxMiniChartChartType Default => new();

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
    public bool ColumnSpecified => !Column.IsDefault;

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
    public bool LineSpecified => !Line.IsDefault;

    /// <summary>
    /// Gets the parent element.
    /// </summary>
    /// <value>
    /// The element that represents the container element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxMiniChart Parent { get; private set; }

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
    public bool WinLossSpecified => !WinLoss.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that determines preferred active mini-chart type. The default is <see cref="MiniChartType.Column"/>.
    /// </summary>
    /// <value>
    /// Preferred active mini-chart type.
    /// </value>
    [XmlAttribute]
    [JsonProperty("chart-active")]
    [DefaultValue(DefaultMiniChartType)]
    public MiniChartType Active
    {
        get => _active;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _active = value;
        }
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of a column mini-chart.
    /// </summary>
    /// <value>
    /// Visual setting of a column mini-chart.
    /// </value>
    [XmlElement]
    [JsonProperty("column-chart")]
    public XlsxMiniChartColumnChartType Column
    {
        get
        {
            _column ??= new XlsxMiniChartColumnChartType();
            _column.SetParent(this);

            return _column;
        }
        set => _column = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of a line mini-chart.
    /// </summary>
    /// <value>
    /// Visual setting of a column mini-chart.
    /// </value>
    [XmlElement]
    [JsonProperty("line-chart")]
    public XlsxMiniChartLineChartType Line
    {
        get
        {
            _line ??= new XlsxMiniChartLineChartType();
            _line.SetParent(this);

            return _line;
        }
        set => _line = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of a line mini-chart.
    /// </summary>
    /// <value>
    /// Visual setting of a column mini-chart.
    /// </value>
    [XmlElement]
    [JsonProperty("winloss-chart")]
    public XlsxMiniChartWinLossChartType WinLoss
    {
        get
        {
            _winLoss ??= new XlsxMiniChartWinLossChartType();
            _winLoss.SetParent(this);

            return _winLoss;
        }
        set => _winLoss = value;
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        Column.IsDefault &&
        Line.IsDefault &&
        WinLoss.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartChartType Clone()
    {
        var cloned = (XlsxMiniChartChartType)MemberwiseClone();
        cloned.Column = Column.Clone();
        cloned.Line = Line.Clone();
        cloned.WinLoss = WinLoss.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartTypeOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Active
    //    MiniChartType? activeOption = options.Active;
    //    bool activeHasValue = activeOption.HasValue;
    //    if (activeHasValue)
    //    {
    //        Active = activeOption.Value;
    //    }
    //    #endregion

    //    //#region Column
    //    //Column.ApplyOptions(options.Column);
    //    //#endregion

    //    //#region Line
    //    //Line.ApplyOptions(options.Line);
    //    //#endregion

    //    //#region WinLoss
    //    //WinLoss.ApplyOptions(options.WinLoss);
    //    //#endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartChartType reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Active.Equals(DefaultMiniChartType))
        {
            Active = reference.Active;
        }

        Line.Combine(reference.Line);
        Column.Combine(reference.Column);
        WinLoss.Combine(reference.WinLoss);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartAxes"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChart reference)
    {
        Parent = reference;
    }

    #endregion
}
