﻿
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Helpers;

    using Shared;

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

        #region [public] XlsxChartSerie(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartSerie"/> class.
        /// </summary>
        public XlsxChartSerie()
        {
            Color = DefaultColor;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxChartSerie>.Combine(XlsxChartSerie): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartSerie>.Combine(XlsxChartSerie reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxChartSerie) Default: Gets default chart data serie of a plot
        /// <summary>
        /// Gets default chart data serie of a plot.
        /// </summary>
        /// <value>
        /// Default chart data serie of a plot.
        /// </value>
        public static XlsxChartSerie Default => new XlsxChartSerie();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) AxisRangeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        #endregion

        #region [public] (bool) FieldRangeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        #endregion

        #region [public] (XlsxChartSeriesCollection) Owner: Gets the element that owns this
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

        #endregion

        #region public properties

        #region [public] (XlsxBaseRange) AxisRange: Gets or sets the range of field that contains axis data of plot
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
            get => _axis ?? (_axis = new XlsxRange());
            set => _axis = value;
        }
        #endregion

        #region [public] (ChartType) ChartType: Gets or sets the preferred chart type
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
        #endregion

        #region [public] (string) Color: Gets or sets preferred serie color
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
        #endregion

        #region [public] (XlsxBaseRange) FieldRange: Gets or sets the range of field that contains data
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
            get => _field ?? (_field = new XlsxRange());
            set => _field = value;
        }
        #endregion

        #region [public] (string) Name: Gets or sets name of this serie
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

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
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

        #endregion

        #region public methods

        #region [public] (Color) GetColor(): Gets a reference to the Color structure than represents background color for this chart
        /// <summary>
        /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for background color for this chart.
        /// </summary>
        /// <returns>
        /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(Color);
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxChartSerieOptions): Apply specified options to this style
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
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxChartSerie): Combines this instance with reference parameter
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

        #endregion

        #region public new methods

        #region [public] (XlsxChartSerie) Clone(): Clones this instance
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

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxChartSeriesCollection): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChartSeriesCollection"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxChartSeriesCollection reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
