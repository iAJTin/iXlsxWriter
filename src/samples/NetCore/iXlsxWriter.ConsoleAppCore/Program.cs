
using iTin.Logging;
using iTin.Logging.ComponentModel;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Samples;

namespace iXlsxWriter;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = Constants.AppName;

        ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
        logger.Debug(">Start Logging<");

        // 01. Generate sample 01
        logger.Info("");
        logger.Info("> Hello world!");
        Sample01.Generate(logger);

        // 02. Generate sample 02
        logger.Info("");
        logger.Info("> Hello world! (with styles)");
        Sample02.Generate(logger);

        // 03. Generate sample 03
        logger.Info("");
        logger.Info("> Shows how to add custom document properties");
        Sample03.Generate(logger);

        // 04. Generate sample 04
        logger.Info("");
        logger.Info("> Shows how to add custom sheet properties");
        Sample04.Generate(logger);

        // 06. Generate sample 06
        logger.Info("");
        logger.Info("> Shows how to use insert datatable and generic collections");
        Sample06.Generate(logger);

        // 07. Generate sample 07
        logger.Info("");
        logger.Info("> Shows how to save a xlsx input as zip file.");
        Sample07.Generate(logger);

        logger.Info("");
        logger.Debug(">End Logging<");
        Console.ReadKey();
    }
}
