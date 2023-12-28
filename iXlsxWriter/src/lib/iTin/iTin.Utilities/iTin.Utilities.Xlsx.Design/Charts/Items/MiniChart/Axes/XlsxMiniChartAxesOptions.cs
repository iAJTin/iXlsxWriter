
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// A Specialization of <see cref="BaseOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxMiniChartAxes"/> instance.
/// </summary>
[Serializable]
public class XlsxMiniChartAxesOptions : BaseOptions, ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxMiniChartAxesOptions"/> class.
    /// </summary>
    public XlsxMiniChartAxesOptions()
    {
        Vertical = null;
        Horizontal = null;
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

    #region public static properties

    /// <summary>
    /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxMiniChartAxes"/> instance.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChartAxesOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxMiniChartAxes"/> instance.
    /// </value>
    public static XlsxMiniChartAxesOptions Default => new();

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
    public bool HorizontalSpecified => Horizontal != null;

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
    public bool VerticalSpecified => Vertical != null;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value that contains the visual setting in an existing <see cref="XlsxMiniChartHorizontalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartHorizontalAxisOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("horizontal")]
    public XlsxMiniChartHorizontalAxisOptions Horizontal { get; set; }

    /// <summary>
    /// Gets or sets a reference that contains the visual setting in an existing <see cref="XlsxMiniChartVerticalAxis"/> instance.
    /// </summary>
    /// <value>
    /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxMiniChartVerticalAxisOptions"/> instance.
    /// </value>
    [XmlElement]
    [JsonProperty("vertical")]
    public XlsxMiniChartVerticalAxisOptions Vertical { get; set; }

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Horizontal == null && Vertical == null;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxMiniChartAxesOptions Clone()
    {
        var cloned = (XlsxMiniChartAxesOptions) MemberwiseClone();

        if (Horizontal != null)
        {
            cloned.Horizontal = Horizontal.Clone();
        }

        if (Vertical != null)
        {
            cloned.Vertical = Vertical.Clone();
        }

        return cloned;
    } 

    #endregion
}
