
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
    /// Represents a Excel cell by row and column values
    /// </summary>
    public partial class XlsxPointRange : ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultRow = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultColumn = 1;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const AbsoluteStrategy DefaultAbsolute = AbsoluteStrategy.None;
        #endregion

        #region private field members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxPoint _point;

        #endregion

        #region constructor/s

        #region [public] XlsxPoint(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxPoint"/> class.
        /// </summary>
        public XlsxPointRange()
        {
            _point = new XlsxPoint
            {
                Row = DefaultRow,
                Column = DefaultColumn,
                AbsoluteStrategy = DefaultAbsolute,
            };
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

        #region [public] (AbsoluteStrategy) AbsoluteStrategy: Gets or sets the preferred absoute strategy for column and row values
        /// <summary>
        /// Gets or sets the preferred absoute strategy for column and row values. The default value is <see cref="Shared.AbsoluteStrategy.None"/>.
        /// </summary>
        /// <value>
        /// Preferred absoute strategy for column and row values.
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("absolute-strategy")]
        [DefaultValue(DefaultAbsolute)]
        public AbsoluteStrategy AbsoluteStrategy
        {
            get => _point.AbsoluteStrategy;
            set => _point.AbsoluteStrategy = value;
        }
        #endregion

        #region [public] (int) Column: Gets or sets the column value
        /// <summary>
        /// Gets or sets the column value. The default value is <b>1</b>.
        /// </summary>
        /// <value>
        /// column
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
        [XmlAttribute]
        [JsonProperty("column")]
        [DefaultValue(DefaultColumn)]
        public int Column
        {
            get => _point.Column;
            set => _point.Column = value;
        }
        #endregion

        #region [public] (int) Row: Gets or sets the row value
        /// <summary>
        /// Gets or sets the row value. The default value is <b>1</b>.
        /// </summary>
        /// <value>
        /// Row
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The value specified is less than 1.</exception>
        [XmlAttribute]
        [JsonProperty("row")]
        [DefaultValue(DefaultRow)]
        public int Row
        {
            get => _point.Row;
            set => _point.Row = value;
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
        public override bool IsDefault =>
            base.IsDefault &&
            Row.Equals(DefaultRow) &&
            Column.Equals(DefaultColumn) &&
            AbsoluteStrategy.Equals(DefaultAbsolute);
        #endregion

        #endregion

        #region public methods

        #region [public] (void) Offset(Point): Translates this XlsxPointRange by the specified amount
        /// <summary>
        /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
        /// </summary>
        public void Offset(Point p) => Offset(p.X, p.Y);
        #endregion

        #region [public] (void) Offset(XlsxPoint): Translates this XlsxPointRange by the specified amount
        /// <summary>
        /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
        /// </summary>
        public void Offset(XlsxPoint p) => Offset(p.Column, p.Row);
        #endregion

        #region [public] (void) Offset(XlsxPointRange): Translates this XlsxPointRange by the specified amount
        /// <summary>
        /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
        /// </summary>
        public void Offset(XlsxPointRange p) => Offset(p.Column, p.Row);
        #endregion

        #region [public] (void) Offset(int, int): Translates this XlsxPointRange by the specified amount
        /// <summary>
        /// Translates this <see cref='XlsxPointRange'/> by the specified amount.
        /// </summary>
        public void Offset(int dx, int dy)
        {
            unchecked
            {
                Column += dx;
                Row += dy;
            }
        }

        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxPointRange) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxPointRange Clone()
        {
            var cloned = (XlsxPointRange)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }

        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxExcelRangeOptions): Apply specified options to this alignment
        ///// <summary>
        ///// Apply specified options to this alignment.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxExcelRangeOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region HorizontalCells
        //    int? horizontalCellsOption = options.HorizontalCells;
        //    bool horizontalCellsHasValue = horizontalCellsOption.HasValue;
        //    if (horizontalCellsHasValue)
        //    {
        //        HorizontalCells = horizontalCellsOption.Value;
        //    }
        //    #endregion

        //    #region VerticalCells
        //    int? verticalCellsOption = options.HorizontalCells;
        //    bool verticalCellsHasValue = verticalCellsOption.HasValue;
        //    if (verticalCellsHasValue)
        //    {
        //        VerticalCells = verticalCellsOption.Value;
        //    }
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxPointRange): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxPointRange reference)
        {
            if (reference == null)
            {
                return;
            }

            if (AbsoluteStrategy.Equals(DefaultAbsolute))
            {
                AbsoluteStrategy = reference.AbsoluteStrategy;
            }

            if (Column.Equals(DefaultColumn))
            {
                Column = reference.Column;
            }

            if (Row.Equals(DefaultRow))
            {
                Row = reference.Row;
            }
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var rowNumber = AbsoluteStrategy == AbsoluteStrategy.Both || AbsoluteStrategy == AbsoluteStrategy.Row ? $"${Row}" : $"{Row}";
            var columnLetter = GetColumnLetter(Column, AbsoluteStrategy == AbsoluteStrategy.Column || AbsoluteStrategy == AbsoluteStrategy.Both);

            return $"{columnLetter}{rowNumber}";
        }
        #endregion

        #endregion
    }
}
