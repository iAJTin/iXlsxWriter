
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Represents a data series of a plot.
/// </summary>
public partial class PlotsModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultBackColor = "White";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private BorderModel _border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private PlotAreasModel _areas;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.PlotsModel" /> class.
    /// </summary>
    public PlotsModel()
    {
        Show = DefaultShow;
        BackColor = DefaultBackColor;
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
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool BorderSpecified => !Border.IsDefault;

    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [Browsable(false)]
    [JsonIgnore]
    public ChartModel Parent { get; private set; }

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool PlotAreasSpecified => _areas != null && _areas.Count > 0;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred back color for this chart plot area. The default is "<b>White</b>".
    /// </summary>
    /// <value>
    /// Preferred back color.
    /// </value>
    [JsonProperty]       
    [XmlAttribute]
    [DefaultValue(DefaultBackColor)]
    public string BackColor { get; set; }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting for common border of plots.
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.ComponentModel.Models.BorderModel" /> reference that contains the visual setting for border of plots.
    /// </value>
    public BorderModel Border
    {
        get => _border ??= new BorderModel();
        set => _border = value; 
    }

    /// <summary>
    /// Gets or sets a value that determines whether the chart plot area is visible. The default value is <see cref="YesNo.Yes" />.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes" />. if the chart plot area is visible; otherwise, <see cref="YesNo.No" />.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    [JsonConverter(typeof(StringEnumConverter))]
    public YesNo Show { get; set; }

    /// <summary>
    /// Gets or sets collection of plots for a chart.
    /// </summary>
    /// <value>
    /// Collection of plots for a chart. Each element represents a chart plot.
    /// </value>
    [XmlArrayItem("PlotArea", typeof(PlotAreaModel))]
    public PlotAreasModel PlotAreas
    {
        get => _areas ??= new PlotAreasModel(this);
        set => _areas = value;
    }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault =>
        Border.IsDefault &&
        PlotAreas.IsDefault &&
        Show.Equals(DefaultShow) &&
        BackColor.Equals(DefaultBackColor);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public PlotsModel Clone() => CopierHelper.DeepCopy(this);

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for chart plot area backcolor
    /// </summary>
    /// <returns>
    /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);

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

    #region internal methods

    /// <summary>
    /// Sets the parent element of the element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    internal void SetParent(ChartModel reference)
    {
        Parent = reference;
    }

    #endregion
}
