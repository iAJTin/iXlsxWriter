
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
/// Base class for different shadow types.<br/>
/// Which acts as the base class for different shadow types implementations.
/// </summary>
/// <remarks>
///   <para>The following table shows the different colored shadows implementations.</para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="XlsxInnerShadow"/></term>
///       <description>Represents a colored inner shadow.</description>
///     </item>
///     <item>
///       <term><see cref="XlsxOuterShadow"/></term>
///       <description>Represents a colored outer shadow.</description>
///     </item>
///     <item>
///       <term><see cref="XlsxPerspectiveShadow"/></term>
///       <description>Represents a colored perspective shadow.</description>
///     </item>
///   </list>
/// </remarks>
public abstract partial class XlsxBaseShadow
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultBlur = 4;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultAngle = 45;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultOffset = 3;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultColor = "Black";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultTransparency = 60;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _blur;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _angle;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _offset;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _transparency;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxBaseShadow"/> class.
    /// </summary>
    protected XlsxBaseShadow()
    {
        Show = DefaultShow;
        Blur = DefaultBlur;
        Color = DefaultColor;
        Angle = DefaultAngle;
        Offset = DefaultOffset;
        Transparency = DefaultTransparency;
    }

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value indicating shadow type.
    /// </summary>
    /// <value>
    /// One of the <see cref="KnownShadowType"/> values.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public KnownShadowType Type
    {
        get
        {
            var shadowType = GetType().Name;
            return shadowType switch
            {
                nameof(XlsxInnerShadow) => KnownShadowType.Inner,
                nameof(XlsxPerspectiveShadow) => KnownShadowType.Perspective,
                nameof(XlsxOuterShadow) => KnownShadowType.Outer,
                _ => KnownShadowType.Outer
            };
        }
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred shadow angle. The default is <b>45</b>.
    /// </summary>
    /// <value>
    /// Preferred shadow angle.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 359.</exception>
    [XmlAttribute]
    [JsonProperty("angle")]
    [DefaultValue(DefaultAngle)]
    public int Angle
    {
        get => _angle;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Angle), value, 0, 359);

            _angle = value;
        }
    }

    /// <summary>
    /// Gets or sets the preferred blur value. The default is <b>4</b>.
    /// </summary>
    /// <value>
    /// Preferred blur value.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 100.</exception>
    [XmlAttribute]
    [JsonProperty("blur")]
    [DefaultValue(DefaultBlur)]
    public int Blur
    {
        get => _blur;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Blur), value, 0, 100);

            _blur = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred shadow color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred shadow color.
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
    /// Gets or sets the shadow distance. The default is <b>3</b>.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> value that represents the shadow distance
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">The value specified must be between 0 and 200.</exception>
    [XmlAttribute]
    [JsonProperty("offset")]
    [DefaultValue(DefaultOffset)]
    public int Offset
    {
        get => _offset;
        set
        {
            SentinelHelper.ArgumentOutOfRange(nameof(Offset), value, 0, 200);

            _offset = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that determines whether displays shadow. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display shadow; otherwise, <see cref="YesNo.No"/>.
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
    /// Gets or sets the shadow transparency value expresed in %. The default is <b>60</b>.
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
