
namespace iXlsxWriter.Samples
{
    using System.IO;

    using iTin.Core.ComponentModel;
    using iTin.Core.Models.Design.Enums;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Picture;
    using iTin.Utilities.Xlsx.Design.Shared;

    using iTin.Utilities.Xlsx.Writer;
    using iTin.Utilities.Xlsx.Writer.ComponentModel;
    using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action.Save;
    using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert;

    using iTinIO = iTin.Core.IO;

    /// <summary>
    /// Shows how to insert an image from uri (byte[]).
    /// </summary>
    internal class Sample09
    {
        // Generates document
        public static void Generate(ILogger logger)
        {
            #region Creates xlsx file reference

            XlsxInput doc = XlsxInput.Create(new[] {"Hoja1", "Hoja2"});

            #endregion

            #region Insert picture from image stream

            InsertResult insertResult;
            using (var image = XlsxImage.FromByteArray(File.ReadAllBytes(iTinIO.Path.PathResolver("~/Resources/Sample-09/image-1.jpg"))))
            {
                insertResult = doc.Insert(new InsertPicture
                {
                    SheetName = "Hoja1",
                    Location = new XlsxPointRange {Column = 1, Row = 1},
                    Picture =
                        image.AsPicture(
                            "image",
                            size: new XlsxSize
                            {
                                Width = 150,
                                Height = 150
                            },
                            border: new XlsxBorder
                            {
                                Width = 2,
                                Color = "Green",
                                Show = YesNo.Yes,
                                Style = KnownLineStyle.DashDot
                            },
                            shapeEffects: new XlsxShapeEffects {Shadow = XlsxOuterShadow.DownRight}
                        )
                });
            }

            #endregion

            #region Insert correctly?

            if (!insertResult.Success)
            {
                logger.Info("   > Error while creating insert");
                logger.Info($"     > Error: {insertResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Create output result

            var result = doc.CreateResult(new OutputResultConfig {AutoFitColumns = true});
            if (!result.Success)
            {
                logger.Info("   > Error creating output result");
                logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Saves output result

            var saveResult = result.Value.Action(new SaveToFile { OutputPath = "~/Output/Sample09/Sample-09" });
            if (!saveResult.Success)
            {
                logger.Info("   > Error while saving to disk");
                logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            logger.Info("   > Saved to disk correctly");
            logger.Info("     > Path: ~/Output/Sample09/Sample-09.xlsx");

            #endregion
        }
    }
}
