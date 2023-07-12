
using System;
using System.IO;

using OfficeOpenXml;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertWithStyleBase"/> class.<br/>
/// Allows insert a text, number or date with style.
/// </summary>
public class InsertText : InsertWithStyleBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertText"/> class.
    /// </summary>
    public InsertText()
    {
        Data = string.Empty;
        SheetName = string.Empty;
        Style = XlsxCellStyle.Default;
        Location = new XlsxPointRange { Column = 1, Row = 1 };
    }

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

        Style ??= XlsxCellStyle.Default;

        return ExecuteImpl(context, input, package, worksheet, Data, Location, Style);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, object data, XlsxBaseRange location, XlsxCellStyle style)
    {
        var outputStream = new MemoryStream();

        try
        {
            var locationAddress = location.ToEppExcelAddress();
            var safeStyle = package.CreateStyle(style);
            var merge = safeStyle.Content.Merge;
            var range = merge.Cells == 1
                ? locationAddress.ToString()
                : merge.Orientation == KnownMergeOrientation.Horizontal
                    ? ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row, locationAddress.Start.Column + merge.Cells - 1)
                    : ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row + merge.Cells - 1, locationAddress.Start.Column);

            var cell = worksheet.Cells[range];
            cell.StyleName = locationAddress.End.Row.IsOdd()
                ? $"{safeStyle.Name}_Alternate"
                : safeStyle.Name ?? XlsxBaseStyle.NameOfDefaultStyle;

            if (style.Content.Show == YesNo.Yes)
            {
                if (data != null)
                {
                    cell.Value = safeStyle.Content.DataType.GetFormattedDataValue(data.ToString()).FormattedValue;

                    if (merge.Cells > 1)
                    {
                        cell.Merge = true;
                    }
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
