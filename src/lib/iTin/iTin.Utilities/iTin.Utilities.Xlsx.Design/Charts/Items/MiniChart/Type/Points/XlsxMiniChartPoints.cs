
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
public partial class XlsxMiniChartPoints : ICombinable<XlsxMiniChartPoints>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartFirstPoint _first;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartHighPoint _high;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartLastPoint _last;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartLowPoint _low;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxMiniChartNegativePoint _negative;

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
    void ICombinable<XlsxMiniChartPoints>.Combine(XlsxMiniChartPoints reference) => Combine(reference);

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
    public bool FirstSpecified => !First.IsDefault;

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
    public bool HighSpecified => !High.IsDefault;

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
    public bool LastSpecified => !Last.IsDefault;

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
    public bool LowSpecified => !Low.IsDefault;

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
    public bool NegativeSpecified => !Negative.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("first")]
    public XlsxMiniChartFirstPoint First
    {
        get => _first ??= new XlsxMiniChartFirstPoint();
        set => _first = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("high")]
    public XlsxMiniChartHighPoint High
    {
        get => _high ??= new XlsxMiniChartHighPoint();
        set => _high = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("last")]
    public XlsxMiniChartLastPoint Last
    {
        get => _last ??= new XlsxMiniChartLastPoint();
        set => _last = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("low")]
    public XlsxMiniChartLowPoint Low
    {
        get => _low ??= new XlsxMiniChartLowPoint();
        set => _low = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("negative")]
    public XlsxMiniChartNegativePoint Negative
    {
        get => _negative ??= new XlsxMiniChartNegativePoint();
        set => _negative = value;
    }

    #endregion

    #region public override properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        First.IsDefault &&
        High.IsDefault &&
        Last.IsDefault &&
        Low.IsDefault &&
        Negative.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartPoints Clone()
    {
        var cloned = (XlsxMiniChartPoints)MemberwiseClone();
        cloned.First = First.Clone();
        cloned.High = High.Clone();
        cloned.Last = Last.Clone();
        cloned.Low = Low.Clone();
        cloned.Negative = Negative.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxMiniChartPointsOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region First
    //    First.ApplyOptions(options.First);
    //    #endregion

    //    #region High
    //    High.ApplyOptions(options.High);
    //    #endregion

    //    #region Last
    //    Last.ApplyOptions(options.Last);
    //    #endregion

    //    #region Low
    //    Low.ApplyOptions(options.Low);
    //    #endregion

    //    #region Negative
    //    Negative.ApplyOptions(options.Negative);
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxMiniChartPoints reference)
    {
        if (reference == null)
        {
            return;
        }

        First.Combine(reference.First);
        High.Combine(reference.High);
        Last.Combine(reference.Last);
        Low.Combine(reference.Low);
        Negative.Combine(reference.Negative);
    }

    #endregion
}
