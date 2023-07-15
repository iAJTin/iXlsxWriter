
using System.Collections.ObjectModel;
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iXlsxWriter.ComponentModel;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to use aggregate functions with a data range.
/// </summary>
internal class Sample22
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

        #region Cell styles

        var numberStyle = new XlsxCellStyle
        {
            Content =
            {
                DataType = new NumberDataType {Decimals = 1, Separator = YesNo.Yes},
                Alignment = {Horizontal = KnownHorizontalAlignment.Right}
            }
        };

        #endregion

        #region Insert data

        doc.Insert(new InsertEnumerable<AgePerson>
        {
            SheetName = "Sheet1",
            Location = new XlsxPointRange { Column = 2, Row = 3 },
            Data = new Collection<AgePerson>
            {
                new() { Name = "Name-01", Surname = "Surname-01", Age = 23 },
                new() { Name = "Name-02", Surname = "Surname-02", Age = 7 },
                new() { Name = "Name-03", Surname = "Surname-03", Age = 11 },
                new() { Name = "Name-04", Surname = "Surname-04", Age = 22 },
                new() { Name = "Name-05", Surname = "Surname-05", Age = 52 },
                new() { Name = "Name-06", Surname = "Surname-06", Age = 33 },
                new() { Name = "Name-07", Surname = "Surname-07", Age = 8 },
                new() { Name = "Name-08", Surname = "Surname-08", Age = 2 },
                new() { Name = "Name-09", Surname = "Surname-09", Age = 12 },
                new() { Name = "Name-10", Surname = "Surname-10", Age = 21 },
            }
        });

        #endregion

        #region Insert aggregate functions

        doc.Insert(new InsertText
        {
            SheetName = "Sheet1",
            Data = "Count",
            Style = XlsxCellStyle.Default,
            Location = new XlsxPointRange { Column = 1, Row = 14 },
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Sheet1",
            Style = numberStyle,
            Aggegate =
            {
                WorkSheet = "Sheet1",
                AggregateType = KnownAggregateType.Count,
                Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
            },
            Location = new XlsxPointRange { Column = 2, Row = 14 }
        }).Insert(new InsertText
        {
            SheetName = "Sheet1",
            Data = "Sum",
            Style = XlsxCellStyle.Default,
            Location = new XlsxPointRange { Column = 1, Row = 15 },
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Sheet1",
            Style = numberStyle,
            Aggegate =
            {
                WorkSheet = "Sheet1",
                AggregateType = KnownAggregateType.Sum,
                Range = new XlsxRange
                {
                    Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 }
                }
            },
            Location = new XlsxPointRange { Column = 2, Row = 15 }
        }).Insert(new InsertText
        {
            SheetName = "Sheet1",
            Data = "Average",
            Style = XlsxCellStyle.Default,
            Location = new XlsxPointRange { Column = 1, Row = 16 },
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Sheet1",
            Style = numberStyle,
            Aggegate =
            {
                WorkSheet = "Sheet1",
                AggregateType = KnownAggregateType.Average,
                Range = new XlsxRange
                {
                    Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 }
                }
            },
            Location = new XlsxPointRange { Column = 2, Row = 16 }
        }).Insert(new InsertText
        {
            SheetName = "Sheet1",
            Data = "Max",
            Style = XlsxCellStyle.Default,
            Location = new XlsxPointRange { Column = 1, Row = 17 },
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Sheet1",
            Style = numberStyle,
            Aggegate =
            {
                WorkSheet = "Sheet1",
                AggregateType = KnownAggregateType.Max,
                Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
            },
            Location = new XlsxPointRange { Column = 2, Row = 17 }
        }).Insert(new InsertText
        {
            SheetName = "Sheet1",
            Data = "Min",
            Style = XlsxCellStyle.Default,
            Location = new XlsxPointRange { Column = 1, Row = 18 },
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Sheet1",
            Style = numberStyle,
            Aggegate =
            {
                WorkSheet = "Sheet1",
                AggregateType = KnownAggregateType.Min,
                Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
            },
            Location = new XlsxPointRange { Column = 2, Row = 18 }
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-22/Sample-22" });

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
        logger.Info("     > Path: ~/Output/Sample-22/Sample-22.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
