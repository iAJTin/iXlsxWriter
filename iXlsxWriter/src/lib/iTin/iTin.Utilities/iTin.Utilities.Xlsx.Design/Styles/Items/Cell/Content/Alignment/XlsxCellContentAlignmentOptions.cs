
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxCellContentAlignment"/> instance.
/// </summary>
/// </summary>
[Serializable]
public partial class XlsxCellContentAlignmentOptions 
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellContentAlignmentOptions"/> class.
    /// </summary>
    public XlsxCellContentAlignmentOptions()
    {
        Vertical = null;
        Horizontal = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxCellContentAlignment"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellContentAlignmentOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxCellContentAlignmentOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred horizontal alignment in an existing <see cref="XlsxCellContentAlignment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownHorizontalAlignment"/>. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("horizontal")]
    public KnownHorizontalAlignment? Horizontal { get; set; }

    /// <summary>
    /// Gets or sets the preferred vertical alignment in an existing <see cref="XlsxCellContentAlignment"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownVerticalAlignment"/>. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("vertical")]
    public KnownVerticalAlignment? Vertical { get; set; }

    #endregion
}
