
using iTin.Logging;
using iTin.Logging.ComponentModel;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Samples;

namespace iXlsxWriter;

class Program
{
    private static async Task Main(string[] args)
    {
        Console.Title = Constants.AppName;

        ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
        logger.Debug(">Start Logging<");

        // 01. Generate sample 01
        logger.Info("");
        logger.Info("> Hello world! asynchronously");
        await Sample01.GenerateAsync(logger).ConfigureAwait(false);

        // 02. Generate sample 02
        logger.Info("");
        logger.Info("> Hello world! (with styles) asynchronously");
        await Sample02.GenerateAsync(logger).ConfigureAwait(false);

        // 03. Generate sample 03
        logger.Info("");
        logger.Info("> Shows how to add custom document properties asynchronously");
        await Sample03.GenerateAsync(logger).ConfigureAwait(false);

        // 04. Generate sample 04
        logger.Info("");
        logger.Info("> Shows how to add custom sheet properties asynchronously");
        await Sample04.GenerateAsync(logger).ConfigureAwait(false);

        // 06. Generate sample 06
        logger.Info("");
        logger.Info("> Shows how to use insert datatable and generic collections asynchronously");
        await Sample06.GenerateAsync(logger).ConfigureAwait(false);

        // 07. Generate sample 07
        logger.Info("");
        logger.Info("> Shows how to save a xlsx input as zip file asynchronously");
        await Sample07.GenerateAsync(logger).ConfigureAwait(false);

        logger.Info("");
        logger.Debug(">End Logging<");
        Console.ReadKey();
    }
}
