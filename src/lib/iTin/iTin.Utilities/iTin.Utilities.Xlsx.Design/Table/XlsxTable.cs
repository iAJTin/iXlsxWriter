
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Design.Table.Headers;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Specialization of the <see cref="TableDefinition"/> class.<br/>
/// Represents a model that defines the properties and configuration of a data table for <strong>xlsx</strong> files.
/// </summary>
/// <remarks>
/// <strong><u>Usage</u></strong>:
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Table ...>
///   <Headers/>
///   <Fields/>
/// </Table>
/// ]]>
/// </code>
/// <para><strong><u>Attributes</u></strong></para>
/// <list type="table">
///  <listheader>
///   <term>Attribute</term>
///   <term>Optional</term>
///   <description>Description</description>
///  </listheader>
///  <item>
///   <term><see cref="TableDefinition.Name"/></term>
///   <term>No</term>
///   <description>Name of the table.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.Alias"/></term>
///   <term>Yes</term>
///   <description>Alias of the table.</description>
///  </item>
///  <item>
///   <term><see cref="AutoFitColumns"/></term>
///   <term>No</term>
///   <description>Determines whether the columns should be automatically resized to fit the content.The default is <see cref="YesNo.No"/>.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.Filter"/></term>
///   <term>Yes</term>
///   <description>Filter key to use. One of the keys defined in filters.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.Show"/></term>
///   <term>Yes</term>
///   <description>Determines whether shows the table. The default is <see cref="YesNo.Yes"/>.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.ShowColumnHeaders"/></term>
///   <term>Yes</term>
///   <description>Determines whether shows column headers.The default is <see cref="YesNo.Yes"/>.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.ShowDataValues"/></term>
///   <term>Yes</term>
///   <description>Determines whether shows data values.The default is <see cref="YesNo.Yes"/>.</description>
///  </item>
/// </list>
/// <para><strong><u>Elements</u></strong></para>
/// <list type="table">
///  <listheader>
///   <term> Element </term>
///   <description>Description</description>
///  </listheader>
///  <item>
///   <term><see cref="TableDefinition.Fields"/></term>
///   <description> Collection of data fields. Each element is a data field.</description>
///  </item>
///  <item>
///   <term><see cref="Headers"/></term>
///   <description> Collection of data fields. Each element is a data field.</description>
///  </item>
///  <item>
///   <term><see cref="TableDefinition.Resources"/></term>
///   <description>Collection of data fields. Each element is a data field.</description>
///  </item>
/// </list>
/// </remarks>
public partial class XlsxTable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultAutoFitColumns = YesNo.No;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _autoFitColumns;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxColumnsHeadersCollection _headers;

    #endregion

    #region constructor/s

    #region [public] XlsxTable(): Initializes a new instance of the class
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxTable"/> class.
    /// </summary>
    public XlsxTable()
    {
        AutoFitColumns = DefaultAutoFitColumns;
        Resources.Styles = new XlsxStylesCollection(this);
    }
    #endregion

    #endregion

    #region public readonly static properties

    #region [public] {static} (XlsxTable) Default: Returns a new instance containing default instance
    /// <summary>
    /// Returns a new instance containing default instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxTable"/> reference containing the default instance.
    /// </value>
    public static XlsxTable Default => new();
    #endregion

    #endregion

    #region public readonly properties

    #region [public] (bool) HeadersSpecified: Gets a value that tells the serializer if the referenced item is to be included
    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the serializer has to include the element; otherwise, <see langword="false"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool HeadersSpecified => !Headers.IsDefault;
    #endregion

    #endregion

    #region public properties

    #region [public] (YesNo) AutoFitColumns: Gets or sets a value indicating whether the columns should be automatically resized to fit the content
    /// <summary>
    /// Gets or sets a value indicating whether the columns should be automatically resized to fit the content.<br/>
    /// The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="YesNo.Yes"/> if columns should be automatically resized to fit the content; Otherwise, <see cref="YesNo.No"/>.
    /// </para>
    /// <strong><u>Usage</u></strong>:
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Table AutoFitColumns="Yes|No" ...>
    ///   ...
    ///   ...
    /// </Table>
    /// ]]>
    /// </code>
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <para><c>C#</c></para>
    /// <code lang="cs">
    /// ...
    /// var table = new TableDefinition
    /// {
    ///     Name = "Sample name",
    ///     Alias = "Sample alias",
    ///     AutoFitColumns = YesNo.Yes,
    ///     ...
    /// };
    /// ...
    /// </code>
    /// <para><c>XML</c></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// ...
    /// <Table AutoFitColumns="Yes" ...>
    ///   ...
    /// </Table>
    /// ]]>
    /// </code>
    /// </remarks>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.<br/>
    /// 
    /// -or-<br/>
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
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
    #endregion

    #region [public] (XlsxColumnsHeadersCollection) Headers: Gets or sets the collection of column headers for the table
    /// <summary>
    /// Gets or sets the collection of column headers for the table.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Collection of column headers.<br/>
    /// Each element is a column header
    /// </para>
    /// <strong><u>Usage</u></strong>:
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Table ...>
    ///   <Headers>
    ///     <Header .../>
    ///     <Header .../>
    ///     ...
    ///   </Headers>
    /// </Table>
    /// ]]>
    /// </code>
    /// </remarks>
    [JsonProperty]
    [XmlArrayItem("Header", typeof(XlsxColumnHeader))]
    public XlsxColumnsHeadersCollection Headers
    {
        get => _headers ??= new XlsxColumnsHeadersCollection(this);
        set => _headers = value;
    }
    #endregion

    #endregion
}
