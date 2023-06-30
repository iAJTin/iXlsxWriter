
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxIlluminationShapeEffect"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxIlluminationShapeEffectOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxIlluminationShapeEffectOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxIlluminationShapeEffectOptions"/> class.
        /// </summary>
        public XlsxIlluminationShapeEffectOptions()
        {
            Show = null;
            Size = null;
            Color = null;
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

        #region [public] {static} (XlsxIlluminationShapeEffectOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxIllumination instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxIlluminationShapeEffect"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static XlsxIlluminationShapeEffectOptions Default => new XlsxIlluminationShapeEffectOptions();
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
            Size == null &&
            Color == null &&
            Show == null &&
            Transparency == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets the preferred illumination effect color in an existing XlsxIlluminationShapeEffect instance
        /// <summary>
        /// Gets or sets the preferred color in an existing <see cref="XlsxIlluminationShapeEffect"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="string"/> value that represents the preferred illumination shape effect color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (int?) Size: Gets or sets a value that contains preferred illumination effect size, expressed in points in an existing in an existing XlsxIlluminationShapeEffect instance
        /// <summary>
        /// Gets or sets a value that contains the preferred illumination effect size, expressed in points in an existing <see cref="XlsxIlluminationShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred illumination effect size value, expressed in points.
        /// </value>
        [XmlAttribute]
        [JsonProperty("size")]
        public int? Size { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="XlsxIlluminationShapeEffect"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (int?) Transparency: Gets or sets a value that contains the preferred illumination effect transparency value expressed in % in an existing in an existing XlsxIllumination instance
        /// <summary>
        /// Gets or sets a value that contains the preferred illumination effect transparency value expresed in % value in an existing <see cref="XlsxIlluminationShapeEffect"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred illumination effect transparency value expressed in %.
        /// </value>
        [XmlAttribute]
        [JsonProperty("transparency")]
        public int? Transparency { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxIlluminationOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxIlluminationShapeEffectOptions Clone() => (XlsxIlluminationShapeEffectOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
