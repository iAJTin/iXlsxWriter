
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Charting.Models.Design
{
    /// <summary>
    /// Represents the visual setting of chart quality.
    /// </summary>
    public sealed partial class CustomQualityModel : ICloneable
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownChartGraphicsQuality DefaultQualityGraphics = KnownChartGraphicsQuality.UseAntiAliasing;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownChartTextAntiAliasingQuality DefaultQualityText = KnownChartTextAntiAliasingQuality.High;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.CustomQualityModel" /> class.
        /// </summary>
        public CustomQualityModel()
        {
            Text = DefaultQualityText;
            Graphics = DefaultQualityGraphics;
        }

        #endregion

        #region interfaces

        #region ICloneable

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

        #region public static readonly members

        /// <summary>
        /// Returns default custom quality, antialising <b>Text</b> property as <b>KnownChartTextAntiAliasingQuality.High</b> and <b>Graphics</b> property as <b>KnownChartGraphicsQuality.UseAntiAliasing</b>.
        /// </summary>
        public static readonly CustomQualityModel DefaultCustomQuality = new();

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value that represents the preferred graphic chart quality. The default value is <b>KnownChartGraphicsQuality.UseAntiAliasing</b>.
        /// </summary>
        /// <value>
        /// Preferred custom graphic chart quality.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultQualityGraphics)]
        public KnownChartGraphicsQuality Graphics { get; set; }

        /// <summary>
        /// Gets or sets a value that represents the preferred text chart quality. The default value is <b>KnownChartTextAntiAliasingQuality.High</b>.
        /// </summary>
        /// <value>
        /// Preferred chart custom width.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultQualityText)]
        public KnownChartTextAntiAliasingQuality Text { get; set; }

        #endregion

        #region public override properties

        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => Graphics.Equals(DefaultQualityGraphics) && Text.Equals(DefaultQualityText);

        #endregion

        #region public methods

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public CustomQualityModel Clone() => (CustomQualityModel)MemberwiseClone();

        #endregion

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";

        #endregion
    }
}
