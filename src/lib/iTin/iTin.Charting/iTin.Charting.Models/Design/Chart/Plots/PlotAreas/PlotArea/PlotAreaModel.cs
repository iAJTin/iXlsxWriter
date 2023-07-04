
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents a chart plot area.
/// </summary>
public partial class PlotAreaModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultUseSecondaryAxis = YesNo.No;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private SeriesModel _series;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" /> class.
    /// </summary>
    public PlotAreaModel()
    {
        UseSecondaryAxis = DefaultUseSecondaryAxis;
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

    #region public readonly properties

    /// <summary>
    /// Gets the element that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" />.
    /// </summary>
    /// <value>
    /// The <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreasModel" /> that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreaModel" />.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    public PlotAreasModel Owner { get; private set; }

    /// <summary>
    /// Gets a value that indicates whether the collection of series has elements. This property is used by the serializer to not serialize an empty collection.
    /// </summary>
    /// <value>
    /// <b>true</b> if there are series in the collection; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool SeriesSpecified => _series != null && _series.Count > 0;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets plot's name of plot area.
    /// </summary>
    /// <value>
    /// Plot's name of plot.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets collection of series for a plot area.
    /// </summary>
    /// <value>
    /// Collection of data series for a plot. Each element represents a data serie of a plot area.
    /// </value>
    [XmlArrayItem("Serie", typeof(SerieModel))]
    public SeriesModel Series
    {
        get => _series ??= new SeriesModel(this);
        set => _series = value;
    }

    /// <summary>
    /// Gets or sets a value that determines whether the plot area uses secondary axis.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes" /> if plot area uses secondary axis; otherwise, <see cref="YesNo.No" />.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultUseSecondaryAxis)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo UseSecondaryAxis { get; set; }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault => Series.Count.Equals(0) && UseSecondaryAxis.Equals(DefaultUseSecondaryAxis);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public PlotAreaModel Clone() => CopierHelper.DeepCopy(this);

    /// <summary>
    /// Sets the element that owns this <see cref="T:iTin.Charting.ComponentModel.Models.PlotAreasModel" />.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    public void SetOwner(PlotAreasModel reference)
    {
        Owner = reference;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current object.
    /// </returns>
    public override string ToString() => !IsDefault ? "Modified" : "Default";

    #endregion
}
