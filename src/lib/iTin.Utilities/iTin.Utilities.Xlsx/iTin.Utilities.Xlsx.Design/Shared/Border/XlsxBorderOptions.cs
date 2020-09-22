
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxBorder"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxBorderOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxBorderOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxBorderOptions"/> class.
        /// </summary>
        public XlsxBorderOptions()
        {
            Show = null;
            Color = null;
            Width = null;
            Style = null;
            Transparency = null;
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

        #region [public] {static} (XlsxBorderOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxBorder instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxBorder"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBorderOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxBorder"/> instance.
        /// </value>
        public static XlsxBorderOptions Default => new XlsxBorderOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets the preferred border color in an existing XlsxBorder instance
        /// <summary>
        /// Gets or sets the preferred border color in an existing <see cref="XlsxBorder"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred border color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing XlsxBorder instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="XlsxBorder"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (KnownLineStyle?) Style: Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing XlsxPoint instance
        /// <summary>
        /// Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing <see cref="XlsxBorder"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or one of the enumeration values <see cref="KnownLineStyle"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("style")]
        public KnownLineStyle? Style { get; set; }
        #endregion

        #region [public] (int?) Transparency: Gets or sets the preferred border transparency percentage value in an existing XlsxBorder instance
        /// <summary>
        /// Gets or sets the preferred border transparency percentage value in an existing <see cref="XlsxBorder"/>" instance.
        /// </summary>
        /// <value>
        /// Preferred border transparency percentage value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("transparency")]
        public int? Transparency { get; set; }
        #endregion

        #region [public] (int?) Width: Gets or sets the preferred border width in an existing XlsxBorder instance
        /// <summary>
        /// Gets or sets the preferred border width in an existing <see cref="XlsxBorder"/>" instance.
        /// </summary>
        /// <value>
        /// Preferred border width.
        /// </value>
        [XmlAttribute]
        [JsonProperty("width")]
        public int? Width { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
                Show == null &&
                Color == null &&
                Width == null &&
                Style == null &&
                Transparency == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBorderOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBorderOptions Clone() => (XlsxBorderOptions) MemberwiseClone();
        #endregion

        #endregion
    }
}
