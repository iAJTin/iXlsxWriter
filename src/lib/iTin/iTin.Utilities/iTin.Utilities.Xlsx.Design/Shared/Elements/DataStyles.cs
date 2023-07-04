
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Styles;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a cell styles to use with data.
/// </summary>
public partial class DataStyles
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="DataStyles"/> class.
    /// </summary>
    public DataStyles()
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

    #region public properties

    /// <summary>
    /// Gets or sets the preferred currency cell style
    /// </summary>
    /// <value>
    /// Preferred currency cell style.
    /// </value>
    public XlsxCellStyle Currency { get; set; }

    /// <summary>
    /// Gets or sets the preferred datetime cell style.
    /// </summary>
    /// <value>
    /// Preferred datetime cell style.
    /// </value>
    public XlsxCellStyle DateTime { get; set; }

    /// <summary>
    /// Gets or sets the preferred decimal cell style
    /// </summary>
    /// <value>
    /// Preferred decimal cell style.
    /// </value>
    public XlsxCellStyle Decimal { get; set; }

    /// <summary>
    /// Gets or sets the preferred numeric cell style.
    /// </summary>
    /// <value>
    /// Preferred numeric cell style.
    /// </value>
    public XlsxCellStyle Numeric { get; set; }

    /// <summary>
    /// Gets or sets the preferred text cell style.
    /// </summary>
    /// <value>
    /// Preferred text cell style.
    /// </value>
    public XlsxCellStyle Text { get; set; }

    #endregion
}
