
namespace iTin.Charting.Models.Design
{
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

        #region [public] SerieModel(): Initializes a new instance of this class
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

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (SeriesModel) Owner: Gets the element that owns this
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

        #endregion

        #region public properties

        #region [public] (KnownChartType) ChartType: Gets or sets preferred chart type
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
        #endregion

        #region [public] (string) Color: Gets or sets preferred color for this data serie
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
        #endregion

        #region [public] (string) Name: Gets or sets name of this serie
        /// <summary>
        /// Gets or sets name of this serie.
        /// </summary>
        /// <value>
        /// Text of legend for this serie.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Name { get; set; }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that indicates whether the series is shown
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
        #endregion

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

        #region [public] (YesNo) UseSecondaryAxis: Gets or sets a value that determines whether the plot uses secondary axis
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
        #endregion

        #region [public] (int) Width: Gets or sets a value that indicates width of this serie
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

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
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

        #endregion

        #region public methods

        #region [public] (SerieModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public SerieModel Clone() => CopierHelper.DeepCopy(this);
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the color structure than represents color for this series
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure than represents color for this data serie.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color" /> structure that represents color of data serie.
        /// </returns> 
        public Color GetColor() => ColorHelper.GetColorFromString(Color);
        #endregion

        #region [public] (void) SetOwner(SeriesModel): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="T:iTin.Export.Model.ChartSerieModel" />.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        public void SetOwner(SeriesModel reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current instance
        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion
    }
}
