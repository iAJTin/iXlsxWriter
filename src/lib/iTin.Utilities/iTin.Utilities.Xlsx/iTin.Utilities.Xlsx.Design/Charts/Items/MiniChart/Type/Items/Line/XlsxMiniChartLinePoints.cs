
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartLinePoints : ICombinable<XlsxMiniChartLinePoints>
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartMarkersPoint _markers;
        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxMiniChartLinePoints>.Combine(XlsxMiniChartLinePoints): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChartLinePoints>.Combine(XlsxMiniChartLinePoints reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) MarkersSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool MarkersSpecified => !Markers.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxMiniChartMarkersPoint) Markers: 
        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// </value>
        [XmlElement]
        [JsonProperty("markers")]
        public XlsxMiniChartMarkersPoint Markers
        {
            get => _markers ?? (_markers = new XlsxMiniChartMarkersPoint());
            set => _markers = value;
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Markers.IsDefault;
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartLinePoints) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartLinePoints Clone()
        {
            var cloned = (XlsxMiniChartLinePoints)MemberwiseClone();
            cloned.Markers = Markers.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartLinePointsOptions): Apply specified options to this minichart
        ///// <summary>
        ///// Apply specified options to this minichart.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartLinePointsOptions options)
        //{
        //    base.ApplyOptions(options);
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartLinePoints): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxMiniChartLinePoints reference)
        {
            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
