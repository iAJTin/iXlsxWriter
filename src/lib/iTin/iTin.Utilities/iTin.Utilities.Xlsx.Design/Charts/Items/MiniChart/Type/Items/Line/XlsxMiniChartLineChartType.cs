
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
public partial class XlsxMiniChartLineChartType : ICombinable<XlsxMiniChartLineChartType>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartLineSerie _serie;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartLinePoints _points;

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

    #region ICombinable

    #region explicit

    #region (void) ICombinable<XlsxMiniChartLineChartType>.Combine(XlsxMiniChartLineChartType): Creates a new object that is a copy of the current instance
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartLineChartType>.Combine(XlsxMiniChartLineChartType reference) => Combine(reference);
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
    public XlsxMiniChartChartType Parent { get; private set; }

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
    public bool PointsSpecified => !Points.IsDefault;

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
    public bool SerieSpecified => !Serie.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the definition of the significant points of the drawn series.
    /// </summary>
    /// <value>
    /// Definition of the significant points of the drawn series.
    /// </value>
    [XmlElement]
    [JsonProperty("points")]
    public XlsxMiniChartLinePoints Points
    {
        get => _points ??= new XlsxMiniChartLinePoints();
        set => _points = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains definition of the data series to draw.
    /// </summary>
    /// <value>
    /// Definition of the data series to draw.
    /// </value>
    [XmlElement]
    [JsonProperty("serie")]
    public XlsxMiniChartLineSerie Serie
    {
        get
        {
            _serie ??= new XlsxMiniChartLineSerie();
            _serie.SetParent(this);

            return _serie;
        }
        set => _serie = value;
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault => base.IsDefault && Serie.IsDefault && Points.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartLineChartType Clone()
    {
        var cloned = (XlsxMiniChartLineChartType)MemberwiseClone();
        cloned.Points = Points.Clone();
        cloned.Serie = Serie.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartLineTypeOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Points
    //    Points.ApplyOptions(options.Points);
    //    #endregion

    //    #region Serie
    //    Serie.ApplyOptions(options.Serie);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartLineChartType reference)
    {
        if (reference == null)
        {
            return;
        }

        Serie.Combine(reference.Serie);
        Points.Combine(reference.Points);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartLineChartType"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChartChartType reference)
    {
        Parent = reference;
    }

    #endregion
}
