
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core;
using iTin.Core.Helpers;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines a generic chart.
    /// </summary>
    public partial class XlsxMiniChartHorizontalAxis : ICombinable<XlsxMiniChartHorizontalAxis>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultRightToLeft = YesNo.No;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const string DefaultAxisColor = "Automatic";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const MiniChartHorizontalAxisType DefaultAxisType = MiniChartHorizontalAxisType.General;
        #endregion

        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _axisColor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _rightToLeft;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MiniChartHorizontalAxisType _axisType;
        #endregion

        #region constructor/s

        #region [public] XlsxMiniChartHorizontalAxis(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartHorizontalAxis"/> class.
        /// </summary>
        public XlsxMiniChartHorizontalAxis()
        {
            Color = DefaultAxisColor;
            RightToLeft = DefaultRightToLeft;
            Show = DefaultShow;
            Type = DefaultAxisType;
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

        #region (void) ICombinable<XlsxMiniChartVerticalAxis>.Combine(XlsxMiniChartHorizontalAxis): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxMiniChartHorizontalAxis>.Combine(XlsxMiniChartHorizontalAxis reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxMiniChartHorizontalAxis) Default: Returns a new instance containing default minichart horizontal axis definition settings
        /// <summary>
        /// Returns a new instance containing default minichart horizontal axis definition settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxMiniChartHorizontalAxis"/> reference containing the default minichart horizontal axis definition settings.
        /// </value>
        public static XlsxMiniChartHorizontalAxis Default => new XlsxMiniChartHorizontalAxis();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (MiniChartAxesModel) Parent: Gets the parent element of the element
        /// <summary>
        /// Gets the parent element of the element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of the element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxMiniChartAxes Parent { get; private set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (string) Color: Gets or sets preferred axis color
        /// <summary>
        /// Gets or sets preferred axis color. The default is <b>Automatic</b>.
        /// </summary>
        /// <value>
        /// Preferred axis color.
        /// </value>
        /// <exception cref="ArgumentNullException">The value specified is <b>null</b> (<b>Nothing</b> in Visual Basic).</exception>
        [XmlAttribute]
        [JsonProperty("color")]
        [DefaultValue(DefaultAxisColor)]
        public string Color
        {
            get => _axisColor;
            set
            {
                SentinelHelper.ArgumentNull(value, nameof(Color));

                _axisColor = value;
            }
        }
        #endregion

        #region [public] (YesNo) RightToLeft: Gets or sets a value indicating whether the data are drawn from right to left
        /// <summary>
        /// Gets or sets a value indicating whether the data are drawn from right to left. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if the data are drawn from right to left; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("right-to-left")]
        [DefaultValue(DefaultRightToLeft)]
        public YesNo RightToLeft
        {
            get => _rightToLeft;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _rightToLeft = value;
            }
        }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether this axis is shown
        /// <summary>
        /// Gets or sets a value that determines whether this axis is shown. The default is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> this axis is shown; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("show")]
        [DefaultValue(DefaultShow)]
        public YesNo Show
        {
            get => _show;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _show = value;
            }
        }
        #endregion

        #region [public] (string) Type: Gets or sets preferred axis type
        /// <summary>
        /// Gets or sets preferred axis type. The default is <see cref="MiniChartHorizontalAxisType.General"/>.
        /// </summary>
        /// <value>
        /// Preferred axis type.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("axis-type")]
        [DefaultValue(DefaultAxisType)]
        public MiniChartHorizontalAxisType Type
        {
            get => _axisType;
            set
            {
                SentinelHelper.IsEnumValid(_axisType);

                _axisType = value;
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
            Color.Equals(DefaultAxisColor) &&
            RightToLeft.Equals(DefaultRightToLeft) && 
            Show.Equals(DefaultShow) && 
            Type.Equals(DefaultAxisType);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartHorizontalAxis) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartHorizontalAxis Clone()
        {
            var cloned = (XlsxMiniChartHorizontalAxis)MemberwiseClone();
            //styleCloned.Borders = Borders.Clone();
            //styleCloned.Content = Content.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #region [public] (Color) GetColor(): Gets a reference to the color structure preferred for this axis
        /// <summary>
        /// Gets a reference to the <see cref="T:System.Drawing.Color"/> structure preferred for this axis.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Drawing.Color"/> structure that represents a .NET color.
        /// </returns>
        public Color GetColor()
        {
            return Color.Equals(DefaultAxisColor)
                ? System.Drawing.Color.Black
                : ColorHelper.GetColorFromString(Color);
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxMiniChartHorizontalAxisOptions): Apply specified options to this axis
        /// <summary>
        /// Apply specified options to this axis.
        /// </summary>
        public virtual void ApplyOptions(XlsxMiniChartHorizontalAxisOptions options)
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

            #region RightToLeft
            YesNo? rightToLeftOption = options.RightToLeft;
            bool rightToLeftHasValue = rightToLeftOption.HasValue;
            if (rightToLeftHasValue)
            {
                RightToLeft = rightToLeftOption.Value;
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

            #region Type
            MiniChartHorizontalAxisType? typeOption = options.Type;
            bool typeHasValue = typeOption.HasValue;
            if (typeHasValue)
            {
                Type = typeOption.Value;
            }
            #endregion

        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartHorizontalAxis): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference style</param>
        public virtual void Combine(XlsxMiniChartHorizontalAxis reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Color.Equals(DefaultAxisColor))
            {
                Color = reference.Color;
            }

            if (RightToLeft.Equals(DefaultRightToLeft))
            {
                RightToLeft = reference.RightToLeft;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Type.Equals(DefaultAxisType))
            {
                Type = reference.Type;
            }
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxMiniChartAxes): Sets the element that owns this
        /// <summary>
        /// Sets the element that owns this <see cref="XlsxMiniChartHorizontalAxis"/>.
        /// </summary>
        /// <param name="reference">Reference to owner.</param>
        internal void SetParent(XlsxMiniChartAxes reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
