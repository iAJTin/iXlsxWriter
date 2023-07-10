
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertBase"/> class.<br/>
/// Allows copy a source range to destination worksheet and point.
/// </summary>
public class InsertCopyRange : InsertBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertCopyRange"/> class.
    /// </summary>
    public InsertCopyRange()
    {
        SourceRange = null;
        Destination = null;
        SheetName = string.Empty;
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
    /// Gets or sets a reference to source range.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxRange"/> reference to source range.
    /// </value>
    public XlsxRange SourceRange { get; set; }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when insert action.
    /// </summary>
    /// <param name="context">Input context</param>
    /// <param name="input"></param>
    /// <param name="package"></param>
    /// <param name="worksheet"></param>
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
        if (string.IsNullOrEmpty(SheetName))
        {
            return ActionResult.CreateErrorResult(
                "Sheet name can not be null or empty",
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }

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

        return ExecuteImpl(context, input, package, worksheet, SheetName, SourceRange, Destination);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, string sheetName, XlsxRange source, QualifiedPointDefinition destination)
    {
        var outputStream = new MemoryStream();

        try
        {
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

            worksheet.Cells[source.Start.Row, source.Start.Column, source.End.Row, source.End.Column].Copy(destinationWorksheet.Cells[destination.Point.Row, destination.Point.Column]);

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
