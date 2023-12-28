﻿
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;
using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to add custom document properties asynchronously.
/// </summary>
internal class Sample03
{
    public static async Task GenerateAsync(ILogger logger, CancellationToken cancellationToken = default)
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

        #region Create async output result

        var result = await doc
            .CreateResultAsync(
                new XlsxOutputResultConfig
                {
                    GlobalSettings = new XlsxSettings
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
                        }
                    }
                },
                cancellationToken)
            .ConfigureAwait(false);

        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves async output result

        var saveResult = await result.Result
            .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-03/Sample-03" }, cancellationToken)
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
        logger.Info("     > Path: ~/Output/Sample-03/Sample-03.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}