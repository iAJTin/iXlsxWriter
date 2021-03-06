﻿
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseChart"/> class.<br/>
    /// Represents a user-defined minichart. Very small chart located in a spreadsheet cell that provides a visual representation of data. 
    /// Use sparklines to reflect the trends of a series of values, such as periodic increases or reductions and economic cycles, 
    /// or to highlight minimum and maximum values.Place the sparkline near the corresponding data for a greater visual impact.
    /// </summary>
    public partial class XlsxMiniChart : ICombinable<XlsxMiniChart>
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultDisplayHidden = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const MiniChartEmptyValuesAs DefaultEmptyValueAs = MiniChartEmptyValuesAs.Zero;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _displayHidden;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartAxes _axes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartRanges _ranges;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartChartType _type;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxMiniChartSize _chartSize;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MiniChartEmptyValuesAs _emptyValuesAs;
        #endregion

        #region constructor/s

        #region [public] XlsxMiniChart(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChart"/> class.
        /// </summary>
        public XlsxMiniChart()
        {
            EmptyValueAs = DefaultEmptyValueAs;
            DisplayHidden = DefaultDisplayHidden;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICombinable

        #region explicit

        #region (void) ICombinable<XlsxMiniChart>.Combine(XlsxMiniChart): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChart>.Combine(XlsxMiniChart reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public new readonly static properties

        #region [public] {new} {static} (XlsxMiniChart) Default: Returns a new instance containing default minichart configuration
        /// <summary>
        /// Returns a new instance containing default minichart configuration.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxMiniChart"/> reference containing the default minichart configuration.
        /// </value>
        public new static XlsxMiniChart Default => new XlsxMiniChart();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) ChartAxesSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool ChartAxesSpecified => !ChartAxes.IsDefault;
        #endregion

        #region [public] (bool) ChartRangesSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool ChartRangesSpecified => !ChartRanges.IsDefault;
        #endregion

        #region [public] (bool) ChartSizeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool ChartSizeSpecified => !ChartSize.IsDefault;
        #endregion

        #region [public] (bool) ChartTypeSpecified: Gets a value that tells the serializer if the referenced item is to be included
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
        public bool ChartTypeSpecified => !ChartType.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxMiniChartAxes) ChartAxes: Gets or sets a reference that contains the visual setting of the minichart axes
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of the minichart axes.
        /// </summary>
        /// <value>
        /// Visual setting of the minichart axes.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-axes")]
        public XlsxMiniChartAxes ChartAxes
        {
            get
            {
                if (_axes == null)
                {
                    _axes = new XlsxMiniChartAxes();
                }

                _axes.SetParent(this);

                return _axes;
            }
            set => _axes = value;
        }
        #endregion

        #region [public] (XlsxMiniChartRanges) ChartRanges: Gets or sets a reference that contains the chart ranges configuration
        /// <summary>
        /// Gets or sets a reference that contains the chart ranges configuration.
        /// </summary>
        /// <value>
        /// The chart ranges configuration.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-ranges")]
        public XlsxMiniChartRanges ChartRanges
        {
            get => _ranges ?? (_ranges = new XlsxMiniChartRanges());
            set
            {
                if (value != null)
                {
                    _ranges = value;
                }
            }
        }
        #endregion

        #region [public] (XlsxMiniChartSize) ChartSize: Gets or sets a reference that contains the minichart size
        /// <summary>
        /// Gets or sets a reference that contains the minichart size.
        /// </summary>
        /// <value>
        /// Preferred cell size.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-size")]
        public XlsxMiniChartSize ChartSize
        {
            get => _chartSize ?? (_chartSize = new XlsxMiniChartSize());
            set => _chartSize = value;
        }
        #endregion

        #region [public] (XlsxMiniChartChartType) ChartType: Gets or sets a reference that contains the type of minichart and its visual configuration
        /// <summary>
        /// Gets or sets a reference that contains the type of minichart and its visual configuration.
        /// </summary>
        /// <value>
        /// Visual setting of minichart types.
        /// </value>
        [XmlElement]
        [JsonProperty("chart-type")]
        public XlsxMiniChartChartType ChartType
        {
            get
            {
                if (_type == null)
                {
                    _type = new XlsxMiniChartChartType();
                }

                _type.SetParent(this);

                return _type;
            }
            set => _type = value;
        }
        #endregion

        #region [public] (YesNo) DisplayHidden: Gets or sets a value that determines preferred action for display hidden values
        /// <summary>
        /// Gets or sets a value that determines preferred action for display hidden values. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if displays display hidden values on mini-chart; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("display-hidden")]
        [DefaultValue(DefaultDisplayHidden)]
        public YesNo DisplayHidden
        {
            get => _displayHidden;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _displayHidden = value;
            }
        }
        #endregion

        #region [public] (MiniChartEmptyValuesAs) EmptyValueAs: Gets or sets a value that determines preferred action when the field does not contain information
        /// <summary>
        /// Gets or sets a value that determines preferred action when the field does not contain information. The default is <see cref="MiniChartEmptyValuesAs.Zero"/>.
        /// </summary>
        /// <value>
        /// A value that determines preferred action when the field does not contain information.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("empty-value")]
        [DefaultValue(DefaultEmptyValueAs)]
        public MiniChartEmptyValuesAs EmptyValueAs
        {
            get => _emptyValuesAs;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _emptyValuesAs = value;
            }
        }
        #endregion

        #endregion

        #region public override readonly properties

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
            ChartAxes.IsDefault &&
            ChartRanges.IsDefault &&
            ChartSize.IsDefault &&
            ChartType.IsDefault &&
            EmptyValueAs.Equals(DefaultEmptyValueAs) &&
            DisplayHidden.Equals(DefaultDisplayHidden); 
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChart) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxMiniChart Clone()
        {
            var cloned = (XlsxMiniChart)base.Clone();
            cloned.ChartAxes = ChartAxes.Clone();
            cloned.ChartRanges = ChartRanges.Clone();
            cloned.ChartSize = ChartSize.Clone();
            cloned.Properties = Properties.Clone();
            
            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxMiniChartOptions): Apply specified options to this minichart
        /// <summary>
        /// Apply specified options to this minichart.
        /// </summary>
        public virtual void ApplyOptions(XlsxMiniChartOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region ChartAxes
            ChartAxes.ApplyOptions(options.ChartAxes);
            #endregion

            #region ChartRanges
            //ChartRanges.ApplyOptions(options.ChartRanges);
            #endregion

            #region ChartSize
            ChartSize.ApplyOptions(options.ChartSize);
            #endregion

            #region ChartType
            //ChartType.ApplyOptions(options.ChartType);
            #endregion

            #region DisplayHidden
            YesNo? displayHiddenOption = options.DisplayHidden;
            bool displayHiddenHasValue = displayHiddenOption.HasValue;
            if (displayHiddenHasValue)
            {
                DisplayHidden = displayHiddenOption.Value;
            }
            #endregion

            #region EmptyValueAs
            MiniChartEmptyValuesAs? emptyValueOption = options.EmptyValueAs;
            bool emptyValueHasValue = emptyValueOption.HasValue;
            if (emptyValueHasValue)
            {
                EmptyValueAs = emptyValueOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChart): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxMiniChart reference)
        {
            if (reference == null)
            {
                return;
            }

            if (DisplayHidden.Equals(DefaultDisplayHidden))
            {
                DisplayHidden = reference.DisplayHidden;
            }

            if (EmptyValueAs.Equals(DefaultEmptyValueAs))
            {
                EmptyValueAs = reference.EmptyValueAs;
            }

            ChartAxes.Combine(reference.ChartAxes);
            ChartRanges.Combine(reference.ChartRanges);
            ChartSize.Combine(reference.ChartSize);
            ChartType.Combine(reference.ChartType);
        }
        #endregion

        #endregion
    }
}
