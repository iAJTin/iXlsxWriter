
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Represents a chart plot area.
    /// </summary>
    public partial class PlotAreaModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultUseSecondaryAxis = YesNo.No;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SeriesModel _series;
        #endregion

        #region constructor/s

        #region [public] PlotAreaModel(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" /> class.
        /// </summary>
        public PlotAreaModel()
        {
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

        #region [public] (PlotAreasModel) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" />.
        /// </summary>
        /// <value>
        /// The <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreasModel" /> that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" />.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        public PlotAreasModel Owner { get; private set; }
        #endregion

        #region [public] (bool) SeriesSpecified: Gets a value that indicates whether the collection of series has elements. This property is used by the serializer to not serialize an empty collection
        /// <summary>
        /// Gets a value that indicates whether the collection of series has elements. This property is used by the serializer to not serialize an empty collection.
        /// </summary>
        /// <value>
        /// <b>true</b> if there are series in the collection; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool SeriesSpecified => _series != null && _series.Count > 0;
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Name: Gets or sets plot's name of plot area
        /// <summary>
        /// Gets or sets plot's name of plot area.
        /// </summary>
        /// <value>
        /// Plot's name of plot.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Name { get; set; }
        #endregion

        #region [public] (SeriesModel) Series: Collection of data series for a plot area
        /// <summary>
        /// Gets or sets collection of series for a plot area.
        /// </summary>
        /// <value>
        /// Collection of data series for a plot. Each element represents a data serie of a plot area.
        /// </value>
        [XmlArrayItem("Serie", typeof(SerieModel))]
        public SeriesModel Series
        {
            get => _series ?? (_series = new SeriesModel(this));
            set => _series = value;
        }
        #endregion

        #region [public] (YesNo) UseSecondaryAxis: Gets or sets a value that determines whether the plot area uses secondary axis
        /// <summary>
        /// Gets or sets a value that determines whether the plot area uses secondary axis.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes" /> if plot area uses secondary axis; otherwise, <see cref="YesNo.No" />.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultUseSecondaryAxis)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo UseSecondaryAxis { get; set; }
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
        public override bool IsDefault => Series.Count.Equals(0) && UseSecondaryAxis.Equals(DefaultUseSecondaryAxis);
        #endregion

        #endregion

        #region public methods

        #region [public] (PlotAreaModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public PlotAreaModel Clone() => CopierHelper.DeepCopy(this);
        #endregion

        #region [public] (void) SetOwner(PlotAreasModel): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreasModel" />.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        public void SetOwner(PlotAreasModel reference)
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
