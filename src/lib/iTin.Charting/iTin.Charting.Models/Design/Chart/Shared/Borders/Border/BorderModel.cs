
namespace iTin.Core.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core;
    using iTin.Core.Helpers;

    using Enums;
    using Helpers;
    using Options;

    /// <summary>
    /// Represents the visual setting of chart border. Includes visibility, shadow definition, line style, width and color.
    /// </summary>
    public partial class BorderModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultColor = "Black";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownLineStyle DefaultLineStyle = KnownLineStyle.Continuous;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultWidth = 1;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _color;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Shadow _shadow;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownLineStyle _style;
        #endregion

        #region constructor/s

        #region [public] BorderModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.BorderModel" /> class.
        /// </summary>
        public BorderModel()
        {
            Show = DefaultShow;
            Color = DefaultColor;
            Width = DefaultWidth;
            Style = DefaultLineStyle;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (BorderModel) Default: Gets a default border
        /// <summary>
        /// Gets a default border.
        /// </summary>
        /// <value>
        /// A default border.
        /// </value>
        public static BorderModel Default => Empty;
        #endregion

        #region [public] {static} (BorderModel) Empty: Gets an empty border
        /// <summary>
        /// Gets an empty border.
        /// </summary>
        /// <value>
        /// An empty border.
        /// </value>
        public static BorderModel Empty => new BorderModel();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (BordersModel) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="BordersModel" />.
        /// </summary>
        /// <value>
        /// The <see cref="BordersModel" /> that owns this <see cref="BorderModel" />.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        public BordersModel Owner { get; private set; }
        #endregion

        #region [public] (bool) ShadowSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ShadowSpecified => !Shadow.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets preferred border color
        /// <summary>
        /// Gets or sets preferred border color. The default is <b>Black</b>.
        /// </summary>
        /// <value>
        /// Preferred border color.
        /// </value>
        /// <exception cref="T:System.ArgumentNullException">The value specified is <b>null</b>.</exception>
        [JsonProperty]
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
        #endregion

        #region [public] (KnownBorderPosition) Position: Gets or sets preferred border position
        /// <summary>
        /// Gets or sets preferred border position.
        /// </summary>
        /// <value>
        /// Preferred border position.
        /// </value>
        public KnownBorderPosition Position { get; set; }
        #endregion

        #region [public] (Shadow) Shadow: Gets or sets a reference that contains the visual setting of border's shadow
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of border's shadow.
        /// </summary>
        /// <value>
        /// A <para><see cref="Shadow"/> reference that contains the visual setting of border's shadow.</para>
        /// </value>
        public Shadow Shadow
        {
            get => _shadow ?? (_shadow = new Shadow());
            set => _shadow = value;
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether to display the border
        /// <summary>
        /// Gets or sets a value that determines whether to display the border. The default is <b><see cref="YesNo.No"/></b>
        /// </summary>
        /// <value>
        /// <b><see cref="YesNo.Yes"/></b> if display the border; otherwise, <b><see cref="YesNo.No"/></b>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo Show { get; set; }
        #endregion

        #region [public] (KnownLineStyle) Style: Gets or sets preferred border line style
        /// <summary>
        /// Gets or sets preferred border line style. The default is <b><see cref="KnownLineStyle.Continuous"/></b>.
        /// </summary>
        /// <value>
        /// Preferred border line style.
        /// </value>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineStyle)]
        [JsonConverter(typeof(StringEnumConverter))]
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

        #region [public] (int) Width: Gets or sets the width of the title border
        /// <summary>
        /// Gets or sets the width of the title border. The default is <b>1</b>.
        /// </summary>
        /// <value>
        /// An <see cref="int" /> value that determines the width of the border, in pixels
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultWidth)]
        public int Width { get; set; }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault =>
            Shadow.IsDefault &&
            Show.Equals(DefaultShow) &&
            Color.Equals(DefaultColor) &&
            Style.Equals(DefaultLineStyle) &&
            Width.Equals(DefaultWidth);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(BorderOptions): Apply specified options to this border
        /// <summary>
        /// Apply specified options to this border.
        /// </summary>
        public void ApplyOptions(BorderOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Color
            string colorOption = options.Color;
            bool colorHasValue = !colorOption.IsNullValue();
            if (colorHasValue)
            {
                Color = colorOption;
            }
            #endregion

            #region Position
            KnownBorderPosition? positionOption = options.Position;
            bool positionHasValue = positionOption.HasValue;
            if (positionHasValue)
            {
                Position = positionOption.Value;
            }
            #endregion

            #region Shadow
            Shadow.ApplyOptions(options.Shadow);
            #endregion

            #region Show
            YesNo? showOption = options.Show;
            bool showHasValue = showOption.HasValue;
            if (showHasValue)
            {
                Show = showOption.Value;
            }
            #endregion

            #region Style
            KnownLineStyle? styleOption = options.Style;
            bool styleHasValue = styleOption.HasValue;
            if (styleHasValue)
            {
                Style = styleOption.Value;
            }
            #endregion

            #region Width
            int? widthOption = options.Width;
            bool widthHasValue = widthOption.HasValue;
            if (widthHasValue)
            {
                Width = widthOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] (BorderModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public BorderModel Clone()
        {
            var cloned = (BorderModel)MemberwiseClone();
            cloned.Shadow = Shadow.Clone();

            return cloned;
        }
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the Color structure that represents color for this border
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure that represents color for this border.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Color"/> structure that represents color for this border.
        /// </returns> 
        public Color GetColor() => ColorHelper.GetColorFromString(Color);
        #endregion

        #region [public] (void) SetOwner(SeriesModel): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="T:iTin.Export.Model.ChartSerieModel" />.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        public void SetOwner(BordersModel reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
