
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Helpers;

    using Options;

    /// <summary>
    /// Represents the visual setting of a axis.
    /// </summary>
    public partial class AxisDefinitionModel : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultLineColor = "Black";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultLineWidth = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownLineStyle DefaultLineDashStyle = KnownLineStyle.Continuous;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultName = "";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisGridModel _grid;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisMarksModel _marks;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisTitleModel _title;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisLabelsModel _labels;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AxisValueModel _values;
        #endregion

        #region constructor/s

        #region [public] AxisDefinitionModel(): Initializes a new instance of this class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:iTin.Charting.ComponentModel.Models.AxisDefinitionModel" /> class.
        /// </summary>
        public AxisDefinitionModel()
        {
            Name = DefaultName;
            LineColor = DefaultLineColor;
            LineDashStyle = DefaultLineDashStyle;
            LineWidth = DefaultLineWidth;
            Show = DefaultShow;
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

        #region public readonly properties

        #region [public] (bool) GridSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool GridSpecified => !Grid.IsDefault;
        #endregion

        #region [public] (bool) LabelsSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool LabelsSpecified => !Labels.IsDefault;
        #endregion

        #region [public] (bool) MarksSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool MarksSpecified => !Marks.IsDefault;
        #endregion

        #region [public] (bool) TitleSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool TitleSpecified => !Title.IsDefault;
        #endregion

        #region [public] (bool) ValuesSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ValuesSpecified => !Values.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (AxisGridModel) Grid: Gets or sets a reference that contains the visual setting of axis grid
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of axis grid.
        /// </summary>
        /// <value>
        /// A <see cref="AxisGridModel" /> reference that contains the visual setting of axis grid.
        /// </value>
        public AxisGridModel Grid
        {
            get
            {
                if (_grid == null)
                {
                    _grid = new AxisGridModel();
                }

                _grid.SetParent(this);

                return _grid;
            }
            set => _grid = value;
        }
        #endregion

        #region [public] (AxisLabelsModel) Labels: Gets or sets a reference that contains the visual setting of labels axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of labels axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisLabelsModel" /> reference that contains the visual setting of labels axis.
        /// </value>
        public AxisLabelsModel Labels
        {
            get
            {
                if (_labels == null)
                {
                    _labels = new AxisLabelsModel();
                }

                _labels.SetParent(this);

                return _labels;
            }
            set => _labels = value;
        }
        #endregion

        #region [public] (string) LineColor: Gets or sets the line color of axis line
        /// <summary>
        /// Gets or sets the line color of axis line. The default value is <b>(Black)</b>.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Int32" /> value that represents the line color.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineColor)]
        public string LineColor { get; set; }
        #endregion

        #region [public] (KnownLineStyle) LineDashStyle: Gets or sets the line style of axis line
        /// <summary>
        /// Gets or sets the line style of axis line. The default value is <b>(<see cref="F:iTin.Charting.Models.Design.KnownLineStyle.Continuous"/>)</b>.
        /// </summary>
        /// <value>
        /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownLineStyle"/>.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineDashStyle)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownLineStyle LineDashStyle { get; set; }
        #endregion

        #region [public] (int) LineWidth: Gets or sets the line width of grid lines
        /// <summary>
        /// Gets or sets the line width of axis line. The default value is one <b>(1)</b>.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Int32" /> value that represents the line width in pixels.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineWidth)]
        public int LineWidth { get; set; }
        #endregion

        #region [public] (AxisMarksModel) Marks: Gets or sets a reference that contains the visual setting of mark axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of mark axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisMarksModel" /> reference that contains the visual setting of mark axis.
        /// </value>
        public AxisMarksModel Marks
        {
            get
            {
                if (_marks == null)
                {
                    _marks = new AxisMarksModel();
                }

                _marks.SetParent(this);

                return _marks;
            }
            set => _marks = value;
        }
        #endregion

        #region [public] (string) Name: Gets or sets a value that contains the axis identifier name
        /// <summary>
        /// Gets or sets a value that contains the axis identifier name.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.String" /> that contains the axis identifier name.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultName)]
        public string Name { get; set; }
        #endregion

        #region [public] (AxisModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxisModel Parent { get; private set; }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays the axis
        /// <summary>
        /// Gets or sets a value that determines whether displays the axis.
        /// </summary>
        /// <value>
        /// <b>true</b> if displays the axis; otherwise, <b>false</b>. The default is <b>true</b>.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo Show { get; set; }
        #endregion

        #region [public] (AxisTitleModel) Title: Gets or sets a reference that contains the visual setting of axis title
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of axis title.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.AxisTitleModel" /> reference that contains the visual setting of axis title.
        /// </value>
        public AxisTitleModel Title
        {
            get => _title ?? (_title = new AxisTitleModel());
            set => _title = value;
        }
        #endregion

        #region [public] (AxisValueModel) Values: Gets or sets a reference that contains the visual setting of values axis
        /// <summary>
        /// Gets or sets a reference that contains the visual setting of values axis.
        /// </summary>
        /// <value>
        /// A <see cref="AxisValueModel" /> reference that contains the visual setting of values axis.
        /// </value>
        public AxisValueModel Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new AxisValueModel();
                }

                _values.SetParent(this);

                return _values;
            }
            set => _values = value;
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        public override bool IsDefault =>
            Grid.IsDefault &&
            Labels.IsDefault &&
            Marks.IsDefault &&
            Title.IsDefault &&
            Values.IsDefault &&
            Name.Equals(DefaultName) &&
            LineColor.Equals(DefaultLineColor) &&
            LineWidth.Equals(DefaultLineWidth) &&
            LineDashStyle.Equals(DefaultLineDashStyle) &&
            Show.Equals(DefaultShow);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) ApplyOptions(AxisDefinitionOptions): Apply specified options to this axis values
        /// <summary>
        /// Apply specified options to this axis values.
        /// </summary>
        public void ApplyOptions(AxisDefinitionOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Grid
            Grid.ApplyOptions(options.Grid);
            #endregion

            #region Labels
            Labels.ApplyOptions(options.Labels);
            #endregion

            #region LineColor
            string lineColorOption = options.LineColor;
            bool lineColorHasValue = !lineColorOption.IsNullValue();
            if (lineColorHasValue)
            {
                LineColor = lineColorOption;
            }
            #endregion

            #region LineDashStyle
            KnownLineStyle? lineDashStyleOption = options.LineDashStyle;
            bool lineDashStyleHasValue = lineDashStyleOption.HasValue;
            if (lineDashStyleHasValue)
            {
                LineDashStyle = lineDashStyleOption.Value;
            }
            #endregion

            #region LineWidth
            int? lineWidthOption = options.LineWidth;
            bool lineWidthHasValue = lineWidthOption.HasValue;
            if (lineWidthHasValue)
            {
                LineWidth = lineWidthOption.Value;
            }
            #endregion

            #region Marks
            Marks.ApplyOptions(options.Marks);
            #endregion

            #region Name
            string nameOption = options.Name;
            bool nameHasValue = !nameOption.IsNullValue();
            if (nameHasValue)
            {
                Name = nameOption;
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

            #region Title
            Title.ApplyOptions(options.Title);
            #endregion

            #region Values
            Values.ApplyOptions(options.Values);
            #endregion
        }
        #endregion

        #region [public] (AxisDefinitionModel) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisDefinitionModel Clone()
        {
            var cloned = (AxisDefinitionModel)MemberwiseClone();
            cloned.Grid.Clone();
            cloned.Labels.Clone();
            cloned.Marks.Clone();
            cloned.Title.Clone();      
            cloned.Values.Clone();
            cloned.SetParent(Parent);

            return cloned;
        }
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the color structure preferred for this line color
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for this line color.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color" /> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(LineColor);
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

        #region internal methods

        #region [internal] (void) SetParent(AxisModel): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxisModel reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
