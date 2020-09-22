
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
    public partial class XlsxMiniChartLineSerie : ICombinable<XlsxMiniChartLineSerie>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultWidth = "0.75";
        #endregion

        #region constructor/s

        #region [public] XlsxMiniChartLineSerie(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartLineSerie"/> class.
        /// </summary>
        public XlsxMiniChartLineSerie()
        {
            Width = DefaultWidth;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

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

        #region ICombinable<XlsxMiniChartLineSerie>

        #region public methods

        #region [public] (void) Combine(XlsxMiniChartLineSerie): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public void Combine(XlsxMiniChartLineSerie reference)
        {
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxMiniChartLineChartType) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxMiniChartLineChartType Parent { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Width: Gets or sets preferred line width
        /// <summary>
        /// Gets or sets preferred line width. The default is <b>0.75</b>.
        /// </summary>
        /// <value>
        /// Preferred line width.
        /// </value>
        [XmlAttribute]
        [JsonProperty("width")]
        [DefaultValue(DefaultWidth)]
        public string Width { get; set; }
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
        public override bool IsDefault => base.IsDefault && Width.Equals(DefaultWidth);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartLineSerie) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartLineSerie Clone() => (XlsxMiniChartLineSerie)MemberwiseClone();
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxMiniChartLineChartType): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxMiniChartLineSerie"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxMiniChartLineChartType reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
