
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// Represents a negative number format. Contains the definition of negative number in a numeric data type.
    /// </summary>
    public partial class NegativeModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownBasicColor DefaultColor = KnownBasicColor.Black;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownNegativeSign DefaultSign = KnownNegativeSign.Standard;
        #endregion

        #region private field member
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownBasicColor _color;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownNegativeSign _sign;
        #endregion

        #region constructor/s

        #region [public] NegativeModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeModel"/> class.
        /// </summary>
        public NegativeModel()
        {
            Sign = DefaultSign;
            Color = DefaultColor;
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

        #region public static properties

        #region [public] {static} (NegativeModel) Default: Default: Gets a default instance
        /// <summary>
        /// Gets a default instance
        /// </summary>
        /// <value>
        /// Default instance
        /// </value>
        public static NegativeModel Default => new NegativeModel();
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownBasicColor) Color: Gets or sets preferred color for display a negative number
        /// <summary>
        /// Gets or sets preferred color for display a negative number.
        /// </summary>
        /// <value>
        /// Preferred color for display a negative number. The default is <see cref="KnownBasicColor.Black"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("color")]
        [DefaultValue(DefaultColor)]
        public KnownBasicColor Color
        {
            get => _color;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _color = value;
            }
        }
        #endregion

        #region [public] (KnownNegativeSign) Sign: Gets or sets visual format of negative value
        /// <summary>
        /// Gets or sets visual format of negative value. The default is <see cref="KnownNegativeSign.Standard"/>.
        /// </summary>
        /// <value>
        /// Visual format of negative value.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("sign")]
        [DefaultValue(DefaultSign)]
        public KnownNegativeSign Sign
        {
            get => _sign;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _sign = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => Sign.Equals(DefaultSign) && Color.Equals(DefaultColor);
        #endregion

        #endregion

        #region public methods

        #region [public] (NegativeModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public NegativeModel Clone()
        {
            var negativeCloned = (NegativeModel)MemberwiseClone();
            negativeCloned.Properties = Properties.Clone();

            return negativeCloned;
        }
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the color structure preferred for this negative format
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure preferred for this negative format.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns> 
        public Color GetColor()
        {
            var basiccolor = System.Drawing.Color.FromName(Color.ToString()).Name;
            return ColorHelper.GetColorFromString(basiccolor);
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(NegativeOptions): Apply specified options to this font
        /// <summary>
        /// Apply specified options to this font.
        /// </summary>
        public virtual void ApplyOptions(NegativeOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Color
            KnownBasicColor? colorOption = options.Color;
            bool colorHasValue = colorOption.HasValue;
            if (colorHasValue)
            {
                Color = colorOption.Value;
            }
            #endregion

            #region Sign
            KnownNegativeSign? signOption = options.Sign;
            bool signHasValue = signOption.HasValue;
            if (signHasValue)
            {
                Sign = signOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(NegativeModel): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        public virtual void Combine(NegativeModel reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Color.Equals(DefaultColor))
            {
                Color = reference.Color;
            }

            if (Sign.Equals(DefaultSign))
            {
                Sign = reference.Sign;
            }
        }
        #endregion

        #endregion
    }
}
