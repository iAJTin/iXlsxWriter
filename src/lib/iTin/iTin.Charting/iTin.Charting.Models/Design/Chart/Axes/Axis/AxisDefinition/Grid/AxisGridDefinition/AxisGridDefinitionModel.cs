
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
    /// Represents the visual setting the labels of a axis.
    /// </summary>
    public partial class AxisGridDefinitionModel : IAxisElementModel, ICloneable
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const float DefaultInterval = 0.0f;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultLineColor = "Black";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultLineWidth = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownLineStyle DefaultLineDashStyle = KnownLineStyle.Continuous;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisGridDefinitionModel" /> class.
        /// </summary>
        public AxisGridDefinitionModel()
        {
            Interval = DefaultInterval;
            LineColor = DefaultLineColor;
            LineDashStyle = DefaultLineDashStyle;
            LineWidth = DefaultLineWidth;
            Show = DefaultShow;
        }

        #endregion

        #region interfaces

        #region IAxisElementModel

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the interval between the main or secondary grid lines. The default value is zero <b>(0)</b>.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Single?" /> value that represents the interval between the grid lines. 
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultInterval)]
        public float? Interval { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the line color of grid lines. The default value is <b>(Black)</b>.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Int32" /> value that represents the line color.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineColor)]
        public string LineColor { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the line style of a grid. The default value is <b>(<see cref="F:iTin.Charting.Models.Design.KnownLineStyle.Continuous"/>)</b>.
        /// </summary>
        /// <value>
        /// An enumeration value <see cref="T:iTin.Charting.Models.Design.KnownLineStyle"/>.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineDashStyle)]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnownLineStyle LineDashStyle { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the line width of grid lines. The default value is one <b>(1)</b>.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Int32" /> value that represents the line width in pixels.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultLineWidth)]
        public int LineWidth { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets a value that determines whether the lines grid are visible. The default value is <b>YesNo.No</b>.
        /// </summary>
        /// <value>
        /// <b>YesNo.Yes</b> if display the the lines grid; otherwise, <b>YesNo.No</b>.
        /// </value>
        [JsonProperty]
        [XmlAttribute]
        [DefaultValue(DefaultShow)]
        [JsonConverter(typeof(StringEnumConverter))]
        public YesNo Show { get; set; }

        #endregion

        #region public methods

        /// <inheritdoc />
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color" /> structure preferred for this font.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color" /> structure that represents a .NET color.
        /// </returns>
        public Color GetColor() => ColorHelper.GetColorFromString(LineColor);

        #endregion

        #endregion

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

        #region public properties

        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        public AxisGridModel Parent { get; private set; }

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
            Interval.Equals(DefaultInterval) &&
            LineColor.Equals(DefaultLineColor) &&
            LineWidth.Equals(DefaultLineWidth) &&
            LineDashStyle.Equals(DefaultLineDashStyle) &&
            Show.Equals(DefaultShow);

        #endregion

        #region public methods

        /// <summary>
        /// Apply specified options to this axis definition.
        /// </summary>
        public void ApplyOptions(AxisGridDefinitionOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Interval
            float? intervalOption = options.Interval;
            bool intervalHasValue = intervalOption.HasValue;
            if (intervalHasValue)
            {
                Interval = intervalOption.Value;
            }
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

            #region Show
            YesNo? showOption = options.Show;
            bool showHasValue = showOption.HasValue;
            if (showHasValue)
            {
                Show = showOption.Value;
            }
            #endregion
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public AxisGridDefinitionModel Clone()
        {
            var cloned = (AxisGridDefinitionModel)MemberwiseClone();
            cloned.SetParent(Parent);

            return cloned;
        }

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
        internal void SetParent(AxisGridModel reference)
        {
            Parent = reference;
        }

        #endregion
    }
}
