
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
/// Represents a range of cells by row and column values.
/// </summary>
public partial class XlsxRange
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxPoint _end;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxPoint _start;

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
    public bool EndSpecified => !End.IsDefault;

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
    public bool StartSpecified => !Start.IsDefault;

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig default range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> reference containing default range.
    /// </value>
    public static XlsxRange Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or set a value containing the starting point of a range. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Starting point of a range.
    /// </value>
    [XmlElement]
    [JsonProperty("start")]
    public XlsxPoint Start
    {
        get => _start ??= new XlsxPoint();
        set => _start = value;
    }

    /// <summary>
    /// Gets or set a value containing the endpoint of a range. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Endpoint of a range.
    /// </value>
    [XmlElement]
    [JsonProperty("end")]
    public XlsxPoint End
    {
        get => _end ??= new XlsxPoint();
        set => _end = value;
    }

    #endregion
}
