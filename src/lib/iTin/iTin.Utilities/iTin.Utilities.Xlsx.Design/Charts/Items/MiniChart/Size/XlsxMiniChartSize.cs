
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Represents a minichart size definition.
    /// </summary>
    public partial class XlsxMiniChartSize : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultVerticalCells = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultHorizontalCells = 1;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _verticalCells;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _horizontalCells;
        #endregion

        #region constructor/s

        #region [public] XlsxMiniChartSize(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxMiniChartSize"/> class.
        /// </summary>
        public XlsxMiniChartSize()
        {
            VerticalCells = DefaultVerticalCells;
            HorizontalCells = DefaultHorizontalCells;
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

        #endregion

        #region public properties

        #region [public] (int) HorizontalCells: Gets or sets the horizontal cells
        /// <summary>
        /// Gets or sets the horizontal cells. The default value is <b>1</b>.
        /// </summary>
        /// <value>
        /// Horizontal cells
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
        [XmlAttribute]
        [JsonProperty("horizontal-cells")]
        [DefaultValue(DefaultHorizontalCells)]
        public int HorizontalCells
        {
            get => _horizontalCells;
            set
            {
                SentinelHelper.ArgumentLessThan(nameof(HorizontalCells), value, 1);
                _horizontalCells = value;
            }
        }
        #endregion

        #region [public] (int) VerticalCells: Gets or sets the vertical cells
        /// <summary>
        /// Gets or sets the vertical cells. The default value is <b>1</b>.
        /// </summary>
        /// <value>
        /// Preferred merge orientation.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
        [XmlAttribute]
        [JsonProperty("vertical-cells")]
        [DefaultValue(DefaultVerticalCells)]
        public int VerticalCells
        {
            get => _verticalCells;
            set
            {
                SentinelHelper.ArgumentLessThan(nameof(VerticalCells), value, 1);
                _verticalCells = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault => HorizontalCells.Equals(DefaultHorizontalCells) && VerticalCells.Equals(DefaultVerticalCells);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxMiniChartSize) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxMiniChartSize Clone() => (XlsxMiniChartSize) MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxMiniChartSizeOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxMiniChartSizeOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region HorizontalCells
            int? horizontalCellsOption = options.HorizontalCells;
            bool horizontalCellsHasValue = horizontalCellsOption.HasValue;
            if (horizontalCellsHasValue)
            {
                HorizontalCells = horizontalCellsOption.Value;
            }
            #endregion

            #region VerticalCells
            int? verticalCellsOption = options.HorizontalCells;
            bool verticalCellsHasValue = verticalCellsOption.HasValue;
            if (verticalCellsHasValue)
            {
                VerticalCells = verticalCellsOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxMiniChartSize): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxMiniChartSize reference)
        {
            if (reference == null)
            {
                return;
            }

            if (HorizontalCells.Equals(DefaultHorizontalCells))
            {
                HorizontalCells = reference.HorizontalCells;
            }

            if (VerticalCells.Equals(DefaultVerticalCells))
            {
                VerticalCells = reference.VerticalCells;
            }
        }
        #endregion

        #endregion
    }
}
