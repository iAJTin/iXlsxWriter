
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core;
using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// Represents a <b>xlsx</b> generic border.
    /// </summary>
    public partial class XlsxBorder : ICombinable<XlsxBorder>, ICloneable
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

        #region [public] XlsxBorder(): Initializes a new instance of this class
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

        #region (object) ICombinable<XlsxBorder>.Combine(XlsxBorder): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference to combine with this instance</param>
        void ICombinable<XlsxBorder>.Combine(XlsxBorder reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxBorder) Default: Returns a new instance containing default border settings
        /// <summary>
        /// Returns a new instance containing default border settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBorder"/> reference containing the default border settings.
        /// </value>
        public static XlsxBorder Default => new XlsxBorder();
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

        #region [public] (KnownLineStyle) Style: Gets or sets the preferred border line style
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
        #endregion

        #region [public] (int) Transparency: Gets or sets the preferred border transparency percentage value
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
        #endregion

        #region [public] (int) Width: Gets or sets the preferred border width
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
            Width.Equals(DefaultWidth) &&
            Style.Equals(DefaultLineStyle) &&
            Transparency.Equals(DefaultTransparency);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBorder) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBorder Clone()
        {
            var cloned = (XlsxBorder) MemberwiseClone();
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

        #region [public] {virtual} (void) ApplyOptions(XlsxBorderOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxBorderOptions options)
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

            #region Transparency
            int? transparencyOption = options.Transparency;
            bool transparencyHasValue = transparencyOption.HasValue;
            if (transparencyHasValue)
            {
                Transparency = transparencyOption.Value;
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

        #region [public] {virtual} (void) Combine(XlsxBorder): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxBorder reference)
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

            if (Style.Equals(DefaultLineStyle))
            {
                Style = reference.Style;
            }

            if (Transparency.Equals(DefaultTransparency))
            {
                Transparency = reference.Transparency;
            }

            if (Width.Equals(DefaultWidth))
            {
                Width = reference.Width;
            }
        }
        #endregion

        #endregion
    }
}
