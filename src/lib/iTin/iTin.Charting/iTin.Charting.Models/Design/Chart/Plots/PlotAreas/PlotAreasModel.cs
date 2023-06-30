
namespace iTin.Charting.Models.Design
{
    using System;

    using iTin.Core.Helpers;

    /// <summary>
    /// Represents a chart plot areas.
    /// </summary>
    public partial class PlotAreasModel : ICloneable
    {
        #region constructor/s

        #region [public] PlotAreasModel(PlotsModel): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreasModel" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public PlotAreasModel(PlotsModel parent) : base(parent)
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

        #region [protected] {override} (PlotAreaModel) GetBy(string): Returns the element specified
        /// <inheritdoc />
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:iTin.Charting.Models.ComponentModel.BaseSimpleModelCollection`2" />.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override PlotAreaModel GetBy(string value) => Find(area => area.Name.Equals(value, StringComparison.Ordinal));
        #endregion

        #region [protected] {override} (void) SetOwner(PlotAreaModel): Sets this collection as the owner of the specified item
        /// <inheritdoc />
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(PlotAreaModel item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (ChartModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public PlotAreasModel Clone() => CopierHelper.DeepCopy(this);
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
