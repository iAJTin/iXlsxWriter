
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellStyle"/> instance.
/// </summary>
/// </summary>
[Serializable]
public partial class XlsxCellStyleOptions 
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellStyleOptions"/> class.
    /// </summary>
    public XlsxCellStyleOptions()
    {
        Font = null;
        Content = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new reference containing set of available settings to model an existing <see cref="XlsxCellStyle"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyleOptions"/> reference containing set of available settings.
    /// </value>
    public static XlsxCellStyleOptions Default => new();

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
    public bool FontSpecified => Font != null;

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
    public bool ContentSpecified => Content != null;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that defines cell style content in an existing <see cref="XlsxCellStyle"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="FontOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("font")]
    public FontOptions Font { get; set; }

    /// <summary>
    /// Gets or sets a value that defines cell style content in an existing <see cref="XlsxCellStyle"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxCellContentOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("content")]
    public XlsxCellContentOptions Content { get; set; }

    #endregion
}
