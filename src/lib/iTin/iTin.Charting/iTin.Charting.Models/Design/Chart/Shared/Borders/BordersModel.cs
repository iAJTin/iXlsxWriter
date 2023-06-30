
namespace iTin.Core.Models.Design
{
    using System;

    using iTin.Core.Helpers;

    using Enums;

    /// <summary>
    /// Defines a borders collection
    /// </summary>
    public partial class BordersModel : ICloneable
    {
        #region constructor/s

        #region [public] BordersModel(): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="BordersModel" /> class.
        /// </summary>
        public BordersModel() : base(null)
        {
        }
        #endregion

        #region [public] BordersModel(object): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="BordersModel" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public BordersModel(object parent) : base(parent)
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

        #region public static methods

        #region [public] {static} (BordersModel) FromCustomColor(string, int = 1): Gets a default borders
        /// <summary>
        /// Gets a default borders.
        /// </summary>
        /// <value>
        /// A default borders.
        /// </value>
        public static BordersModel FromCustomColor(string borderColor, int width = 1) => CreeateCustomColor(borderColor, width);
        #endregion

        #region [public] {static} (BordersModel) FromKnownColor(KnownBorderColor, int = 1): Gets a default borders
        /// <summary>
        /// Gets a default borders.
        /// </summary>
        /// <value>
        /// A default borders.
        /// </value>
        public static BordersModel FromKnownColor(KnownBorderColor borderColor, int width = 1) => CreeateKnownBorder(borderColor, width);
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (BorderModel) GetBy(KnownBorderPosition): Returns the element specified
        /// <inheritdoc />
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="T:iTin.Charting.Models.ComponentModel.BaseSimpleModelCollection`2" />.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override BorderModel GetBy(KnownBorderPosition value) => Find(border => border.Position == value);
        #endregion

        #region [protected] {override} (void) SetOwner(BorderModel): Sets this collection as the owner of the specified item
        /// <inheritdoc />
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(BorderModel item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (BordersModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public BordersModel Clone()
        {
            var bordersCloned = new BordersModel(Parent);
            foreach (BorderModel border in this)
            {
                bordersCloned.Add(border.Clone());
            }

            return bordersCloned;

        }
        #endregion

        #endregion

        #region private static methods

        private static BordersModel CreeateCustomColor(string borderColor, int width = 1)
            => new BordersModel
            {
                new BorderModel {Color = borderColor, Position = KnownBorderPosition.Left, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor, Position = KnownBorderPosition.Top, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor, Position = KnownBorderPosition.Right, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor, Position = KnownBorderPosition.Bottom, Width = width, Show = YesNo.Yes}
            };

        private static BordersModel CreeateKnownBorder(KnownBorderColor borderColor, int width = 1)
            => new BordersModel
            {
                new BorderModel {Color = borderColor.ToString(), Position = KnownBorderPosition.Left, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor.ToString(), Position = KnownBorderPosition.Top, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor.ToString(), Position = KnownBorderPosition.Right, Width = width, Show = YesNo.Yes},
                new BorderModel {Color = borderColor.ToString(), Position = KnownBorderPosition.Bottom, Width = width, Show = YesNo.Yes}
            };

        #endregion
    }
}
