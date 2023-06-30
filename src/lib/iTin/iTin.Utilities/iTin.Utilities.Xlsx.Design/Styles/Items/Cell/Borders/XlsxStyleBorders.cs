
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Linq;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// Defines the <b>xlsx</b> header or footer sections.
    /// </summary>
    public partial class XlsxStyleBorders : IBorders
    {
        #region constructor/s

        #region [public] XlsxStyleBorders(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxStyleBorders"/> class.
        /// </summary>
        public XlsxStyleBorders() : base(null)
        {
        }
        #endregion

        #region [public] XlsxStyleBorders(XlsxBaseStyle): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxStyleBorders"/> class.
        /// </summary>
        public XlsxStyleBorders(XlsxBaseStyle parent) : base(parent)
        {
        }
        #endregion

        #endregion

        #region interfaces

        #region IBorders

        #region (void) ICombinable<IBorders>.Combine(IBorders): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        void ICombinable<IBorders>.Combine(IBorders reference) => Combine((XlsxStyleBorders) reference);
        #endregion

        #endregion

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Create a new object that is a copy of the current instance
        /// <inheritdoc/>
        /// <summary>
        /// Create a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="object"/> that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (void) SetOwner(XlsxStyleBorder): Sets this collection as the owner of the specified item
        /// <summary>
        /// Sets this collection as the owner of the specified item.
        /// </summary>
        /// <param name="item">Target item to set owner.</param>
        protected override void SetOwner(XlsxStyleBorder item)
        {
            SentinelHelper.ArgumentNull(item, nameof(item));

            item.SetOwner(this);
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxStyleBorders) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxStyleBorders Clone()
        {
            var cloned = new XlsxStyleBorders(Parent)
            {
                Properties = Properties.Clone()
            };

            foreach (XlsxStyleBorder border in this)
            {
                cloned.Add(border.Clone());
            }

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxStyleBorders): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxStyleBorders reference)
        {
            if (reference == null)
            {
                return;
            }

            var hasElements = this.Any();
            if (!hasElements)
            {
                foreach (var referenceSection in reference)
                {
                    var sheet = referenceSection.Clone();
                    sheet.SetOwner(this);
                    Add(sheet);
                }
            }
            else
            {
                int i = 0;
                foreach (var border in this)
                {
                    var refBorder = reference[i];
                    if (refBorder != null)
                    {
                        border.Combine(refBorder);
                    }

                    i++;
                }
            }
        }
        #endregion

        #endregion
    }
}
