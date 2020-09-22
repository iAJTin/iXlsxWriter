
namespace iTin.Utilities.Xlsx.Design.Shape
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
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// A Specialization of <see cref="BaseContent"/> class.<br/>
    /// Defines a <b>xlsx</b> shape content.
    /// </summary>
    public partial class XlsxShapeContent : ICombinable<XlsxShapeContent>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultTransparency = 0;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _transparency;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxShapeContentAlignment _alignment;
        #endregion

        #region constructor/s

        #region [public] XlsxShapeContent(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxShapeContent"/> class.
        /// </summary>
        public XlsxShapeContent()
        {
            Transparency = DefaultTransparency;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxShapeContent>.Combine(XlsxShapeContent): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference to combine with this instance</param>
        void ICombinable<XlsxShapeContent>.Combine(XlsxShapeContent reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public new readonly static properties

        #region [public] {new} {static} (XlsxShapeContent) Default: Returns a new instance containing default shape content style settings
        /// <summary>
        /// Returns a new instance containing default shape content style settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShapeContent"/> reference containing the default shape content style settings.
        /// </value>
        public new static XlsxShapeContent Default => new XlsxShapeContent();
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
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool AlignmentSpecified => !Alignment.IsDefault;
        #endregion

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

        #region [public] (XlsxShapeContentAlignment) Alignment: Gets or sets shape content distribution
        /// <summary>
        /// Gets or sets shape content distribution.
        /// </summary>
        /// <value>
        /// Reference for shape content distribution.
        /// </value>
        [XmlElement]
        [JsonProperty("alignment")]
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public XlsxShapeContentAlignment Alignment
        {
            get
            {
                if (_alignment == null)
                {
                    _alignment = XlsxShapeContentAlignment.Default;
                }

                _alignment.SetParent(this);

                return _alignment;
            }
            set
            {
                if (value != null)
                {
                    _alignment = value;
                }
            }
        }
        #endregion

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

        #region [public] (string) Text: Gets or sets the shape content text
        /// <summary>
        ///  Gets or sets shape content text.
        /// </summary>
        /// <value>
        /// The shape content text.
        /// </value>
        [XmlAttribute]
        [JsonProperty("text")]
        public string Text { get; set; }
        #endregion

        #region [public] (int) Transparency: Gets or sets the preferred shape content transparency percentage value
        /// <summary>
        /// Gets or sets the preferred shape content transparency percentage value. The default value is <b>0</b>.
        /// </summary>
        /// <value>
        /// Preferred picture shape transparency percentage value.
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
        public override bool IsDefault => 
            base.IsDefault &&
            Font.IsDefault &&
            Alignment.IsDefault &&
            string.IsNullOrEmpty(Text) && 
            Transparency.Equals(DefaultTransparency);
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxShapeContentOptions): Apply specified options to this shape instance
        /// <summary>
        /// Apply specified options to this shape instance.
        /// </summary>
        public virtual void ApplyOptions(XlsxShapeContentOptions options)
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
            Alignment.ApplyOptions(options.Alignment);
            #endregion

            #region Color
            string colorOption = options.Color;
            bool colorHasValue = !colorOption.IsNullValue();
            if (colorHasValue)
            {
                Color = colorOption;
            }
            #endregion

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

            #region Transparency
            int? transparencyOption = options.Transparency;
            bool transparencyHasValue = transparencyOption.HasValue;
            if (transparencyHasValue)
            {
                Transparency = transparencyOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxShapeContent): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxShapeContent reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            if (Text == null)
            {
                Text = reference.Text;
            }

            if (Transparency.Equals(DefaultTransparency))
            {
                Transparency = reference.Transparency;
            }

            Font.Combine(reference.Font);
            Alignment.Combine(reference.Alignment);
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxShapeContent) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxShapeContent Clone()
        {
            var cloned = (XlsxShapeContent) base.Clone();
            cloned.Font = Font.Clone();
            cloned.Alignment = Alignment.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
