
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines header and footer document configuration, it allow define margin and data.
/// </summary>
public partial class XlsxDocumentHeaderFooter
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentHeaderFooterSections _sections;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooter"/> class.
    /// </summary>
    public XlsxDocumentHeaderFooter()
    {
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default header or footer document settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentHeaderFooter"/> reference containing the default header or footer document settings.
    /// </value>
    public static XlsxDocumentHeaderFooter Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element of this element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of this element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxSheetSettings Parent { get; private set; }

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
    public bool SectionsSpecified => !Sections.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that allows you to define the sections settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentHeaderFooterSections"/> refetence containing the sections settings.
    /// </value>
    [JsonProperty("sections")]
    [XmlArrayItem("Section", typeof(XlsxDocumentHeaderFooterSection), IsNullable = false)]
    public XlsxDocumentHeaderFooterSections Sections
    {
        get => _sections ??= new XlsxDocumentHeaderFooterSections(this);
        set => _sections = value;
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the parent element of this element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    internal void SetParent(XlsxSheetSettings reference)
    {
        Parent = reference;
    }

    #endregion
}
