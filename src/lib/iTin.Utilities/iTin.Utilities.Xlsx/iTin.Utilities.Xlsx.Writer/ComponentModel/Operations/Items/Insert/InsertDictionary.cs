
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="InsertBase"/> class.<br/>
    /// Allows insert a <see cref="Dictionary{TKey,TValue}"/> reference.
    /// TKey is <see cref="string"/>
    /// TValue is <see cref="object"/>.
    /// </summary>
    public class InsertDictionary : InsertBase
    {
        #region constructor/s

        #region [public] InsertDataset(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertDataTable"/> class.
        /// </summary>
        public InsertDictionary()
        {
            Data = null;
            SheetName = string.Empty;
            Location = new XlsxPointRange { Column = 1, Row = 1 };
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (Dictionary<string, object>) Data: Gets or sets a reference to dictionary to insert
        /// <summary>
        /// Gets or sets a reference to dictionary to insert.
        /// </summary>
        /// <value>
        /// A <see cref="Dictionary{TKey, TValue}"/> reference to insert. TKey is <see cref="string"/>, TValue is <see cref="object"/>.
        /// </value>
        public Dictionary<string, object> Data { get; set; }
        #endregion

        #region [public] (XlsxPointRange) Location: Gets or sets a reference a XlsxPointRange which represents the insert location
        /// <summary>
        /// Gets or sets a reference a <see cref="XlsxPointRange"/> which represents the insert location.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPointRange"/> object that contains the insert location.
        /// </value>
        public XlsxPointRange Location { get; set; }
        #endregion

        #region [public] (DictionaryStyles) Styles: Gets or sets a reference containing the cell data and headers styles to use
        /// <summary>
        /// Gets or sets a reference containing the cell data and headers styles to use.
        /// </summary>
        /// <value>
        /// A <see cref="DataStyles"/> object that contains the cell styles to use
        /// </value>
        public DictionaryStyles Styles { get; set; }
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (InsertResult) InsertImpl(Stream, IInput): Implementation to execute when insert action
        /// <summary>
        /// Implementation to execute when insert action.
        /// </summary>
        /// <param name="input">stream input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        protected override InsertResult InsertImpl(Stream input, IInput context)
        {
            if (string.IsNullOrEmpty(SheetName))
            {
                return InsertResult.CreateErroResult(
                    "Sheet name can not be null or empty",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            if (Location == null)
            {
                Location = new XlsxPointRange { Column = 1, Row = 1 };
            }

            if (Data == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Styles == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return InsertImpl(context, input, SheetName, (XlsxPointRange)Location, Data, Styles);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxPointRange location, Dictionary<string, object> data, DictionaryStyles styles)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    var ws = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
                    if (ws == null)
                    {
                        return InsertResult.CreateErroResult(
                            $"Sheet '{sheetName}' not found",
                            new InsertResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }

                    // cell styles > Headers
                    XlsxCellStyle headerTextTextStyle = excel.CreateStyle(styles.Headers.Text);

                    // cell styles > Values
                    XlsxCellStyle valueTextTextStyle = excel.CreateStyle(styles.Values.Text);
                    XlsxCellStyle valueDatetimeCellStyle = excel.CreateStyle(styles.Values.DateTime);
                    XlsxCellStyle valueDecimalCellStyle = excel.CreateStyle(styles.Values.Decimal);

                    var keys = data.Keys;
                    foreach (var key in keys)
                    {
                        var isOdd = location.Row.IsOdd();

                        var headerCell = ws.Cells[location.Row, location.Column];
                        headerCell.StyleName = isOdd ? $"{headerTextTextStyle.Name}_Alternate" : headerTextTextStyle.Name ?? XlsxBaseStyle.NameOfDefaultStyle;
                        headerCell.Value = key;

                        var value = data[key];
                        var valueCell = ws.Cells[location.Row, location.Column + 1];

                        XlsxCellStyle styleToUse;
                        switch (value)
                        {
                            case string _:
                                styleToUse = valueTextTextStyle;
                                break;

                            case float _:
                            case double _:
                                styleToUse = valueDecimalCellStyle;
                                break;

                            case DateTime _:
                                styleToUse = valueDatetimeCellStyle;
                                break;

                            default:
                                styleToUse = valueTextTextStyle;
                                break;
                        }

                        valueCell.StyleName = isOdd ? $"{styleToUse.Name}_Alternate" : styleToUse.Name ?? XlsxBaseStyle.NameOfDefaultStyle;
                        valueCell.Value = styleToUse.Content.DataType.GetFormattedDataValue(value.ToString()).FormattedValue;

                        location.Offset(0, 1);
                    }

                    excel.SaveAs(outputStream);

                    return InsertResult.CreateSuccessResult(new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = outputStream
                    });
                }
            }
            catch (Exception ex)
            {
                return InsertResult.FromException(
                    ex,
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }
        }

        #endregion
    }
}
