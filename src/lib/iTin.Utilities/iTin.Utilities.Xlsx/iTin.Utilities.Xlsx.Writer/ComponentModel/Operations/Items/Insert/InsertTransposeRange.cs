
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="InsertWithStyleBase"/> class.<br/>
    /// Allows to transpose a range of data indicating the destination sheet and the starting point.
    /// </summary>
    public class InsertTransposeRange : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertTransposeRange(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertTransposeRange"/> class.
        /// </summary>
        public InsertTransposeRange()
        {
            SourceRange = null;
            Destination = null;
            SheetName = string.Empty;
            ValueStyle = XlsxCellStyle.Default;
            HeaderStyle = XlsxCellStyle.Default;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (QualifiedPointDefinition) Destination: Gets or sets a reference to destination point
        /// <summary>
        /// Gets or sets a reference to destination point.
        /// </summary>
        /// <value>
        /// A <see cref="QualifiedPointDefinition"/> reference to destination point.
        /// </value>
        public QualifiedPointDefinition Destination { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) HeaderStyle: Gets or sets a reference to header style
        /// <summary>
        /// Gets or sets a reference to header style.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> reference to header style.
        /// </value>
        public XlsxCellStyle HeaderStyle { get; set; }
        #endregion

        #region [public] (XlsxRange) SourceRange: Gets or sets a reference to source range
        /// <summary>
        /// Gets or sets a reference to source range.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxRange"/> reference to source range.
        /// </value>
        public XlsxRange SourceRange { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) ValueStyle: Gets or sets a reference to values style
        /// <summary>
        ///Gets or sets a reference to values style.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> reference to values style.
        /// </value>
        public XlsxCellStyle ValueStyle { get; set; }
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
                    "Source sheet name can not be null or empty",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            if (Destination == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (string.IsNullOrEmpty(Destination.WorkSheet))
            {
                return InsertResult.CreateErroResult(
                    "Destination sheet name can not be null or empty",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            if (SourceRange == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (HeaderStyle == null)
            {
                HeaderStyle = XlsxCellStyle.Default;
            }

            if (ValueStyle == null)
            {
                ValueStyle = XlsxCellStyle.Default;
            }

            return InsertImpl(context, input, SheetName, SourceRange, Destination, HeaderStyle, ValueStyle);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxRange source, QualifiedPointDefinition destination, XlsxCellStyle headerStyle, XlsxCellStyle valueStyle)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    var sourceWorksheet = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
                    if (sourceWorksheet == null)
                    {
                        return InsertResult.CreateErroResult(
                            $"source sheet '{sheetName}' not found",
                            new InsertResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }

                    var destinationWorksheet = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(destination.WorkSheet, StringComparison.OrdinalIgnoreCase));
                    if (destinationWorksheet == null)
                    {
                        return InsertResult.CreateErroResult(
                            $"Destination sheet '{sheetName}' not found",
                            new InsertResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }

                    var startDestination = destination.Point.Clone();
                    var x = destination.Point.Column - 1;
                    var sourceRange = sourceWorksheet.Cells[source.Start.Row, source.Start.Column, source.End.Row, source.End.Column];
                    for (var column = 0; column < sourceRange.Columns; column++)
                    {
                        destination.Point = new XlsxPoint { Column = x, Row = destination.Point.Row };
                        for (var row = 0; row < sourceRange.Rows; row++)
                        {
                            destination.Point.Offset(1, 0);
                            destinationWorksheet.Cells[destination.Point.Row, destination.Point.Column].Value = sourceWorksheet.Cells[source.Start.Row + row, source.Start.Column + column].Value;
                        }

                        destination.Point.Offset(0, 1);
                    }

                    XlsxCellStyle headerStyleToUse = excel.CreateStyle(headerStyle);
                    var headerRange = destinationWorksheet.Cells[startDestination.Row, startDestination.Column, startDestination.Row, destination.Point.Column];
                    headerRange.StyleName = headerStyleToUse.Name;

                    XlsxCellStyle valueStyleToUse = excel.CreateStyle(valueStyle);
                    var valueRange = destinationWorksheet.Cells[startDestination.Row + 1, startDestination.Column, destination.Point.Row - 1, destination.Point.Column];
                    valueRange.StyleName = valueStyleToUse.Name;

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
