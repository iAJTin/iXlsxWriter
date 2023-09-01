
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

        // 05.

        // 06. Generate sample 06
        logger.Info("");
        logger.Info("> Shows how to use insert datatable and generic collections");
        Sample06.Generate(logger);

        // 07. Generate sample 07
        logger.Info("");
        logger.Info("> Shows how to save a xlsx input as zip file.");
        Sample07.Generate(logger);

        // 08.

        // 09. Generate sample 09
        logger.Info("");
        logger.Info("> Shows how to insert a picture with effects");
        Sample09.Generate(logger);

        // 10. Generate sample 10
        logger.Info("");
        logger.Info("> Shows how to insert an image from file and byte array.");
        Sample10.Generate(logger);

        // 11. Generate sample 11
        logger.Info("");
        logger.Info("> Shows how to insert a shapes with shape effects.");
        Sample11.Generate(logger);

        // 12. Generate sample 12
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles.");
        Sample12.Generate(logger);

        // 13. Generate sample 13
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles and column headers.");
        Sample13.Generate(logger);

        // 14.Generate sample 14
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles and data filter.");
        Sample14.Generate(logger);

        // 15. Generate sample 15
        logger.Info("");
        logger.Info("> Shows the use mini charts.");
        Sample15.Generate(logger);

        // 16. Generate sample 16
        logger.Info("");
        logger.Info("> Shows how to use insert a DataTable by InsertTable action without styles.");
        Sample16.Generate(logger);

        // 17. Generate sample 17
        logger.Info("");
        logger.Info(">  Shows how to use insert a table with styles and fixed fields.");
        Sample17.Generate(logger);

        // 18.Generate sample 18
        logger.Info("");
        logger.Info(">  Shows how to use insert a table with inherits styles and grouped fields.");
        Sample18.Generate(logger);

        //// 19.Generate sample 19
        //logger.Info("");
        //logger.Info(">  Shows how to use insert a table from xml file configuration.");
        //Sample19.Generate(logger);

        // 20. Generate sample 20
        logger.Info("");
        logger.Info("> Shows how to copy ranges.");
        Sample20.Generate(logger);

        // 21. Generate sample 21
        logger.Info("");
        logger.Info("> Shows how to transpose a range of data.");
        Sample21.Generate(logger);

        // 22. Generate sample 22
        logger.Info("");
        logger.Info("> Shows how to use aggregate functions with a data range.");
        Sample22.Generate(logger);

        // 25. Generate sample 25
        logger.Info("");
        logger.Info("> Shows the use stacked charts.");
        Sample25.Generate(logger);

        // 26. Generate sample 26
        logger.Info("");
        logger.Info("> Shows the use charts with more than one chart type and secondary axis.");
        Sample26.Generate(logger);

        // 27.Generate sample 27
        logger.Info("");
        logger.Info("> Shows the use mini charts.");
        Sample27.Generate(logger);

        logger.Info("");
        logger.Debug(">End Logging<");
        Console.ReadKey();
    }
}

