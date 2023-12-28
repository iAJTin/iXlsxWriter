
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellPattern"/> instance.
/// </summary>
/// </summary>
[Serializable]
public partial class XlsxCellPatternOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellPatternOptions"/> class.
    /// </summary>
    public XlsxCellPatternOptions()
    {
        Color = null;
        PatternType = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellPattern"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellPatternOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxCellPatternOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred pattern color in an existing <see cref="XlsxCellPattern"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred pattern color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates preferred pattern type for an existing <see cref="XlsxCellPattern"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
    /// </value>
    [XmlAttribute]
    [JsonProperty("pattern-type")]
    public KnownPatternType? PatternType { get; set; }

    #endregion
}
