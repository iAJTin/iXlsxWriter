
using System;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines a generic minichart data point.
    /// </summary>
    public partial class XlsxMiniChartMarkersPoint : ICombinable<XlsxMiniChartMarkersPoint>, ICloneable
    {
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

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartMarkersPoint) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartMarkersPoint Clone() => (XlsxMiniChartMarkersPoint)MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxMiniChartMarkersPoint): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxMiniChartMarkersPoint reference)
        {
            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
