
namespace iTin.Charting.Models.Design
{
    using System;

    using iTin.Core.Helpers;

    /// <summary>
    /// Represents a data series of a plot.
    /// </summary>
    public partial class SeriesModel : ICloneable
    {
        #region constructor/s

        #region [public] SeriesModel(PlotAreaModel): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.SeriesModel" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public SeriesModel(PlotAreaModel parent) : base(parent)
        {
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

        #region protected override methods

        #region [protected] {override} (SerieModel) GetBy(string): Returns the element specified
        /// <inheritdoc />
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:iTin.Charting.Models.ComponentModel.BaseSimpleModelCollection`2" />.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override SerieModel GetBy(string value) => Find(serie => serie.Name.Equals(value, StringComparison.Ordinal));
        #endregion

        #region [protected] {override} (void) SetOwner(SerieModel): Sets this collection as the owner of the specified item
        /// <inheritdoc />
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(SerieModel item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (SeriesModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public SeriesModel Clone() => CopierHelper.DeepCopy(this);
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
