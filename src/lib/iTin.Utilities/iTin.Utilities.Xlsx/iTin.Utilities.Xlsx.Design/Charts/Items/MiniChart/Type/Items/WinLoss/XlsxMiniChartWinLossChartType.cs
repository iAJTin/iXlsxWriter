
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartWinLossChartType : ICombinable<XlsxMiniChartWinLossChartType>, ICloneable
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartWinLossSerie _serie;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartWinLossPoints _points;
        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
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

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxMiniChartWinLossChartType>.Combine(XlsxMiniChartWinLossChartType): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChartWinLossChartType>.Combine(XlsxMiniChartWinLossChartType reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxMiniChartChartType) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxMiniChartChartType Parent { get; private set; }
        #endregion

        #region [public] (bool) PointsSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool PointsSpecified => !Points.IsDefault;
        #endregion

        #region [public] (bool) SerieSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool SerieSpecified => !Serie.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxMiniChartWinLossSerie) Serie: Gets or sets a reference that contains definition of the data series to draw
        /// <summary>
        /// Gets or sets a reference that contains definition of the data series to draw.
        /// </summary>
        /// <value>
        /// Definition of the data series to draw.
        /// </value>
        [XmlElement]
        [JsonProperty("serie")]
        public XlsxMiniChartWinLossSerie Serie
        {
            get
            {
                if (_serie == null)
                {
                    _serie = new XlsxMiniChartWinLossSerie();
                }

                _serie.SetParent(this);

                return _serie;
            }
            set => _serie = value;
        }
        #endregion

        #region [public] (XlsxMiniChartWinLossPoints) Points: Gets or sets a reference that contains the definition of the significant points of the drawn series
        /// <summary>
        /// Gets or sets a reference that contains the definition of the significant points of the drawn series.
        /// </summary>
        /// <value>
        /// Definition of the significant points of the drawn series.
        /// </value>
        [XmlElement]
        [JsonProperty("points")]
        public XlsxMiniChartWinLossPoints Points
        {
            get => _points ?? (_points = new XlsxMiniChartWinLossPoints());
            set => _points = value;
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
        public override bool IsDefault => base.IsDefault && Serie.IsDefault && Points.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartWinLossType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartWinLossChartType Clone()
        {
            var cloned = (XlsxMiniChartWinLossChartType)MemberwiseClone();
            cloned.Points = Points.Clone();
            cloned.Serie = Serie.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartWinLossTypeOptions): Apply specified options to this minichart
        ///// <summary>
        ///// Apply specified options to this minichart.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartWinLossTypeOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region Points
        //    Points.ApplyOptions(options.Points);
        //    #endregion

        //    #region Serie
        //    Serie.ApplyOptions(options.Serie);
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartWinLossChartType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxMiniChartWinLossChartType reference)
        {
            if (reference == null)
            {
                return;
            }

            Serie.Combine(reference.Serie);
            Points.Combine(reference.Points);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxMiniChartChartType): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxMiniChartWinLossChartType"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxMiniChartChartType reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
