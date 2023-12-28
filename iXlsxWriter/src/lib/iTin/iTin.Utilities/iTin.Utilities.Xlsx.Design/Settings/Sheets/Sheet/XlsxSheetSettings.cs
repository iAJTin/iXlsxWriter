
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines sheet settings. Allows to set the sheet margins, header, footer, default view, size and orientation.
/// </summary>
public partial class XlsxSheetSettings
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownDocumentSize DefaultSize = KnownDocumentSize.A4;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownDocumentView DefaultView = KnownDocumentView.Normal;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownDocumentOrientation DefaultOrientation = KnownDocumentOrientation.Portrait;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownDocumentView _view;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxPoint _freezePanesPoint;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownDocumentSize _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentMargins _margins;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentHeaderFooter _footer;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentHeaderFooter _header;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownDocumentOrientation _orientation;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxSheetSettings"/> class.
    /// </summary>
    public XlsxSheetSettings()
    {
        Size = DefaultSize;
        View = DefaultView;
        SheetName = string.Empty;
        Orientation = DefaultOrientation;
        FreezePanesPoint = XlsxPoint.Default;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default sheet settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSheetSettings"/> reference containing the default sheet settings.
    /// </value>
    public static XlsxSheetSettings Default => new();

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
    public bool FreezePanesPointSpecified => !FreezePanesPoint.IsDefault;

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
    public bool FooterSpecified => !Footer.IsDefault;

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
    public bool HeaderSpecified => !Header.IsDefault;

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
    public bool MarginsSpecified => !Margins.IsDefault;

    /// <summary>
    /// Gets the element that owns this <see cref="XlsxSheetSettings"/>.
    /// </summary>
    /// <value>
    /// The <see cref="XlsxSheetsSettingsCollection"/> that owns this <see cref="XlsxSheetSettings"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public XlsxSheetsSettingsCollection Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred freeze panes point. Only applies when <see cref="KnownDocumentView.Normal"/> view mode is selected. The default point is <b>A1</b>.
    /// </summary>
    /// <value>
    /// Preferred freeze panes point.
    /// </value>
    [XmlElement]
    [JsonProperty("sheet-freeze-panes-point")]
    public XlsxPoint FreezePanesPoint
    {
        get => _freezePanesPoint ??= XlsxPoint.Default;
        set => _freezePanesPoint = value;
    }

    /// <summary>
    /// Gets or sets a reference to footer document configuration, it allow define margin and data.
    /// </summary>
    /// <value>
    /// Reference to footer document configuration, it allow define margin and data.
    /// </value>
    [XmlElement]
    [JsonProperty("sheet-footer")]
    public XlsxDocumentHeaderFooter Footer
    {
        get
        {
            _footer ??= new XlsxDocumentHeaderFooter();
            _footer.SetParent(this);

            return _footer;
        }
        set => _footer = value;
    }

    /// <summary>
    /// Gets or sets a reference to header document configuration, it allow define margin and data.
    /// </summary>
    /// <value>
    /// Reference to header document configuration, it allow define margin and data.
    /// </value>
    [XmlElement]
    [JsonProperty("sheet-header")]
    public XlsxDocumentHeaderFooter Header
    {
        get
        {
            _header ??= new XlsxDocumentHeaderFooter();
            _header.SetParent(this);

            return _header;
        }
        set => _header = value;
    }

    /// <summary>
    /// Gets or sets a reference that allows you to define the margins settings for this document.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMargins"/> refetence containing the margins settings for this document.
    /// </value>
    [XmlElement]
    [JsonProperty("sheet-margins")]
    public XlsxDocumentMargins Margins
    {
        get => _margins ??= new XlsxDocumentMargins();
        set => _margins = value;
    }

    /// <summary>
    /// Gets or sets the preferred document orientation. The default is <see cref="KnownDocumentOrientation.Portrait"/>.
    /// </summary>
    /// <value>
    /// Preferred document orientation.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("sheet-orientation")]
    [DefaultValue(DefaultOrientation)]
    public KnownDocumentOrientation Orientation
    {
        get => _orientation;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _orientation = value;
        }
    }

    /// <summary>
    /// Gets or sets the sheet name view.
    /// </summary>
    /// <value>
    /// Sheet name.
    /// </value>
    [XmlAttribute]
    [JsonProperty("sheet-name")]
    public string SheetName { get; set; }

    /// <summary>
    /// Gets or sets the preferred document size. The default is <see cref="KnownDocumentSize.A4"/>.
    /// </summary>
    /// <value>
    /// Preferred document size.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("sheet-size")]
    [DefaultValue(DefaultSize)]
    public KnownDocumentSize Size
    {
        get => _size;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _size = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred document view. The default is <see cref="KnownDocumentView.Normal"/>.
    /// </summary>
    /// <value>
    /// Preferred document view.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("sheet-view")]
    [DefaultValue(DefaultView)]
    public KnownDocumentView View
    {
        get => _view;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _view = value;
        }
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxSheetsSettingsCollection"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(XlsxSheetsSettingsCollection reference)
    {
        Owner = reference;
    }

    #endregion
}
