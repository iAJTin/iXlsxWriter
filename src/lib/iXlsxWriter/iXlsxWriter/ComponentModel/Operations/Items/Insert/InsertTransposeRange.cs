
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.ComponentModel.Result.Insert;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// A Specialization of <see cref="InsertWithStyleBase"/> class.<br/>
/// Allows to transpose a range of data indicating the destination sheet and the starting point.
/// </summary>
public class InsertTransposeRange : InsertLocationBase
{
    #region constructor/s

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

    #region public properties

    /// <summary>
    /// Gets or sets a reference to destination point.
    /// </summary>
    /// <value>
    /// A <see cref="QualifiedPointDefinition"/> reference to destination point.
    /// </value>
    public QualifiedPointDefinition Destination { get; set; }

    /// <summary>
    /// Gets or sets a reference to header style.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyle"/> reference to header style.
    /// </value>
    public XlsxCellStyle HeaderStyle { get; set; }

    /// <summary>
    /// Gets or sets a reference to source range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> reference to source range.
    /// </value>
    public XlsxRange SourceRange { get; set; }

    /// <summary>
    ///Gets or sets a reference to values style.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyle"/> reference to values style.
    /// </value>
    public XlsxCellStyle ValueStyle { get; set; }

    #endregion

    #region protected override methods

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
            return InsertResult.CreateErrorResult(
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
            return InsertResult.CreateErrorResult(
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

        HeaderStyle ??= XlsxCellStyle.Default;
        ValueStyle ??= XlsxCellStyle.Default;

        return InsertImpl(context, input, SheetName, SourceRange, Destination, HeaderStyle, ValueStyle);
    }

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
                    return InsertResult.CreateErrorResult(
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
                    return InsertResult.CreateErrorResult(
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
