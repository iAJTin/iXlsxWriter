
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Helpers;

    /// <summary>
    /// Represents a merge cells definition. Includes cells number in merge and orientation.
    /// </summary>
    public partial class XlsxCellMerge : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultMergeCells = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownMergeOrientation DefaultMergeOrientation = KnownMergeOrientation.Horizontal;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownMergeOrientation _mergeOrientation;
        #endregion

        #region constructor/s

        #region [public] XlsxCellMerge(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxCellMerge"/> class.
        /// </summary>
        public XlsxCellMerge()
        {
            Cells = DefaultMergeCells;
            Orientation = DefaultMergeOrientation;
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

        #region [public] (int) Cells: Gets or sets the merge cells
        /// <summary>
        /// Gets or sets the merge cells. The default value is <b>1</b>.
        /// </summary>
        /// <value>
        /// Merge cells.
        /// </value>
        [XmlAttribute]
        [JsonProperty("cells")]
        [DefaultValue(DefaultMergeCells)]
        public int Cells { get; set; }
        #endregion

        #region [public] (KnownMergeOrientation) Orientation: Gets or sets preferred merge orientation
        /// <summary>
        /// Gets or sets preferred merge orientation. The default value is <see cref="KnownMergeOrientation.Horizontal"/>.
        /// </summary>
        /// <value>
        /// Preferred merge orientation.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("orientation")]
        [DefaultValue(DefaultMergeOrientation)]
        public KnownMergeOrientation Orientation
        {
            get => _mergeOrientation;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _mergeOrientation = value;
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
        public override bool IsDefault => Orientation.Equals(DefaultMergeOrientation) && Cells.Equals(DefaultMergeCells);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxCellMerge) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxCellMerge Clone()
        {
            var cloned = (XlsxCellMerge) MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) ApplyOptions(XlsxCellMergeOptions): Apply specified options to this alignment
        /// <summary>
        /// Apply specified options to this alignment.
        /// </summary>
        public virtual void ApplyOptions(XlsxCellMergeOptions options)
        {
            if (options == null)
            {
                return;
            }

            if (options.IsDefault)
            {
                return;
            }

            #region Cells
            int? cellsOption = options.Cells;
            bool cellsHasValue = cellsOption.HasValue;
            if (cellsHasValue)
            {
                Cells = cellsOption.Value;
            }
            #endregion

            #region Orientation
            KnownMergeOrientation? orientationOption = options.Orientation;
            bool orientationHasValue = orientationOption.HasValue;
            if (orientationHasValue)
            {
                Orientation = orientationOption.Value;
            }
            #endregion
        }
        #endregion

        #region [public] {virtual} (void) Combine(XlsxCellMerge): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxCellMerge reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Orientation.Equals(DefaultMergeOrientation))
            {
                Orientation = reference.Orientation;
            }

            if (Cells.Equals(DefaultMergeCells))
            {
                Cells = reference.Cells;
            }
        }
        #endregion

        #endregion
    }
}
