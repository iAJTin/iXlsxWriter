
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="NumericDataType"/> class.<br/>
    /// Represents currency format, the currency symbol appears right next to the first digit.
    /// You can specify the number of decimal places that you want to use and how you want to display negative numbers.
    /// </summary>
    public partial class CurrencyDataType : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownCulture LocaleDefault = KnownCulture.Current;
        #endregion

        #region private fields members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownCulture _locale;
        #endregion

        #region constructor/s

        #region [public] CurrencyDataType(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyDataType"/> class.
        /// </summary>
        public CurrencyDataType()
        {
            _locale = LocaleDefault;
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

        #region public properties

        #region [public] (KnownCulture) Locale: Gets or sets preferred culture
        /// <summary>
        /// Gets or sets preferred culture. The default is <see cref="KnownCulture.Current"/>.
        /// </summary>
        /// <value>
        /// Preferred culture.
        /// </value>
        [XmlAttribute]
        [JsonProperty("locale")]
        [DefaultValue(LocaleDefault)]
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
                    : LocaleDefault;
            }
        }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Locale.Equals(LocaleDefault);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (CurrencyDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new CurrencyDataType Clone()
        {
            var currencyDataTypeCloned = (CurrencyDataType)MemberwiseClone();
            currencyDataTypeCloned.Error = Error.Clone();
            currencyDataTypeCloned.Negative = Negative.Clone();
            currencyDataTypeCloned.Properties = Properties.Clone();

            return currencyDataTypeCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(CurrencyDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(CurrencyDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Locale.Equals(LocaleDefault))
            {
                Locale = reference.Locale;
            }

            base.Combine(reference);
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (bool) IsValidCulture: Gets a value indicating whether the specified culture is installed on this system
        /// <summary>
        /// Gets a value indicating whether the font is installed on this system.
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
