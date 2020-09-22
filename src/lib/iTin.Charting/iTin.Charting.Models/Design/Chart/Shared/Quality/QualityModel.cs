
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Helpers;

    using Options;

    /// <summary>
    /// Represents the chart quality settings of chart.
    /// </summary>
    public sealed partial class QualityModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownChartSmoothingStyle DefaultSmoothingStyle = KnownChartSmoothingStyle.High;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CustomQualityModel _customQuality;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownChartSmoothingStyle _smoothingStyle;
        #endregion

        #region constructor/s

        #region [public] QualityModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.QualityModel" /> class.
        /// </summary>
        public QualityModel()
        {
            SmoothingStyle = DefaultSmoothingStyle;
            CustomQuality = CustomQualityModel.DefaultCustomQuality;
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

        #region public readonly properties

        #region [public] (bool) CustomQualitySpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool CustomQualitySpecified => !CustomQuality.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (CustomQualityModel) CustomQuality: Gets or sets a reference that contains the custom chart quality defined by user
        /// <summary>
        /// Gets or sets a reference that contains the custom chart quality defined by user.
        /// </summary>
        /// <value>
        /// Preferred chart custom size.
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        public CustomQualityModel CustomQuality
        {
            get => _customQuality ?? (_customQuality = new CustomQualityModel());
            set => _customQuality = value;
        }

        #endregion

        #region [public] (KnownChartSmoothingStyle) SmoothingStyle: Gets or sets the chart smoothing style, includes graphic and text smoothing
        /// <summary>
        /// Gets or sets the chart smoothing style, includes graphic and text smoothing. The default is <b>(KnownChartSmoothingStyle.High)</b>".
        /// </summary>
        /// <value>
        /// One of the values of the enumeration <see cref="KnownChartSmoothingStyle" /> that defines chart smoothing style.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultSmoothingStyle)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownChartSmoothingStyle SmoothingStyle
        {
            get => _smoothingStyle;
            set
            {
                SentinelHelper.IsEnumValid(value);

                if (value == _smoothingStyle)
                {
                    return;
                }

                _smoothingStyle = value;

                if (value == KnownChartSmoothingStyle.Custom)
                {
                    CustomQuality = CustomQualityModel.DefaultCustomQuality;
                }
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
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault => CustomQuality.IsDefault && SmoothingStyle.Equals(DefaultSmoothingStyle);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(QualityOptions): Apply specified options to this font
        /// <summary>
        /// Apply specified options to this quality.
        /// </summary>
        public void ApplyOptions(QualityOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region SmoothingStyle
            KnownChartSmoothingStyle? smoothingStyleOption = options.SmoothingStyle;
            bool qualityHasValue = smoothingStyleOption.HasValue;
            if (qualityHasValue)
            {
                SmoothingStyle = smoothingStyleOption.Value;
            }
            #endregion

            #region CustomQuality
            CustomQualityModel customQualityOption = options.CustomQuality;
            bool customQualityOptionHasValue = customQualityOption != null;
            if (customQualityOptionHasValue)
            {
                CustomQuality = customQualityOption;
            }
            #endregion
        }
        #endregion

        #region [public] (QualityModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public QualityModel Clone() => (QualityModel)MemberwiseClone();
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current instance
        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion
    }
}
