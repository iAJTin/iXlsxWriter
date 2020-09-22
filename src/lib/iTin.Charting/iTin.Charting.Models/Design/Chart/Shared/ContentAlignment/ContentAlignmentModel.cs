
namespace iTin.Core.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Helpers;

    using Enums;
    using Options;

    /// <summary>
    /// Defines content alignment.
    /// </summary>
    public partial class ContentAlignmentModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownVerticalAlignment DefaultVerticalAlignment = KnownVerticalAlignment.Top;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownHorizontalAlignment DefaultHorizontalAlignment = KnownHorizontalAlignment.Center;
        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownVerticalAlignment _vertical;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownHorizontalAlignment _horizontal;

        #endregion

        #region constructor/s

        #region [public] ContentAlignmentModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentAlignmentModel"/> class.
        /// </summary>
        public ContentAlignmentModel()
        {
            Vertical = DefaultVerticalAlignment;
            Horizontal = DefaultHorizontalAlignment;
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

        #region public static properties

        #region [public] {static} (ContentAlignmentModel) Default: Gets default alignament
        /// <summary>
        /// Gets default alignament.
        /// </summary>
        /// <value>
        /// Default alignament
        /// </value>
        public static ContentAlignmentModel Default => new ContentAlignmentModel();

        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHorizontalAlignment) Horizontal: Gets or sets horizontal alignment.
        /// <summary>
        /// Gets or sets horizontal alignment. The default is <b>(<see cref="KnownHorizontalAlignment.Center"/>)</b>.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownHorizontalAlignment"/> values.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultHorizontalAlignment)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownHorizontalAlignment Horizontal
        {
            get => _horizontal;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _horizontal = value;
            }
        }
        #endregion

        #region [public] (KnownVerticalAlignment) Vertical: Gets or sets vertical alignment.
        /// <summary>
        /// Gets or sets vertical alignment. The default is <b>(<see cref="KnownVerticalAlignment.Top"/>)</b>.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownVerticalAlignment"/> values.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultVerticalAlignment)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownVerticalAlignment Vertical
        {
            get => _vertical;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _vertical = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => Vertical.Equals(DefaultVerticalAlignment) && Horizontal.Equals(DefaultHorizontalAlignment);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(ContentAlignmentOptions): Apply specified options to this font
        /// <summary>
        /// Apply specified options to this font.
        /// </summary>
        public void ApplyOptions(ContentAlignmentOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Horizontal
            KnownHorizontalAlignment? horizontalOption = options.Horizontal;
            bool horizontalHasValue = horizontalOption.HasValue;
            if (horizontalHasValue)
            {
                Horizontal = horizontalOption.Value;
            }
            #endregion

            #region Vertical
            KnownVerticalAlignment? verticalOption = options.Vertical;
            bool verticalHasValue = verticalOption.HasValue;
            if (verticalHasValue)
            {
                Vertical = verticalOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] (ContentAlignmentModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public ContentAlignmentModel Clone() => (ContentAlignmentModel)MemberwiseClone();
        #endregion

        #endregion
    }
}
