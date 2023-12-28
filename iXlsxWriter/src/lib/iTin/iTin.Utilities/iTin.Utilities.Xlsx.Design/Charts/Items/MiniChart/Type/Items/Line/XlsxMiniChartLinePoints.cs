
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartLinePoints : ICombinable<XlsxMiniChartLinePoints>
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartMarkersPoint _markers;

    #endregion

    #region interfaces

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartLinePoints>.Combine(XlsxMiniChartLinePoints reference) => Combine(reference);

    #endregion

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool MarkersSpecified => !Markers.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("markers")]
    public XlsxMiniChartMarkersPoint Markers
    {
        get => _markers ??= new XlsxMiniChartMarkersPoint();
        set => _markers = value;
    }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Markers.IsDefault;

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxMiniChartLinePoints Clone()
    {
        var cloned = (XlsxMiniChartLinePoints)MemberwiseClone();
        cloned.Markers = Markers.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartLinePointsOptions options)
    //{
    //    base.ApplyOptions(options);
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartLinePoints reference)
    {
        base.Combine(reference);
    }

    #endregion
}
