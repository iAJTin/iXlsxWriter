
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// A Specialization of <see cref="XlsxBaseStyle"/> class.<br/>
    /// Defines a <b>xlsx</b> cell style.
    /// </summary>
    public partial class XlsxCellStyle
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellContent _content;
        #endregion

        #region public new readonly static properties

        #region [public] {new} {static} (XlsxCellStyle) Default: Gets default cell style
        /// <summary>
        /// Gets default cell style.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> reference containing the default cell style.
        /// </value>
        public new static XlsxCellStyle Default => new XlsxCellStyle();
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
        [JsonIgnore]
        [XmlIgnore]
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
            get => _font ?? (_font = FontModel.DefaultFont);
            set => _font = value;
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) ContentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool ContentSpecified => !Content.IsDefault;
        #endregion

        #endregion

        #region public new properties

        #region [public] {new} (XlsxCellContent) Content: Gets or sets cell content distribution
        /// <summary>
        /// Gets or sets cell content distribution.
        /// </summary>
        /// <value>
        /// Reference to cell content distribution.
        /// </value>
        [XmlElement]
        [JsonProperty("content")]
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public new XlsxCellContent Content
        {
            get
            {
                if (_content == null)
                {
                    _content = XlsxCellContent.Default;
                }

                _content.SetParent(this);

                return _content;
            }
            set
            {
                if (value != null)
                {
                    _content = value;
                }
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool IsDefault => base.IsDefault && Content.IsDefault;
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxCellStyle) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxCellStyle Clone()
        {
            var cloned = (XlsxCellStyle)base.Clone();
            cloned.Font = Font.Clone();
            cloned.Borders = Borders.Clone();
            cloned.Content = Content.Clone();
            cloned.Borders = Borders.Clone();
            cloned.Properties = Properties.Clone();
            
            return cloned;
        }
        #endregion

        #region [public] (XlsxCellStyle) TryGetInheritStyle(): Try gets a reference to inherit model
        /// <summary>
        /// Try gets a reference to inherit model.
        /// </summary>
        /// <returns>
        /// An inherit style.
        /// </returns>
        public new XlsxCellStyle TryGetInheritStyle() => InheritStyle;
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellStyleOptions): Apply specified options to this style
        /// <summary>
        /// Apply specified options to this style.
        /// </summary>
        public void ApplyOptions(XlsxCellStyleOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Content
            Content.ApplyOptions(options.Content);
            #endregion

            #region Font
            Font.ApplyOptions(options.Font);
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxCellStyle): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxCellStyle reference)
        {
            base.Combine(reference);

            Font.Combine(reference.Font);
            Content.Combine(reference.Content);
        }
        #endregion

        #endregion

        #region private properties

        #region [private] (XlsxCellStyle) InheritStyle: Gets a reference to inherit model
        /// <summary>
        /// Gets a reference to inherit model.
        /// </summary>
        /// <value>
        /// A inherit style.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellStyle InheritStyle => Owner == null ? new XlsxCellStyle() : (XlsxCellStyle) Owner.GetBy(Inherits);
        #endregion

        #endregion
    }
}
