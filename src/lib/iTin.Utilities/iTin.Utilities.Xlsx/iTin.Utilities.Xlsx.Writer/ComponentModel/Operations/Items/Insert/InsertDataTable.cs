﻿
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;

    using Design.Shared;

    using Result.Insert;

    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert a <see cref="DataTable"/> reference.
    /// </summary>
    public class InsertDataTable : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertDataset(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertDataTable"/> class.
        /// </summary>
        public InsertDataTable()
        {
            Data = null;
            SheetName = string.Empty;
            Location = new XlsxPointRange { Column = 1, Row = 1 };
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (DataTable) Data: Gets or sets a reference to datatable to insert
        /// <summary>
        /// Gets or sets a reference to datatable to insert.
        /// </summary>
        /// <value>
        /// A <see cref="DataTable"/> reference to insert.
        /// </value>
        public DataTable Data { get; set; }
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

            if (Data == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return InsertImpl(context, input, SheetName, Data, Location);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, DataTable data, XlsxBaseRange location)
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

                    ExcelAddressBase locationAddress = location.ToEppExcelAddress();
                    ws.Cells[locationAddress.ToString()].LoadFromDataTable(data, true);

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
