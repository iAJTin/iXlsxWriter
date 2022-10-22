
using System;
using System.IO;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="SetBase"/> class.<br/>
    /// Allows autofit columns.
    /// </summary>
    internal class SetAutoFitColumns : SetBase
    {
        #region constructor/s

        #region [public] SetAutoFitColumns(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SetAutoFitColumns"/> class.
        /// </summary>
        public SetAutoFitColumns()
        {
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (SetResult) SetImpl(Stream, IInput): Implementation to execute when set action
        /// <summary>
        /// Implementation to execute when set action.
        /// </summary>
        /// <param name="input">stream input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="SetResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        protected override SetResult SetImpl(Stream input, IInput context) => SetImpl(context, input);
        #endregion

        #endregion

        #region private static methods

        private static SetResult SetImpl(IInput context, Stream input)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    foreach (var ws in excel.Workbook.Worksheets)
                    {
                        var hasDimension = ws.Dimension != null;
                        if (!hasDimension)
                        {
                            continue;
                        }

                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        var start = ws.Cells[ws.Dimension.Address].Start.Column;
                        var end = ws.Cells[ws.Dimension.Address].End.Column;
                        for (int col = start; col <= end; col++)
                        {
                            ws.Column(col).BestFit = true;
                            ws.Column(col).Width = ws.Column(col).Width + 1;
                        }
                    }

                    excel.SaveAs(outputStream);

                    return SetResult.CreateSuccessResult(new SetResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = outputStream
                    });
                }
            }
            catch (Exception ex)
            {
                return SetResult.FromException(
                    ex,
                    new SetResultData
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
