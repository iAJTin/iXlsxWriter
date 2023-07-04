
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChartSize"/> instance.
/// </summary>
/// </summary>
[Serializable]
public class XlsxMiniChartSizeOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxMiniChartSizeOptions"/> class.
    /// </summary>
    public XlsxMiniChartSizeOptions()
    {
        VerticalCells = null;
        HorizontalCells = null;
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
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChartSize"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChartSizeOptions"/> reference containing set of default options.
    /// </value>
    public static XlsxMiniChartSizeOptions Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the vertical cells in existing <see cref="XlsxMiniChartSize"/>" instance.
    /// </summary>
    /// <value>
    /// Merge cells.
    /// </value>
    [XmlAttribute]
    [JsonProperty("vertical-cells")]
    public int? VerticalCells { get; set; }

    /// <summary>
    /// Gets or sets the horizontal cells in existing <see cref="XlsxMiniChartSize"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, Preferred cell merge orientation.
    /// </value>
    [XmlAttribute]
    [JsonProperty("horizontal-cells")]
    public int? HorizontalCells { get; set; }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && HorizontalCells == null && VerticalCells == null;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartSizeOptions Clone() => (XlsxMiniChartSizeOptions) MemberwiseClone();

    #endregion
}
