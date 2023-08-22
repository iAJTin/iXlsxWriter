
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;
using iTin.Core.Models.Design.Table.Headers;

using iTin.Logging.ComponentModel;
using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Design.Table.Headers;
using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows the use mini charts.
/// </summary>
internal class Sample27
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Sheet1" });

        #endregion

        #region Cell styles

        //var cellStylesTable = new Dictionary<string, XlsxCellStyle>
        //{
        //    {
        //        "HeaderStyle",
        //        new XlsxCellStyle
        //        {
        //            Name = "HeaderStyle",
        //            Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
        //            Content =
        //            {
        //                Alignment = { Horizontal = KnownHorizontalAlignment.Left },
        //                Color = "#ED7D31", 
        //                DataType = new TextDataType()
        //            }
        //        }
        //    },
        //    {
        //        "DecimalValueStyle",
        //        new XlsxCellStyle
        //        {
        //            Name = "DecimalValueStyle",
        //            Font = { Name = "Calibri", Size = 11.0f },
        //            Borders =
        //            {
        //                new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
        //            },
        //            Content =
        //            {
        //                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
        //                DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
        //            }
        //        }
        //    },
        //    {
        //        "LastFiedlDecimalValueStyle",
        //        new XlsxCellStyle
        //        {
        //            Name = "LastFiedlDecimalValueStyle",
        //            Font = { Name = "Calibri", Size = 11.0f },
        //            Borders =
        //            {
        //                new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
        //                new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
        //            },
        //            Content =
        //            {
        //                Alignment = { Horizontal = KnownHorizontalAlignment.Right },
        //                DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
        //            }
        //        }
        //    }
        //};

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
            Data = "~/Resources/Sample-27/input.xml",
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
                        Name = "HeaderStyle",
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
                        Name = "DatetimeValueStyle",
                        Font = { Name = "Calibri" },
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
                        Name = "LastFiedlDecimalValueStyle",
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
                    }
                },
                //Filter = { Field = "AUD", Criterial = KnownOperator.EqualTo, Value = "6,17350" },
                Fields =
                {
                    new DataField { Name = "DATE", Alias = "Date", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DatetimeValueStyle" } },
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
                    new DataField { Name = "SEK", Alias = "SEK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "THB", Alias = "THB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "TRY", Alias = "TRY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                    new DataField { Name = "USD", Alias = "USD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFiedlDecimalValueStyle" } }
                },
                Headers =
                {
                    new XlsxColumnHeader { From = "AUD", To = "CHF", Text = "AUD-CHF", Show = YesNo.Yes, Style = "HeaderStyle"},
                }
            }
        });

        #endregion

        //#region Insert Mini-Chart(s)

        //doc.Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Column,
        //                Column =
        //                {
        //                    Serie = { Color = "#37609" },
        //                    Points = { High = { Color = "Red" } }
        //                }
        //            }
        //        },
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Column,
        //                Column =
        //                {
        //                    Serie = { Color = "#37609" },
        //                    Points = { High = { Color = "Red" } }
        //                }
        //            }
        //        },
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Column,
        //                Column =
        //                {
        //                    Serie = { Color = "#37609" },
        //                    Points = { High = { Color = "Red" } }
        //                }
        //            }
        //        },
        //    })
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //})
        //    .Insert(new InsertMiniChart
        //{
        //    SheetName = "Chart And Secondary Axis",
        //    Location = new XlsxPointRange { Column = 8, Row = 2 },
        //    MiniChart =
        //    {
        //        EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //        ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //        ChartAxes = { Horizontal = { Show = YesNo.Yes } },
        //        ChartType =
        //        {
        //            Active = MiniChartType.Column,
        //            Column =
        //            {
        //                Serie = { Color = "#37609" },
        //                Points = { High = { Color = "Red" } }
        //            }
        //        }
        //    },
        //});

        //doc.Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    })
        //    .Insert(new InsertMiniChart
        //    {
        //        SheetName = "Chart And Secondary Axis",
        //        Location = new XlsxPointRange { Column = 8, Row = 2 },
        //        MiniChart =
        //        {
        //            EmptyValueAs = MiniChartEmptyValuesAs.Zero,
        //            ChartSize = { HorizontalCells = -1, VerticalCells = 40 },
        //            ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
        //            ChartType =
        //            {
        //                Active = MiniChartType.Line,
        //                Line =
        //                {
        //                    Serie = { Color = "#376092" },
        //                }
        //            }
        //        }
        //    });

        //#endregion

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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-27/Sample-27" });

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
        logger.Info("     > Path: ~/Output/Sample-27/Sample-27.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}

//new XlsxCellStyle
//{
//    Name = "HeaderStyle",
//    Borders =
//    {
//        new XlsxStyleBorder
//        {
//            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
//            Color = "White"
//        },
//        new XlsxStyleBorder
//        {
//            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
//            Color = "White"
//        },
//        new XlsxStyleBorder
//        {
//            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
//            Color = "White"
//        },
//        new XlsxStyleBorder
//        {
//            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
//            Color = "White"
//        }
//    },
//    Content = { Color = "#ED7D31" },
//    Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
//}


//Styles = new XlsxStylesCollection
//Fields = new List<InsertXmlData.Field>
//{
//    new()
//    {
//        Name = "DATE",
//        Alias = "Date",
//        Header = new InsertXmlData.FieldHeader { Style = "DATE" },
//        Value = new InsertXmlData.FieldValue { Style = "DATE" },
//        Aggregate = new InsertXmlData.FieldAggregate { Style = "DATE" }
//    }
//}
