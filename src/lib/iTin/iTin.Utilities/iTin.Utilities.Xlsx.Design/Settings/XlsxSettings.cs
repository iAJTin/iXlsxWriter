
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Utilities.Xlsx.Design.Settings.Document;
using iTin.Utilities.Xlsx.Design.Settings.Sheets;

namespace iTin.Utilities.Xlsx.Design.Settings;

/// <summary>
/// Defines sheets collection settings. Allows to set the document metadata, margins, header, footer, default view, size and orientation.
/// </summary>
public partial class XlsxSettings
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxSheetsSettingsCollection _sheets;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentMetadataSettings _document;

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSettings"/> reference containing the default settings.
    /// </value>
    public static XlsxSettings Default => new();

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
    public bool DocumentSettingsSpecified => !DocumentSettings.IsDefault;

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
    public bool SheetsSettingsSpecified => !SheetsSettings.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value containing document settings. Allows to set the document metadata.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMetadataSettings"/> reference containing the document settings.
    /// </value>
    [XmlElement]
    [JsonProperty("document")]
    public XlsxDocumentMetadataSettings DocumentSettings
    {
        get => _document ??= new XlsxDocumentMetadataSettings();
        set => _document = value;
    }

    /// <summary>
    /// Gets or sets a value containing sheets settings. Allows to set margins, header, footer, default view, size and orientation.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSheetsSettingsCollection"/> reference containing the document settings.
    /// </value>
    [JsonProperty("sheets")]
    [XmlArrayItem("SheetSettings", typeof(XlsxSheetSettings), IsNullable = false)]
    public XlsxSheetsSettingsCollection SheetsSettings
    {
        get => _sheets ??= new XlsxSheetsSettingsCollection(this);
        set => _sheets = value;
    }

    #endregion
}
