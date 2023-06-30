
namespace iXlsxWriter
{
    using System;

    using iTin.Logging;
    using iTin.Logging.ComponentModel;

    using ComponentModel;
    using Samples;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Constants.AppName;

            ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
            logger.Debug(">Start Logging<");

            // 01. Generate sample 01
            logger.Info("");
            logger.Info("> Shows the use of how creates a report");
            Sample01.Generate(logger);

            // 02. Generate sample 02
            logger.Info("");
            logger.Info("> Shows the use of how creates a report with minicharts");
            Sample02.Generate(logger);

            // 03. Generate sample 03
            logger.Info("");
            logger.Info("> Shows the use of how creates a report with minicharts and conditional inserts");
            Sample03.Generate(logger);

            // 04. Generate sample 04
            logger.Info("");
            logger.Info("> Shows the use of how serialize and deserialize global settings, styles, pictures, shapes and mini-charts");
            Sample04.Generate(logger);

            // 05. Generate sample 05
            logger.Info("");
            logger.Info("> Shows the use of how insert an autofilter");
            Sample05.Generate(logger);

            // 06. Generate sample 06
            logger.Info("");
            logger.Info("> Shows how to use insert datatable and generic collections");
            Sample06.Generate(logger);

            // 07. Generate sample 07
            logger.Info("");
            logger.Info("> Shows how to insert a pictures");
            Sample07.Generate(logger);

            // 08. Generate sample 08
            logger.Info("");
            logger.Info("> Shows how to insert a shapes with shape effects");
            Sample08.Generate(logger);

            // 09. Generate sample 09
            logger.Info("");
            logger.Info("> Shows how to insert an image from uri (stream)");
            Sample09.Generate(logger);

            // 10. Generate sample 10
            logger.Info("");
            logger.Info("> Shows how to insert a pictures with shape effects");
            Sample10.Generate(logger);

            // 11. Generate sample 11
            logger.Info("");
            logger.Info(">  Shows how to copy ranges");
            Sample11.Generate(logger);

            // 12. Generate sample 12
            logger.Info("");
            logger.Info(">  Shows how to transpose a range of data");
            Sample12.Generate(logger);

            // 13.Generate sample 13
            logger.Info("");
            logger.Info(">  Shows how to use aggregate functions with a data range");
            Sample13.Generate(logger);

            // 14.Generate sample 14
            logger.Info("");
            logger.Info(">  Shows the use stacked charts");
            Sample14.Generate(logger);

            // 15.Generate sample 15
            logger.Info("");
            logger.Info(">  Shows the use charts with more than one chart type and secondary axis");
            Sample15.Generate(logger);

            logger.Info("");
            logger.Debug(">End Logging<");
            Console.ReadKey();
        }
    }
}
