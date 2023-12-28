
using System;
using System.IO;

using OfficeOpenXml;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Set;

/// <summary>
/// A Specialization of <see cref="SetBase"/> class.<br/>
/// Allows autofit columns.
/// </summary>
internal class SetAutoFitColumns : SetBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="SetAutoFitColumns"/> class.
    /// </summary>
    public SetAutoFitColumns()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when set action.
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
        => ExecuteImpl(context, input, package, worksheet);

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet)
    {
        var outputStream = new MemoryStream();

        try
        {
            foreach (var ws in package.Workbook.Worksheets)
            {
                var hasDimension = ws.Dimension != null;
                if (!hasDimension)
                {
                    continue;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                var start = ws.Cells[ws.Dimension.Address].Start.Column;
                var end = ws.Cells[ws.Dimension.Address].End.Column;
                for (var col = start; col <= end; col++)
                {
                    ws.Column(col).BestFit = true;
                    ws.Column(col).Width = ws.Column(col).Width + 1;
                }
            }

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
