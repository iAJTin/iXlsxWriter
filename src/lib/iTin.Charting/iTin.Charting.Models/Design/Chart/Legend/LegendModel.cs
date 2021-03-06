﻿
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
    /// Represents the visual setting of chart legend. Includes visibility, location, border and font.
    /// </summary>
    public partial class LegendModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultBackColor = "White";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownLegendLocation DefaultLocation = KnownLegendLocation.Bottom;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownTextAlignment DefaultAlignment = KnownTextAlignment.Center;

        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BorderModel _border;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _backColor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownLegendLocation _location;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownTextAlignment _alignment;

        #endregion

        #region constructor/s

        #region [public] LegendModel(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.LegendModel" /> class.
        /// </summary>
        public LegendModel()
        {
            Show = DefaultShow;
            Location = DefaultLocation;
            BackColor = DefaultBackColor;
            Alignment = DefaultAlignment;
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

        #region public readonly properties

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

        #endregion

        #region public properties

        #region [public] (KnownTextAlignment) Alignment: Gets or sets preferred location for chart legend
        /// <summary>
        /// Gets or sets preferred horizontal alignment for chart legend. The default value is <b>(<see cref="F:iTin.Charting.Models.Design.KnownHorizontalAlignment.Center" />)</b>.
        /// </summary>
        /// <value>
        /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownHorizontalAlignment" />. 
        /// </value>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultAlignment)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownTextAlignment Alignment
        {
            get => _alignment;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _alignment = value;
            }
        }
        #endregion

        #region [public] (string) BackColor: Gets or sets preferred back color for this chart legend
        /// <summary>
        /// Gets or sets preferred back color for this chart legend. The default is <b>(White)</b>.
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

        #region [public] (BorderModel) Border: Gets or sets a reference that contains the visual setting of legend border
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of legend border.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.BorderModel" /> reference that contains the visual setting of legend border.
        /// </value>
        public BorderModel Border
        {
            get => _border ?? (_border = new BorderModel());
            set => _border = value;
        }
        #endregion

        #region [public] (FontModel) Font: Gets or sets a reference for font model defined for this legend
        /// <summary>
        /// Gets or sets a reference for font model defined for this legend.
        /// </summary>
        /// <value>
        /// Reference for font model defined for this legend.
        /// </value>
        public FontModel Font
        {
            get => _font ?? (_font = new FontModel());
            set => _font = value;
        }
        #endregion

        #region [public] (KnownLegendLocation) Location: Gets or sets preferred location for chart legend
        /// <summary>
        /// Gets or sets preferred location for chart legend. The default value is <b>(<see cref="F:iTin.Charting.Models.Design.KnownLegendLocation.Bottom" />)</b>.
        /// </summary>
        /// <value>
        /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownLegendLocation" />. 
        /// </value>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLocation)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownLegendLocation Location
        {
            get => _location;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _location = value;
            }
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays the chart legend
        /// <summary>
        /// Gets or sets a value that determines whether displays the chart legend. The default is <b>YesNo.No</b>.
        /// </summary>
        /// <value>
        /// <b>YesNo.Yes</b> if display the chart legend; otherwise, <b>YesNo.No</b>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo Show { get; set; }
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
            Show.Equals(DefaultShow) &&
            Alignment.Equals(DefaultAlignment) &&
            Location.Equals(DefaultLocation) &&
            BackColor.Equals(DefaultBackColor);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(LegendOptions): Apply specified options to this legend
        /// <summary>
        /// Apply specified options to this legend.
        /// </summary>
        public void ApplyOptions(LegendOptions options)
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
            KnownTextAlignment? alignmentOption = options.Alignment;
            bool alignmentHasValue = alignmentOption.HasValue;
            if (alignmentHasValue)
            {
                Alignment = alignmentOption.Value;
            }
            #endregion

            #region BackColor
            string colorOption = options.BackColor;
            bool colorHasValue = !colorOption.IsNullValue();
            if (colorHasValue)
            {
                BackColor = colorOption;
            }
            #endregion

            #region Border
            Border.ApplyOptions(options.Border);
            #endregion

            #region Font
            Font.ApplyOptions(options.Font);
            #endregion

            #region Location
            KnownLegendLocation? locationOption = options.Location;
            bool locationHasValue = locationOption.HasValue;
            if (locationHasValue)
            {
                Location = locationOption.Value;
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
        }
        #endregion

        #region [public] (LegendModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public LegendModel Clone()
        {
            var cloned = (LegendModel)MemberwiseClone();
            cloned.Font.Clone();
            cloned.Border.Clone();

            return cloned;
        }
        #endregion

        #region [public] (Color) GetBackColor(): Gets a reference to the color structure preferred for chart legend backcolor
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for chart legend backcolor
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);
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
