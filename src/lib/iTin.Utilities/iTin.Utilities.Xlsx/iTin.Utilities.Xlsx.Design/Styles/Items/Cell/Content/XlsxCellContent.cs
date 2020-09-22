
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Styling;

    /// <summary>
    /// A Specialization of <see cref="BaseContent"/> class.<br/>
    /// Defines a <b>xlsx</b> cell content.
    /// </summary>
    public partial class XlsxCellContent
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellMerge _merge;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BaseDataType _dataType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellPattern _pattern;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxCellContentAlignment _alignment;
        #endregion

        #region public new readonly static properties

        #region [public] {new} {static} (XlsxCellContent) Default: Returns a new instance containing default cell content style settings
        /// <summary>
        /// Returns a new instance containing default cell content style settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellContent"/> reference containing the default cell content style settings.
        /// </value>
        public new static XlsxCellContent Default => new XlsxCellContent();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) DataTypeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool DataTypeSpecified => !DataType.IsDefault;
        #endregion

        #region [public] (bool) MergeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool MergeSpecified => !Merge.IsDefault;
        #endregion

        #region [public] (bool) PatternSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool PatternSpecified => !Pattern.IsDefault;
        #endregion

        #endregion

        #region public new readonly properties

        #region [public] {new} (bool) AlignmentSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public new bool AlignmentSpecified => !Alignment.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (BaseDataType) DataType: Gets or sets content data type
        /// <summary>
        /// Gets or sets content data type.
        /// </summary>
        /// <value>
        /// Reference to content data type.
        /// </value>
        [XmlElement("Currency", typeof(CurrencyDataType))]
        [XmlElement("DateTime", typeof(DateTimeDataType))]
        [XmlElement("Number", typeof(NumberDataType))]
        [XmlElement("Percentage", typeof(PercentageDataType))]
        [XmlElement("Scientific", typeof(ScientificDataType))]
        [XmlElement("Text", typeof(TextDataType))]
        [JsonProperty("datatype")]
        public BaseDataType DataType
        {
            get
            {
                if (_dataType != null)
                {
                    _dataType.SetParent(this);
                }
                else
                {
                    if (((XlsxCellStyle)Parent).Inherits == null)
                    {
                        _dataType = new TextDataType();
                    }
                    else
                    {
                        var inheritStyle = ((XlsxCellStyle) Parent).TryGetInheritStyle();
                        _dataType = inheritStyle.Content.DataType;
                    }
                }

                return _dataType;
            }
            set
            {
                if (value != null)
                {
                    _dataType = value;
                }
            }
        }
        #endregion

        #region [public] (XlsxCellMerge) Merge: Gets or sets the merge content cells definition
        /// <summary>
        /// Gets or sets the merge content cells definition.
        /// </summary>
        /// <value>
        /// Reference that contains the merge content cells definition.
        /// </value>
        [XmlElement]
        [JsonProperty("merge")]
        public XlsxCellMerge Merge
        {
            get => _merge ?? (_merge = new XlsxCellMerge());
            set => _merge = value;
        }
        #endregion

        #region [public] (XlsxCellPattern) Pattern: Gets or sets a reference to cell pattern
        /// <summary>
        /// Gets or sets a reference to cell pattern.
        /// </summary>
        /// <value>
        /// A <see cref="Pattern"/> reference.
        /// </value>
        [XmlElement]
        [JsonProperty("pattern")]
        public XlsxCellPattern Pattern
        {
            get => _pattern ?? (_pattern = new XlsxCellPattern());
            set => _pattern = value;
        }
        #endregion

        #endregion

        #region public new properties

        #region [public] {new} (XlsxCellContentAlignment) Alignment: Gets or sets content distribution
        /// <summary>
        /// Gets or sets content distribution.
        /// </summary>
        /// <value>
        /// Reference for content distribution.
        /// </value>
        [XmlElement]
        [JsonProperty("alignment")]
        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public new XlsxCellContentAlignment Alignment
        {
            get
            {
                if (_alignment == null)
                {
                    _alignment = XlsxCellContentAlignment.Default;
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
            Merge.IsDefault &&
            Pattern.IsDefault &&
            Alignment.IsDefault &&
            DataType.GetType() == typeof(TextDataType);
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellContentOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxCellContentOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Color
            string colorOption = options.Color;
            bool colorHasValue = !colorOption.IsNullValue();
            if (colorHasValue)
            {
                Color = colorOption;
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

            #region Alignment
            Alignment.ApplyOptions(options.Alignment);
            #endregion

            #region Merge
            Merge.ApplyOptions(options.Merge);
            #endregion

            #region Pattern
            Pattern.ApplyOptions(options.Pattern);
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxCellContent): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxCellContent reference)
        {
            if (reference == null)
            {
                return;
            }

            base.Combine(reference);

            var referenceDataType = reference.DataType;
            if (_dataType == null)
            {
                switch (referenceDataType.Type)
                {
                    case KnownDataType.Currency:
                        _dataType = new CurrencyDataType();
                        break;

                    case KnownDataType.DateTime:
                        _dataType = new DateTimeDataType();
                        break;

                    case KnownDataType.Numeric:
                        _dataType = new NumberDataType();
                        break;

                    case KnownDataType.Percentage:
                        _dataType = new PercentageDataType();
                        break;

                    case KnownDataType.Scientific:
                        _dataType = new ScientificDataType();
                        break;

                    default:
                        _dataType = new TextDataType();
                        break;
                }
            }

            if (_dataType.Type.Equals(referenceDataType.Type))
            {
                DataType.Combine(referenceDataType);
            }

            Merge.Combine(reference.Merge);
            Pattern.Combine(reference.Pattern);
            Alignment.Combine(reference.Alignment);
        }
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxCellContent) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxCellContent Clone()
        {
            var cloned = (XlsxCellContent) base.Clone();
            cloned.Merge = Merge.Clone();
            cloned.Pattern = Pattern.Clone();
            cloned.DataType = DataType.Clone();
            cloned.Alignment = Alignment.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
