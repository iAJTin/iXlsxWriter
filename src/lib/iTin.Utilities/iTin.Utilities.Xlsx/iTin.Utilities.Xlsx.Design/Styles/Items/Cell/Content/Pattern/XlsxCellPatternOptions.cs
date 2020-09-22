
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellPattern"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxCellPatternOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxCellPatternOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellPatternOptions"/> class.
        /// </summary>
        public XlsxCellPatternOptions()
        {
            Color = null;
            PatternType = null;
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

        #region [public] {static} (XlsxCellPatternOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxCellPattern instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellPattern"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellPatternOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxCellPatternOptions Default => new XlsxCellPatternOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets the preferred pattern color in an existing PdfTableContent instance
        /// <summary>
        /// Gets or sets the preferred pattern color in an existing <see cref="XlsxCellPattern"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred pattern color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (KnownPatternType?) PatternType: Gets or sets a value that indicates preferred pattern type for an existing XlsxCellPattern instance
        /// <summary>
        /// Gets or sets a value that indicates preferred pattern type for an existing <see cref="XlsxCellPattern"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
        /// </value>
        [XmlAttribute]
        [JsonProperty("pattern-type")]
        public KnownPatternType? PatternType { get; set; }
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
        public override bool IsDefault => base.IsDefault && Color == null && PatternType == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellPatternOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellPatternOptions Clone() => (XlsxCellPatternOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
