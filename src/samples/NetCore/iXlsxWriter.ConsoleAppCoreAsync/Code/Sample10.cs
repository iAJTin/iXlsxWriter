
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;
using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

using iTinIO = iTin.Core.IO;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to insert an image from file and byte array asynchronously.
/// </summary>
internal class Sample10
{
    public static async Task GenerateAsync(ILogger logger, CancellationToken cancellationToken = default)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1" });

        #endregion

        #region Add cell styles

        var cellStyles = new Dictionary<string, XlsxCellStyle>
        {
            {
                "Title",
                new XlsxCellStyle
                {
                    Borders = new XlsxStyleBorders { new() { Position = KnownBorderPosition.Bottom, Color = "Red" } },
                    Content = new XlsxCellContent { Color = "LightGray" },
                    Font = new FontModel { Bold = YesNo.Yes, Size = 14.0f, Name = "Segoe UI" }
                }
            }
        };

        #endregion

        #region Insert picture from byte array and file

        using var image1 = XlsxImage.FromFile(iTinIO.Path.PathResolver("~/Resources/Sample-10/image-1.jpg"));
        using var image2 = XlsxImage.FromByteArray(await File.ReadAllBytesAsync(iTinIO.Path.PathResolver("~/Resources/Sample-10/image-2.jpg"), cancellationToken).ConfigureAwait(false));
        doc.Insert(new InsertText
            {
                SheetName = "Sheet1",
                Data = "From ByteArray",
                Style = cellStyles["Title"],
                Location = new XlsxPointRange { Column = 4, Row = 2 }
            })
            .Insert(new InsertText
            {
                SheetName = "Sheet1",
                Data = "From File",
                Style = cellStyles["Title"],
                Location = new XlsxPointRange { Column = 8, Row = 2 }
            })
            .Insert(new InsertPicture
            {
                SheetName = "Sheet1",
                Location = new XlsxPointRange { Column = 4, Row = 4 },
                Picture = image2
                    .AsPicture(
                        "image1",
                        size: new XlsxSize { Width = 150, Height = 150 },
                        border: new XlsxBorder { Width = 2, Color = "Green", Show = YesNo.Yes, Style = KnownLineStyle.DashDot },
                        shapeEffects: new XlsxShapeEffects { Shadow = XlsxOuterShadow.DownRight })
            })
            .Insert(new InsertPicture
            {
                SheetName = "Sheet1",
                Location = new XlsxPointRange { Column = 8, Row = 4 },
                Picture = image1
                    .AsPicture(
                        "image2",
                        size: new XlsxSize { Width = 150, Height = 150 },
                        shapeEffects: new XlsxShapeEffects { Shadow = XlsxOuterShadow.Left })
            });

        #endregion

        #region Create output result

        var result = await doc.CreateResultAsync(cancellationToken: cancellationToken);
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves output result

        var saveResult = await result.Result
            .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-10/Sample-10" }, cancellationToken)
            .ConfigureAwait(false);

        var ts = sw.Elapsed;
        sw.Stop();

        if (!saveResult.Success)
        {
            logger.Info("   > Error while saving to disk");
            logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
            logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");
            return;
        }

        logger.Info("   > Saved to disk correctly");
        logger.Info("     > Path: ~/Output/Sample-10/Sample-10.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
