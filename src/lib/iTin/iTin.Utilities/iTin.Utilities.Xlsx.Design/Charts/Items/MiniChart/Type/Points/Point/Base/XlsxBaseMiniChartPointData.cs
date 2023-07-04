
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Base class for the different mini-chart data point settings.<br />
/// Which acts as the base class for different mini-chart data point.
/// </summary>
/// <remarks>
/// <para>The following table shows different mini-chart data point.</para>
/// <list type="table">
///   <listheader>
///     <term>Class</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="XlsxMiniChartFirstPoint"/></term>
///     <description>Represents a first data point settings.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartHighPoint"/></term>
///     <description>Represents a high data point settings.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartLastPoint"/></term>
///     <description>Represents a last data point settings.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartLowPoint"/></term>
///     <description>Represents a low data point settings.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartMarkersPoint"/></term>
///     <description>Represents a markers data point settings.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartNegativePoint"/></term>
///     <description>Represents a negative data point settings.</description>
///   </item>
/// </list>
/// </remarks>
public partial class XlsxBaseMiniChartPointData : ICombinable<XlsxBaseMiniChartPointData>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private fields members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxBaseMiniChartPointData"/> class.
    /// </summary>
    protected XlsxBaseMiniChartPointData()
    {
        Show = DefaultShow;
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

    #region ICombinable

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxBaseMiniChartPointData>.Combine(XlsxBaseMiniChartPointData reference) => Combine(reference);

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

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred point color.
    /// </summary>
    /// <value>
    /// Preferred font color.
    /// </value>
    [XmlAttribute]
    [JsonProperty("color")]
    public string Color
    {
        get => _color;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(Color));

            _color = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays this point on mini-chart. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if displays this point on mini-chart; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("show")]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => _show;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _show = value;
        }
    }

    #endregion

    #region public override properties

    /// <inheritdoc/>
    /// <summary>
    /// Gets a value indicating whether this instance contains the default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Show.Equals(DefaultShow) && string.IsNullOrEmpty(Color);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxBaseMiniChartPointData Clone() => (XlsxBaseMiniChartPointData)MemberwiseClone();

    /// <summary>
    /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for this mini-chart data point.
    /// </summary>
    /// <returns>
    /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxBaseMiniChartPointData reference)
    {
        if (reference == null)
        {
            return;
        }

        Color = reference.Color;

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }

    }

    #endregion
}
