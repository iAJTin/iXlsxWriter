
using System.Collections.ObjectModel;
using System.Diagnostics;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows the use mini charts.
/// </summary>
internal class Sample27
{
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1" });

        #endregion

        #region Sheet 1

        #region Hides the grid lines

        doc.Set(new SetGridLines
        {
            Show = YesNo.No,
            SheetName = "Sheet1"
        });

        #endregion

        #region Insert Data

        doc.Insert(new InsertTable
        {
            SheetName = "Sheet1",
            Data = new DataTableInput(
                new Collection<Person>
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
                }.ToDataTable<Person>("Person")),
            Location = new XlsxPointRange { Column = 2, Row = 2 },
            Table =
            {
                Name = "Person",
                Alias = "Person",
                ShowColumnHeaders = YesNo.Yes,
                ShowDataValues = YesNo.Yes,
                //Styles = new XlsxStylesCollection
                //{
                //    new XlsxCellStyle
                //    {
                //        Name = "HeaderStyle",
                //        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                //        Content = { Color = "#ED7D31", DataType = new TextDataType() }
                //    },
                //    new XlsxCellStyle
                //    {
                //        Name = "ValueStyle",
                //        Font = { Name = "Calibri" },
                //        Borders =
                //        {
                //            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                //            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                //            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                //        },
                //        Content = { DataType = new TextDataType() }
                //    },
                //    new XlsxCellStyle
                //    {
                //        Name = "LastFieldValueStyle",
                //        Font = { Name = "Calibri", Size = 11.0f },
                //        Borders =
                //        {
                //            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                //            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                //        },
                //        Content = { DataType = new TextDataType() }
                //    },
                //},
                //Fields =
                //{
                //    new DataField { Name = "Name", Alias = "Name", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "ValueStyle" } },
                //    new DataField { Name = "Surname", Alias = "Surname", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFieldValueStyle" } }
                //}
            }
        });

        #endregion

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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-27/Sample-27" });

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
        logger.Info("     > Path: ~/Output/Sample-27/Sample-27.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
