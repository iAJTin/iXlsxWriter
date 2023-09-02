
using System;
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Shared;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

using iTinPath = iTin.Core.IO.Path;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to use insert a table from xml file configuration.
/// </summary>
internal class Sample19
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

        var t = XlsxTable.LoadFromFile(iTinPath.PathResolver("~/Resources/Sample-19/Configuration.xml"));

        doc.Insert(new InsertTable
        {
            SheetName = "Sheet1",
            Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-19/Input.xml"))),
            Location = new XlsxPointRange { Column = 1, Row = 2 },
            Table = (XlsxTable) XlsxTable.LoadFromFile(iTinPath.PathResolver("~/Resources/Sample-19/Configuration.xml"))
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-19/Sample-19" });

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
        logger.Info("     > Path: ~/Output/Sample-19/Sample-19.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
        //var a = t.SaveToFile("~/Resources/Sample-19/Conf.json", KnownFileFormat.Json);

        //var t2 = XlsxTable.LoadFromFile(iTinPath.PathResolver("~/Resources/Sample-19/Configuration.json"), KnownFileFormat.Json);
