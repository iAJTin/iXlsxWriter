
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxBorder"/> instance.
/// </summary>
[Serializable]
public partial class XlsxBorderOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxBorderOptions"/> class.
    /// </summary>
    public XlsxBorderOptions()
    {
        Show = null;
        Color = null;
        Width = null;
        Style = null;
        Transparency = null;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxBorder"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBorderOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxBorder"/> instance.
    /// </value>
    public static XlsxBorderOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred border color in an existing <see cref="XlsxBorder"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// Preferred border color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether an existing <see cref="XlsxBorder"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("show")]
    public YesNo? Show { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the preferred absoute strategy for column and row values in an existing <see cref="XlsxBorder"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or one of the enumeration values <see cref="KnownLineStyle"/>. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("style")]
    public KnownLineStyle? Style { get; set; }

    /// <summary>
    /// Gets or sets the preferred border transparency percentage value in an existing <see cref="XlsxBorder"/>" instance.
    /// </summary>
    /// <value>
    /// Preferred border transparency percentage value.
    /// </value>
    [XmlAttribute]
    [JsonProperty("transparency")]
    public int? Transparency { get; set; }

    /// <summary>
    /// Gets or sets the preferred border width in an existing <see cref="XlsxBorder"/>" instance.
    /// </summary>
    /// <value>
    /// Preferred border width.
    /// </value>
    [XmlAttribute]
    [JsonProperty("width")]
    public int? Width { get; set; }

    #endregion
}
