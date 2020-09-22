
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;

    using Result.Set;

    /// <summary>
    /// A Specialization of <see cref="SetBase"/> class.<br/>
    /// Allows modify column(s) width in the specified worksheet.
    /// </summary>
    public class SetColumnWidth : SetBase
    {
        #region constructor/s

        #region [public] SetColumnWidth(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SetColumnWidth"/> class.
        /// </summary>
        public SetColumnWidth()
        {
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (IEnumerable<ColumnDefinition>) Columns: Gets or sets a reference containing columns definitions
        /// <summary>
        /// Gets or sets a reference containing columns definitions.
        /// </summary>
        /// <value>
        /// A <see cref="IEnumerable{ColumnDefinition}"/> reference containing columns definitions.
        /// </value>
        public IEnumerable<ColumnDefinition> Columns { get; set; }
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

            if (Columns == null)
            {
                return SetResult.CreateSuccessResult(new SetResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return SetImpl(context, input, SheetName, Columns);
        }
        #endregion

        #endregion

        #region private static methods

        private static SetResult SetImpl(IInput context, Stream input, string sheetName, IEnumerable<ColumnDefinition> columns)
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

                    foreach (var column in columns)
                    {
                        ws.Column(column.Column).Width = column.Width;
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
        /// Defines a column.
        /// </summary>
        public struct ColumnDefinition
        {
            #region constructor/s

            #region [public] ColumnDefinition(): Initializes a new instance of the class
            /// <summary>
            /// Initializes a new instance of the <see cref="ColumnDefinition"/> class.
            /// </summary>
            /// <param name="column">Column index</param>
            /// <param name="width">Column width value</param>
            public ColumnDefinition(int column, double width)
            {
                Width = width;
                Column = column;
            }
            #endregion

            #endregion

            #region public properties

            #region [public] (int) Column: Gets or sets a value containing column index value
            /// <summary>
            /// Gets or sets a value containing column index value.
            /// </summary>
            /// <value>
            /// A <see cref="int"/> containing column index.
            /// </value>
            public int Column { get; set; }
            #endregion

            #region [public] (double) Width: Gets or sets a value containing column width value
            /// <summary>
            /// Gets or sets a value containing column width value.
            /// </summary>
            /// <value>
            /// A <see cref="double"/> containing column width value.
            /// </value>
            public double Width { get; set; }
            #endregion

            #endregion
        }

        #endregion
    }
}
