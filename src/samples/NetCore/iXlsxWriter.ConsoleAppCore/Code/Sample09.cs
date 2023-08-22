
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Picture;
using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to insert a picture.
/// </summary>
internal class Sample09
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1" });

        #endregion

        #region Insert picture

        doc.Insert(new InsertPicture
        {
            SheetName = "Sheet1",
            Location = new XlsxPointRange { Column = 4, Row = 4 },
            Picture = new XlsxPicture
            {
                Show = YesNo.Yes,
                Name = "image",
                Path = "~/Resources/Sample-09/image-1.jpg",
                Size = new XlsxSize
                {
                    Width = 300,
                    Height = 300
                },
                Effects =
                {
                    new XlsxDarkEffect(),
                    new XlsxDisabledEffect(),
                    new XlsxOpacityEffect { Value = 50.0f }
                },
                Border =
                {
                    Width = 4,
                    Color = "Green",
                    Show = YesNo.Yes,
                    Transparency = 50,
                    Style = KnownLineStyle.DashDot
                },
                Content =
                {
                    Color = "Blue",
                    Show = YesNo.Yes,
                    Transparency = 50,
                },
                ShapeEffects =
                {
                    Shadow = new XlsxOuterShadow
                    {
                        Offset = 2,
                        Color = "Yellow",
                        Show = YesNo.Yes,
                    }
                }
            }
        });

        #endregion

        #region Create output result

        var result = doc.CreateResult();
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves output result

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-09/Sample-09" });

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
        logger.Info("     > Path: ~/Output/Sample-09/Sample-09.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
