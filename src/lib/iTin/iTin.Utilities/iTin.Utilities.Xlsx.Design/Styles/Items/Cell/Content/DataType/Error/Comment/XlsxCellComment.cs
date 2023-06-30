
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Represents a comment. Includes comment text, format, including font face, size, and style attributes.
    /// </summary>
    public partial class XlsxCellComment : ICombinable<XlsxCellComment>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;
        #endregion

        #region constructor/s

        #region [public] XlsxCellComment(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellComment"/> class.
        /// </summary>
        public XlsxCellComment()
        {
            Show = DefaultShow;
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

        #region (object) ICombinable<XlsxCellComment>.Combine(XlsxCellComment): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxCellComment>.Combine(XlsxCellComment reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) FontSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool FontSpecified => !Font.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (FontModel) Font: Gets or sets the font model
        /// <summary>
        /// Gets or sets the font model.
        /// </summary>
        /// <value>
        /// Reference that contains the definition of a font.            
        /// </value>
        [XmlElement]
        [JsonProperty("font")]
        public FontModel Font
        {
            get => _font ?? (_font = new FontModel());
            set => _font = value;
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays a comment that contains the original value of the field
        /// <summary>
        /// Gets or sets a value indicating whether displays a comment that contains the original value of the field. The default is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> displays a comment that contains the original value of the field; Otherwise, <see cref="YesNo.No"/>. 
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

        #region [public] (string) Text: Gets or sets the comment text
        /// <summary>
        /// Gets or sets the comment text.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        [XmlAttribute]
        [JsonProperty("text")]
        public string Text { get; set; }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Font.IsDefault &&
            string.IsNullOrEmpty(Text) &&
            Show.Equals(DefaultShow);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellComment) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellComment Clone()
        {
            var commentCloned = (XlsxCellComment)MemberwiseClone();
            commentCloned.Font = Font.Clone();
            commentCloned.Properties = Properties.Clone();

            return commentCloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellCommentOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxCellCommentOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Font
            Font.ApplyOptions(options.Font);
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

        #region [public] {virtual} (void) Combine(XlsxCellComment): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public void Combine(XlsxCellComment reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Text == null)
            {
                Text = reference.Text;
            }

            Font.Combine(reference.Font);
        }
        #endregion

        #endregion
    }
}
