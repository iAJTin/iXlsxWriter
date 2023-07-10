﻿
using iTin.Logging;
using iTin.Logging.ComponentModel;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Samples;

namespace iXlsxWriter
{
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

            logger.Info("");
            logger.Debug(">End Logging<");
            Console.ReadKey();
        }
    }
}
