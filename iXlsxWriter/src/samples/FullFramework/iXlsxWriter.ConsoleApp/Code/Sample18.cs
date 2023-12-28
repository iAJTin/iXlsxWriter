
using System;
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;
using iTin.Core.Models.Design.Table.Resource;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

using iTinPath = iTin.Core.IO.Path;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to use insert a table with inherits styles and grouped fields.
/// </summary>
internal class Sample18
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

        doc.Insert(new InsertTable
        {
            SheetName = "Sheet1",
            Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-18/Input.xml"))),
            Location = new XlsxPointRange { Column = 1, Row = 2 },
            Table =
            {
                Name = "Invoice",
                Alias = "Invoice",
                Resources =
                {
                    Styles = new XlsxStylesCollection
                    {
                        new XlsxCellStyle
                        {
                            Name = "HeaderStyle",
                            Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes },
                            Borders =
                            {
                                new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                            },
                            Content =
                            {
                                Color = "#ED7D31",
                                DataType = new TextDataType()
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "CustomerHeaderStyle",
                            Inherits = "HeaderStyle",
                            Content = { Color = "Green" }
                        },
                        new XlsxCellStyle
                        {
                            Name = "NumericStyle",
                            Font = { Name = "Calibri", Color = "White" },
                            Content =
                            {
                                Color = "#ED7D31",
                                DataType = new NumberDataType { Decimals = 0 }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DateStyle",
                            Font = { Name = "Calibri" },
                            Content =
                            {
                                Color = "#FCE4D6",
                                DataType = new DateTimeDataType { Format = KnownDateTimeFormat.ShortDatePattern }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DateStyle",
                            Font = { Name = "Calibri" },
                            Content =
                            {
                                Color = "#FCE4D6",
                                DataType = new DateTimeDataType { Format = KnownDateTimeFormat.ShortDatePattern }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "StringStyle",
                            Font = { Name = "Calibri" },
                            Content =
                            {
                                Color = "#FCE4D6",
                                DataType = new TextDataType()
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "CustomerStringStyle",
                            Inherits = "StringStyle",
                            Content = { Color = "LightGreen" }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DecimalStyle",
                            Font = { Name = "Calibri" },
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                Color = "#FCE4D6",
                                DataType = new NumberDataType { Separator = YesNo.Yes }
                            }
                        },
                    },
                    Groups =  
                    {
                        new Group
                        { 
                            Name = "CustomerName",
                            Fields =
                            {
                                new GroupItem { Name = "CUSTOMERFIRSTNAME", Trim = YesNo.Yes, Separator = ", " },
                                new GroupItem { Name = "CUSTOMERLASTNAME" }
                            }
                        }
                    }
                },
                Fields =
                {
                    new DataField { Name = "ID", Alias = "Id", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "NumericStyle" } },
                    new DataField { Name = "DATE", Alias = "Date", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateStyle" } },
                    new GroupField { Name = "CustomerName", Alias = "Customer", Header = { Style = "CustomerHeaderStyle", Show = YesNo.Yes }, Value = { Style = "CustomerStringStyle" } },
                    new DataField { Name = "CUSTOMERPHONE", Alias = "Phone", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "CUSTOMEREMAIL", Alias = "Email", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "BILLINGADDRESS", Alias = "Address", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "BILLINGCITY", Alias = "City", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "BILLINGSTATE", Alias = "State", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "BILLINGCOUNTRY", Alias = "Country", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "BILLINGPOSTALCODE", Alias = "Postal Code", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                    new DataField { Name = "TOTAL", Alias = "Total", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalStyle" } },
                }
            }
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-18/Sample-18" });

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
        logger.Info("     > Path: ~/Output/Sample-18/Sample-18.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
