
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Borders;

/// <summary>
/// A Specialization of <see cref="IBorder"/> interface.<br/>
/// Which acts as the base class for different border configurations.
/// </summary>
public partial class BaseBorder
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Black";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const float DefaultWidth = 1.0f;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownLineStyle DefaultLineStyle = KnownLineStyle.Continuous;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private KnownLineStyle _style;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBorder"/> class.
    /// </summary>
    public BaseBorder()
    {
        Show = DefaultShow;
        Color = DefaultColor;
        Width = DefaultWidth;
        Style = DefaultLineStyle;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default border.
    /// </summary>
    /// <value>
    /// A default border.
    /// </value>
    public static BaseBorder Default => Empty;

    /// <summary>
    /// Gets an empty border.
    /// </summary>
    /// <value>
    /// An empty border.
    /// </value>
    public static BaseBorder Empty => new();

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the width of a border. The default is <b>1</b>.
    /// </summary>
    /// <value>
    /// An <see cref="float"/> value that determines the width of a border.
    /// </value>
    [XmlAttribute]
    [JsonProperty("width")]
    [DefaultValue(DefaultWidth)]
    public float Width { get; set; }

    #endregion
}
