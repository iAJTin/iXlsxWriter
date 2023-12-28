
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines a generic chart.
/// </summary>
public partial class XlsxMiniChartRanges : ICombinable<XlsxMiniChartRanges>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseRange _axis;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseRange _data;

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
    /// Combines this instance with reference parameter..
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<XlsxMiniChartRanges>.Combine(XlsxMiniChartRanges reference) => Combine(reference);

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
    public bool AxisSpecified => !Axis.IsDefault;

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
    public bool DataSpecified => !Data.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("axis")]
    public XlsxBaseRange Axis
    {
        get => _axis ??= new XlsxBaseRange();
        set => _axis = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// </value>
    [XmlElement]
    [JsonProperty("data")]
    public XlsxBaseRange Data
    {
        get => _data ??= new XlsxBaseRange();
        set => _data = value;
    }

    #endregion

    #region public override properties

    /// <inheritdoc/>
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Axis.IsDefault && Data.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartRanges Clone()
    {
        var cloned = (XlsxMiniChartRanges)MemberwiseClone();
        cloned.Axis = Axis.Clone();
        cloned.Data = Data.Clone();
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
    public virtual void Combine(XlsxMiniChartRanges reference)
    {
        if (reference == null)
        {
            return;
        }

        Axis.Combine(reference.Axis);
        Data.Combine(reference.Data);
    }

    #endregion
}
