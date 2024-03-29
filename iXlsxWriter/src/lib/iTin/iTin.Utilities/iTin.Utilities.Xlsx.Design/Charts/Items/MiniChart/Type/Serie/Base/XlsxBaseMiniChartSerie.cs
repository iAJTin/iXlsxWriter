﻿
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Base class for the different types of mini-chart series supported.<br />
/// Which acts as the base class for different mini-chart serie.
/// </summary>
/// <remarks>
/// <para>The following table shows different mini-chart series.</para>
/// <list type="table">
///   <listheader>
///     <term>Class</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="XlsxMiniChartColumnSerie"/></term>
///     <description>Represents a serie for column mini-chart.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartLineSerie"/></term>
///     <description>Represents a serie for line mini-chart.</description>
///   </item>
///   <item>
///     <term><see cref="XlsxMiniChartWinLossSerie"/></term>
///     <description>Represents a serie for win-loss mini-chart.</description>
///   </item>
/// </list>
/// </remarks>
public partial class XlsxBaseMiniChartSerie : ICombinable<XlsxBaseMiniChartSerie>, ICloneable
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

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
    void ICombinable<XlsxBaseMiniChartSerie>.Combine(XlsxBaseMiniChartSerie reference) => Combine(reference);

    #endregion

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred serie color.
    /// </summary>
    /// <value>
    /// Preferred serie color.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
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

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance contains the default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && string.IsNullOrEmpty(Color);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxBaseMiniChartSerie Clone() => (XlsxBaseMiniChartSerie)MemberwiseClone();

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </returns> 
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion

    #region public virtual methods

    ///// <summary>
    ///// Apply specified options to this minichart.
    ///// </summary>
    //public virtual void ApplyOptions(XlsxBaseMiniChartSerieOptions options)
    //{
    //    if (options == null)
    //    {
    //        return;
    //    }

    //    if (options.IsDefault)
    //    {
    //        return;
    //    }

    //    #region Color
    //    string colorOption = options.Color;
    //    bool colorHasValue = !colorOption.IsNullValue();
    //    if (colorHasValue)
    //    {
    //        Color = colorOption;
    //    }
    //    #endregion
    //}

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public virtual void Combine(XlsxBaseMiniChartSerie reference)
    {
        if (reference == null)
        {
            return;
        }

        Color = reference.Color;
    }

    #endregion
}
