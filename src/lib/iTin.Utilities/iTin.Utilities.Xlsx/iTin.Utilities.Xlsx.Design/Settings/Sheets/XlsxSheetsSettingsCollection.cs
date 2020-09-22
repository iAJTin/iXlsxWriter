
namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    using System;
    using System.Linq;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Collections;

    /// <summary>
    /// Defines sheets collection settings. Allows to set the document metadata, margins, header, footer, default view, size and orientation.
    /// </summary>
    public partial class XlsxSheetsSettingsCollection : ICloneable
    {
        #region constructor/s

        #region [public] XlsxSheetsSettingsCollection(): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxSheetsSettingsCollection"/> class.
        /// </summary>
        public XlsxSheetsSettingsCollection() : base(null)
        {
        }
        #endregion

        #region [public] XlsxSheetsSettingsCollection(XlsxSettings): Initializes a new instance of the class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxSheetsSettingsCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public XlsxSheetsSettingsCollection(XlsxSettings parent) : base(parent)
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

        #region [protected] {override} (BaseBorder) GetBy(string): Returns the element specified
        /// <inheritdoc />
        /// <summary>
        /// Returns the element specified.
        /// </summary>
        /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
        /// <returns>
        /// Returns the specified element.
        /// </returns>
        public override XlsxSheetSettings GetBy(string value) => Find(sheet => sheet.SheetName.Equals(value, StringComparison.OrdinalIgnoreCase));
        #endregion

        #region [protected] {override} (void) SetOwner(XlsxSheetSettings): Sets this collection as the owner of the specified item
        /// <inheritdoc/>
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxSheetSettings item)
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
        public XlsxSheetsSettingsCollection Clone()
        {
            var cloned = new XlsxSheetsSettingsCollection(Parent)
            {
                Properties = Properties.Clone()
            };

            foreach (XlsxSheetSettings sheet in this)
            {
                cloned.Add(sheet.Clone());
            }

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxSheetsSettingsCollection): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxSheetsSettingsCollection reference)
        {
            if (reference == null)
            {
                return;
            }

            var hasElements = this.Any();
            if (!hasElements)
            {
                foreach (var referenceSheet in reference)
                {
                    var sheet = referenceSheet.Clone();
                    sheet.SetOwner(this);
                    Add(sheet);
                }
            }
            else
            {
                foreach (var sheet in this)
                {
                    var refSheet = reference.GetBy(sheet.SheetName);
                    if (refSheet != null)
                    {
                        sheet.Combine(refSheet);
                    }
                }

                foreach (var referenceSheet in reference)
                {
                    var sheet = GetBy(referenceSheet.SheetName);
                    if (sheet != null)
                    {
                        continue;
                    }

                    var newSheet = referenceSheet.Clone();
                    newSheet.SetOwner(this);
                    Add(newSheet);
                }
            }
        }
        #endregion

        #endregion
    }
}
