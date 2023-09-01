﻿
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to use insert a table with styles.
/// </summary>
internal class Sample12
{
    public static async Task GenerateAsync(ILogger logger, CancellationToken cancellationToken = default)
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

        #region Insert Table

        doc.Insert(new InsertTable
        {
            SheetName = "Sheet1",
            Data = "~/Resources/Sample-12/input.xml",
            Location = new XlsxPointRange { Column = 1, Row = 2 },
            Table =
            {
                Name = "Rates",
                Alias = "Rates",
                ShowColumnHeaders = YesNo.Yes,
                ShowDataValues = YesNo.Yes,
                Styles = new XlsxStylesCollection
                {
                    new XlsxCellStyle
                    {
                        Name = "GroupHeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Center },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "HeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateHeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Left },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateValueStyle",
                        Font = { Name = "Calibri" },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new DateTimeDataType{ Format = KnownDateTimeFormat.ShortDatePattern }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "LastFieldDecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "SekValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 0 }
                        }
                    }
                },
                Fields =
                {
                    new DataField { Name = "DATE", Alias = "Date", Header = { Style = "DateHeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateValueStyle" } },
                    new DataField { Name = "AUD", Alias = "AUD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "CAD", Alias = "CAD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "CHF", Alias = "CHF", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "DKK", Alias = "DKK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "EUR", Alias = "EUR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "GBP", Alias = "GBP", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "HKD", Alias = "HKD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "JPY", Alias = "JPY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "MYR", Alias = "MYR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "NOK", Alias = "NOK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "NZD", Alias = "NZD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "RUB", Alias = "RUB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "SEK", Alias = "SEK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "SekValueStyle" } },
                    new DataField { Name = "THB", Alias = "THB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "TRY", Alias = "TRY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "USD", Alias = "USD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFieldDecimalValueStyle" } }
                }
            }
        });

        #endregion

        #endregion

        #region Create output result

        var result = await doc.CreateResultAsync(cancellationToken: cancellationToken);
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves output result

        var saveResult = await result.Result
            .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-12/Sample-12" }, cancellationToken)
            .ConfigureAwait(false);

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
        logger.Info("     > Path: ~/Output/Sample-12/Sample-12.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}