
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    /// <summary>
    /// Defines a <b>Xlsx</b> section settings.
    /// </summary>
    public partial class XlsxDocumentHeaderFooterSection : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultText = "";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownHeaderFooterSectionType DefaultType = KnownHeaderFooterSectionType.Odd;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownHeaderFooterAlignment DefaultAlignment = KnownHeaderFooterAlignment.Center;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownHeaderFooterSectionType _type;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownHeaderFooterAlignment _alignment;
        #endregion

        #region constructor/s

        #region [public] XlsxDocumentHeaderFooterSection(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooterSection"/> class.
        /// </summary>
        public XlsxDocumentHeaderFooterSection()
        {
            Text = DefaultText;
            Type = DefaultType;
            Alignment = DefaultAlignment;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Create a new object that is a copy of the current instance
        /// <inheritdoc/>
        /// <summary>
        /// Create a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="object"/> that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxDocumentHeaderFooterSection) Default: Returns a new instance containing the default section settings
        /// <summary>
        /// Returns a new instance containing the default section settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxDocumentHeaderFooterSection"/> reference containing the default section settings.
        /// </value>
        public static XlsxDocumentHeaderFooterSection Default => new XlsxDocumentHeaderFooterSection();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (XlsxDocumentHeaderFooterSections) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
        /// </summary>
        /// <value>
        /// The <see cref="XlsxDocumentHeaderFooterSections"/> that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public XlsxDocumentHeaderFooterSections Owner { get; private set; }

        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHeaderFooterAlignment) Alignment: Gets or sets the preferred section Alignment
        /// <summary>
        /// Gets or sets the preferred section Alignment. The default is <see cref="KnownHeaderFooterAlignment.Center"/>.
        /// </summary>
        /// <value>
        /// Preferred section alignment.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("alignment")]
        [DefaultValue(DefaultAlignment)]
        public KnownHeaderFooterAlignment Alignment
        {
            get => _alignment;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _alignment = value;
            }
        }
        #endregion

        #region [public] (string) Name: Gets or sets a value that contains a string to identify this section
        /// <summary>
        /// Gets or sets a value that contains a <see cref="string"/> to identify this section.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the section identifier.
        /// </value>
        [XmlAttribute]
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region [public] (string) Text: Gets or sets a value that contains the section text
        /// <summary>
        /// Gets or sets a value that contains the section text.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the section text.
        /// </value>
        [XmlAttribute]
        [JsonProperty("text")]
        [DefaultValue(DefaultText)]
        public string Text { get; set; }
        #endregion

        #region [public] (KnownHeaderFooterSectionType) Type: Gets or sets the preferred section type
        /// <summary>
        /// Gets or sets the preferred section type. The default is <see cref="KnownHeaderFooterSectionType.Odd"/>.
        /// </summary>
        /// <value>
        /// Preferred section type.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("type")]
        [DefaultValue(DefaultType)]
        public KnownHeaderFooterSectionType Type
        {
            get => _type;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _type = value;
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
            Text.Equals(DefaultText) &&
            Type.Equals(DefaultType) &&
            Alignment.Equals(DefaultAlignment);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxDocumentHeaderFooterSection) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxDocumentHeaderFooterSection Clone() => (XlsxDocumentHeaderFooterSection) MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxDocumentHeaderFooterSection): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxDocumentHeaderFooterSection reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Alignment.Equals(DefaultAlignment))
            {
                Alignment = reference.Alignment;
            }

            if (Text.Equals(DefaultText))
            {
                Text = reference.Text;
            }

            if (Type.Equals(DefaultType))
            {
                Type = reference.Type;
            }
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxDocumentHeaderFooterSections): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxDocumentHeaderFooterSection"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxDocumentHeaderFooterSections reference)
        {
            Owner = reference;
        }
        #endregion

        #endregion
    }
}
