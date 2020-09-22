
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using iTin.Core.Helpers;

    using iTin.Core.Models.Collections;
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// Defines a styles collection.
    /// </summary>
    public partial class XlsxStylesCollection : IXlsxStyles
    {
        #region constructor/s

        #region [public] XlsxStylesCollection(): Initializes a new instance of the class
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxStylesCollection"/> class.
        /// </summary>
        public XlsxStylesCollection() : base(null)
        {
        }
        #endregion

        #region [public] XlsxStylesCollection(object): Initializes a new instance of the class
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxStylesCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public XlsxStylesCollection(object parent) : base(parent)
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

        #region IStyles

        #region explicit

        #region (IStyle) IStyles.GetBy(string): Returns specified style by name
        /// <summary>
        /// Returns specified style by name.
        /// </summary>
        /// <param name="value">Style name to get</param>
        /// <returns>
        /// A <see cref="IStyle"/> reference.
        /// </returns>
        IStyle IStyles.GetBy(string value) => GetBy(value);
        #endregion

        #endregion

        #endregion

        #region IXlsxStyles

        #region explicit

        #region (IXlsxStyle) IXlsxStyles.GetBy(string): Returns specified style by name
        /// <summary>
        /// Returns specified style by name.
        /// </summary>
        /// <param name="value">Style name to get</param>
        /// <returns>
        /// A <see cref="IStyle"/> reference.
        /// </returns>
        IXlsxStyle IXlsxStyles.GetBy(string value) => GetBy(value);
        #endregion

        #endregion

        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (XlsxBaseStyle) GetBy(string): Returns the element specified
        /// <inheritdoc />
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override XlsxBaseStyle GetBy(string value) 
        {
            if (string.IsNullOrEmpty(value))
            {
                return XlsxBaseStyle.Default;
            }

            var style = Find(s => s.Name.Equals(value));

            return style ?? XlsxBaseStyle.Default;
        }
        #endregion

        #region [protected] {override} (void) SetOwner(BaseStyle): Sets this collection as the owner of the specified item
        /// <inheritdoc />
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxBaseStyle item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxStylesCollection) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxStylesCollection Clone() => CopierHelper.DeepCopy(this);
        #endregion

        #endregion
    }
}
