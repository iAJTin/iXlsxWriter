
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// </summary>
    [Serializable]
    public class XlsxCellCommentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxCellCommentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellCommentOptions"/> class.
        /// </summary>
        public XlsxCellCommentOptions()
        {
            Font = null;
            Show = null;
            Text = null;
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

        #region [public] {static} (XlsxCellCommentOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxCellComment instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellComment"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellCommentOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxCellCommentOptions Default => new XlsxCellCommentOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) FontSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool FontSpecified => Font != null;
        #endregion

        #endregion

        #region public properties

        #region [public] (FontOptions) Font: Gets or sets a value that defines font cell style in an existing XlsxCellComment instance.
        /// <summary>
        /// Gets or sets a value that defines cell style content in an existing <see cref="XlsxCellComment"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="FontOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("font")]
        public FontOptions Font { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing XlsxCellComment instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="XlsxCellComment"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (string) Text: Gets or sets the preferred cell comment color in an existing XlsxCellComment instance
        /// <summary>
        /// Gets or sets the preferred cell comment color in an existing <see cref="XlsxCellComment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred cell content color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("text")]
        public string Text { get; set; }
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
        public override bool IsDefault => base.IsDefault && Font == null && Show == null && Text == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellCommentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellCommentOptions Clone()
        {
            var cloned = (XlsxCellCommentOptions)MemberwiseClone();
            if (Font != null)
            {
                cloned.Font = Font.Clone();
            }

            return cloned;
        } 
        #endregion

        #endregion
    }
}
