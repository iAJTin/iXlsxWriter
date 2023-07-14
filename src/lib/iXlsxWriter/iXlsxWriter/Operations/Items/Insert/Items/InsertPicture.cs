
using System;
using System.IO;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Helpers;

using iTin.Core;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Picture;
using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a picture in the specified location
/// </summary>
public class InsertPicture : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertPicture"/> class.
    /// </summary>
    public InsertPicture()
    {
        Location = null;
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to picture configuration.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPicture"/> reference to picture configuration.
    /// </value>
    public XlsxPicture Picture { get; set; }

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
                    InputStream = context.ToStream(),
                    OutputStream = context.ToStream()
                });
        }

        if (Location == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = context.ToStream(),
                OutputStream = context.ToStream()
            });
        }

        if (Picture == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = context.ToStream(),
                OutputStream = context.ToStream()
            });
        }

        if (Picture.Show == YesNo.No)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = context.ToStream(),
                OutputStream = context.ToStream()
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, Picture);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, XlsxPicture xlsxPicture)
    {
        var outputStream = new MemoryStream();

        try
        {
            using (var image = xlsxPicture.GetImage())
            {
                if (image == null)
                {
                    return ActionResult.CreateErrorResult(
                        "The image could not be loaded, please check that the path is correct",
                        new ActionResultData
                        {
                            Context = context,
                            InputStream = input,
                            OutputStream = input
                        });
                }

                var pictureName = xlsxPicture.Name.HasValue() ? xlsxPicture.Name : $"picture{worksheet.Drawings.Count}";
                foreach (var item in worksheet.Drawings)
                {
                    var pic = item as ExcelPicture;
                    if (pic == null)
                    {
                        continue;
                    }

                    var existPicture = pic.Name.Equals(pictureName, StringComparison.OrdinalIgnoreCase);
                    if (!existPicture)
                    {
                        continue;
                    }

                    return ActionResult.CreateErrorResult(
                        $"There is already an image with the name '{pictureName}' in the collection, please rename the image.",
                        new ActionResultData
                        {
                            Context = context,
                            InputStream = input,
                            OutputStream = input
                        });
                }

                ExcelPicture picture = worksheet.Drawings.AddPicture(pictureName, image);
                var writer = new OfficeOpenPictureWriter(picture, worksheet);
                writer.SetBorder(xlsxPicture.Border);
                writer.SetContent(xlsxPicture.Content);
                writer.SetPosition(location);
                writer.SetSize(xlsxPicture.Size);
                writer.SetShapeEffects(xlsxPicture.ShapeEffects, pictureName);
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
