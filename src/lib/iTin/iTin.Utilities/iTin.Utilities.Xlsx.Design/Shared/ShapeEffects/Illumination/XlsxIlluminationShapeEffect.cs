
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
/// Represents a <b>xlsx</b> illumination shape effect.
/// </summary>
public partial class XlsxIlluminationShapeEffect 
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultSize = 1;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultTransparency = 60;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Transparent";

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _transparency;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxIlluminationShapeEffect"/> class.
    /// </summary>
    public XlsxIlluminationShapeEffect()
    {
        Size = DefaultSize;
        Show = DefaultShow;
        Color = DefaultColor;
        Transparency = DefaultTransparency;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing a hidden shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect None => new();

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis1Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#1464F4", Transparency = 60};

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis1Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#1464F4", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis1Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#1464F4", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis1Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#1464F4", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis2Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#FF7000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis2Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#FF7000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis2Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#FF7000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis2Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#FF7000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis3Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#A5A5A5", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis3Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#A5A5A5", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis3Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#A5A5A5", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis3Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#A5A5A5", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis4Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#FFF000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis4Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#FFF000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis4Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#FFF000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis4Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#FFF000", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis5Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#2D9DFF", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis5Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#2D9DFF", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis5Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#2D9DFF", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis5Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#2D9DFF", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis6Points5 => new() { Show = YesNo.Yes, Size = 5, Color = "#68D321", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis6Points8 => new() { Show = YesNo.Yes, Size = 8, Color = "#68D321", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis6Points11 => new() { Show = YesNo.Yes, Size = 11, Color = "#68D321", Transparency = 60 };

    /// <summary>
    /// Returns a new instance containig the shadow.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxIlluminationShapeEffect"/> reference containing the shadow.
    /// </value>
    public static XlsxIlluminationShapeEffect Emphasis6Points18 => new() { Show = YesNo.Yes, Size = 18, Color = "#68D321", Transparency = 60 };

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred illumination color. The default is <b>Transparent</b>.
    /// </summary>
    /// <value>
    /// Preferred illumination color.
    /// </value>
    /// <exception cref="ArgumentNullException">The value specified is <b>null</b>.</exception>
    [XmlAttribute]
    [JsonProperty("color")]
    [DefaultValue(DefaultColor)]
    public string Color
    {
        get => _color;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(value));

            _color = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred illumination effect size, expressed in points. The default is <b>1</b>.
    /// </summary>
    /// <value>
    /// Preferred illumination effect size.
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

    /// <summary>
    /// Gets or sets a value that determines whether displays illumination effect. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display illumination effect; otherwise, <see cref="YesNo.No"/>.
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
    /// Gets or sets the illumination effect transparency value expresed in %. The default is <b>60</b>.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> value that represents the shadow transparency value.
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

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for shadow color.
    /// </summary>
    /// <returns>
    /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
    /// </returns>
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion
}
