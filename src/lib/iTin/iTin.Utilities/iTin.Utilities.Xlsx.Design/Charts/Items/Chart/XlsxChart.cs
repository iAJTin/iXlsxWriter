
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// A Specialization of <see cref="XlsxBaseChart"/> class.<br/>
/// Defines a <b>xlsx</b> chart.
/// </summary>
public partial class XlsxChart : ICombinable<XlsxChart>, IParent
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultBackColor = "White";

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxSize _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBorder _border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartAxes _axes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartTitle _title;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartLegend _legend;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxShapeEffects _shapeEffects;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxChartPlotsCollection _plots;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChart"/> class.
    /// </summary>
    public XlsxChart()
    {
        BackColor = DefaultBackColor;
    }

    #endregion

    #region interfaces

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxChart>.Combine(XlsxChart reference) => Combine(reference);

    #endregion

    #endregion

    #region public new readonly static properties

    /// <summary>
    /// Gets default chart configuration.
    /// </summary>
    /// <value>
    /// Default chart configuration.
    /// </value>
    public new static XlsxMiniChart Default => new();

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
    public bool AxesSpecified => !Axes.IsDefault;

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
    public bool BorderSpecified => !Border.IsDefault;

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
    public bool LegendSpecified => !Legend.IsDefault;

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
    public bool PlotsSpecified => !Plots.IsDefault;

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
    public bool SizeSpecified => !Size.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of the chart axes.
    /// </summary>
    /// <value>
    /// Reference that contains the visual setting of the chart axes.
    /// </value>
    [XmlElement]
    [JsonProperty("axes")]
    public XlsxChartAxes Axes
    {
        get
        {
            _axes ??= new XlsxChartAxes();
            _axes.SetParent(this);

            return _axes;
        }
        set => _axes = value;
    }

    /// <summary>
    /// Gets or sets preferred back color for this chart. The default is <b>White</b>.
    /// </summary>
    /// <value>
    /// Preferred back color. 
    /// </value>
    [XmlAttribute]
    [JsonProperty("backcolor")]
    [DefaultValue(DefaultBackColor)]
    public string BackColor { get; set; }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart border.
    /// </summary>
    /// <value>
    /// Reference that contains the visual setting of chart border.
    /// </value>
    [XmlElement]
    [JsonProperty("border")]
    public XlsxBorder Border
    {
        get => _border ??= XlsxBorder.Default;
        set => _border = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart legend.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartLegend"/> reference that contains the visual setting of chart legend.
    /// </value>
    public XlsxChartLegend Legend
    {
        get => _legend ??= new XlsxChartLegend();
        set => _legend = value;
    }

    /// <summary>
    /// Gets or sets a value containing the chart plots collection settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartPlotsCollection"/> reference containing the chart plots collection settings.
    /// </value>
    [JsonProperty("plots")]
    [XmlArrayItem("Plot", typeof(XlsxChartPlot))]
    public XlsxChartPlotsCollection Plots
    {
        get => _plots ??= new XlsxChartPlotsCollection(this);
        set => _plots = value;
    }

    /// <summary>
    /// Gets or sets a value containing chart size.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSize"/> reference containing shape size.
    /// </value>
    [XmlElement]
    [JsonProperty("size")]
    public XlsxSize Size
    {
        get => _size ??= new XlsxSize();
        set => _size = value;
    }

    /// <summary>
    /// Gets or sets a value containing shape effects reference.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseShadow"/> reference containing shape effects reference.
    /// </value>
    [XmlElement]
    [JsonProperty("chart-effects")]
    public XlsxShapeEffects Effects
    {
        get => _shapeEffects ??= XlsxShapeEffects.Default;
        set => _shapeEffects = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart title.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChartTitle"/> reference that contains the visual setting of chart title.
    /// </value>
    public XlsxChartTitle Title
    {
        get => _title ??= new XlsxChartTitle();
        set => _title = value;
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault =>
        base.IsDefault &&
        Axes.IsDefault &&
        Plots.IsDefault &&
        Title.IsDefault &&
        Border.IsDefault &&
        Legend.IsDefault &&
        Effects.IsDefault &&
        BackColor.Equals(DefaultBackColor);

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for background color for this chart.
    /// </summary>
    /// <returns>
    /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this style.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxCellStyleOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Content
    //    Content.ApplyOptions(options.Content);
    //    #endregion

    //    #region Font
    //    Font.ApplyOptions(options.Font);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxChart reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);

        if (BackColor.Equals(DefaultBackColor))
        {
            BackColor = reference.BackColor;
        }

        //Size.Combine(reference.Size);
        Axes.Combine(reference.Axes);
        Plots.Combine(reference.Plots);
        Title.Combine(reference.Title);
        Border.Combine(reference.Border);
        Legend.Combine(reference.Legend);
        Effects.Combine(reference.Effects);
    }

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxChart Clone()
    {
        var cloned = (XlsxChart)base.Clone();
        cloned.Axes = Axes.Clone();
        cloned.Size = Size.Clone();
        cloned.Plots = Plots.Clone();
        cloned.Border = Border.Clone();
        cloned.Legend = Legend.Clone();
        cloned.Effects = Effects.Clone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }

    #endregion
}
