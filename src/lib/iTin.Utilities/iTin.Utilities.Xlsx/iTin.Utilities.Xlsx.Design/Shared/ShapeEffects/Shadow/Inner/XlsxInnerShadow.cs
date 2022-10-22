
using System;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
    /// Represents a inner shadow.
    /// </summary>
    public partial class XlsxInnerShadow : ICombinable<XlsxInnerShadow>, ICloneable
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

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxInnerShadow>.Combine(XlsxInnerShadow): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxInnerShadow>.Combine(XlsxInnerShadow reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxInnerShadow) None: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow None => new XlsxInnerShadow();
        #endregion

        #region [public] {static} (XlsxInnerShadow) TopLeft: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow TopLeft => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 225, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) Top: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow Top => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 270, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) TopRight: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow TopRight => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 315, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) Left: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow Left => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 180, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) Center: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow Center => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 0, Blur = 9, Offset = 0, Transparency = 0};
        #endregion

        #region [public] {static} (XlsxInnerShadow) Right: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow Right => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 0, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) DownLeft: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow DownLeft => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 135, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) Down: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow Down => new XlsxInnerShadow {Show = YesNo.Yes, Angle = 90, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #region [public] {static} (XlsxInnerShadow) DownRight: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxInnerShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxInnerShadow DownRight => new XlsxInnerShadow {Show = YesNo.Yes, Blur = 5, Offset = 4, Transparency = 50};
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxInnerShadow) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxInnerShadow Clone()
        {
            var cloned = (XlsxInnerShadow)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxInnerShadowOptions): Apply specified options to this instance
        /// <summary>
        /// Apply specified options to this instance.
        /// </summary>
        public virtual void ApplyOptions(XlsxInnerShadowOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            base.ApplyOptions(options);
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxInnerShadow): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(XlsxInnerShadow reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);
        }
        #endregion

        #endregion
    }
}
