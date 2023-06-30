
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Helpers;

    using ComponentModel;
    using Options;

    /// <summary>
    /// Represents the visual setting of chart size.
    /// </summary>
    public partial class SizeModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownChartResolution DefaultResolution = KnownChartResolution.SXGA;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CustomSizeModel _customSize;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownChartResolution _resolution;

        #endregion

        #region constructor/s

        #region [public] SizeModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.SizeModel" /> class.
        /// </summary>
        public SizeModel()
        {
            Resolution = DefaultResolution;
            CustomSize = CustomSizeModel.DefaultCustomSize;
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

        #region [public] (bool) CustomSizeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool CustomSizeSpecified => !CustomSize.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (CustomSizeModel) CustomSize: Gets or sets a reference that contains the custom chart size defined by user
        /// <summary>
        /// Gets or sets a reference that contains the custom chart size defined by user.
        /// </summary>
        /// <value>
        /// Preferred chart custom size.
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        public CustomSizeModel CustomSize
        {
            get => _customSize ?? (_customSize = new CustomSizeModel());
            set => _customSize = value;
        }

        #endregion

        #region [public] (KnownChartResolution) Resolution: Gets the chart surface dimensions measured in pixels
        /// <summary>
        /// Gets the chart surface dimensions measured in pixels. The default is <b>(KnownChartResolution.SXGA)</b>".
        /// </summary>
        /// <value>
        /// One of the values of the enumeration <see cref="KnownChartResolution" /> that defines char resolution.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultResolution)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownChartResolution Resolution
        {
            get => _resolution;
            set
            {
                SentinelHelper.IsEnumValid(value);

                if (value == _resolution)
                {
                    return;
                }

                _resolution = value;

                if (value == KnownChartResolution.Custom)
                {
                    CustomSize = CustomSizeModel.DefaultCustomSize;
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
        public override bool IsDefault => CustomSize.IsDefault && Resolution.Equals(DefaultResolution);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(SizeOptions): Apply specified options to this font
        /// <summary>
        /// Apply specified options to this font.
        /// </summary>
        public void ApplyOptions(SizeOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Resolution
            KnownChartResolution? resolutionOption = options.Resolution;
            bool resolutionHasValue = resolutionOption.HasValue;
            if (resolutionHasValue)
            {
                Resolution = resolutionOption.Value;
            }
            #endregion

            #region CustomSize
            CustomSizeModel sizeOption = options.CustomSize;
            bool sizeHasValue = sizeOption != null;
            if (sizeHasValue)
            {
                CustomSize = sizeOption;
            }
            #endregion
        }
        #endregion

        #region [public] (SizeModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public SizeModel Clone() => (SizeModel)MemberwiseClone();
        #endregion

        #region [public] (ResolutionInformation) GetResolutionInformation(): Gets a reference thats contains chart resolution information
        /// <summary>
        /// Gets a reference to the <see cref="T:iTin.Charting.Models.Design.ResolutionInformation" /> thats contains chart resolution information.
        /// </summary>
        /// <returns>
        /// Chart resolution information.
        /// </returns>
        public ResolutionInformation GetResolutionInformation()
        {
            ResolutionInformation info = Resolution.GetResolutionInformation();
            if (info.Resolution != KnownChartResolution.Custom)
            {
                return info;
            }

            info.Size = CustomSize.ToSize();
            info.Height = CustomSize.Height;
            info.Width = CustomSize.Width;
            info.AspectRatioValue = CustomSize.Width / (float)CustomSize.Height;
            info.AspectRatioNormalized = $"{info.AspectRatioValue:00}:1";
            info.AspectRatio = string.Empty;

            return info;
        }
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
