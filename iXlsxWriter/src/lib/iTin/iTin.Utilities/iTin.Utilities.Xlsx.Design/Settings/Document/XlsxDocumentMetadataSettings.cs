﻿
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Settings.Document;

/// <summary>
/// Defines a <b>xlsx</b> document properties metadata.
/// </summary>
public partial class XlsxDocumentMetadataSettings
{
    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default document metadata.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMetadataSettings"/> reference containing the default document metadata.
    /// </value>
    public static XlsxDocumentMetadataSettings Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the author of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the author of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("author")]
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the category of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the category of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("category")]
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the additional comments in this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the additional comments for this document
    /// </value>
    [XmlElement]
    [JsonProperty("comments")]
    public string Comments { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the company of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the company of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("company")]
    public string Company { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the keywords of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the keywords of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("keywords")]
    public string Keywords { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the manager of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the manager of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("manager")]
    public string Manager { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the subject of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the subject of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the title of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the title of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the url of this document.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the url of this document.
    /// </value>
    [XmlElement]
    [JsonProperty("url")]
    public string Url { get; set; }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        string.IsNullOrEmpty(Title) &&
        string.IsNullOrEmpty(Subject) &&
        string.IsNullOrEmpty(Author) &&
        string.IsNullOrEmpty(Manager) &&
        string.IsNullOrEmpty(Company) &&
        string.IsNullOrEmpty(Category) &&
        string.IsNullOrEmpty(Keywords) &&
        string.IsNullOrEmpty(Comments) &&
        string.IsNullOrEmpty(Url);

    #endregion
}