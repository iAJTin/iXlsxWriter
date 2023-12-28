
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows the use charts with more than one chart type and secondary axis.
/// </summary>
internal class Sample26
{
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Chart And Secondary Axis" });

        #endregion

        #region Cell styles

        var cellStylesTable = new Dictionary<string, XlsxCellStyle>
        {
            {
                "FieldHeader",
                new XlsxCellStyle
                {
                    Name = "HeaderStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Content = { Color = "#ED7D31" },
                    Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
                }
            },
            {
                "NumericStyle",
                new XlsxCellStyle
                {
                    Name = "NumberStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Content =
                    {
                        Color = "#F8CBAD",
                        AlternateColor = "#FCE4D6",
                        DataType = new NumberDataType { Decimals = 0 },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                    },
                    Font = { Name = "Calibri", Size = 11.0f }
                }
            },
            {
                "TextStyle",
                new XlsxCellStyle
                {
                    Name = "TextStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Font = { Name = "Calibri", Size = 11.0f },
                    Content = { Color = "#F8CBAD", AlternateColor = "#FCE4D6" }
                }
            },
            {
                "DecimalStyle",
                new XlsxCellStyle
                {
                    Name = "DecimalStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Content =
                    {
                        Color = "#F8CBAD",
                        AlternateColor = "#FCE4D6",
                        DataType = new NumberDataType { Decimals = 2 },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                    },
                    Font = { Name = "Calibri", Size = 11.0f }
                }
            },
            {
                "AggregateNumericStyle",
                new XlsxCellStyle
                {
                    Name = "AggregateNumericStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Content =
                    {
                        Color = "#ED7D31",
                        DataType = new NumberDataType { Decimals = 0 },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                    },
                    Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
                }
            },
            {
                "AggregateDecimalStyle",
                new XlsxCellStyle
                {
                    Name = "AggregateDecimalStyle",
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        },
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                            Color = "White"
                        }
                    },
                    Content =
                    {
                        Color = "#ED7D31",
                        DataType = new NumberDataType { Decimals = 2 },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                    },
                    Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
                }
            }
        };

        #endregion

        #region Sheet 1

        #region Hides the grid lines

        doc.Set(new SetGridLines
        {
            Show = YesNo.No,
            SheetName = "Chart And Secondary Axis"
        });

        #endregion

        #region Insert Data

        #region ID

        doc.Insert(new InsertText
        {
            Data = "ID",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 1, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 12001,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 1, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 12002,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 1, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 12003,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 1, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 12010,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 1, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 12011,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 1, Row = 6 }
        }).Insert(new InsertText
        {
            Data = "Total",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 1, Row = 7 }
        });

        #endregion

        #region Product

        doc.Insert(new InsertText
        {
            Data = "Product",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 2, Row = 1 }
        }).Insert(new InsertText
        {
            Data = "Nails",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["TextStyle"],
            Location = new XlsxPointRange { Column = 2, Row = 2 }
        }).Insert(new InsertText
        {
            Data = "Hammer",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["TextStyle"],
            Location = new XlsxPointRange { Column = 2, Row = 3 },
        }).Insert(new InsertText
        {
            Data = "Saw",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["TextStyle"],
            Location = new XlsxPointRange { Column = 2, Row = 4 }
        }).Insert(new InsertText
        {
            Data = "Drill",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["TextStyle"],
            Location = new XlsxPointRange { Column = 2, Row = 5 }
        }).Insert(new InsertText
        {
            Data = "Crowbar",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["TextStyle"],
            Location = new XlsxPointRange { Column = 2, Row = 6 }
        }).Insert(new InsertText
        {
            Data = "",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 2, Row = 7 }
        });

        #endregion

        #region Items in Stock

        doc.Insert(new InsertText
        {
            Data = "Items in Stock",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 3, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 37,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 5,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 12,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 20,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 7,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["NumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 6 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Chart And Secondary Axis",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  3, Row = 2},
                        End = {Column =  3, Row = 6}
                    }
                },
            Style = cellStylesTable["AggregateNumericStyle"],
            Location = new XlsxPointRange { Column = 3, Row = 7 }
        });

        #endregion

        #region Purchase Price

        doc.Insert(new InsertText
        {
            Data = "Purchase Price",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 4, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 1.30f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 5.33f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 8.99f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 4.30f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 13.77f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 6 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Chart And Secondary Axis",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  4, Row = 2},
                        End = {Column =  4, Row = 6}
                    }
                },
            Style = cellStylesTable["AggregateDecimalStyle"],
            Location = new XlsxPointRange { Column = 4, Row = 7 }
        });

        #endregion

        #region Price

        doc.Insert(new InsertText
        {
            Data = "Price",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 5, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 3.99f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 12.10f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 15.37f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 8.0f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 23.48f,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 6 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Chart And Secondary Axis",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  5, Row = 2},
                        End = {Column =  5, Row = 6}
                    }
                },
            Style = cellStylesTable["AggregateDecimalStyle"],
            Location = new XlsxPointRange { Column = 5, Row = 7 }
        });

        #endregion

        #region Profit

        doc.Insert(new InsertText
        {
            Data = "Profit",
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["FieldHeader"],
            Location = new XlsxPointRange { Column = 6, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 2.69,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 6.77,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 6.38,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 3.70,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 9.71,
            SheetName = "Chart And Secondary Axis",
            Style = cellStylesTable["DecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 6 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Chart And Secondary Axis",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  6, Row = 2},
                        End = {Column =  6, Row = 6}
                    }
                },
            Style = cellStylesTable["AggregateDecimalStyle"],
            Location = new XlsxPointRange { Column = 6, Row = 7 }
        });

        #endregion

        #endregion

        #region Insert Autofilter

        doc.Insert(new InsertAutoFilter
        {
            SheetName = "Chart And Secondary Axis",
            Location = new XlsxStringRange { Address = "A1:F1" }
        });

        #endregion

        #region Define plot axis

        var axisRangePlot1 = new XlsxRange
        {
            Start = { Column = 2, Row = 2 },
            End = { Column = 2, Row = 6 }
        };

        var axisRangePlot2 = new XlsxRange
        {
            Start = { Column = 1, Row = 2 },
            End = { Column = 1, Row = 6 }
        };

        #endregion

        #region Insert Chart(s)

        doc.Insert(new InsertChart
        {
            SheetName = "Chart And Secondary Axis",
            Location = new XlsxPointRange { Column = 8, Row = 2 },
            Chart = new XlsxChart
            {
                Name = "chart1",
                Size = { Width = 800, Height = 600 },
                Border =
                {
                    Color = "Green"
                },
                Axes =
                {
                    Primary =
                    {
                        Values = { GridLines = GridLine.Major }
                    },
                    Secondary =
                    {
                        Values =
                        {
                            Labels = { Position = LabelPosition.High },
                            Values = { Maximum = "50" }
                        },
                        Category =
                        {
                            Labels = { Position = LabelPosition.High }
                        }
                    }
                },
                Legend =
                {
                    Show = YesNo.Yes,
                    Font = { Name = "Calibri" }
                },
                Plots =
                {
                    new XlsxChartPlot
                    {
                        Name = "plot1",
                        Series =
                        {
                            new XlsxChartSerie
                            {
                                Name = "Purchase Price",
                                Color = "#336EA9",
                                ChartType = ChartType.ColumnStacked,
                                AxisRange = axisRangePlot1,
                                FieldRange = new XlsxRange { Start = { Column = 4, Row = 2 }, End = { Column = 4, Row = 6 } }
                            },
                            new XlsxChartSerie
                            {
                                Name = "Profit",
                                Color = "#ED7D31",
                                ChartType = ChartType.ColumnStacked,
                                AxisRange = axisRangePlot1,
                                FieldRange = new XlsxRange { Start = { Column = 6, Row = 2 }, End = { Column = 6, Row = 6 } }
                            },
                        }
                    },
                    new XlsxChartPlot
                    {
                        Name = "plot2",
                        UseSecondaryAxis = YesNo.Yes,
                        Series =
                        {
                            new XlsxChartSerie
                            {
                                Name = "Items in Stock",
                                Color = "Gray",
                                ChartType = ChartType.Line,
                                AxisRange = axisRangePlot2,
                                FieldRange = new XlsxRange { Start = { Column = 3, Row = 2 }, End = { Column = 3, Row = 6 } }
                            }
                        }
                    }
                },
                Effects =
                {
                    Shadow = XlsxPerspectiveShadow.Down,
                    Illumination = XlsxIlluminationShapeEffect.Emphasis1Points8
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-26/Sample-26" });

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
        logger.Info("     > Path: ~/Output/Sample-26/Sample-26.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
