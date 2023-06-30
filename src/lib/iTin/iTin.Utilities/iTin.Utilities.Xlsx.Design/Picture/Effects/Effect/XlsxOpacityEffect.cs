
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Drawing.Helpers;
using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Picture
{
    /// <summary>
    /// A Specialization of <see cref="XlsxBaseEffect"/> class.<br/>
    /// Represents represents opacity effect.
    /// </summary>
    public partial class XlsxOpacityEffect
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultPercent = 100.0f;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private float _percent;
        #endregion

        #region constructor/s

        #region [public] XlsxOpacityEffect(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxOpacityEffect"/> class.
        /// </summary>
        public XlsxOpacityEffect()
        {
            Value = DefaultPercent;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (int) Value: Gets or sets the preferred opacitiy value
        /// <summary>
        /// Gets or sets the preferred opacitiy value, expresed in %. The default value is <b>100.0</b>.
        /// </summary>
        /// <value>
        /// Preferred opacitiy value
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
        [XmlAttribute]
        [JsonProperty("value")]
        [DefaultValue(DefaultPercent)]
        public float Value
        {
            get => _percent;
            set
            {
                SentinelHelper.ArgumentOutOfRange("Value", value, 0.0f, 100.0f, "The value must be between 0 and 100");

                _percent = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Value.Equals(DefaultPercent);
        #endregion

        #endregion

        #region public override methods

        #region [public] {overide} (ImageAttributes) Apply(): Returns the manipulation of the colors in an image to an effect
        /// <summary>
        /// Returns the manipulation of the colors in an image to an effect.
        /// </summary>
        /// <returns>
        /// A <see cref="ImageAttributes"/> object that contains the information about how bitmap colors are manipulated. 
        /// </returns>
        public override ImageAttributes Apply() => ImageHelper.GetImageAttributesFromOpacityValueEffect(_percent);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxOpacityEffect) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxOpacityEffect Clone()
        {
            var cloned = (XlsxOpacityEffect)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
