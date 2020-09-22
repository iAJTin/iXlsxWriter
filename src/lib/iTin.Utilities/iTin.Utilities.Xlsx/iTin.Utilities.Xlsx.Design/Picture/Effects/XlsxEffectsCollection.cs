
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;

    using iTin.Core.Helpers;

    /// <summary>
    /// Defines picture effects collection settings.
    /// </summary>
    public partial class XlsxEffectsCollection : ICloneable
    {
        #region constructor/s

        #region [public] XlsxEffectsCollection(): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxEffectsCollection"/> class.
        /// </summary>
        public XlsxEffectsCollection() : base(null)
        {
        }
        #endregion

        #region [public] XlsxEffectsCollection(XlsxPicture): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxEffectsCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public XlsxEffectsCollection(XlsxPicture parent) : base(parent)
        {
        }
        #endregion

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
        
        #endregion

        #region protected override methods

        #region [protected] {override} (void) SetOwner(XlsxBaseEffect): Sets this collection as the owner of the specified item
        /// <inheritdoc/>
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxBaseEffect item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxSheetsSettingsCollection) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxEffectsCollection Clone()
        {
            var cloned = new XlsxEffectsCollection()
            {
                Properties = Properties.Clone()
            };

            foreach (XlsxBaseEffect sheet in this)
            {
                cloned.Add(sheet.Clone());
            }

            return cloned;
        }
        #endregion

        #endregion
    }
}
