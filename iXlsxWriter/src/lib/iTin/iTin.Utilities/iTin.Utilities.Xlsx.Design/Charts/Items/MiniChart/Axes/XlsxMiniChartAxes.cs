
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
public partial class XlsxMiniChartAxes : ICombinable<XlsxMiniChartAxes>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartHorizontalAxis _horizontalAxis;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartVerticalAxis _verticalAxis;

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
    void ICombinable<XlsxMiniChartAxes>.Combine(XlsxMiniChartAxes reference) => Combine(reference);

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing default minichart axes settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChartAxes"/> reference containing the default minichart axes settings.
    /// </value>
    public static XlsxMiniChartAxes Default => new();

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
    public bool HorizontalSpecified => !Horizontal.IsDefault;

    /// <summary>
    /// Gets the parent element.
    /// </summary>
    /// <value>
    /// The element that represents the container element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxMiniChart Parent { get; private set; }

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
    public bool VerticalSpecified => !Vertical.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of horizontal axis.
    /// </summary>
    /// <value>
    /// Visual setting of horizontal axis.
    /// </value>
    [XmlElement]
    [JsonProperty("horizontal")]
    public XlsxMiniChartHorizontalAxis Horizontal
    {
        get
        {
            _horizontalAxis ??= new XlsxMiniChartHorizontalAxis();
            _horizontalAxis.SetParent(this);

            return _horizontalAxis;
        }
        set => _horizontalAxis = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting of vertical axis.
    /// </summary>
    /// <value>
    /// Visual setting of vertical axis.
    /// </value>
    [XmlElement]
    [JsonProperty("vertical")]
    public XlsxMiniChartVerticalAxis Vertical
    {
        get
        {
            _verticalAxis ??= new XlsxMiniChartVerticalAxis();
            _verticalAxis.SetParent(this);

            return _verticalAxis;
        }
        set => _verticalAxis = value;
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Horizontal.IsDefault && Vertical.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartAxes Clone()
    {
        var cloned = (XlsxMiniChartAxes)MemberwiseClone();
        cloned.Vertical = Vertical.Clone();
        cloned.Horizontal = Horizontal.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this axes.
    /// </summary>
    public virtual void ApplyOptions(XlsxMiniChartAxesOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Horizontal
        Horizontal.ApplyOptions(options.Horizontal);
        #endregion

        #region Vertical
        Vertical.ApplyOptions(options.Vertical);
        #endregion
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartAxes reference)
    {
        if (reference == null)
        {
            return;
        }

        Vertical.Combine(reference.Vertical);
        Horizontal.Combine(reference.Horizontal);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartAxes"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChart reference)
    {
        Parent = reference;
    }

    #endregion
}
