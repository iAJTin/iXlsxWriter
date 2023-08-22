
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxPoint"/> instance.
/// </summary>
[Serializable]
public partial class XlsxPointOptions 
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPointOptions"/> class.
    /// </summary>
    public XlsxPointOptions()
    {
        Row = null;
        Column = null;
        AbsoluteStrategy = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxPoint"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPointOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxPoint"/> instance.
    /// </value>
    public static XlsxPointOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing <see cref="XlsxPoint"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or one of the enumeration values <see cref="Shared.AbsoluteStrategy"/>. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("absolute-strategy")]
    public AbsoluteStrategy? AbsoluteStrategy { get; set; }

    /// <summary>
    /// Gets or sets the column value in an existing <see cref="XlsxPoint"/>" instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value.
    /// </value>
    [XmlAttribute]
    [JsonProperty("column")]
    public int? Column { get; set; }

    /// <summary>
    /// Gets or sets the row value in an existing <see cref="XlsxPoint"/>" instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value.
    /// </value>
    [XmlAttribute]
    [JsonProperty("row")]
    public int? Row { get; set; }

    #endregion
}
