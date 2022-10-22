
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="SetBase"/> class.<br/>
    /// Allows modify row(s) height in the specified worksheet.
    /// </summary>
    public class SetRowHeight : SetBase
    {
        #region constructor/s

        #region [public] SetRowHeight(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SetRowHeight"/> class.
        /// </summary>
        public SetRowHeight()
        {
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (IEnumerable<RowDefinition>) Rows: Gets or sets a reference containing rows definitions
        /// <summary>
        /// Gets or sets a reference containing rows definitions.
        /// </summary>
        /// <value>
        /// A <see cref="IEnumerable{RowDefinition}"/> reference containing rows definitions.
        /// </value>
        public IEnumerable<RowDefinition> Rows { get; set; }
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

            if (Rows == null)
            {
                return SetResult.CreateSuccessResult(new SetResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return SetImpl(context, input, SheetName, Rows);
        }

        #endregion

        #endregion

        #region private static methods

        private static SetResult SetImpl(IInput context, Stream input, string sheetName, IEnumerable<RowDefinition> rows)
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

                    foreach (var row in rows)
                    {
                        ws.Row(row.Row).Height = row.Height;
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


        #region public nestes structs

        /// <summary>
        /// Defines a row.
        /// </summary>
        public struct RowDefinition
        {
            #region constructor/s

            #region [public] RowDefinition(): Initializes a new instance of the class
            /// <summary>
            /// Initializes a new instance of the <see cref="RowDefinition"/> class.
            /// </summary>
            /// <param name="row">Row index</param>
            /// <param name="height">Row height value</param>
            public RowDefinition(int row, double height)
            {
                Height = height;
                Row = row;
            }
            #endregion

            #endregion

            #region public properties

            #region [public] (int) Row: Gets or sets a value containing row index value
            /// <summary>
            /// Gets or sets a value containing row index value.
            /// </summary>
            /// <value>
            /// A <see cref="int"/> containing row index.
            /// </value>
            public int Row { get; set; }
            #endregion

            #region [public] (double) Height: Gets or sets a value containing row height value
            /// <summary>
            /// Gets or sets a value containing row height value.
            /// </summary>
            /// <value>
            /// A <see cref="double"/> containing row height value.
            /// </value>
            public double Height { get; set; }
            #endregion

            #endregion
        }

        #endregion
    }
}
