
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartLineSerie : ICombinable<XlsxMiniChartLineSerie>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultWidth = "0.75";

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxMiniChartLineSerie"/> class.
    /// </summary>
    public XlsxMiniChartLineSerie()
    {
        Width = DefaultWidth;
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

    #region ICombinable<XlsxMiniChartLineSerie>

    #region public methods

    #region [public] (void) Combine(XlsxMiniChartLineSerie): Combines this instance with reference parameter
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public void Combine(XlsxMiniChartLineSerie reference)
    {
    }
    #endregion

    #endregion

    #endregion

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element.
    /// </summary>
    /// <value>
    /// The element that represents the container element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxMiniChartLineChartType Parent { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred line width. The default is <b>0.75</b>.
    /// </summary>
    /// <value>
    /// Preferred line width.
    /// </value>
    [XmlAttribute]
    [JsonProperty("width")]
    [DefaultValue(DefaultWidth)]
    public string Width { get; set; }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Width.Equals(DefaultWidth);

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxMiniChartLineSerie Clone() => (XlsxMiniChartLineSerie)MemberwiseClone();

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartLineSerie"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChartLineChartType reference)
    {
        Parent = reference;
    }

    #endregion
}
