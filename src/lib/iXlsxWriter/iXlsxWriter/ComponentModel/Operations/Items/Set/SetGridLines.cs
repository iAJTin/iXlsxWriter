
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Core.Models.Design.Enums;
using iXlsxWriter.ComponentModel.Result.Set;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="SetBase"/> class.<br/>
    /// Allows to establish the visibility of the grid lines of a spreadsheet.
    /// </summary>
    public class SetGridLines : SetBase
    {
        #region constructor/s

        #region [public] SetGridLines(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SetGridLines"/> class.
        /// </summary>
        public SetGridLines()
        {
            Show = YesNo.Yes;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (YesNo) Show: Gets or sets a value that indicates whether the grid lines are displayed
        /// <summary>
        /// Gets or sets a value that indicates whether the grid lines are displayed. The default value is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if the grid lines are displayed; otherwise <see cref="YesNo.No"/>.
        /// </value>
        public YesNo Show { get; set; }
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
        protected override SetResult SetImpl(Stream input, IInput context)
        {
            if (string.IsNullOrEmpty(SheetName))
            {
                return SetResult.CreateErroResult(
                    "Sheet name can not be null or empty",
                    new SetResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            return SetImpl(context, input, SheetName, Show);
        }
        #endregion

        #endregion

        #region private static methods

        private static SetResult SetImpl(IInput context, Stream input, string sheetName, YesNo show)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    var ws = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
                    if (ws == null)
                    {
                        return SetResult.CreateErroResult(
                            $"Sheet '{sheetName}' not found",
                            new SetResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }

                    ws.View.ShowGridLines = show == YesNo.Yes;

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
