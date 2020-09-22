
namespace iTin.Utilities.Xlsx.Design.Settings.Sheets
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    using Shared;

    /// <summary>
    /// Defines sheet settings. Allows to set the sheet margins, header, footer, default view, size and orientation.
    /// </summary>
    public partial class XlsxSheetSettings : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownDocumentSize DefaultSize = KnownDocumentSize.A4;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownDocumentView DefaultView = KnownDocumentView.Normal;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownDocumentOrientation DefaultOrientation = KnownDocumentOrientation.Portrait;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownDocumentView _view;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxPoint _freezePanesPoint;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownDocumentSize _size;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxDocumentMargins _margins;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxDocumentHeaderFooter _footer;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxDocumentHeaderFooter _header;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownDocumentOrientation _orientation;
        #endregion

        #region constructor/s

        #region [public] XlsxSheetSettings(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxSheetSettings"/> class.
        /// </summary>
        public XlsxSheetSettings()
        {
            Size = DefaultSize;
            View = DefaultView;
            SheetName = string.Empty;
            Orientation = DefaultOrientation;
            FreezePanesPoint = XlsxPoint.Default;
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

        #region [public] {static} (XlsxSheetSettings) Default: Returns a new instance containing default sheet settings
        /// <summary>
        /// Returns a new instance containing default sheet settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSheetSettings"/> reference containing the default sheet settings.
        /// </value>
        public static XlsxSheetSettings Default => new XlsxSheetSettings();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) FreezePanesPointSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool FreezePanesPointSpecified => !FreezePanesPoint.IsDefault;
        #endregion

        #region [public] (bool) FooterSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool FooterSpecified => !Footer.IsDefault;
        #endregion

        #region [public] (bool) HeaderSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool HeaderSpecified => !Header.IsDefault;
        #endregion

        #region [public] (bool) MarginsSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool MarginsSpecified => !Margins.IsDefault;
        #endregion

        #region [public] (XlsxSheetsSettingsCollection) Owner: Gets the element that owns this
        /// <summary>
        /// Gets the element that owns this <see cref="XlsxSheetSettings"/>.
        /// </summary>
        /// <value>
        /// The <see cref="XlsxSheetsSettingsCollection"/> that owns this <see cref="XlsxSheetSettings"/>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public XlsxSheetsSettingsCollection Owner { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxPoint) FreezePanesPoint: Gets or sets the preferred freeze panes point
        /// <summary>
        /// Gets or sets the preferred freeze panes point. Only applies when <see cref="KnownDocumentView.Normal"/> view mode is selected. The default point is <b>A1</b>.
        /// </summary>
        /// <value>
        /// Preferred freeze panes point.
        /// </value>
        [XmlElement]
        [JsonProperty("sheet-freeze-panes-point")]
        public XlsxPoint FreezePanesPoint
        {
            get => _freezePanesPoint ?? (_freezePanesPoint = XlsxPoint.Default);
            set => _freezePanesPoint = value;
        }
        #endregion

        #region [public] (XlsxDocumentHeaderFooter) Footer: Gets or sets a reference to footer document configuration, it allow define margin and data
        /// <summary>
        /// Gets or sets a reference to footer document configuration, it allow define margin and data.
        /// </summary>
        /// <value>
        /// Reference to footer document configuration, it allow define margin and data.
        /// </value>
        [XmlElement]
        [JsonProperty("sheet-footer")]
        public XlsxDocumentHeaderFooter Footer
        {
            get
            {
                if (_footer == null)
                {
                    _footer = new XlsxDocumentHeaderFooter();
                }

                _footer.SetParent(this);

                return _footer;
            }
            set => _footer = value;
        }
        #endregion

        #region [public] (XlsxDocumentHeaderFooter) Header: Gets or sets a reference to header document configuration, it allow define margin and data
        /// <summary>
        /// Gets or sets a reference to header document configuration, it allow define margin and data.
        /// </summary>
        /// <value>
        /// Reference to header document configuration, it allow define margin and data.
        /// </value>
        [XmlElement]
        [JsonProperty("sheet-header")]
        public XlsxDocumentHeaderFooter Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new XlsxDocumentHeaderFooter();
                }

                _header.SetParent(this);

                return _header;
            }
            set => _header = value;
        }
        #endregion

        #region [public] (XlsxDocumentMargins) Margins: Gets or sets a reference to 
        /// <summary>
        /// Gets or sets a reference that allows you to define the margins settings for this document.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxDocumentMargins"/> refetence containing the margins settings for this document.
        /// </value>
        [XmlElement]
        [JsonProperty("sheet-margins")]
        public XlsxDocumentMargins Margins
        {
            get => _margins ?? (_margins = new XlsxDocumentMargins());
            set => _margins = value;
        }
        #endregion

        #region [public] (KnownDocumentOrientation) Orientation: Gets or sets the preferred document orientation
        /// <summary>
        /// Gets or sets the preferred document orientation. The default is <see cref="KnownDocumentOrientation.Portrait"/>.
        /// </summary>
        /// <value>
        /// Preferred document orientation.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("sheet-orientation")]
        [DefaultValue(DefaultOrientation)]
        public KnownDocumentOrientation Orientation
        {
            get => _orientation;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _orientation = value;
            }
        }
        #endregion

        #region [public] (string) SheetName: Gets or sets the sheet name
        /// <summary>
        /// Gets or sets the sheet name view.
        /// </summary>
        /// <value>
        /// Sheet name.
        /// </value>
        [XmlAttribute]
        [JsonProperty("sheet-name")]
        public string SheetName { get; set; }
        #endregion

        #region [public] (KnownDocumentSize) Size: Gets or sets the preferred size of document
        /// <summary>
        /// Gets or sets the preferred document size. The default is <see cref="KnownDocumentSize.A4"/>.
        /// </summary>
        /// <value>
        /// Preferred document size.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("sheet-size")]
        [DefaultValue(DefaultSize)]
        public KnownDocumentSize Size
        {
            get => _size;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _size = value;
            }
        }
        #endregion

        #region [public] (KnownDocumentView) View: Gets or sets the preferred document view
        /// <summary>
        /// Gets or sets the preferred document view. The default is <see cref="KnownDocumentView.Normal"/>.
        /// </summary>
        /// <value>
        /// Preferred document view.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("sheet-view")]
        [DefaultValue(DefaultView)]
        public KnownDocumentView View
        {
            get => _view;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _view = value;
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
            Footer.IsDefault &&
            Header.IsDefault &&
            Margins.IsDefault &&
            View.Equals(DefaultView) &&
            Size.Equals(DefaultSize) &&
            string.IsNullOrEmpty(SheetName) &&
            Orientation.Equals(DefaultOrientation);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxSheetSettings) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxSheetSettings Clone()
        {
            var cloned = (XlsxSheetSettings) MemberwiseClone();
            cloned.Header = Header.Clone();
            cloned.Footer = Footer.Clone();
            cloned.Margins = Margins.Clone();
            cloned.Properties = Properties.Clone();
            cloned.FreezePanesPoint = FreezePanesPoint.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxSheetSettings): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxSheetSettings reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Orientation.Equals(DefaultOrientation))
            {
                Orientation = reference.Orientation;
            }

            if (Size.Equals(DefaultSize))
            {
                Size = reference.Size;
            }

            if (View.Equals(DefaultView))
            {
                View = reference.View;
            }

            reference.Footer.Combine(reference.Footer);
            reference.Header.Combine(reference.Header);
            reference.Margins.Combine(reference.Margins);
            reference.FreezePanesPoint.Combine(reference.FreezePanesPoint);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetOwner(XlsxSheetsSettingsCollection): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxSheetsSettingsCollection"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetOwner(XlsxSheetsSettingsCollection reference)
        {
            Owner = reference;
        }

        #endregion

        #endregion
    }
}
