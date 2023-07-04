
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Represents a <b>xlsx</b> generic border.
/// </summary>
public partial class XlsxStyleBorder
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultWidth = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Black";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownBorderStyle DefaultBorderStyle = KnownBorderStyle.Thin;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownBorderStyle _borderStyle;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStyleBorder"/> class.
    /// </summary>
    public XlsxStyleBorder()
    {
        Show = DefaultShow;
        Color = DefaultColor;
        Style = DefaultBorderStyle;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default cell border settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxStyleBorder"/> reference containing the default cell border settings.
    /// </value>
    public static XlsxStyleBorder Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the element that owns this <see cref="XlsxStyleBorders"/>.
    /// </summary>
    /// <value>
    /// The <see cref="XlsxStyleBorders"/> that owns this <see cref="XlsxStyleBorders"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public XlsxStyleBorders Owner { get; private set; }

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
    /// Gets or sets preferred border position.
    /// </summary>
    /// <value>
    /// Preferred border position.
    /// </value>
    [XmlAttribute]
    [JsonProperty("position")]
    public KnownBorderPosition Position { get; set; }

    /// <summary>
    /// Gets or sets the preferred cell border style. The default value is <see cref="KnownBorderStyle.Thin"/>.
    /// </summary>
    /// <value>
    /// Preferred cell border style
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    [XmlAttribute]
    [JsonProperty("style")]
    [DefaultValue(DefaultBorderStyle)]
    public KnownBorderStyle Style
    {
        get => _borderStyle;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _borderStyle = value;
        }
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Color.Equals(DefaultColor) &&
        Show.Equals(DefaultShow) &&
        Style.Equals(DefaultBorderStyle);

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

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxStyleBorders"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(XlsxStyleBorders reference)
    {
        Owner = reference;
    }

    #endregion
}
