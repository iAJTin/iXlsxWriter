
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines a <b>Xlsx</b> section settings.
/// </summary>
public partial class XlsxDocumentHeaderFooterSection
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultText = "";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownHeaderFooterSectionType DefaultType = KnownHeaderFooterSectionType.Odd;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownHeaderFooterAlignment DefaultAlignment = KnownHeaderFooterAlignment.Center;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownHeaderFooterSectionType _type;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownHeaderFooterAlignment _alignment;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooterSection"/> class.
    /// </summary>
    public XlsxDocumentHeaderFooterSection()
    {
        Text = DefaultText;
        Type = DefaultType;
        Alignment = DefaultAlignment;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing the default section settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentHeaderFooterSection"/> reference containing the default section settings.
    /// </value>
    public static XlsxDocumentHeaderFooterSection Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the element that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
    /// </summary>
    /// <value>
    /// The <see cref="XlsxDocumentHeaderFooterSections"/> that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public XlsxDocumentHeaderFooterSections Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred section Alignment. The default is <see cref="KnownHeaderFooterAlignment.Center"/>.
    /// </summary>
    /// <value>
    /// Preferred section alignment.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("alignment")]
    [DefaultValue(DefaultAlignment)]
    public KnownHeaderFooterAlignment Alignment
    {
        get => _alignment;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _alignment = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that contains a <see cref="string"/> to identify this section.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the section identifier.
    /// </value>
    [XmlAttribute]
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the section text.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the section text.
    /// </value>
    [XmlAttribute]
    [JsonProperty("text")]
    [DefaultValue(DefaultText)]
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the preferred section type. The default is <see cref="KnownHeaderFooterSectionType.Odd"/>.
    /// </summary>
    /// <value>
    /// Preferred section type.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("type")]
    [DefaultValue(DefaultType)]
    public KnownHeaderFooterSectionType Type
    {
        get => _type;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _type = value;
        }
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(XlsxDocumentHeaderFooterSections reference)
    {
        Owner = reference;
    }

    #endregion
}
