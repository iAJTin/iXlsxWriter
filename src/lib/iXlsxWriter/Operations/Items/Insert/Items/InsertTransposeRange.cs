
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

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
    /// <param name="context">Input context</param>
    /// <param name="input">Input stream</param>
    /// <param name="package">Package reference</param>
    /// <param name="worksheet">Worksheet reference</param>
    /// <returns>
    /// <para>
    /// A <see cref="ActionResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="ActionResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public override ActionResult Execute(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet)
    {
        if (Destination == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (string.IsNullOrEmpty(Destination.WorkSheet))
        {
            return ActionResult.CreateErrorResult(
                "Destination sheet name can not be null or empty",
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }

        if (SourceRange == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        HeaderStyle ??= XlsxCellStyle.Default;
        ValueStyle ??= XlsxCellStyle.Default;

        return ExecuteImpl(context, input, package, SheetName, SourceRange, Destination, HeaderStyle, ValueStyle);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, string sheetName, XlsxRange source, QualifiedPointDefinition destination, XlsxCellStyle headerStyle, XlsxCellStyle valueStyle)
    {
        var outputStream = new MemoryStream();

        try
        {
            var sourceWorksheet = package.Workbook.Worksheets.FirstOrDefault(wk => wk.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
            if (sourceWorksheet == null)
            {
                return ActionResult.CreateErrorResult(
                    $"source sheet '{sheetName}' not found",
                    new ActionResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            var destinationWorksheet = package.Workbook.Worksheets.FirstOrDefault(wk => wk.Name.Equals(destination.WorkSheet, StringComparison.OrdinalIgnoreCase));
            if (destinationWorksheet == null)
            {
                return ActionResult.CreateErrorResult(
                    $"Destination sheet '{sheetName}' not found",
                    new ActionResultData
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

            var headerStyleToUse = package.CreateEmptyNamedStyle(headerStyle);
            var headerRange = destinationWorksheet.Cells[startDestination.Row, startDestination.Column, startDestination.Row, destination.Point.Column];
            headerRange.StyleID = package.Workbook.Styles.GetNamedStyleId(headerStyleToUse.Name);
            headerRange.Style.FormatFromModel(headerStyleToUse);
            
            var valueStyleToUse = package.CreateEmptyNamedStyle(valueStyle);
            var valueRange = destinationWorksheet.Cells[startDestination.Row + 1, startDestination.Column, destination.Point.Row - 1, destination.Point.Column];
            valueRange.StyleID = package.Workbook.Styles.GetNamedStyleId(valueStyleToUse.Name);
            valueRange.Style.FormatFromModel(valueStyleToUse);

            package.SaveAs(outputStream);

            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = outputStream
            });
        }
        catch (Exception ex)
        {
            return ActionResult.FromException(
                ex,
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }

    #endregion
}
