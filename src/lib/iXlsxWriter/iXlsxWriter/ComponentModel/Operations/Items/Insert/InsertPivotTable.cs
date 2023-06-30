
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.ComponentModel.Result.Insert;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert a pivot table in the specified location
    /// </summary>
    public class InsertPivotTable : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertPivotTable(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertPivotTable"/> class.
        /// </summary>
        public InsertPivotTable()
        {
            Location = null;
            SheetName = string.Empty;
        }
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

            return InsertImpl(context, input, SheetName, Location);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location)
        {
            var outputStream = new MemoryStream();

            try
            {
                using var excel = new ExcelPackage(input);
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

                //ws.PivotTables.Add(,, "name");

                ExcelAddressBase locationAddress = location.ToEppExcelAddress();
                ws.Cells[locationAddress.ToString()].AutoFilter = true;

                excel.SaveAs(outputStream);

                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = outputStream
                });
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
