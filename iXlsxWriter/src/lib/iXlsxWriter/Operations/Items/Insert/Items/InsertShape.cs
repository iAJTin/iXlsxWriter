
using System;
using System.IO;

using OfficeOpenXml;
using OfficeOpenXml.Helpers;

using iTin.Core;
using iTin.Core.Models.Design.Enums;
using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a <b>xlsx</b> shape.
/// </summary>
public class InsertShape : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertShape"/> class.
    /// </summary>
    public InsertShape()
    {
        Location = null;
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to shape configuration.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShape"/> reference to shape configuration.
    /// </value>
    public XlsxShape Shape { get; set; }

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

        if (Shape == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (Shape.Show == YesNo.No)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, Shape);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, XlsxShape xlsxShape)
    {
        var outputStream = new MemoryStream();

        try
        {
            var shapeName = xlsxShape.Name.HasValue() ? xlsxShape.Name : $"shape{worksheet.Drawings.Count}";
            var shape = worksheet.Drawings.AddShape(shapeName, eShapeStyle.Rect);

            var writer = new OfficeOpenShapeWriter(shape, worksheet);
            writer.SetBorder(xlsxShape.Border);
            writer.SetContent(xlsxShape.Content);
            writer.SetFont(xlsxShape.Content.Font);
            writer.SetPosition(location);
            writer.SetSize(xlsxShape.Size);
            writer.SetShapeEffects(xlsxShape.ShapeEffects, shapeName);
            writer.SetShapeStyle(xlsxShape.ShapeType);
            writer.SetText(xlsxShape.Content.Text);

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
