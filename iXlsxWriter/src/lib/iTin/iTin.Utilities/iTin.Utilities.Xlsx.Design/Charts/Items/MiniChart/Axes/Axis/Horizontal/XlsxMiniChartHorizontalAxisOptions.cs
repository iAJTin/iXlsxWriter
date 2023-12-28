
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
/// </summary>
[Serializable]
public class XlsxMiniChartHorizontalAxisOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxMiniChartHorizontalAxisOptions"/> class.
    /// </summary>
    public XlsxMiniChartHorizontalAxisOptions()
    {
        Show = null;
        Type = null;
        Color = null;
        RightToLeft = null;
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChartHorizontalAxisOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </value>
    public static XlsxMiniChartHorizontalAxisOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the preferred axis color in an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartHorizontalAxisOptions"/> instance.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the data are drawn from right to left in an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartHorizontalAxisOptions"/> instance.
    /// </value>
    [XmlAttribute]
    [JsonProperty("righttoleft")]
    public YesNo? RightToLeft { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this axis is shown in an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartHorizontalAxisOptions"/> instance.
    /// </value>
    [XmlAttribute]
    [JsonProperty("show")]
    public YesNo? Show { get; set; }

    /// <summary>
    /// Gets or sets a value that contains the preferred axis type in an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartHorizontalAxisOptions"/> instance.
    /// </value>
    [XmlAttribute]
    [JsonProperty("axis-type")]
    public MiniChartHorizontalAxisType? Type { get; set; }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Color == null && RightToLeft == null && Show == null && Type == null;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartHorizontalAxisOptions Clone() => (XlsxMiniChartHorizontalAxisOptions) MemberwiseClone();

    #endregion
}
