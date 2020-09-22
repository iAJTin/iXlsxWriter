
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
    public class XlsxCellContentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxCellContentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellContentOptions"/> class.
        /// </summary>
        public XlsxCellContentOptions()
        {
            Color = null;
            Show = null;
            Merge = null;
            Pattern = null;
            Alignment = null;
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

        #region [public] {static} (XlsxCellContentOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxCellContent instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellContent"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellContentOptions"/> reference containing set of default options.
        /// </value>
        public static XlsxCellContentOptions Default => new XlsxCellContentOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) AlignmentSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool AlignmentSpecified => Alignment != null;
        #endregion

        #region [public] (bool) MergeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool MergeSpecified => Merge != null;
        #endregion

        #region [public] (bool) PatternSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool PatternSpecified => Pattern != null;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxCellContentAlignmentOptions) Alignment: Gets or sets a value that defines cell alignment style in an existing XlsxCellContent instance
        /// <summary>
        /// Gets or sets a value that defines cell alignment style in an existing <see cref="XlsxCellContent"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellContentAlignmentOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("alignment")]
        public XlsxCellContentAlignmentOptions Alignment { get; set; }
        #endregion

        #region [public] (string) Color: Gets or sets the preferred cell content color in an existing XlsxCellContent instance
        /// <summary>
        /// Gets or sets the preferred cell content color in an existing <see cref="XlsxCellContent"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred cell content color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (XlsxCellMergeOptions) Merge: Gets or sets a value that defines cell merge in an existing XlsxCellContent instance
        /// <summary>
        /// Gets or sets a value that defines cell merge in an existing <see cref="XlsxCellContent"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellMergeOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("merge")]
        public XlsxCellMergeOptions Merge { get; set; }
        #endregion

        #region [public] (XlsxCellPatternOptions) Pattern: Gets or sets a value that defines content pattern style in an existing XlsxCellContent instance
        /// <summary>
        /// Gets or sets a value that defines content pattern style in an existing <see cref="XlsxCellContent"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellPatternOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("pattern")]
        public XlsxCellPatternOptions Pattern { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing XlsxCellContent instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="XlsxCellContent"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
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
            Show == null &&
            Color == null &&
            Merge == null &&
            Pattern == null &&
            Alignment == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellContentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellContentOptions Clone()
        {
            var cloned = (XlsxCellContentOptions)MemberwiseClone();

            if (Merge != null)
            {
                cloned.Merge = Merge.Clone();
            }

            if (Pattern != null)
            {
                cloned.Pattern = Pattern.Clone();
            }

            if (Alignment != null)
            {
                cloned.Alignment = Alignment.Clone();
            }

            return cloned;
        } 
        #endregion

        #endregion
    }
}
