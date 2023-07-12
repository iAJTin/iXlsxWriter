
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.ComponentModel;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert an aggregate function applied to specified data range in the specified location.
/// </summary>
public class InsertAggregateFunction : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertAggregateFunction"/> class.
    /// </summary>
    public InsertAggregateFunction()
    {
        SheetName = string.Empty;
        Style = XlsxCellStyle.Default;
        Aggegate = new QualifiedAggregateDefinition();
        Location = new XlsxPointRange { Column = 1, Row = 1 };
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to aggregate definition.
    /// </summary>
    /// <value>
    /// A <see cref="QualifiedAggregateDefinition"/> reference to aggregate definition.
    /// </value>
    public QualifiedAggregateDefinition Aggegate { get; set; }

    /// <summary>
    /// Gets or sets a reference to datatable to insert.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyle"/> reference to insert.
    /// </value>
    public XlsxCellStyle Style { get; set; }

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

        if (Location == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (Aggegate == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        Style ??= XlsxCellStyle.Default;

        return ExecuteImpl(context, input, package, worksheet, SheetName, Location, Aggegate, Style);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, string sheetName, XlsxBaseRange location, QualifiedAggregateDefinition aggregate, XlsxCellStyle style)
    {
        var outputStream = new MemoryStream();

        try
        {
            string aggregateWorksheetName = aggregate.WorkSheet;
            if (string.IsNullOrEmpty(aggregate.WorkSheet))
            {
                aggregateWorksheetName = sheetName;
            }

            var aggregateWorksheet = worksheet;
            bool sameSheetName = aggregateWorksheetName.Equals(sheetName, StringComparison.OrdinalIgnoreCase);
            if (!sameSheetName)
            {
                aggregateWorksheet = package.Workbook.Worksheets.FirstOrDefault(wk => wk.Name.Equals(aggregateWorksheetName, StringComparison.OrdinalIgnoreCase));
            }

            if (aggregateWorksheet == null)
            {
                return ActionResult.CreateErrorResult(
                    $"Aggregate sheet '{aggregateWorksheetName}' not found",
                    new ActionResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            ExcelAddressBase locationAddress = location.ToEppExcelAddress();
            XlsxCellStyle safeStyle = package.CreateStyle(style);
            XlsxCellMerge merge = safeStyle.Content.Merge;
            string range = merge.Cells == 1
                ? locationAddress.ToString()
                : merge.Orientation == KnownMergeOrientation.Horizontal
                    ? ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row, locationAddress.Start.Column + merge.Cells - 1)
                    : ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row + merge.Cells - 1, locationAddress.Start.Column);

            ExcelRange cell = aggregateWorksheet.Cells[range];
            cell.StyleName = cell.StyleName = locationAddress.End.Row.IsOdd()
                ? $"{safeStyle.Name}_Alternate"
                : safeStyle.Name ?? XlsxBaseStyle.NameOfDefaultStyle;

            if (style.Content.Show == YesNo.Yes)
            {
                var formula = new XlsxFormulaResolver(aggregate) { HasAutoFilter = aggregate.HasAutoFilter, WorkSheet = sheetName };
                cell.Formula = formula.Resolve();

                if (merge.Cells > 1)
                {
                    cell.Merge = true;
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
