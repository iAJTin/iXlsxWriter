
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
///  Represents a data serie of a plot.
/// </summary>
public partial class XlsxChartSerie : ICombinable<XlsxChartSerie>
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Black";

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseRange _axis;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseRange _field;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private ChartType _chartType;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartSerie"/> class.
    /// </summary>
    public XlsxChartSerie()
    {
        Color = DefaultColor;
    }

    #endregion

    #region interfaces

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxChartSerie>.Combine(XlsxChartSerie reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Gets default chart data serie of a plot.
    /// </summary>
    /// <value>
    /// Default chart data serie of a plot.
    /// </value>
    public static XlsxChartSerie Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool AxisRangeSpecified => !AxisRange.IsDefault;

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool FieldRangeSpecified => !FieldRange.IsDefault;

    /// <summary>
    /// Gets the element that owns this <see cref="XlsxChartSerie"/>.
    /// </summary>
    /// <value>
    /// The <see cref="XlsxChartSeriesCollection"/> that owns this <see cref="XlsxChartSerie"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public XlsxChartSeriesCollection Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the range of field that contains axis data of plot.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseRange"/> that contains the range of field that contains axis data of plot.
    /// </value>
    [XmlElement]
    [JsonProperty("axis-range")]
    public XlsxBaseRange AxisRange
    {
        get => _axis ??= new XlsxRange();
        set => _axis = value;
    }

    /// <summary>
    /// Gets or sets the preferred chart type.
    /// </summary>
    /// <value>
    /// Preferred chart type.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("chart-type")]
    public ChartType ChartType
    {
        get => _chartType;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _chartType = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred serie color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    [DefaultValue(DefaultColor)]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets the range of field that contains data.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseRange"/> that contains range of field that contains data.
    /// </value>
    [XmlElement]
    [JsonProperty("field-range")]
    public XlsxBaseRange FieldRange
    {
        get => _field ??= new XlsxRange();
        set => _field = value;
    }

    /// <summary>
    /// Gets or sets name of this serie.
    /// </summary>
    /// <value>
    /// Text of legend for this serie.
    /// </value>
    [XmlAttribute]
    [JsonProperty("name")]
    public string Name { get; set; }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        AxisRange.IsDefault &&
        FieldRange.IsDefault &&
        Color.Equals(DefaultColor);

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for background color for this chart.
    /// </summary>
    /// <returns>
    /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this style.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxChartSerieOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Content
    //    Content.ApplyOptions(options.Content);
    //    #endregion

    //    #region Font
    //    Font.ApplyOptions(options.Font);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxChartSerie reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        AxisRange.Combine(reference.AxisRange);
        FieldRange.Combine(reference.FieldRange);
    }

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxChartSerie Clone()
    {
        var cloned = (XlsxChartSerie) MemberwiseClone();
        cloned.AxisRange = AxisRange.Clone();
        cloned.FieldRange = FieldRange.Clone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxChartSeriesCollection"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(XlsxChartSeriesCollection reference)
    {
        Owner = reference;
    }

    #endregion
}
