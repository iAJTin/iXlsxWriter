
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
/// Allows modify column(s) width in the specified worksheet.
/// </summary>
public class SetColumnWidth : SetBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="SetColumnWidth"/> class.
    /// </summary>
    public SetColumnWidth()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference containing columns definitions.
    /// </summary>
    /// <value>
    /// A <see cref="IEnumerable{ColumnDefinition}"/> reference containing columns definitions.
    /// </value>
    public IEnumerable<ColumnDefinition> Columns { get; set; }

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

        if (Columns == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Columns);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, IEnumerable<ColumnDefinition> columns)
    {
        var outputStream = new MemoryStream();

        try
        {
            foreach (var column in columns)
            {
                worksheet.Column(column.Column).Width = column.Width;
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
    /// Defines a column.
    /// </summary>
    public struct ColumnDefinition
    {
        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDefinition"/> class.
        /// </summary>
        /// <param name="column">Column index</param>
        /// <param name="width">Column width value</param>
        public ColumnDefinition(int column, double width)
        {
            Width = width;
            Column = column;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value containing column index value.
        /// </summary>
        /// <value>
        /// A <see cref="int"/> containing column index.
        /// </value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets a value containing column width value.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> containing column width value.
        /// </value>
        public double Width { get; set; }

        #endregion
    }

    #endregion
}
