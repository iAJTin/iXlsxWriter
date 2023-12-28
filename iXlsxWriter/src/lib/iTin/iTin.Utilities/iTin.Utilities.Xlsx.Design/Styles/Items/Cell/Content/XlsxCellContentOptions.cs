
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellContent"/> instance.
/// </summary>
/// </summary>
[Serializable]
public partial class XlsxCellContentOptions
{
    #region constructor/s

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

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellContentOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxCellContentOptions Default => new();

    #endregion

    #region public readonly properties

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

    #region public properties

    /// <summary>
    /// Gets or sets a value that defines cell alignment style in an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellContentAlignmentOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("alignment")]
    public XlsxCellContentAlignmentOptions Alignment { get; set; }

    /// <summary>
    /// Gets or sets the preferred cell content color in an existing <see cref="XlsxCellContent"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred cell content color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value that defines cell merge in an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellMergeOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("merge")]
    public XlsxCellMergeOptions Merge { get; set; }

    /// <summary>
    /// Gets or sets a value that defines content pattern style in an existing <see cref="XlsxCellContent"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellPatternOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("pattern")]
    public XlsxCellPatternOptions Pattern { get; set; }

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
}
