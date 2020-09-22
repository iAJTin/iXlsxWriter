
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxBaseShadow"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxBaseShadowOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxBaseShadowOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxBaseShadowOptions"/> class.
        /// </summary>
        public XlsxBaseShadowOptions()
        {
            Show = null;
            Blur = null;
            Angle = null;
            Color = null;
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

        #region [public] {static} (XlsxBaseShadowOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxBaseShadow"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static XlsxBaseShadowOptions Default => new XlsxBaseShadowOptions();
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
            Angle == null &&
            Blur == null &&
            Color == null &&
            Offset == null &&
            Show == null &&
            Transparency == null;
        #endregion

        #endregion

        #region public properties

        #region [public] (int?) Angle: Gets or sets a value that contains the preferred shadow angle value in an existing in an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets or sets a value that contains the preferred shadow angle value in an existing <see cref="XlsxBaseShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred shadow angle value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("angle")]
        public int? Angle { get; set; }
        #endregion

        #region [public] (int?) Blur: Gets or sets a value that contains the preferred blur value in an existing in an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets or sets a value that contains the preferred blur value in an existing <see cref="XlsxBaseShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred blur value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("blur")]
        public int? Blur { get; set; }
        #endregion

        #region [public] (string) Color: Gets or sets the preferred back color in an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets or sets the preferred color in an existing <see cref="XlsxBaseShadow"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="string"/> value that represents the preferred shadow color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (int?) Offset: Gets or sets a value that contains the shadow shift, expressed in pixels in an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets or sets a value that contains the shadow shift, expressed in pixels in an existing <see cref="XlsxBaseShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the shadow displacement, in pixels.
        /// </value>
        [XmlAttribute]
        [JsonProperty("offset")]
        public int? Offset { get; set; }
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

        #region [public] (int?) Transparency: Gets or sets a value that contains the preferred shadow transparency value expressed in % in an existing in an existing XlsxBaseShadow instance
        /// <summary>
        /// Gets or sets a value that contains the preferred shadow transparency value expressed in % value in an existing <see cref="XlsxBaseShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred shadow transparency value expressed in %.
        /// </value>
        [XmlAttribute]
        [JsonProperty("transparency")]
        public int? Transparency { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBaseShadowOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBaseShadowOptions Clone() => (XlsxBaseShadowOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
