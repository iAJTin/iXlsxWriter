
namespace iTin.Charting.Models.Design
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
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Helpers;

    using Options;

    /// <summary>
    /// Represents the visual setting of title. Includes a text, visibility, orientation, border and font.
    /// </summary>
    public partial class TitleModel : ITitleModel, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultBackColor = "White";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultText = "";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownTextOrientation DefaultOrientation = KnownTextOrientation.Auto;
        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _backColor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BorderModel _border;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ContentAlignmentModel _alignment;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownTextOrientation _orientation;

        #endregion

        #region constructor/s

        #region [public] TitleModel(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.TitleModel"/> class.
        /// </summary>
        public TitleModel()
        {
            Show = DefaultShow;
            Text = DefaultText;
            Font = FontModel.DefaultFont;
            BackColor = DefaultBackColor;
            Orientation = DefaultOrientation;
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

        #region ITitleModel

        #region public properties

        #region [public] (string) BackColor: Gets or sets preferred back color for this chart title
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets preferred back color for this chart title. The default is "<b>(White)</b>".
        /// </summary>
        /// <value>
        /// Preferred back color.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultBackColor)]
        public string BackColor
        {
            get => _backColor;
            set
            {
                SentinelHelper.ArgumentNull(value, nameof(value));

                _backColor = value;
            }
        }
        #endregion

        #region [public] (BorderModel) Border: Gets or sets a reference that contains the visual setting for border of title
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a reference that contains the visual setting for border of title.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.BorderModel" /> reference that contains the visual setting for border of title.
        /// </value>
        public BorderModel Border
        {
            get => _border ?? (_border = new BorderModel());
            set => _border = value;
        }
        #endregion

        #region [public] (bool) BorderSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool BorderSpecified => !Border.IsDefault;
        #endregion

        #region [public] (FontModel) Font: Gets or sets a reference to the font model defined for this title
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a reference to the font model defined for this title.
        /// </summary>
        /// <value>
        /// Reference to the font model defined for this title.
        /// </value>
        public FontModel Font
        {
            get => _font ?? (_font = new FontModel());
            set => _font = value;
        }
        #endregion

        #region [public] (bool) FontSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool FontSpecified => !Font.IsDefault;
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether to display the border
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that determines whether displays the title. The default is <b>YesNo.Yes</b>.
        /// </summary>
        /// <value>
        /// <b>YesNo.Yes</b> if display the title; otherwise, <b>YesNo.No</b>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo Show { get; set; }
        #endregion

        #region [public] (string) Text: Gets or sets text of title
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets text of title. The default is <b>""</b>.
        /// </summary>
        /// <value>
        /// The text of title.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultText)]
        public string Text { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (Color) GetBackColor(): Gets a reference to the color structure preferred for chart title backcolor
        /// <inheritdoc />
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for chart title backcolor
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color" /> structure that represents a .NET color.
        /// </returns>
        public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) AlignmentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool AlignmentSpecified => !Alignment.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (ContentAlignmentModel) Alignment: Gets or sets preferred location for chart title
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of chart title.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.ContentAlignmentModel" /> reference that contains the visual setting of chart title.
        /// </value>
        public ContentAlignmentModel Alignment
        {
            get => _alignment ?? (_alignment = new ContentAlignmentModel());
            set => _alignment = value;
        }
        #endregion

        #region [public] (KnownTextOrientation) Orientation: Gets or sets the orientation of the text in the axis title
        /// <summary>
        /// Gets or sets the orientation of the text in the axis title. The default value is <b>(<see cref="F:iTin.Charting.Models.Design.KnownTextOrientation.Auto"/>)</b>.
        /// </summary>
        /// <value>
        /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownTextOrientation"/>. 
        /// </value>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultOrientation)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownTextOrientation Orientation
        {
            get => _orientation;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _orientation = value;
            }
        }
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
            Font.IsDefault &&
            Border.IsDefault &&
            Alignment.IsDefault &&
            Show.Equals(DefaultShow) &&
            string.IsNullOrEmpty(Text) &&
            BackColor.Equals(DefaultBackColor) &&
            Orientation.Equals(DefaultOrientation);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(TitleOptions): Apply specified options to this title
        /// <summary>
        /// Apply specified options to this title.
        /// </summary>
        public void ApplyOptions(TitleOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Alignment
            KnownTextAlignment? alignamentOption = options.Alignment;
            bool alignamentHasValue = alignamentOption.HasValue;
            if (alignamentHasValue)
            {
                Alignment.Horizontal = alignamentOption.Value.ToHorizontalAlignment();
            }
            #endregion

            #region BackColor
            string backColorOption = options.BackColor;
            bool backColorHasValue = !backColorOption.IsNullValue();
            if (backColorHasValue)
            {
                BackColor = backColorOption;
            }
            #endregion

            #region Border
            Border.ApplyOptions(options.Border);
            #endregion

            #region Font
            Font.ApplyOptions(options.Font);
            #endregion

            #region Orientation
            KnownTextOrientation? orientationOption = options.Orientation;
            bool orientationHasValue = orientationOption.HasValue;
            if (orientationHasValue)
            {
                Orientation = orientationOption.Value;
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

            #region Text
            string textOption = options.Text;
            bool textHasValue = !textOption.IsNullValue();
            if (textHasValue)
            {
                Text = textOption;
            }
            #endregion
        }
        #endregion

        #region [public] (TitleModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public TitleModel Clone()
        {
            var cloned = (TitleModel)MemberwiseClone();
            cloned.Font = Font.Clone();
            cloned.Border = Border.Clone();
            cloned.Alignment = Alignment.Clone();

            return cloned;
        }
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the backcolor structure preferred for this title
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for this backcolor title.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(BackColor);
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current instance
        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion
    }
}
