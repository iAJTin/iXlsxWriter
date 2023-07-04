
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Root element of <strong>iTin charting</strong> configuration file that contains a user-defined chart definition.
/// </summary>
/// <remarks>
/// <para>Represents <strong>iTin charting root</strong> element of a configuration file.
/// <code lang="xml" title="iTin Object Element Usage">
/// <![CDATA[
/// <?xml version="1.0" encoding="utf-8">
/// <Chart xmlns="http://schemas.iTin.com/charting/chart/v1.0" BackColor="White">
///   <Size />
///   <Axes />
///   <Border />
///   <Title />
///   <FooterTitle />
///   <Legend />
///   <Plots />
///   <Properties />
/// </Chart>
/// ]]>
/// </code>
/// </para>
/// <para><strong>Attributes</strong></para>
/// <table>
///   <thead>
///     <tr>
///       <th>Attribute</th>
///       <th>Optional</th>
///       <th>Description</th>
///     </tr>
///   </thead>
///   <tbody>
///     <tr>
///       <td><see cref="P:iTin.Charting.Models.Design.ChartModel.BackColor" /></td>
///       <td align="center">Yes</td>
///       <td>Preferred back color. The default is "<b>White</b>".</td>
///     </tr>
///   </tbody>
/// </table>
/// <para><strong>Elements</strong>
/// </para>
/// <list type="table">
///   <listheader>
///     <term>Element</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Border" /></term> 
///     <description>Reference that contains the visual setting of chart border. Includes visibility, shadow definition, line style, width and color.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Title" /></term> 
///     <description>Reference that contains the visual setting of chart title. Includes a text, visibility, orientation, border and font.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.FooterTitle" /></term> 
///     <description>Reference that contains the visual setting of chart footer title. Includes a text, visibility, orientation, border and font.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Legend" /></term> 
///     <description>Reference that contains the visual setting of chart legend. Includes visibility, location, border and font.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Axes" /></term> 
///     <description>Reference that contains the visual setting of chart axes.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Size" /></term> 
///     <description>Reference that contains the width and height of the chart. Allows define custom resolution, for more information, please see <see cref="P:iTin.Charting.Models.Design.SizeModel.Resolution" /> property.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Plots" /></term> 
///     <description>Reference that contains the visual setting of chart plot areas.</description>
///   </item>
///   <item>
///     <term><see cref="P:iTin.Charting.Models.Design.ChartModel.Quality" /></term> 
///     <description>Reference that contains the preferred chart quality definition.</description>
///   </item>
/// </list>
/// </remarks>
public sealed partial class ChartModel : ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultBackColor = "White";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private AxesModel _axes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private SizeModel _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private QualityModel _quality;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private TitleModel _title;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FooterTitleModel _footerTitle;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private PlotsModel _plots;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private BorderModel _border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private LegendModel _legend;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Inicializa un nueva instancia de la clase <see cref="T:iTin.Charting.ComponentModel.ChartModel" />.
    /// </summary>
    public ChartModel()
    {
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
    public bool AxesSpecified => !Axes.IsDefault;

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
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool FooterTitleSpecified => !FooterTitle.IsDefault;

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool LegendSpecified => !Legend.IsDefault;

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool PlotsSpecified => !Plots.IsDefault;

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool SizeSpecified => !Size.IsDefault;

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool TitleSpecified => !Size.IsDefault;

    /// <summary>
    /// Gets a value that indicates the serializer if the referenced item is to be included
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool QualitySpecified => !Quality.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of the chart axes.
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.Models.Design.AxesModel" /> reference that contains the visual setting of the chart axes.
    /// </value>
    public AxesModel Axes
    {
        get
        {
            _axes ??= new AxesModel();
            _axes.SetParent(this);

            return _axes;
        }
        set => _axes = value;
    }

    /// <summary>
    /// Gets or sets preferred background color for this chart. The default is "<b>(White)</b>".
    /// </summary>
    /// <value>
    /// Preferred back color.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultBackColor)]
    public string BackColor { get; set; }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart border.
    /// </summary>
    /// <value>
    /// Reference that contains the visual setting of chart border.
    /// </value>
    public BorderModel Border
    {
        get => _border ??= new BorderModel();
        set => _border = value;
    }

    /// <summary>
    /// Gets or sets preferred chart smoothing quality.
    /// </summary>
    /// <value>
    /// Preferred chart smoothing quality.
    /// </value>
    public QualityModel Quality
    {
        get => _quality ??= new QualityModel();
        set => _quality = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of bottom chart title (footer).
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.ComponentModel.Models.FooterTitleModel" /> reference that contains the visual setting of chart bottom title (footer).
    /// </value>
    public FooterTitleModel FooterTitle
    {
        get => _footerTitle ??= new FooterTitleModel();
        set => _footerTitle = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart legend.
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.ComponentModel.Models.LegendModel" /> reference that contains the visual setting of chart legend.
    /// </value>
    public LegendModel Legend
    {
        get => _legend ??= new LegendModel();
        set => _legend = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of the chart plot areas.
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.Models.Design.PlotsModel" /> reference that contains the visual setting of the chart plot areas.
    /// </value>
    public PlotsModel Plots
    {
        get
        {
            _plots ??= new PlotsModel();
            _plots.SetParent(this);

            return _plots;
        }
        set => _plots = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the chart size information.
    /// </summary>
    /// <value>
    /// Reference that contains the chart size information.
    /// </value>
    public SizeModel Size
    {
        get => _size ??= new SizeModel();
        set => _size = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of chart title.
    /// </summary>
    /// <value>
    /// A <see cref="T:iTin.Charting.ComponentModel.Models.TitleModel" /> reference that contains the visual setting of chart title.
    /// </value>
    public TitleModel Title
    {
        get => _title ??= new TitleModel();
        set => _title = value;
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
        BackColor.Equals(DefaultBackColor) &&
        Title.IsDefault &&
        FooterTitle.IsDefault &&
        Border.IsDefault &&
        Legend.IsDefault &&
        Plots.IsDefault &&
        Quality.IsDefault &&
        Size.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public ChartModel Clone()
    {
        var clonned = (ChartModel)MemberwiseClone();
        clonned.FooterTitle = FooterTitle.Clone();
        clonned.Plots = Plots.Clone();
        clonned.Axes = Axes.Clone();
        clonned.Border = Border.Clone();
        clonned.Legend = Legend.Clone();
        clonned.FooterTitle = FooterTitle.Clone();
        clonned.Size = Size.Clone();
        clonned.Title = Title.Clone();
        clonned.Quality = Quality.Clone();

        return clonned;
    }

    #region [public] (Color) GetBackColor(): Gets a reference to the color structure preferred for chart backcolor
    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for chart backcolor
    /// </summary>
    /// <returns>
    /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);
    #endregion

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
