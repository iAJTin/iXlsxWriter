
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
/// Represents a perspective shadow.
/// </summary>
public partial class XlsxPerspectiveShadow 
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
    /// Initializes a new instance of the <see cref="XlsxPerspectiveShadow"/> class.
    /// </summary>
    public XlsxPerspectiveShadow()
    {
        Size = DefaultSize;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing a hidden shadow.
    /// </value>
    public static XlsxPerspectiveShadow None => new();

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxOuterShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow TopLeft => new() {Show = YesNo.Yes, Angle = 225, Blur = 6, Offset = 0, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow TopRight => new() { Show = YesNo.Yes, Angle = 315, Blur = 6, Offset = 0, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow DownLeft => new() { Show = YesNo.Yes, Angle = 135, Blur = 6, Offset = 1, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow DownRight => new() { Show = YesNo.Yes, Blur = 6, Offset = 1, Transparency = 80};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPerspectiveShadow"/> reference containing the shadow.
    /// </value>
    public static XlsxPerspectiveShadow Down => new() {Show = YesNo.Yes, Angle = 90, Blur = 12, Offset = 25, Transparency = 85};

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
