
namespace iXlsxWriter.Samples
{
    using System.Collections.ObjectModel;

    using iTin.Core;
    using iTin.Core.ComponentModel;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Shared;

    using iTin.Utilities.Xlsx.Writer;
    using iXlsxWriter.ComponentModel;
    using iXlsxWriter.ComponentModel.Result.Action.Save;

    using ComponentModel;

    /// <summary>
    /// Shows how to transpose a range of data
    /// </summary>
    internal class Sample12
    {
        // Generates document
        public static void Generate(ILogger logger)
        {
            #region Creates xlsx file reference

            XlsxInput doc = XlsxInput.Create(new[] {"Hoja1", "Hoja2"});

            #endregion

            #region Insert datatable and generic collections

            doc.Insert(new InsertText
            {
                SheetName = "Hoja1",
                Location = new XlsxPointRange { Column = 2, Row = 1 },
                Data = "Custom text"
            }).Insert(new InsertEnumerable<Person>
            {
                SheetName = "Hoja1",
                Location = new XlsxPointRange { Column = 2, Row = 3 },
                Data = new Collection<Person>
                {
                    new Person {Name = "Name-01", Surname = "Surname-01"},
                    new Person {Name = "Name-02", Surname = "Surname-02"},
                    new Person {Name = "Name-03", Surname = "Surname-03"},
                    new Person {Name = "Name-04", Surname = "Surname-04"},
                    new Person {Name = "Name-05", Surname = "Surname-05"},
                    new Person {Name = "Name-06", Surname = "Surname-06"},
                    new Person {Name = "Name-07", Surname = "Surname-07"},
                    new Person {Name = "Name-08", Surname = "Surname-08"},
                    new Person {Name = "Name-09", Surname = "Surname-09"},
                    new Person {Name = "Name-10", Surname = "Surname-10"}
                }
            }).Insert(new InsertDataTable
            {
                SheetName = "Hoja1",
                Location = new XlsxPointRange { Column = 10, Row = 3 },
                Data = new Collection<Person>
                {
                    new Person {Name = "Name-01", Surname = "Surname-01"},
                    new Person {Name = "Name-02", Surname = "Surname-02"},
                    new Person {Name = "Name-03", Surname = "Surname-03"},
                    new Person {Name = "Name-04", Surname = "Surname-04"},
                    new Person {Name = "Name-05", Surname = "Surname-05"},
                    new Person {Name = "Name-06", Surname = "Surname-06"},
                    new Person {Name = "Name-07", Surname = "Surname-07"},
                    new Person {Name = "Name-08", Surname = "Surname-08"},
                    new Person {Name = "Name-09", Surname = "Surname-09"},
                    new Person {Name = "Name-10", Surname = "Surname-10"}
                }.ToDataTable<Person>("Person")
            });

            #endregion

            #region Transpose a range

            doc.Insert(new InsertTransposeRange
            {
                SheetName = "Hoja1",
                SourceRange = new XlsxRange
                {
                    Start = {Column = 2, Row = 3},
                    End = {Column = 3, Row = 13}
                },
                Destination = new QualifiedPointDefinition
                {
                    WorkSheet = "Hoja2",
                    Point = new XlsxPoint {Column = 2, Row = 3}
                }
            });

            #endregion

            #region Create output result

            var result = doc.CreateResult(new OutputResultConfig {AutoFitColumns = true});
            if (!result.Success)
            {
                logger.Info("   > Error creating output result");
                logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Saves output result

            var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample12/Sample-12" });
            if (!saveResult.Success)
            {
                logger.Info("   > Error while saving to disk");
                logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            logger.Info("   > Saved to disk correctly");
            logger.Info("     > Path: ~/Output/Sample12/Sample-12.xlsx");

            #endregion
        }
    }
}
