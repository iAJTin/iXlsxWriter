
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

using iTin.Charting.Models.Design.Options;

namespace iTin.Charting.Models.Design
{
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

        #region interfaces

        #region ICloneable
        
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

        #region public readonly properties

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

        #region public properties

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
                _grid ??= new AxisGridModel();
                _grid.SetParent(this);

                return _grid;
            }
            set => _grid = value;
        }

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
                _labels ??= new AxisLabelsModel();
                _labels.SetParent(this);

                return _labels;
            }
            set => _labels = value;
        }

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
                _marks ??= new AxisMarksModel();
                _marks.SetParent(this);

                return _marks;
            }
            set => _marks = value;
        }

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

        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [Browsable(false)]
        [JsonIgnore]
        public AxisModel Parent { get; private set; }

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

        /// <summary>
        /// Gets or sets a reference that contains the visual setting of axis title.
        /// </summary>
        /// <value>
        /// A <see cref="T:iTin.Charting.ComponentModel.Models.AxisTitleModel" /> reference that contains the visual setting of axis title.
        /// </value>
        public AxisTitleModel Title
        {
            get => _title ??= new AxisTitleModel();
            set => _title = value;
        }

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
                _values ??= new AxisValueModel();
                _values.SetParent(this);

                return _values;
            }
            set => _values = value;
        }

        #endregion

        #region public override properties

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

        #region public methods

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

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for this line color.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color" /> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(LineColor);

        #endregion

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";

        #endregion

        #region internal methods

        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        internal void SetParent(AxisModel reference)
        {
            Parent = reference;
        }

        #endregion
    }
}
