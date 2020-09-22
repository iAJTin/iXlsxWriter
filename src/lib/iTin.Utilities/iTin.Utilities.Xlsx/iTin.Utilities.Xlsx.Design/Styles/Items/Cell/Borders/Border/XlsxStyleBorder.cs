
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Helpers;

    /// <summary>
    /// Represents a <b>xlsx</b> generic border.
    /// </summary>
    public partial class XlsxStyleBorder : ICombinable<XlsxStyleBorder>, ICloneable
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

        #region [public] XlsxStyleBorder(): Initializes a new instance of this class
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

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
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

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxStyleBorder>.Combine(XlsxStyleBorder): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference to combine with this instance</param>
        void ICombinable<XlsxStyleBorder>.Combine(XlsxStyleBorder reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxStyleBorder) Default: Returns a new instance containing default cell border settings
        /// <summary>
        /// Returns a new instance containing default cell border settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxStyleBorder"/> reference containing the default cell border settings.
        /// </value>
        public static XlsxStyleBorder Default => new XlsxStyleBorder();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxStyleBorders) Owner: Gets the element that owns this
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
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays this border
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
        #endregion

        #region [public] (KnownBorderPosition) Position: Gets or sets preferred border position
        /// <summary>
        /// Gets or sets preferred border position.
        /// </summary>
        /// <value>
        /// Preferred border position.
        /// </value>
        [XmlAttribute]
        [JsonProperty("position")]
        public KnownBorderPosition Position { get; set; }
        #endregion

        #region [public] (KnownBorderStyle) Style: Gets or sets the preferred cell border style
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

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
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

        #endregion

        #region public methods

        #region [public] (XlsxStyleBorder) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxStyleBorder Clone()
        {
            var cloned = (XlsxStyleBorder) MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }

        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the color structure preferred for border color
        /// <summary>
        /// Gets a reference to the <see cref="System.Drawing.Color"/> structure preferred for border color.
        /// </summary>
        /// <returns>
        /// <see cref="System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(Color);
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxStyleBorderOptions): Apply specified options to this alignment
        ///// <summary>
        ///// Apply specified options to this alignment.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxStyleBorderOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region Color
        //    string colorOption = options.Color;
        //    bool colorHasValue = !colorOption.IsNullValue();
        //    if (colorHasValue)
        //    {
        //        Color = colorOption;
        //    }
        //    #endregion

        //    #region Show
        //    YesNo? showOption = options.Show;
        //    bool showHasValue = showOption.HasValue;
        //    if (showHasValue)
        //    {
        //        Show = showOption.Value;
        //    }
        //    #endregion

        //    #region Style
        //    KnownLineStyle? styleOption = options.Style;
        //    bool styleHasValue = styleOption.HasValue;
        //    if (styleHasValue)
        //    {
        //        Style = styleOption.Value;
        //    }
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxStyleBorder): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxStyleBorder reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Color.Equals(DefaultColor))
            {
                Color = reference.Color;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Style.Equals(DefaultBorderStyle))
            {
                Style = reference.Style;
            }
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxStyleBorders): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxStyleBorders"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxStyleBorders reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
