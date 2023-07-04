
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellPattern : IPattern
{
    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
    bool IPattern.IsEmpty => IsDefault;

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
    /// </value>
    public override bool IsDefault => Color.Equals(DefaultColor) && PatternType.Equals(DefaultPatternType);

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    public bool IsEmpty => IsDefault;

    /// <summary>
    /// Gets or sets preferred pattern color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred pattern color.
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
    /// Gets or sets preferred pattern type. The default is <see cref="KnownPatternType.Solid"/>.
    /// </summary>
    /// <value>
    /// Preferred pattern type. 
    /// </value>
    /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
    [XmlAttribute]
    [JsonProperty("patterntype")]
    [DefaultValue(DefaultPatternType)]
    public KnownPatternType PatternType
    {
        get => _type;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _type = value;
        }
    }

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </returns> 
    public Color GetColor() => ColorHelper.GetColorFromString(Color);
}
