
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br/>
    /// Displays data field as datetime format. You can specify the output culture.
    /// </summary>
    public partial class DateTimeDataType : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownCulture DefaultLocale = KnownCulture.Current;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownDateTimeFormat DefaultFormat = KnownDateTimeFormat.ShortDatePattern;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownCulture _locale;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTimeError _error;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownDateTimeFormat _format;
        #endregion

        #region constructor/s

        #region [public] DateTimeDataType(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeDataType"/> class.
        /// </summary>
        public DateTimeDataType()
        {
            Locale = DefaultLocale;
            Format = DefaultFormat;
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

        #region public readonly properties

        #region [public] (bool) ErrorSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ErrorSpecified => !Error.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (DateTimeError) Error: Gets or sets a reference that contains datetime data type error settings
        /// <summary>
        /// Gets or sets a reference that contains datetime data type error settings.
        /// </summary>
        /// <value>
        /// Datetime data type error settings
        /// </value>
        [XmlElement]
        [JsonProperty("error")]
        public DateTimeError Error
        {
            get => _error ?? (_error = new DateTimeError());
            set => _error = value;
        }
        #endregion

        #region [public] (KnownDateTimeFormat) Format: Gets or sets preferred output date time format
        /// <summary>
        /// Gets or sets preferred output date time format. The default is <see cref="KnownDateTimeFormat.ShortDatePattern"/>.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownDateTimeFormat"/> values.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("format")]
        [DefaultValue(DefaultFormat)]
        public KnownDateTimeFormat Format
        {
            get => _format;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _format = value;
            }
        }
        #endregion

        #region [public] (KnownCulture) Locale: Gets or sets preferred culture
        /// <summary>
        /// Gets or sets preferred culture. The default is <see cref="KnownCulture.Current"/>.
        /// </summary>
        /// <value>
        /// Preferred culture.
        /// </value>
        [XmlAttribute]
        [JsonProperty("locale")]
        [DefaultValue(DefaultLocale)]
        public KnownCulture Locale
        {
            get => _locale;
            set
            {
                var isValidLocale = true;
                if (!value.Equals(KnownCulture.Current))
                {
                    var isValidCulture = IsValidCulture(value);
                    if (!isValidCulture)
                    {
                        isValidLocale = false;
                    }
                }

                _locale = isValidLocale
                    ? value
                    : DefaultLocale;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Error.IsDefault &&
            Format.Equals(DefaultFormat) &&
            Locale.Equals(DefaultLocale);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (DateTimeDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public new DateTimeDataType Clone()
        {
            var datetimeCloned = (DateTimeDataType)MemberwiseClone();
            datetimeCloned.Error = Error.Clone();
            datetimeCloned.Properties = Properties.Clone();

            return datetimeCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(DateTimeDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(DateTimeDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Locale.Equals(DefaultLocale))
            {
                Locale = reference.Locale;
            }

            if (Format.Equals(DefaultFormat))
            {
                Format = reference.Format;
            }

            Error.Combine(reference.Error);
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (bool) IsValidCulture: Gets a value indicating whether specified culture is installed on this system
        /// <summary>
        /// Gets a value indicating whether specified culture is installed on this system.
        /// </summary>
        /// <param name="culture">Culture to check.</param>
        /// <returns>
        /// <b>true</b> if the specified culture is installed on the system; otherwise, <b>false</b>.
        /// </returns>
        private static bool IsValidCulture(KnownCulture culture)
        {
            var iw32C = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures);
            return iw32C.Any(clt => clt.Name == culture.GetDescription());
        }
        #endregion

        #endregion 
    }
}
