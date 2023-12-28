
using System;
using System.Collections.Generic;
using System.IO;

using OfficeOpenXml;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Set;

/// <summary>
/// A Specialization of <see cref="SetBase"/> class.<br/>
/// Allows modify row(s) height in the specified worksheet.
/// </summary>
public class SetRowHeight : SetBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="SetRowHeight"/> class.
    /// </summary>
    public SetRowHeight()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference containing rows definitions.
    /// </summary>
    /// <value>
    /// A <see cref="IEnumerable{RowDefinition}"/> reference containing rows definitions.
    /// </value>
    public IEnumerable<RowDefinition> Rows { get; set; }

    #endregion

    #region public override methods

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

        if (Rows == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Rows);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, IEnumerable<RowDefinition> rows)
    {
        var outputStream = new MemoryStream();

        try
        {
            foreach (var row in rows)
            {
                worksheet.Row(row.Row).Height = row.Height;
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


    #region public nestes structs

    /// <summary>
    /// Defines a row.
    /// </summary>
    public struct RowDefinition
    {
        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="RowDefinition"/> class.
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="height">Row height value</param>
        public RowDefinition(int row, double height)
        {
            Height = height;
            Row = row;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value containing row index value.
        /// </summary>
        /// <value>
        /// A <see cref="int"/> containing row index.
        /// </value>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets a value containing row height value.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> containing row height value.
        /// </value>
        public double Height { get; set; }

        #endregion
    }

    #endregion
}
