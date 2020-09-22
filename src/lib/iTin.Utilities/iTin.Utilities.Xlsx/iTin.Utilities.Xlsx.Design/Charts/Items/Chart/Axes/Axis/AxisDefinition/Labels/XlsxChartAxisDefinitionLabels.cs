
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    ///Represents the visual setting the labels of a axis.
    /// </summary>
    public partial class XlsxChartAxisDefinitionLabels : ICombinable<XlsxChartAxisDefinitionLabels>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const LabelPosition DefaultPosition = LabelPosition.Low;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const LabelOrientation DefaultOrientation = LabelOrientation.Automatic;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownHorizontalAlignment DefaultAlignment = KnownHorizontalAlignment.Center;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FontModel _font;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LabelPosition _position;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LabelOrientation _orientation;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownHorizontalAlignment _alignment;
        #endregion

        #region constructor/s

        #region [public] XlsxChartAxisDefinitionLabels(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxChartAxisDefinitionLabels"/> class.
        /// </summary>
        public XlsxChartAxisDefinitionLabels()
        {
            Position = DefaultPosition;
            Alignment = DefaultAlignment;
            Orientation = DefaultOrientation;
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

        #region (void) ICombinable<XlsxChartAxisDefinitionLabels>.Combine(XlsxChartAxisDefinitionLabels): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxChartAxisDefinitionLabels>.Combine(XlsxChartAxisDefinitionLabels reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxChartAxisDefinitionLabels) Default: Returns a new instance containing default chart axis labels definition settings
        /// <summary>
        /// Returns a new instance containing default chart axis labels definition settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxChartAxisDefinitionLabels"/> reference containing the default chart axis labels definition settings.
        /// </value>
        public static XlsxChartAxisDefinitionLabels Default => new XlsxChartAxisDefinitionLabels();
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

        #region [public] (XlsxChartAxisDefinition) Parent: Gets the parent element
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <value>
        /// The element that represents the container element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxChartAxisDefinition Parent { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (KnownHorizontalAlignment) Alignment: Gets or sets the preferred alignment for axis labels
        /// <summary>
        /// Gets or sets the preferred alignment for axis labels. The default is <see cref="KnownVerticalAlignment.Center"/>.
        /// </summary>
        /// <value>
        /// Preferred alignment for axis labels.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultAlignment)]
        public KnownHorizontalAlignment Alignment
        {
            get => _alignment;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _alignment = value;
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
            get => _font ?? (_font = FontModel.DefaultFont);
            set => _font = value;
        }
        #endregion

        #region [public] (LabelOrientation) Orientation: Gets or sets the preferred orientation for axis labels
        /// <summary>
        /// Gets or sets the preferred orientation for axis labels. The default is <see cref="LabelOrientation.Automatic"/>.
        /// </summary>
        /// <value>
        /// Preferred orientation for axis labels.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultOrientation)]
        public LabelOrientation Orientation
        {
            get => _orientation;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _orientation = value;
            }
        }
        #endregion

        #region [public] (LabelPosition) Position: Gets or sets the preferred position for axis labels
        /// <summary>
        /// Gets or sets the preferred position for axis labels. The default is <see cref="LabelPosition.Low"/>.
        /// </summary>
        /// <value>
        /// Preferred position for axis labels.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultPosition)]
        public LabelPosition Position
        {
            get => _position;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _position = value;
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
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Font.IsDefault &&
            Alignment.Equals(DefaultAlignment) &&
            Orientation.Equals(DefaultOrientation) &&
            Position.Equals(DefaultPosition);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxChartAxisDefinitionLabels) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxChartAxisDefinitionLabels Clone()
        {
            var cloned = (XlsxChartAxisDefinitionLabels)MemberwiseClone();
            cloned.Font = Font.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxMiniChartAxesOptions): Apply specified options to this axes
        ///// <summary>
        ///// Apply specified options to this axes.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxMiniChartAxesOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region Horizontal
        //    Horizontal.ApplyOptions(options.Horizontal);
        //    #endregion

        //    #region Vertical
        //    Vertical.ApplyOptions(options.Vertical);
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxChartAxisDefinitionLabels): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxChartAxisDefinitionLabels reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Alignment.Equals(DefaultAlignment))
            {
                Alignment = reference.Alignment;
            }

            if (Orientation.Equals(DefaultOrientation))
            {
                Orientation = reference.Orientation;
            }

            if (Position.Equals(DefaultPosition))
            {
                Position = reference.Position;
            }

            Font.Combine(reference.Font);
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxChartAxisDefinition): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxChartAxisDefinition"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxChartAxisDefinition reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
