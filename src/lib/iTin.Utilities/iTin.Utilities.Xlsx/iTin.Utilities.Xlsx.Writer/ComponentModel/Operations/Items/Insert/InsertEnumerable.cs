
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="InsertWithStyleBase"/> class.<br/>
    /// Allows insert a <see cref="InsertEnumerable{T}"/> reference.
    /// </summary>
    public class InsertEnumerable<Ti> : InsertWithStyleBase
    {
        #region constructor/s

        #region [public] InsertEnumerable(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertEnumerable{Ti}"/> class.
        /// </summary>
        public InsertEnumerable()
        {
            Data = null;
            ShowHeaders = YesNo.Yes;
            SheetName = string.Empty;
            Style = XlsxCellStyle.Default;
            Location = new XlsxPointRange { Column = 1, Row = 1 };
        }
        #endregion

        #endregion

        #region public new properties

        #region [public] {new} (IEnumerable<Ti>) Data: Gets or sets a reference to enumerable data to insert
        /// <summary>
        /// Gets or sets a reference to enumerable data to insert.
        /// </summary>
        /// <value>
        /// A <see cref="IEnumerable{T}"/> object containing information to insert
        /// </value>
        public new IEnumerable<Ti> Data { get; set; }
        #endregion

        #endregion

        #region public properties

        #region [public] (YesNo) ShowHeaders: Gets or sets the preferred option for show headers
        /// <summary>
        /// Gets or sets the preferred option for show headers. The default value is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> for show headers; otherwise <see cref="YesNo.No"/>.
        /// </value>
        public YesNo ShowHeaders { get; set; }
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
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Style == null)
            {
                Style = XlsxCellStyle.Default;
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

            return InsertImpl(context, input, SheetName, Data, Location, ShowHeaders, Style);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl<T>(IInput context, Stream input, string sheetName, IEnumerable<T> data, XlsxBaseRange location, YesNo showHeaders, XlsxCellStyle style)
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

                    var safeData = data.ToList();
                    ExcelAddressBase locationAddress = location.ToEppExcelAddress();
                    ws.Cells[locationAddress.ToString()].LoadFromCollection(safeData, showHeaders == YesNo.Yes);

                    XlsxCellStyle styleToUse = excel.CreateStyle(style);
                    var range = ws.Cells[locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.End.Row + safeData.Count - 1, locationAddress.End.Column];
                    range.StyleName = styleToUse.Name;

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
