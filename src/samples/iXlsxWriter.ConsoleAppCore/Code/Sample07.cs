
namespace iXlsxWriter.Samples
{
    using iTin.Core.ComponentModel;
    using iTin.Core.Models.Design.Enums;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Picture;
    using iTin.Utilities.Xlsx.Design.Shared;

    using iTin.Utilities.Xlsx.Writer;
    using iXlsxWriter.ComponentModel;
    using iXlsxWriter.ComponentModel.Result.Action.Save;

    /// <summary>
    /// Shows how to insert a pictures.
    /// </summary>
    internal class Sample07
    {
        // Generates document
        public static void Generate(ILogger logger)
        {
            #region Creates xlsx file reference

            XlsxInput doc = XlsxInput.Create(new[] {"Hoja1", "Hoja2"});

            #endregion

            #region Insert picture

            doc.Insert(new InsertPicture
            {
                SheetName = "Hoja1",
                Location = new XlsxPointRange {Column = 3, Row = 3},
                Picture = new XlsxPicture
                {
                    Show = YesNo.Yes,
                    Name = "image",
                    Path = "~/Resources/Sample-07/image-1.jpg",
                    Size = new XlsxSize
                    {
                        Width = 300,
                        Height = 300
                    },
                    Effects =
                    {
                        new XlsxDarkEffect(),
                        new XlsxDisabledEffect(),
                        new XlsxOpacityEffect {Value = 50.0f}
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

            var result = doc.CreateResult(new OutputResultConfig {AutoFitColumns = true});
            if (!result.Success)
            {
                logger.Info("   > Error creating output result");
                logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Saves output result

            var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample07/Sample-07" });
            if (!saveResult.Success)
            {
                logger.Info("   > Error while saving to disk");
                logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            logger.Info("   > Saved to disk correctly");
            logger.Info("     > Path: ~/Output/Sample07/Sample-07.xlsx");

            #endregion
        }
    }
}
