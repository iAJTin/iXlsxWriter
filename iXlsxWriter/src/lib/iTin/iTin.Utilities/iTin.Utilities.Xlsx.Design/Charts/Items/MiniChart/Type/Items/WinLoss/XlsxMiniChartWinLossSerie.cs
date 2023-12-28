
using System;
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartWinLossSerie : ICombinable<XlsxMiniChartWinLossSerie>, ICloneable
{
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

    #region ICombinable<XlsxMiniChartWinLossSerie>

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public void Combine(XlsxMiniChartWinLossSerie reference)
    {
    }

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
    public XlsxMiniChartWinLossChartType Parent { get; private set; }

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxMiniChartWinLossSerie Clone() => (XlsxMiniChartWinLossSerie)MemberwiseClone();

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartWinLossSerie"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChartWinLossChartType reference)
    {
        Parent = reference;
    }

    #endregion
}
