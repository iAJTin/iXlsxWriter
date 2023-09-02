
using iTin.Logging;
using iTin.Logging.ComponentModel;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.Samples;

namespace iXlsxWriter;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = Constants.AppName;

        ILogger logger = new Logger(Constants.AppName, new ILog[] { new FileLog(), new ColoredConsoleLog() }) { Deep = LogDeep.OnlyApplicationCalls, Status = LogStatus.Running };
        logger.Debug(">Start Logging<");

        // 01. Generate sample 01
        logger.Info("");
        logger.Info("> Hello world!");
        await Sample01.GenerateAsync(logger);

        // 02. Generate sample 02
        logger.Info("");
        logger.Info("> Hello world! (with styles)");
        await Sample02.GenerateAsync(logger);

        // 03. Generate sample 03
        logger.Info("");
        logger.Info("> Shows how to add custom document properties");
        await Sample03.GenerateAsync(logger);

        // 04. Generate sample 04
        logger.Info("");
        logger.Info("> Shows how to add custom sheet properties");
        await Sample04.GenerateAsync(logger);

        // 05.

        // 06. Generate sample 06
        logger.Info("");
        logger.Info("> Shows how to use insert datatable and generic collections");
        await Sample06.GenerateAsync(logger);

        // 07. Generate sample 07
        logger.Info("");
        logger.Info("> Shows how to save a xlsx input as zip file.");
        await Sample07.GenerateAsync(logger);

        // 08.

        // 09. Generate sample 09
        logger.Info("");
        logger.Info("> Shows how to insert a picture.");
        await Sample09.GenerateAsync(logger);

        // 10. Generate sample 10
        logger.Info("");
        logger.Info("> Shows how to insert an image from file and byte array.");
        await Sample10.GenerateAsync(logger);

        // 11. Generate sample 11
        logger.Info("");
        logger.Info("> Shows how to insert a shapes with shape effects.");
        await Sample11.GenerateAsync(logger);

        // 12. Generate sample 12
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles.");
        await Sample12.GenerateAsync(logger);

        // 13. Generate sample 13
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles and column headers.");
        await Sample13.GenerateAsync(logger);

        // 14. Generate sample 14
        logger.Info("");
        logger.Info("> Shows how to use insert a table with styles and data filter.");
        await Sample14.GenerateAsync(logger);

        // 15. Generate sample 15
        logger.Info("");
        logger.Info("> Shows the use mini charts.");
        await Sample15.GenerateAsync(logger);

        // 16. Generate sample 16
        logger.Info("");
        logger.Info("> Shows how to use insert a DataTable by InsertTable action without styles.");
        await Sample16.GenerateAsync(logger);

        // 17. Generate sample 17
        logger.Info("");
        logger.Info(">  Shows how to use insert a table with styles and fixed fields.");
        await Sample17.GenerateAsync(logger);

        // 18.Generate sample 18
        logger.Info("");
        logger.Info(">  Shows how to use insert a table with inherits styles and grouped fields.");
        await Sample18.GenerateAsync(logger);

        // 19.

        // 20. Generate sample 20
        logger.Info("");
        logger.Info("> Shows how to copy ranges.");
        await Sample20.GenerateAsync(logger);

        // 21. Generate sample 21
        logger.Info("");
        logger.Info("> Shows how to transpose a range of data.");
        await Sample21.GenerateAsync(logger);

        // 22. Generate sample 22
        logger.Info("");
        logger.Info("> Shows how to use aggregate functions with a data range.");
        await Sample22.GenerateAsync(logger);

        // 25. Generate sample 25
        logger.Info("");
        logger.Info("> Shows the use stacked charts.");
        await Sample25.GenerateAsync(logger);

        // 26. Generate sample 26
        logger.Info("");
        logger.Info("> Shows the use charts with more than one chart type and secondary axis.");
        await Sample26.GenerateAsync(logger);

        // 27. Generate sample 27
        //logger.Info("");
        //logger.Info("> Shows the use mini charts.");
        //Sample27.GenerateAsync(logger);

        logger.Info("");
        logger.Debug(">End Logging<");
        Console.ReadKey();
    }
}

