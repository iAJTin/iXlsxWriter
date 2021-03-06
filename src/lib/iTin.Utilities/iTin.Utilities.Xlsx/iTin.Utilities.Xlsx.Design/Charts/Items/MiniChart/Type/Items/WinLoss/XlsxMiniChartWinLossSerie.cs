﻿
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartWinLossSerie : ICombinable<XlsxMiniChartWinLossSerie>, ICloneable
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

        #region ICombinable<XlsxMiniChartWinLossSerie>

        #region public methods

        #region [public] (void) Combine(XlsxMiniChartWinLossSerie): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public void Combine(XlsxMiniChartWinLossSerie reference)
        {
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxMiniChartWinLossChartType) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxMiniChartWinLossChartType Parent { get; private set; }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartWinLossSerie) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartWinLossSerie Clone() => (XlsxMiniChartWinLossSerie)MemberwiseClone();
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxMiniChartWinLossChartType): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxMiniChartWinLossSerie"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxMiniChartWinLossChartType reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
