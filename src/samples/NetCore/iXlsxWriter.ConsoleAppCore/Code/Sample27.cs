
using System.Diagnostics;

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
    public static void Generate(ILogger logger, int rows)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1" });

        #endregion

        #region Create data input

        var rnd = new Random();
        var collection = new List<CustomDataModel>();

        for (var row = 1; row <= rows; row++)
        {
            collection.Add(new CustomDataModel
            {
                Index = row,
                Text = $"Row {row}",
                Date = DateTime.Today.AddDays(row),
                Number = rnd.NextDouble() * 10000
            });
        }

        #endregion

        #region Sheet 1

        #region Hides the grid lines

        doc.Set(new SetGridLines
        {
            Show = YesNo.No,
            SheetName = "Sheet1"
        });

        #endregion

        #region Insert Table

        doc.Insert(new InsertTable
        {
            SheetName = "Sheet1",
            Data = new EnumerableInput<CustomDataModel>(collection, "CustomDataModel"), // new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-27/Input.xml"))), //, new DataInputConfiguration { InputNodes = "CustomDataModel", OutputTable = "CustomDataModelTable" }), //, "CustomDataModel"),
            Location = new XlsxPointRange { Column = 1, Row = 2 },
            Table =
            {
                Name = "CustomDataModel",
                Alias = "Custom Data Model",
                ShowColumnHeaders = YesNo.Yes,
                ShowDataValues = YesNo.Yes,
                Resources =
                {
                    Styles = new XlsxStylesCollection
                    {
                        new XlsxCellStyle
                        {
                            Name = "HeaderStyle",
                            Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Center },
                                Color = "Navy",
                                DataType = new TextDataType()
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "NumberValueStyle",
                            Font = { Name = "Calibri", Size = 11.0f },
                            Content =
                            {
                                AlternateColor = "#FCE4D6",
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                DataType = new NumberDataType { Decimals = 0 }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "NumberValueAggregateStyle",
                            Inherits = "HeaderStyle",
                            Font = { Size = 14.0f },
                            Content =
                            {
                                DataType = new NumberDataType { Decimals = 0 }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "StringValueStyle",
                            Font = { Name = "Calibri", Size = 11.0f },
                            Content =
                            {
                                AlternateColor = "#FCE4D6",
                                Alignment = { Horizontal = KnownHorizontalAlignment.Left },
                                DataType = new TextDataType(),
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DateValueStyle",
                            Font = { Name = "Calibri", Size = 11.0f },
                            Content =
                            {
                                AlternateColor = "#FCE4D6",
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                DataType = new DateTimeDataType{ Format = KnownDateTimeFormat.ShortDatePattern }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DecimalValueStyle",
                            Font = { Name = "Calibri", Size = 11.0f },
                            Content =
                            {
                                AlternateColor = "#FCE4D6",
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                DataType = new NumberDataType { Decimals = 2, Separator = YesNo.Yes },
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DecimalValueAggregateStyle",
                            Font = { Name = "Calibri", Size = 11.0f, Bold = YesNo.Yes },
                            Content =
                            {
                                Color = "LightGray",
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                DataType = new NumberDataType { Decimals = 2, Separator = YesNo.Yes },
                            }
                        }
                    }
                },
                Fields =
                {
                    new DataField
                    {
                        Name = "INDEX", 
                        Alias = "Index", 
                        Header = { Style = "HeaderStyle", Show = YesNo.Yes }, 
                        Value = { Style = "NumberValueStyle" },
                        Aggregate = { Location = KnownAggregateLocation.Top, AggregateType = KnownAggregateType.Count, Style = "NumberValueAggregateStyle", Show = YesNo.Yes }
                    },
                    new DataField
                    {
                        Name = "Text",
                        Alias = "Text", 
                        Header = { Style = "HeaderStyle", Show = YesNo.Yes }, 
                        Value = { Style = "StringValueStyle" }
                    },
                    new DataField
                    {
                        Name = "Date", 
                        Alias = "Date",
                        Header = { Style = "HeaderStyle", Show = YesNo.Yes },
                        Value = { Style = "DateValueStyle" }
                    },
                    new DataField
                    {
                        Name = "NUMBER", 
                        Alias = "Number", 
                        Header = { Style = "HeaderStyle", Show = YesNo.Yes },
                        Value = { Style = "DecimalValueStyle" }, 
                        Aggregate = { Location = KnownAggregateLocation.Bottom, AggregateType = KnownAggregateType.Sum, Style = "DecimalValueAggregateStyle", Show = YesNo.Yes }
                    }
                }
            }
        });

        #endregion

        #region Insert AutoFilter

        doc.Insert(new InsertAutoFilter
        {
            SheetName = "Sheet1",
            Location = new XlsxStringRange { Address = "A3:D3" }
        });

        #endregion

        #endregion

        #region Create output result

        var result = doc.CreateResult(new XlsxOutputResultConfig {AutoFitColumns = true});
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
            logger.Info($"   > Elapsed time: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}");
            return;
        }

        logger.Info("   > Saved to disk correctly");
        logger.Info("     > Path: ~/Output/Sample-27/Sample-27.xlsx");
        logger.Info($"   > Elapsed time: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}");

        #endregion
    }
}
