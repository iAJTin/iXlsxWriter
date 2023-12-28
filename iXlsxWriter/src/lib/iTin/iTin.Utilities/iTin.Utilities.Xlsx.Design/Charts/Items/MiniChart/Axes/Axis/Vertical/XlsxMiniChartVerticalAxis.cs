
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core;
using iTin.Core.Helpers;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartVerticalAxis : ICombinable<XlsxMiniChartVerticalAxis>, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultMaxValue = "Automatic";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultMinValue = "Automatic";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _maxValue;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]

    private string _minValue;
    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxMiniChartVerticalAxis"/> class.
    /// </summary>
    public XlsxMiniChartVerticalAxis()
    {
        Max = DefaultMaxValue;
        Min = DefaultMinValue;
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
    void ICombinable<XlsxMiniChartVerticalAxis>.Combine(XlsxMiniChartVerticalAxis reference) => Combine(reference);

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Returns a new instance containing default minichart vertical axis definition.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChartVerticalAxis"/> reference containing the default minichart vertical axis definition.
    /// </value>
    public static XlsxMiniChartVerticalAxis Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxMiniChartAxes Parent { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred maximun value for the axis. If you prefer you can manually set a value. The default is <b>Automatic</b>.
    /// </summary>
    /// <value>
    /// Preferred maximun value for the axis.
    /// </value>
    [XmlAttribute]
    [JsonProperty("max")]
    [DefaultValue(DefaultMaxValue)]
    public string Max
    {
        get => _maxValue;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(Max));

            _maxValue = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred minimun value for the axis. If you prefer you can manually set a value. The default is <b>Automatic</b>.
    /// </summary>
    /// <value>
    /// Preferred minimun value for the axis.
    /// </value>
    [XmlAttribute]
    [JsonProperty("min")]
    [DefaultValue(DefaultMinValue)]
    public string Min
    {
        get => _minValue;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(Min));

            _minValue = value;
        }
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Max.Equals(DefaultMaxValue) && Min.Equals(DefaultMinValue);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartVerticalAxis Clone()
    {
        var cloned = (XlsxMiniChartVerticalAxis)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this axis.
    /// </summary>
    public virtual void ApplyOptions(XlsxMiniChartVerticalAxisOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Max
        string maxOption = options.Max;
        bool maxHasValue = !maxOption.IsNullValue();
        if (maxHasValue)
        {
            Max = maxOption;
        }
        #endregion

        #region Min
        string minOption = options.Min;
        bool minHasValue = !minOption.IsNullValue();
        if (minHasValue)
        {
            Min = minOption;
        }
        #endregion
    }

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxMiniChartVerticalAxis reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Max.Equals(DefaultMaxValue))
        {
            Max = reference.Max;
        }

        if (Min.Equals(DefaultMinValue))
        {
            Min = reference.Min;
        }
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxMiniChartVerticalAxis"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetParent(XlsxMiniChartAxes reference)
    {
        Parent = reference;
    }

    #endregion
}
