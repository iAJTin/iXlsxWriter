
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;

    using iTin.Core.Models.Design.Enums;

    using Styles;

    /// <summary>
    /// Represents a cell header styles to use with data.
    /// </summary>
    public class HeaderStyles : ICloneable
    {
        #region constructor/s

        #region [public] HeaderStyles(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="DataStyles"/> class.
        /// </summary>
        public HeaderStyles()
        {
            Text = XlsxCellStyle.Default;
            DateTime = new XlsxCellStyle
            {
                Content =
                {
                    DataType = new DateTimeDataType
                    {
                        Format = KnownDateTimeFormat.ShortDatePattern
                    }
                }
            };
            Numeric = new XlsxCellStyle
            {
                Content =
                {
                    DataType = new NumberDataType {Decimals = 0, Separator = YesNo.Yes}
                }
            };
            Decimal = new XlsxCellStyle
            {
                Content =
                {
                    DataType = new NumberDataType {Decimals = 2, Separator = YesNo.Yes}
                }
            };
            Currency = new XlsxCellStyle
            {
                Content =
                {
                    DataType = new CurrencyDataType {Decimals = 2}
                }
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

        #region [public] (XlsxCellStyle) Currency: Gets or sets the preferred currency cell style
        /// <summary>
        /// Gets or sets the preferred currency cell style
        /// </summary>
        /// <value>
        /// Preferred currency cell style.
        /// </value>
        public XlsxCellStyle Currency { get; set; }
        #endregion 

        #region [public] (XlsxCellStyle) DateTime: Gets or sets the preferred datetime cell style
        /// <summary>
        /// Gets or sets the preferred datetime cell style.
        /// </summary>
        /// <value>
        /// Preferred datetime cell style.
        /// </value>
        public XlsxCellStyle DateTime { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) Decimal: Gets or sets the preferred decimal cell style
        /// <summary>
        /// Gets or sets the preferred decimal cell style
        /// </summary>
        /// <value>
        /// Preferred decimal cell style.
        /// </value>
        public XlsxCellStyle Decimal { get; set; }
        #endregion 

        #region [public] (XlsxCellStyle) Numeric: Gets or sets the preferred numeric cell style
        /// <summary>
        /// Gets or sets the preferred numeric cell style.
        /// </summary>
        /// <value>
        /// Preferred numeric cell style.
        /// </value>
        public XlsxCellStyle Numeric { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) Text: Gets or sets the preferred text cell style
        /// <summary>
        /// Gets or sets the preferred text cell style.
        /// </summary>
        /// <value>
        /// Preferred text cell style.
        /// </value>
        public XlsxCellStyle Text { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (HeaderStyles) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public HeaderStyles Clone()
        {
            var cloned = (HeaderStyles)MemberwiseClone();
            cloned.Text = Text.Clone();
            cloned.Decimal = Text.Clone();
            cloned.Numeric = Text.Clone();
            cloned.DateTime = Text.Clone();
            cloned.Currency = Currency.Clone();

            return cloned;
        }
        #endregion

        #endregion
    }
}
