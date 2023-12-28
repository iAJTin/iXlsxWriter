
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadow"/> class.<br/>
/// Represents a outer shadow.
/// </summary>
public partial class XlsxOuterShadow
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultSize = 100;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _size;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxOuterShadow"/> class.
    /// </summary>
    public XlsxOuterShadow()
    {
        Size = DefaultSize;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing a hidden shadow.
    /// </value>
    public static XlsxOuterShadow None => new();

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow DownRight => new() { Show = YesNo.Yes, Angle = 45};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow Down => new() { Show = YesNo.Yes, Angle = 90};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow DownLeft => new() { Show = YesNo.Yes, Angle = 135};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow Right => new() { Show = YesNo.Yes, Angle = 0};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow Center => new() { Show = YesNo.Yes, Blur = 5, Angle = 0, Offset =  0, Size = 102};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow Left => new() { Show = YesNo.Yes, Angle = 180};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow TopRight => new() { Show = YesNo.Yes, Angle = 315};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow Top => new() { Show = YesNo.Yes, Angle = 270};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxOuterShadow TopLeft => new() { Show = YesNo.Yes, Angle = 225};

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred shadow size, expressed in %. The default is <b>100</b>.
    /// </summary>
    /// <value>
    /// Preferred shadow size.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 1 and 200.</exception>
    [XmlAttribute]
    [JsonProperty("size")]
    [DefaultValue(DefaultSize)]
    public int Size
    {
        get => _size;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Size), value, 1, 200);

            _size = value;
        }
    }

    #endregion
}
