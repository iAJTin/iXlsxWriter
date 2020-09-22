
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellContentAlignment"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxCellContentAlignmentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxCellContentAlignmentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellContentAlignmentOptions"/> class.
        /// </summary>
        public XlsxCellContentAlignmentOptions()
        {
            Vertical = null;
            Horizontal = null;
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

        #region [public] {static} (XlsxCellContentAlignmentOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxCellContentAlignment instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellContentAlignment"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellContentAlignmentOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxCellContentAlignmentOptions Default => new XlsxCellContentAlignmentOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHorizontalAlignment?) Horizontal: Gets or sets the preferred horizontal alignment in an existing XlsxCellContentAlignment instance
        /// <summary>
        /// Gets or sets the preferred horizontal alignment in an existing <see cref="XlsxCellContentAlignment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownHorizontalAlignment"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("horizontal")]
        public KnownHorizontalAlignment? Horizontal { get; set; }
        #endregion

        #region [public] (KnownVerticalAlignment?) Vertical: Gets or sets the preferred vertical alignment in an existing XlsxCellContentAlignment instance
        /// <summary>
        /// Gets or sets the preferred vertical alignment in an existing <see cref="XlsxCellContentAlignment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownVerticalAlignment"/>. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("vertical")]
        public KnownVerticalAlignment? Vertical { get; set; }
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
        public override bool IsDefault => base.IsDefault && Vertical == null && Horizontal == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellContentAlignmentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public XlsxCellContentAlignmentOptions Clone() => (XlsxCellContentAlignmentOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
