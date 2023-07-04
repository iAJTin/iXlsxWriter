
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
public partial class XlsxMiniChartColumnChartType : ICombinable<XlsxMiniChartColumnChartType>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartColumnSerie _serie;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartColumnPoints _points;

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

    #region (void) ICombinable<XlsxMiniChartColumnChartType>.Combine(XlsxMiniChartColumnChartType): Creates a new object that is a copy of the current instance
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartColumnChartType>.Combine(XlsxMiniChartColumnChartType reference) => Combine(reference);
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
    public XlsxMiniChartColumnPoints Points
    {
        get => _points ??= new XlsxMiniChartColumnPoints();
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
    public XlsxMiniChartColumnSerie Serie
    {
        get
        {
            _serie ??= new XlsxMiniChartColumnSerie();
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
    public XlsxMiniChartColumnChartType Clone()
    {
        var cloned = (XlsxMiniChartColumnChartType)MemberwiseClone();
        cloned.Serie = Serie.Clone();
        cloned.Points = Points.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartColumnTypeOptions options)
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
    public virtual void Combine(XlsxMiniChartColumnChartType reference)
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
    /// Sets the element that owns this <see cref="XlsxMiniChartColumnChartType"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChartChartType reference)
    {
        Parent = reference;
    }

    #endregion
}
