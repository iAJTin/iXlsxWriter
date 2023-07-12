
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Settings;
using iTin.Utilities.Xlsx.Design.Settings.Sheets;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to add custom sheet properties
/// </summary>
internal class Sample04
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create("Sheet1");

        #endregion

        #region Add cell styles

        var cellStyles = new Dictionary<string, XlsxCellStyle>
        {
            {
                "Title",
                new XlsxCellStyle 
                {
                    Font =
                    {
                        Name = "Arial",
                        Size = 28.0f,
                        Bold = YesNo.Yes,
                        Color = "Blue"
                    }
                }
            }
        };

        #endregion

        #region Insert actions

        doc.Insert(
            new InsertText
            {
                SheetName = "Sheet1",
                Style = cellStyles["Title"],
                Location = new XlsxPointRange { Column = 2, Row = 1 },
                Data = "Hello world! from iXlsxWriter"
            });

        #endregion

        #region Create output result

        var globalSettings = new XlsxSettings
        {
            DocumentSettings =
            {
                Author = "iTin",
                Company = "iTin",
                Manager = "Filled from iXlsxWriter",
                Category = "Filled from iXlsxWriter",
                Subject = "Filled from iXlsxWriter",
                Url = "http://www.url-test.com",
                Title = "Filled from iXlsxWriter",
                Keywords = "Reports, Excel, Summary",
                Comments = "Filled from iXlsxWriter"
            },
            SheetsSettings =
            {
                new XlsxSheetSettings
                {
                    Size = KnownDocumentSize.A3,
                    View = KnownDocumentView.Design,
                    Orientation = KnownDocumentOrientation.Landscape,
                    FreezePanesPoint =
                    {
                        Row = 3,
                        Column = 3,
                    },
                    Margins =
                    {
                        Bottom = 25,
                        Left = 25,
                        Right = 25,
                        Top = 25,
                        Units = KnownUnit.Millimeters
                    },
                    Header =
                    {
                        Sections =
                        {
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Sample header",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Left,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Sample header",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Left,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "iTin",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Center,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "iTin",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Center,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Header text",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Right,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Header text",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Right,
                            }
                        }
                    },
                    Footer =
                    {
                        Sections =
                        {
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Sample footer",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Left,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "Sample footer",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Left,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "iTin",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Center,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "iTin",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Center,
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "@PageNumber / @NumberOfPages",
                                Type = KnownHeaderFooterSectionType.Odd,
                                Alignment = KnownHeaderFooterAlignment.Right
                            },
                            new XlsxDocumentHeaderFooterSection
                            {
                                Text = "@PageNumber / @NumberOfPages",
                                Type = KnownHeaderFooterSectionType.Even,
                                Alignment = KnownHeaderFooterAlignment.Right
                            },
                        }
                    }
                }
            }
        };

        var result = doc.CreateResult(new XlsxOutputResultConfig { GlobalSettings = globalSettings });
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves output result

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-04/Sample-04" });
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
        logger.Info("     > Path: ~/Output/Sample-04/Sample-04.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
