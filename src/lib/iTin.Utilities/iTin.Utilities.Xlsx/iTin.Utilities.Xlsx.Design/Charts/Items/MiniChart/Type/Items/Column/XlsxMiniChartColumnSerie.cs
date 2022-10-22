
using System;
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartColumnSerie : ICombinable<XlsxMiniChartColumnSerie>, ICloneable
    {
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

        #region ICombinable<XlsxMiniChartColumnSerie>

        #region public methods

        #region [public] (void) Combine(XlsxMiniChartColumnSerie): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public void Combine(XlsxMiniChartColumnSerie reference)
        {
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxMiniChartColumnChartType) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxMiniChartColumnChartType Parent { get; private set; }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartColumnSerie) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartColumnSerie Clone() => (XlsxMiniChartColumnSerie) MemberwiseClone();
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxMiniChartColumnChartType): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxMiniChartColumnSerie"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxMiniChartColumnChartType reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
