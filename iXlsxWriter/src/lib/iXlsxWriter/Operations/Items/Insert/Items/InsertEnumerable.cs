
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OfficeOpenXml;
using OfficeOpenXml.Style;

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
/// Allows insert a <see cref="InsertEnumerable{T}"/> reference.
/// </summary>
public class InsertEnumerable<Ti> : InsertWithStyleBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertEnumerable{Ti}"/> class.
    /// </summary>
    public InsertEnumerable()
    {
        Data = null;
        ShowHeaders = YesNo.Yes;
        SheetName = string.Empty;
        Style = XlsxCellStyle.Default;
        Location = new XlsxPointRange { Column = 1, Row = 1 };
    }

    #endregion

    #region public new properties

    /// <summary>
    /// Gets or sets a reference to enumerable data to insert.
    /// </summary>
    /// <value>
    /// A <see cref="IEnumerable{T}"/> object containing information to insert
    /// </value>
    public new IEnumerable<Ti> Data { get; set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the preferred option for show headers. The default value is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> for show headers; otherwise <see cref="YesNo.No"/>.
    /// </value>
    public YesNo ShowHeaders { get; set; }

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

        if (Data == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Data, Location, ShowHeaders, Style);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, IEnumerable<Ti> data, XlsxBaseRange location, YesNo showHeaders, XlsxCellStyle style)
    {
        var outputStream = new MemoryStream();

        try
        {
            var safeData = data.ToList();
            var locationAddress = location.ToEppExcelAddress();
            worksheet.Cells[locationAddress.ToString()].LoadFromCollection(safeData, showHeaders == YesNo.Yes);

            var styleToUse = package.CreateEmptyNamedStyle(style);
            var range = worksheet.Cells[locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.End.Row + safeData.Count - 1, locationAddress.End.Column];
            range.StyleID = package.Workbook.Styles.GetNamedStyleId(styleToUse.Name);
            range.Style.FormatFromModel(styleToUse);

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
