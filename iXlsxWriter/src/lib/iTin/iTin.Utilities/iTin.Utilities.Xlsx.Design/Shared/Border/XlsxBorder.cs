
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> generic border.
/// </summary>
public partial class XlsxBorder
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultWidth = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultTransparency = 0;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Black";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownLineStyle DefaultLineStyle = KnownLineStyle.Continuous;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _width;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _transparency;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownLineStyle _lineStyle;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxBorder"/> class.
    /// </summary>
    public XlsxBorder()
    {
        Show = DefaultShow;
        Color = DefaultColor;
        Width = DefaultWidth;
        Style = DefaultLineStyle;
        Transparency = DefaultTransparency;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default border settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBorder"/> reference containing the default border settings.
    /// </value>
    public static XlsxBorder Default => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred border color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred border color.
    /// </value>
    /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
    [XmlAttribute]
    [JsonProperty("color")]
    [DefaultValue(DefaultColor)]
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
    /// Gets or sets a value that determines whether displays this border. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> displays this border; Otherwise, <see cref="YesNo.No"/>. 
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

    /// <summary>
    /// Gets or sets the preferred border line style. The default value is <see cref="KnownLineStyle.Continuous"/>.
    /// </summary>
    /// <value>
    /// Preferred border line style.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("style")]
    [DefaultValue(DefaultLineStyle)]
    public KnownLineStyle Style
    {
        get => _lineStyle;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _lineStyle = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred border transparency percentage value. The default value is <b>0</b>.
    /// </summary>
    /// <value>
    /// Preferred transparency border transparency percentage value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
    [XmlAttribute]
    [JsonProperty("transparency")]
    [DefaultValue(DefaultTransparency)]
    public int Transparency
    {
        get => _transparency;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Transparency), value, 0, 100);
            _transparency = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred border width. The default value is <b>1</b>.
    /// </summary>
    /// <value>
    /// Preferred border width.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
    [XmlAttribute]
    [JsonProperty("width")]
    [DefaultValue(DefaultWidth)]
    public int Width
    {
        get => _width;
        set
        {
            SentinelHelper.ArgumentLessThan(nameof(Width), value, 1);
            _width = value;
        }
    }

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for border color.
    /// </summary>
    /// <returns>
    /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion
}
