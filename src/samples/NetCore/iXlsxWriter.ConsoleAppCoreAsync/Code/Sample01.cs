
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Logging.ComponentModel;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Hello world! asynchronously.
/// </summary>
internal class Sample01
{
    // Generates document
    public static async Task GenerateAsync(ILogger logger, CancellationToken cancellationToken = default)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create("Sheet1");

        #endregion

        #region Insert actions

        doc.Insert(
            new InsertText
            {
                SheetName = "Sheet1",
                Data = "Hello world! from iXlsxWriter"
            });

        #endregion

        #region Create async output result

        var result = await doc.CreateResultAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves async output result

        var saveResult = await result.Result
            .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-01/Sample-01" }, cancellationToken)
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
        logger.Info("     > Path: ~/Output/Sample-01/Sample-01.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
