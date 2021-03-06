﻿
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="QualityModel"/> instance.
    /// </summary>
    [Serializable]
    public sealed class QualityOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] QualityOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="QualityOptions"/> class.
        /// </summary>
        public QualityOptions()
        {
            CustomQuality = null;
            SmoothingStyle = null;
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

        #region [public] {static} (QualityOptions) Default: Gets a reference that contains the set of available settings to model an existing QualityModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="QualityModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static QualityOptions Default => new QualityOptions();
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => SmoothingStyle == null && CustomQuality == null;
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

        #region [public] (KnownChartSmoothingStyle?) SmoothingStyle: Gets or sets the preferred chart quality in an existing QualityModel instance
        /// <summary>
        /// Gets or sets the preferred chart quality in an existing <see cref="QualityModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="QualityOptions"/> instance
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownChartSmoothingStyle? SmoothingStyle { get; set; }
        #endregion

        #region [public] (CustomQualityModel) CustomQuality: Gets or sets a value that defines the custom size in an existing QualityModel instance.
        /// <summary>
        /// Gets or sets a value that defines the custom quality in an existing <see cref="QualityModel" /> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a new <see cref="CustomQualityModel" />.
        /// </value>
        public CustomQualityModel CustomQuality { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (QualityOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public QualityOptions Clone()
        {
            var clonned = (QualityOptions)MemberwiseClone();
            clonned.CustomQuality = CustomQuality?.Clone();

            return clonned;
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
