
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents a data serie of a plot.
/// </summary>
public partial class SerieModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultSerieWidth = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShowInLegend = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultSerieColor = "Black";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultUseSecondaryAxis = YesNo.No;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownChartType _chartType;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.SerieModel" /> class.
    /// </summary>
    public SerieModel()
    {
        Show = DefaultShow;
        Color = DefaultSerieColor;
        Width = DefaultSerieWidth;
        ShowInLegend = DefaultShowInLegend;
        UseSecondaryAxis = DefaultUseSecondaryAxis;
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

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the element that owns this <see cref="T:iTin.Charting.ComponentModel.Models.SeriesModel" />.
    /// </summary>
    /// <value>
    /// The <see cref="T:iTin.Charting.ComponentModel.Models.SeriesModel" /> that owns this <see cref="T:iTin.Charting.ComponentModel.Models.SerieModel" />.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    public SeriesModel Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred chart type.
    /// </summary>
    /// <value>
    /// One of <see cref="T:iTin.Export.Model.KnownChartType" /> values.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [JsonConverter(typeof(StringEnumConverter))]
    public KnownChartType ChartType
    {
        get => _chartType;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _chartType = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred color for this data serie. The default is <b>(Black)</b>.
    /// </summary>
    /// <value>
    /// Preferred color for this data serie.
    /// </value>
    /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultSerieColor)]
    public string Color
    {
        get => _color;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(value));

            _color = value;
        }
    }

    /// <summary>
    /// Gets or sets name of this serie.
    /// </summary>
    /// <value>
    /// Text of legend for this serie.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether the series is shown. The default is <b>YesNo.Yes</b>.
    /// </summary>
    /// <value>
    /// <b>YesNo.Yes</b> if the string is shown; otherwise, <b>YesNo.No</b>.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo Show { get; set; }

    #region [public] (YesNo) ShowInLegend: Gets or sets a value that indicates whether the series is shown in the chart legend
    /// <summary>
    /// Gets or sets a value that indicates whether the series is shown in the chart legend. The default is <b>YesNo.Yes</b>.
    /// </summary>
    /// <value>
    /// <b>YesNo.Yes</b> if the string is shown in the legend; otherwise, <b>YesNo.No</b>.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultShowInLegend)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo ShowInLegend { get; set; }
    #endregion

    /// <summary>
    /// Gets or sets a value that determines whether the series uses secondary axis. The default is <b>YesNo.No</b>.
    /// </summary>
    /// <value>
    /// <b>YesNo.Yes</b>" if serie uses secondary axis; otherwise, <b>YesNo.No</b>.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultUseSecondaryAxis)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo UseSecondaryAxis { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates width of this serie. The default is <b>(1)</b>.
    /// </summary>
    /// <value>
    /// Width of this serie.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultSerieWidth)]
    public int Width { get; set; }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault =>
        Show.Equals(DefaultShow) &&
        Color.Equals(DefaultSerieColor) &&
        Width.Equals(DefaultSerieWidth) &&
        ShowInLegend.Equals(DefaultShowInLegend) &&
        UseSecondaryAxis.Equals(DefaultUseSecondaryAxis);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public SerieModel Clone() => CopierHelper.DeepCopy(this);

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure than represents color for this data serie.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color" /> structure that represents color of data serie.
    /// </returns> 
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    /// <summary>
    /// Sets the element that owns this <see cref="T:iTin.Export.Model.ChartSerieModel" />.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    public void SetOwner(SeriesModel reference)
    {
        Owner = reference;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current object.
    /// </returns>
    public override string ToString() => !IsDefault ? "Modified" : "Default";

    #endregion
}
