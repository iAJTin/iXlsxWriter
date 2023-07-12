
using System.Collections.ObjectModel;
using System.Diagnostics;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Logging.ComponentModel;
using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to use insert datatable and generic collections.
/// </summary>
internal class Sample06
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });

        #endregion

        #region Insert datatable and generic collections

        doc.Insert(new InsertText
            {
                SheetName = "Sheet1",
                Location = new XlsxPointRange { Column = 2, Row = 1 },
                Data = "Custom text"
            })
            .Insert(new InsertEnumerable<Person>
            {
                SheetName = "Sheet1",
                Location = new XlsxPointRange { Column = 2, Row = 3 },
                Data = new Collection<Person>
                {
                    new() { Name = "Name-01", Surname = "Surname-01" },
                    new() { Name = "Name-02", Surname = "Surname-02" },
                    new() { Name = "Name-03", Surname = "Surname-03" },
                    new() { Name = "Name-04", Surname = "Surname-04" },
                    new() { Name = "Name-05", Surname = "Surname-05" },
                    new() { Name = "Name-06", Surname = "Surname-06" },
                    new() { Name = "Name-07", Surname = "Surname-07" },
                    new() { Name = "Name-08", Surname = "Surname-08" },
                    new() { Name = "Name-09", Surname = "Surname-09" },
                    new() { Name = "Name-10", Surname = "Surname-10" }
                }
            }).Insert(new InsertDataTable
            {
                SheetName = "Sheet1",
                Location = new XlsxPointRange { Column = 10, Row = 3 },
                Data = new Collection<Person>
                {
                    new() { Name = "Name-01", Surname = "Surname-01" },
                    new() { Name = "Name-02", Surname = "Surname-02" },
                    new() { Name = "Name-03", Surname = "Surname-03" },
                    new() { Name = "Name-04", Surname = "Surname-04" },
                    new() { Name = "Name-05", Surname = "Surname-05" },
                    new() { Name = "Name-06", Surname = "Surname-06" },
                    new() { Name = "Name-07", Surname = "Surname-07" },
                    new() { Name = "Name-08", Surname = "Surname-08" },
                    new() { Name = "Name-09", Surname = "Surname-09" },
                    new() { Name = "Name-10", Surname = "Surname-10" }
                }.ToDataTable<Person>("Person")
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-06/Sample-06" });

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
        logger.Info("     > Path: ~/Output/Sample-06/Sample-06.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
