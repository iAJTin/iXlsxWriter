
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;

    using iTin.Core.Models.Design;

    /// <summary>
    /// Defines a generic minichart data point.
    /// </summary>
    public partial class XlsxMiniChartFirstPoint : ICombinable<XlsxMiniChartFirstPoint>, ICloneable
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

        #region [public] {new} (XlsxMiniChartFirstPoint) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChartFirstPoint Clone() => (XlsxMiniChartFirstPoint)MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxMiniChartFirstPoint): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxMiniChartFirstPoint reference)
        {
            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
