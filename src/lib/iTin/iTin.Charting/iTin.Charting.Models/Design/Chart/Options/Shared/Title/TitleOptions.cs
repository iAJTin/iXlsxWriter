
namespace iTin.Charting.Models.Design.Options
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="TitleModel"/> instance.
    /// </summary>
    [Serializable]
    public sealed class TitleOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] TitleOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleOptions"/> class.
        /// </summary>
        public TitleOptions()
        {
            Show = null;
            Text = null;
            Alignment = null;
            BackColor = null;
            Orientation = null;

            Font = FontOptions.Default;
            Border = BorderOptions.Default;
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

        #region [public] {static} (TitleOptions) Default: Gets a reference that contains the set of available settings to model an existing TitleModel instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="TitleModel"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public static TitleOptions Default => new TitleOptions();
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Show == null &&
            Text == null &&
            Alignment == null &&
            BackColor == null &&
            Orientation == null &&
            Font.IsDefault &&
            Border.IsDefault;
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

        #region [public] (KnownTextAlignment?) Alignment: Gets or sets a value that contains type of title alignment in an existing TitleModel instance
        /// <summary>
        /// Gets or sets a value that contains type of title alignment in an existing <see cref="TitleModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownTextAlignment"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownTextAlignment? Alignment { get; set; }
        #endregion

        #region [public] (BorderOptions) Border: Gets or sets a value that defines the border of the title in an existing TitleModel instance
        /// <summary>
        /// Gets or sets a value that defines the border of the title in an existing <see cref="TitleModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="BorderOptions"/> instance.
        /// </value>
        public BorderOptions Border { get; set; }
        #endregion

        #region [public] (string) BackColor: Gets or sets the preferred back color in an existing TitleModel instance
        /// <summary>
        /// Gets or sets the preferred back color in an existing <see cref="TitleModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred back color.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string BackColor { get; set; }
        #endregion

        #region [public] (FontOptions) Font: Gets or sets a value that defines the font of the title in an existing TitleModel instance
        /// <summary>
        /// Gets or sets a value that defines the font of the title in an existing <see cref="TitleModel"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="FontOptions"/> instance.
        /// </value>
        public FontOptions Font { get; set; }
        #endregion

        #region [public] (KnownTextOrientation?) Orientation: Gets or sets a value that contains type of vertical title orientation in an existing TitleModel instance
        /// <summary>
        /// Gets or sets a value that contains type of vertical title orientation in an existing <see cref="TitleModel"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, One of the enumeration values <see cref="KnownTextOrientation"/>. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownTextOrientation? Orientation { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing TitleModel instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="TitleModel"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (string) Text: Gets or sets a value that contains the title text in an existing TitleModel instance
        /// <summary>
        /// Gets or sets a value that contains the title text in an existing <see cref="TitleModel"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String"/> that contains the text of the title to be displayed.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        public string Text { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (TitleOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public TitleOptions Clone()
        {
            var clonned = (TitleOptions)MemberwiseClone();
            clonned.Font = Font.Clone();
            clonned.Border = Border.Clone();

            return clonned;
        }
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
