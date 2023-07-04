
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Core.Models.Design;

public partial class BaseBasicContent
{
    /// <summary>
    /// Gets a value indicating whether this style is an empty border.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty border; otherwise, <b>false</b>.
    /// </value>        
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    bool IContent.IsEmpty => IsDefault;

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    [XmlIgnore]
    [JsonIgnore]
    public bool IsEmpty => IsDefault;


    #region public properties

    /// <summary>
    /// Gets or sets preferred alternate content color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred alternate content color.
    /// </value>
    /// <exception cref="ArgumentNullException">The value specified is <b>null</b>.</exception>
    [XmlAttribute]
    public string AlternateColor
    {
        get => string.IsNullOrEmpty(_alternateColor) ? _color : _alternateColor;
        set
        {
            SentinelHelper.ArgumentNull(value, nameof(AlternateColor));

            _alternateColor = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred content color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred content color.
    /// </value>
    /// <exception cref="ArgumentNullException">The value specified is <b>null</b>.</exception>
    [XmlAttribute]
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
    /// Gets or sets a value that determines whether to display the border. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display the border; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    [XmlAttribute]
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

    #endregion

    #region public methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference content</param>
    public void Combine(IContent reference)
    {
        if (AlternateColor.Equals(DefaultColor))
        {
            AlternateColor = reference.AlternateColor;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (Show.Equals(DefaultShow))
        {
            Show = reference.Show;
        }
    }

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents alternate color for this content.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> structure that represents alternate color for this content.
    /// </returns> 
    public Color GetAlternateColor() => ColorHelper.GetColorFromString(AlternateColor);

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this content.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this content.
    /// </returns> 
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion



    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Show.Equals(DefaultShow) &&
        Color.Equals(DefaultColor) &&
        Alignment.IsDefault;
}
