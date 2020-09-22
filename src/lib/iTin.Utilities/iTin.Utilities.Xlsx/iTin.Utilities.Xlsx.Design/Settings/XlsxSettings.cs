
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Document;
    using Sheets;

    /// <summary>
    /// Defines sheets collection settings. Allows to set the document metadata, margins, header, footer, default view, size and orientation.
    /// </summary>
    public partial class XlsxSettings : ICloneable
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxSheetsSettingsCollection _sheets;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxDocumentMetadataSettings _document;
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

        #region [public] {static} (XlsxSettings) Default: Returns a new instance containing default settings
        /// <summary>
        /// Returns a new instance containing default settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSettings"/> reference containing the default settings.
        /// </value>
        public static XlsxSettings Default => new XlsxSettings();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) DocumentSettingsSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool DocumentSettingsSpecified => !DocumentSettings.IsDefault;
        #endregion

        #region [public] (bool) SheetsSettingsSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool SheetsSettingsSpecified => !SheetsSettings.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxDocumentMetadataSettings) DocumentSettings: Gets or sets a value containing document settings
        /// <summary>
        /// Gets or sets a value containing document settings. Allows to set the document metadata.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxDocumentMetadataSettings"/> reference containing the document settings.
        /// </value>
        [XmlElement]
        [JsonProperty("document")]
        public XlsxDocumentMetadataSettings DocumentSettings
        {
            get => _document ?? (_document = new XlsxDocumentMetadataSettings());
            set => _document = value;
        }
        #endregion

        #region [public] (XlsxSheetsSettingsCollection) SheetsSettings: Gets or sets a value containing sheets settings
        /// <summary>
        /// Gets or sets a value containing sheets settings. Allows to set margins, header, footer, default view, size and orientation.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSheetsSettingsCollection"/> reference containing the document settings.
        /// </value>
        [JsonProperty("sheets")]
        [XmlArrayItem("SheetSettings", typeof(XlsxSheetSettings), IsNullable = false)]
        public XlsxSheetsSettingsCollection SheetsSettings
        {
            get => _sheets ?? (_sheets = new XlsxSheetsSettingsCollection(this));
            set => _sheets = value;
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
        public override bool IsDefault => base.IsDefault && DocumentSettings.IsDefault && SheetsSettings.IsDefault;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxSettings) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxSettings Clone()
        {
            var cloned = (XlsxSettings)MemberwiseClone();
            cloned.DocumentSettings = DocumentSettings.Clone();
            cloned.SheetsSettings = SheetsSettings.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxSettings): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxSettings reference)
        {
            if (reference == null)
            {
                return;
            }

            reference.SheetsSettings.Combine(reference.SheetsSettings);
            reference.DocumentSettings.Combine(reference.DocumentSettings);
        }
        #endregion

        #endregion
    }
}
