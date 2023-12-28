
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table;
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
/// Shows how to use insert a table with styles and fixed fields.
/// </summary>
internal class Sample17
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
            Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-17/As400Packet.xml"))),
            Location = new XlsxPointRange { Column = 1, Row = 2 },
            Table =
            {
                Name = "R740D01",
                Alias = "AS400 - Ayers Rock",
                Resources =
                {
                    Styles = new XlsxStylesCollection
                    {
                        new XlsxCellStyle
                        {
                            Name = "CommonHeader",
                            Font = { Name = "Navy", Bold = YesNo.Yes },
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Center },
                                Color = "#C9C9C9",
                                DataType = new TextDataType()
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "LineValue",
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                Color = "DarkGray",
                                DataType = new NumberDataType   
                                {
                                    Decimals = 0,
                                    Negative =
                                    {
                                        Color = KnownBasicColor.Yellow, 
                                        Sign = KnownNegativeSign.Brackets
                                    },
                                    Error = 
                                    {
                                        Comment =
                                        {
                                            Show = YesNo.Yes, 
                                            Text = "Underlying value: ", 
                                            Font = { Name = "Navy", Size = 12.0f }
                                        }
                                    }
                                }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "PercentValue",
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                Color = "DarkGray",
                                DataType = new PercentageDataType { Decimals = 1 }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "DateValue",
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Center },
                                Color = "sc# 0.15 0.15 0.15",
                                DataType = new DateTimeDataType
                                {
                                    Locale = KnownCulture.enUS,
                                    Format = KnownDateTimeFormat.YearMonthPattern,
                                    Error =
                                    {
                                        Value = "Today",
                                        Comment =
                                        {
                                            Show = YesNo.Yes,
                                            Text = "Underlying value: ",
                                            Font = { Name = "Comic Sans MS", Size = 16.0f, Color = "Navy", Bold = YesNo.Yes, Italic = YesNo.Yes, Underline = YesNo.Yes }
                                        }
                                    }
                                }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "AccountValue",
                            Content =
                            {
                                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                                Color = "White",
                                DataType = new CurrencyDataType 
                                { 
                                    Locale = KnownCulture.enUS, 
                                    Negative =
                                    {
                                        Color = KnownBasicColor.Red,
                                        Sign = KnownNegativeSign.Parenthesis
                                    }
                                }
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "NameValue",
                            Content =
                            {
                                Color = "White",
                                DataType = new TextDataType()
                            }
                        },
                        new XlsxCellStyle
                        {
                            Name = "FixedValue",
                            Content =
                            {
                                Color = "LightBlue",
                                DataType = new TextDataType()
                            }
                        }
                    },
                    Fixed =
                    {
                        new Fixed
                        {
                            Name = "Pieces",
                            Reference = "SFLDTA",
                            Pieces =
                            {
                                new Piece { Name = "DCALL", From = 0, Lenght = 2, Trim = YesNo.Yes, TrimMode = KnownTrimMode.All },
                                new Piece { Name = "NOCOL", From = 2, Lenght = 14 },
                                new Piece { Name = "SHOP", From = 16, Lenght = 5 },
                                new Piece { Name = "SIT", From = 21, Lenght = 5 },
                                new Piece { Name = "PIK", From = 27, Lenght = 5 },
                                new Piece { Name = "PKG", From = 32, Lenght = 5 },
                                new Piece { Name = "DG", From = 37, Lenght = 5 },
                                new Piece { Name = "REM", From = 37, Lenght = 5 },
                                new Piece { Name = "SPR", From = 42, Lenght = 9 },
                                new Piece { Name = "DATESHOP", From = 56, Lenght = 11 }
                            }
                        }
                    }
                },
                Fields =
                {
                    new DataField { Name = "##LINE", Alias = "Line", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "LineValue" } },
                    new DataField { Name = "*PERCENT", Alias = "%", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "PercentValue" } },
                    new DataField { Name = "SFORDDATE", Alias = "Date", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "DateValue" } },
                    new DataField { Name = "CMCUST", Alias = "Account", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "AccountValue" } },
                    new DataField { Name = "CMNAME", Alias = "Name", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "NameValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "DCALL", Alias = "D/Call", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "NOCOL", Alias = "No/Col", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "SHOP", Alias = "Shop", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "SIT", Alias = "SIT", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "PIK", Alias = "Pik", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "PKG", Alias = "PKG", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "DG", Alias = "D&G", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "REM", Alias = "Rem", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "SPR", Alias = "SPR 2013", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                    new FixedField { Pieces = "Pieces", Piece = "DATESHOP", Alias = "Date in Shop", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-17/Sample-17" });

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
        logger.Info("     > Path: ~/Output/Sample-17/Sample-17.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
