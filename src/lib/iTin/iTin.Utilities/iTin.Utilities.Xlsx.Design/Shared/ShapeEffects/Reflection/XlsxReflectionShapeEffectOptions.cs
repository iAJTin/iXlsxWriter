
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxReflectionShapeEffect"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxReflectionShapeEffectOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxReflectionShapeEffectOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxReflectionShapeEffectOptions"/> class.
        /// </summary>
        public XlsxReflectionShapeEffectOptions()
        {
            Show = null;
            Blur = null;
            Size = null;
            Offset = null;
            Transparency = null;
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

        #region [public] {static} (XlsxReflectionShapeEffectOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxReflectionShapeEffect instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxReflectionShapeEffect"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static XlsxReflectionShapeEffectOptions Default => new XlsxReflectionShapeEffectOptions();
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
        public override bool IsDefault =>
            base.IsDefault &&
            Blur == null &&
            Offset == null &&
            Size == null &&
            Show == null &&
            Transparency == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (float?) Blur: Gets or sets a value that contains the preferred reflection effect blur value in an existing in an existing XlsxReflectionShapeEffect instance
        /// <summary>
        /// Gets or sets a value that contains the preferred reflection effect blur value in an existing <see cref="XlsxReflectionShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="float"/> value that represents the preferred reflection effect blur value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("blur")]
        public float? Blur { get; set; }
        #endregion

        #region [public] (float?) Size: Gets or sets a value that contains the preferred reflection effect size value in an existing in an existing XlsxReflectionShapeEffect instance
        /// <summary>
        /// Gets or sets a value that contains the preferred reflection effect size value in an existing <see cref="XlsxReflectionShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="float"/> value that represents the preferred reflection effect size value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("size")]
        public float? Size { get; set; }
        #endregion

        #region [public] (float?) Offset: Gets or sets a value that contains the reflection effect offset value expressed in points in an existing XlsxReflectionShapeEffect instance
        /// <summary>
        /// Gets or sets a value that contains the reflection offset value expressed in points in an existing <see cref="XlsxReflectionShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="float"/> value that represents the reflection offset value expressed in points.
        /// </value>
        [XmlAttribute]
        [JsonProperty("offset")]
        public float? Offset { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (int?) Transparency: Gets or sets a value that contains the preferred reflection effect transparency value expressed in % in an existing in an existing XlsxBaseColoredShadow instance
        /// <summary>
        /// Gets or sets a value that contains the preferred reflection effect transparency value expressed in % value in an existing <see cref="XlsxReflectionShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred reflection effect transparency value expressed in %.
        /// </value>
        [XmlAttribute]
        [JsonProperty("transparency")]
        public int? Transparency { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxReflectionShapeEffectOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxReflectionShapeEffectOptions Clone() => (XlsxReflectionShapeEffectOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
