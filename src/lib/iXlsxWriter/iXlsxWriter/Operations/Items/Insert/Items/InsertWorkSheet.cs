﻿
using System;
using System.IO;

using OfficeOpenXml;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertBase"/> class.<br/>
/// Allows insert a new worksheet.
/// </summary>
public class InsertWorkSheet : InsertBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertWorkSheet"/> class.
    /// </summary>
    public InsertWorkSheet()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether to check that the name is not null or empty.
    /// </summary>
    /// <value>
    /// <b>true</b> if check name; otherwise, <b>false</b>.
    /// </value>
    public override bool CheckSheetName => false;

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

        return ExecuteImpl(context, input, package, SheetName);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, string sheetName)
    {
        var outputStream = new MemoryStream();

        try
        {
            package.Workbook.Worksheets.Add(sheetName);

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
