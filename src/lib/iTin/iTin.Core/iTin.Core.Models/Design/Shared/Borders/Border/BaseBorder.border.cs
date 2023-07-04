
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Core.Models.Design.Borders;

public partial class BaseBorder : IBorder
{
    #region explicit

    /// <summary>
    /// Gets a value indicating whether this style is an empty border.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty border; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
    bool IBorder.IsEmpty => IsDefault;

    /// <summary>
    /// Sets the element that owns this <see cref="IBorder"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void IBorder.SetOwner(IBorders reference) => SetOwner(reference);

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    public bool IsEmpty => IsDefault;

    /// <summary>
    /// Gets the element that owns this <see cref="IBorder"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IBorders"/> that owns this <see cref="IBorder"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public IBorders Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets preferred border color. The default is <b>Black</b>.
    /// </summary>
    /// <value>
    /// Preferred border color.
    /// </value>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/></exception>
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
    /// Gets or sets preferred border position.
    /// </summary>
    /// <value>
    /// Preferred border position.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [XmlAttribute]
    public KnownBorderPosition Position { get; set; }

    /// <summary>
    /// Gets or sets a value that determines whether to display the border. The default is <see cref="YesNo.No"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display the border; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
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

    /// <summary>
    /// Gets or sets preferred border line style. The default is <see cref="KnownLineStyle.Continuous"/>.
    /// </summary>
    /// <value>
    /// Preferred border line style.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [XmlAttribute]
    [DefaultValue(DefaultLineStyle)]
    public KnownLineStyle Style
    {
        get => _style;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _style = value;
        }
    }

    #endregion

    #region public override readonly properties

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
        Width.Equals(DefaultWidth) &&
        Style.Equals(DefaultLineStyle);

    #endregion

    #region public methods

    /// <summary>
    /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
    /// </returns> 
    public Color GetColor() => ColorHelper.GetColorFromString(Color);

    #endregion
}
