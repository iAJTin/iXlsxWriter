
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    ///  Represents a data serie of a plot.
    /// </summary>
    public partial class XlsxChartPlot : ICombinable<XlsxChartPlot>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultUseSecondaryAxis = YesNo.No;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _useSecondaryAxis;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxChartSeriesCollection _series;
        #endregion

        #region constructor/s

        #region [public] XlsxChartPlot(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartPlot"/> class.
        /// </summary>
        public XlsxChartPlot()
        {
            UseSecondaryAxis = DefaultUseSecondaryAxis;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxChartPlot>.Combine(XlsxChartPlot): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartPlot>.Combine(XlsxChartPlot reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxChartPlot) Default: Gets default chart data serie of a plot
        /// <summary>
        /// Gets default chart data serie of a plot.
        /// </summary>
        /// <value>
        /// Default chart data serie of a plot.
        /// </value>
        public static XlsxChartPlot Default => new XlsxChartPlot();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) SeriesSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool SeriesSpecified => !Series.IsDefault;
        #endregion

        #region [public] (XlsxSheetsSettingsCollection) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="XlsxChartPlot"/>.
        /// </summary>
        /// <value>
        /// The <see cref="XlsxChartPlotsCollection"/> that owns this <see cref="XlsxChartPlot"/>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public XlsxChartPlotsCollection Owner { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Name: Gets or sets name of plot
        /// <summary>
        /// Gets or sets name of plot.
        /// </summary>
        /// <value>
        /// The name of plot. Are only allow strings made ​​up of letters, numbers and following special chars <strong>'<c>_ - # @ % $</c>'</strong>.
        /// </value>
        [XmlAttribute]
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region [public] (Series) Series: Collection of data series for a plot
        /// <summary>
        /// Gets or sets collection of series for a plot.
        /// </summary>
        /// <value>
        /// Collection of data series for a plot. Each element represents a data serie of a plot.
        /// </value>
        [JsonProperty("serie")]
        [XmlArrayItem("Serie", typeof(XlsxChartSerie))]
        public XlsxChartSeriesCollection Series
        {
            get => _series ?? (_series = new XlsxChartSeriesCollection(this));
            set => _series = value;
        }
        #endregion

        #region [public] (YesNo) UseSecondaryAxis: Gets or sets a value that determines whether the plot uses secondary axis
        /// <summary>
        /// Gets or sets a value that determines whether the plot uses secondary axis. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if plot uses secondary axis; otherwise, <see cref="YesNo.No"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("use-secondary-axis")]
        [DefaultValue(DefaultUseSecondaryAxis)]
        public YesNo UseSecondaryAxis
        {
            get => _useSecondaryAxis;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _useSecondaryAxis = value;
            }
        }
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
            UseSecondaryAxis.Equals(DefaultUseSecondaryAxis);
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxChartPlotOptions): Apply specified options to this style
        ///// <summary>
        ///// Apply specified options to this style.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxChartPlotOptions options)
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

        #region [public] {virtual} (void) Combine(XlsxChartPlot): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxChartPlot reference)
        {
            if (reference == null)
            {
                return;
            }

            if (UseSecondaryAxis.Equals(DefaultUseSecondaryAxis))
            {
                UseSecondaryAxis = reference.UseSecondaryAxis;
            }
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] (XlsxChartPlot) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartPlot Clone()
        {
            var cloned = (XlsxChartPlot) MemberwiseClone();
            cloned.Properties = Properties.Clone();
            
            return cloned;
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxChartPlotsCollection): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChartPlotsCollection"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxChartPlotsCollection reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
