
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Table.Headers;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> table.
/// </summary>
public partial class XlsxTable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultAutoFitColumns = YesNo.No;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxSize _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _autoFitColumns;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxColumnsHeadersCollection _headers;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxTable"/> class.
    /// </summary>
    public XlsxTable()
    {
        Show = DefaultShow;
        AutoFitColumns = DefaultAutoFitColumns;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default shape settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxTable"/> reference containing the default shape settings.
    /// </value>
    public static XlsxTable Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool SizeSpecified => !Size.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    [XmlAttribute]
    [JsonProperty]
    [DefaultValue(DefaultAutoFitColumns)]
    public YesNo AutoFitColumns
    {
        get => GetStaticBindingValue(_autoFitColumns.ToString()).ToUpperInvariant() == "NO" ? YesNo.No : YesNo.Yes;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _autoFitColumns = value;
        }
    }

    /// <summary>
    /// Gets or sets the headers.
    /// </summary>
    /// <value>
    /// The headers.
    /// </value>
    [XmlArrayItem("Header", typeof(XlsxColumnHeader))]
    public virtual XlsxColumnsHeadersCollection Headers
    {
        get => _headers ??= new XlsxColumnsHeadersCollection(this);
        set => _headers = value;
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays this <see cref="XlsxTable"/>. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> displays this <see cref="XlsxTable"/>; Otherwise, <see cref="YesNo.No"/>. 
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => _show;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _show = value;
        }
    }

    /// <summary>
    /// Gets or sets a value containing shape size.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSize"/> reference containing shape size.
    /// </value>
    [XmlElement]
    [JsonProperty]
    public XlsxSize Size
    {
        get => _size ??= new XlsxSize();
        set => _size = value;
    }

    #endregion
}
