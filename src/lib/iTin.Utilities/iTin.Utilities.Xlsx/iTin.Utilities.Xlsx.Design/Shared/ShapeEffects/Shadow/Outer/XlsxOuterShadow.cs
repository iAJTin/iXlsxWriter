
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
    /// Represents a outer shadow.
    /// </summary>
    public partial class XlsxOuterShadow : ICombinable<XlsxOuterShadow>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultSize = 100;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _size;
        #endregion

        #region constructor/s

        #region [protected] XlsxOuterShadow(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxOuterShadow"/> class.
        /// </summary>
        public XlsxOuterShadow()
        {
            Size = DefaultSize;
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

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxOuterShadow>.Combine(XlsxOuterShadow): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxOuterShadow>.Combine(XlsxOuterShadow reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxOuterShadow) None: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing a hidden shadow.
        /// </value>
        public static XlsxOuterShadow None => new XlsxOuterShadow();
        #endregion

        #region [public] {static} (XlsxOuterShadow) DownRight: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow DownRight => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 45};
        #endregion

        #region [public] {static} (XlsxOuterShadow) Down: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow Down => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 90};
        #endregion

        #region [public] {static} (XlsxOuterShadow) DownLeft: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow DownLeft => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 135};
        #endregion

        #region [public] {static} (XlsxOuterShadow) Right: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow Right => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 0};
        #endregion

        #region [public] {static} (XlsxOuterShadow) Center: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow Center => new XlsxOuterShadow {Show = YesNo.Yes, Blur = 5, Angle = 0, Offset =  0, Size = 102};
        #endregion

        #region [public] {static} (XlsxOuterShadow) Left: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow Left => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 180};
        #endregion

        #region [public] {static} (XlsxOuterShadow) TopRight: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow TopRight => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 315};
        #endregion

        #region [public] {static} (XlsxOuterShadow) Top: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow Top => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 270};
        #endregion

        #region [public] {static} (XlsxOuterShadow) TopLeft: Returns a new instance containig the shadow
        /// <summary>
        /// Returns a new instance containig the shadow.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
        /// </value>
        public static XlsxOuterShadow TopLeft => new XlsxOuterShadow {Show = YesNo.Yes, Angle = 225};
        #endregion

        #endregion

        #region public properties

        #region [public] (int) Size: Gets or sets the preferred shadow size.
        /// <summary>
        /// Gets or sets the preferred shadow size, expressed in %. The default is <b>100</b>.
        /// </summary>
        /// <value>
        /// Preferred shadow size.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 1 and 200.</exception>
        [XmlAttribute]
        [JsonProperty("size")]
        [DefaultValue(DefaultSize)]
        public int Size
        {
            get => _size;
            set
            {
                SentinelHelper.ArgumentOutOfRange(nameof(Size), value, 1, 200);

                _size = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Size.Equals(DefaultSize);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxOuterShadow) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxOuterShadow Clone()
        {
            var cloned = (XlsxOuterShadow)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxOuterShadowOptions): Apply specified options to this instance
        /// <summary>
        /// Apply specified options to this instance.
        /// </summary>
        public virtual void ApplyOptions(XlsxOuterShadowOptions options)
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

            #region Size
            int? sizeOption = options.Size;
            bool sizeHasValue = sizeOption.HasValue;
            if (sizeHasValue)
            {
                Size = sizeOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxOuterShadow): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(XlsxOuterShadow reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            if (Size.Equals(DefaultSize))
            {
                Size = reference.Size;
            }
        }
        #endregion

        #endregion
    }
}
