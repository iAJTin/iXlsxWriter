
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

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows the use stacked charts.
/// </summary>
internal class Sample25
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        XlsxInput doc = XlsxInput.Create(new[] { "Stacked area chart", "Sheet2" });

        #endregion

        #region Cell styles

        var cellStyles = new Dictionary<string, XlsxCellStyle>
            {
                {
                    "FieldHeader",
                    new XlsxCellStyle
                    {
                        Font =
                        {
                            Name = "Calibri",
                            Size = 11.0f,
                            Bold = YesNo.Yes,
                        },
                        Borders =
                        {
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Color = "#9BC2E6"},
                        },
                        Content =
                        {
                            Color = "#DDEBF7"
                        }
                    }
                },
                {
                    "FieldValue",
                    new XlsxCellStyle
                    {
                        Font =
                        {
                            Name = "Calibri",
                            Size = 11.0f,
                        },
                        Borders =
                        {
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                        },
                        Content =
                        {
                            Color = "#BDD7EE",
                            AlternateColor = "#DDEBF7",
                            DataType = new NumberDataType
                            {
                                Decimals = 1,
                                Separator = YesNo.Yes
                            },
                            Alignment =
                            {
                                Horizontal = KnownHorizontalAlignment.Right
                            }
                        }
                    }
                },
                {
                    "PeriodValue",
                    new XlsxCellStyle
                    {
                        Font =
                        {
                            Name = "Calibri",
                            Size = 11.0f,
                            Bold = YesNo.Yes,
                        },
                        Content =
                        {
                            Color = "#BDD7EE",
                            AlternateColor = "#DDEBF7",
                            DataType = new DateTimeDataType
                            {
                                Locale = KnownCulture.Current,
                                Format = KnownDateTimeFormat.ShortDatePattern
                            }
                        }
                    }
                },
                {
                    "AggregateHeader",
                    new XlsxCellStyle
                    {
                        Font =
                        {
                            Name = "Calibri",
                            Size = 11.0f,
                            Bold = YesNo.Yes,
                        },
                        Borders =
                        {
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Top, Color = "#9BC2E6"},
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                        },
                        Content =
                        {
                            Color = "#DDEBF7",
                        }
                    }
                },
                {
                    "AggregateFieldValue",
                    new XlsxCellStyle
                    {
                        Font =
                        {
                            Name = "Calibri",
                            Size = 11.0f,
                            Bold = YesNo.Yes,
                        },
                        Borders =
                        {
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Top, Color = "#9BC2E6"},
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                            new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                        },
                        Content =
                        {
                            Color = "#DDEBF7",
                            DataType = new NumberDataType
                            {
                                Decimals = 1,
                                Separator = YesNo.Yes
                            },
                            Alignment =
                            {
                                Horizontal = KnownHorizontalAlignment.Right
                            }
                        }
                    }
                }
            };

        #endregion

        #region Sheet 1

        #region Sheet 1 > Insert Data

        #region PERIOD

        doc.Insert(new InsertText
        {
            Data = "Period",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 1, Row = 1 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/01/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 2 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/02/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 3 },
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/03/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 4 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/04/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 5 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/05/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 6 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/06/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 7 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/07/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 8 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/08/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 9 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/09/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 10 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/10/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 11 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/11/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 12 }
        }).Insert(new InsertText
        {
            Data = DateTime.Parse("01/12/2010"),
            SheetName = "Stacked area chart",
            Style = cellStyles["PeriodValue"],
            Location = new XlsxPointRange { Column = 1, Row = 13 }
        }).Insert(new InsertText
        {
            Data = "Total",
            SheetName = "Stacked area chart",
            Style = cellStyles["AggregateHeader"],
            Location = new XlsxPointRange { Column = 1, Row = 14 }
        });

        #endregion

        #region Europe

        doc.Insert(new InsertText
        {
            Data = "Europe",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 2, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 12.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 13.9,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 11.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 12.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 9.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 14.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 7.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 19.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 21.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 23.8,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 25.6,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 17.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  2, Row = 2},
                        End = {Column =  2, Row = 13}
                    }
                },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 2, Row = 14 }
        });

        #endregion

        #region Africa

        doc.Insert(new InsertText
        {
            Data = "Africa",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 3, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 8.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 9.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 8.7,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 9.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 10.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 9.8,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 11.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 10.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 8.5,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 9.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 10.8,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 12.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  3, Row = 2},
                        End = {Column =  3, Row = 13}
                    }
                },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 3, Row = 14 }
        });

        #endregion

        #region Asia

        doc.Insert(new InsertText
        {
            Data = "Asia",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 4, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 55.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 51.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 54.7,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 53.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 45.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 49.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 50.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 49.6,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 41.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 45.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 49.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 43.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =  4, Row = 2},
                        End = {Column =  4, Row = 13}
                    }
                },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 4, Row = 14 }
        });

        #endregion

        #region North America

        doc.Insert(new InsertText
        {
            Data = "North America",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 5, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 35.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 35.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 32.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 35.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 25.8,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 29.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 31.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 35.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 35.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 32.0,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 33.6,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 35.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =   5, Row = 2},
                        End = {Column =   5, Row = 13}
                    }
                },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 5, Row = 14 }
        });

        #endregion

        #region South America

        doc.Insert(new InsertText
        {
            Data = "South America",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 6, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 14.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 14.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 13.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 11.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 12.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 14.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 14.9,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 13.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 14.5,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 16.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 14.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 15.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
            {
                AggregateType = KnownAggregateType.Sum,
                HasAutoFilter = YesNo.Yes,
                Range = new XlsxRange
                {
                    Start = { Column = 6, Row = 2 },
                    End = { Column = 6, Row = 13 }
                }
            },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 6, Row = 14 }
        });

        #endregion

        #region Australia

        doc.Insert(new InsertText
        {
            Data = "Australia",
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldHeader"],
            Location = new XlsxPointRange { Column = 7, Row = 1 }
        }).Insert(new InsertText
        {
            Data = 12.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 2 }
        }).Insert(new InsertText
        {
            Data = 11.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 3 },
        }).Insert(new InsertText
        {
            Data = 12.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 4 }
        }).Insert(new InsertText
        {
            Data = 10.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 5 }
        }).Insert(new InsertText
        {
            Data = 13.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 6 }
        }).Insert(new InsertText
        {
            Data = 14.2,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 7 }
        }).Insert(new InsertText
        {
            Data = 12.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 8 }
        }).Insert(new InsertText
        {
            Data = 10.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 9 }
        }).Insert(new InsertText
        {
            Data = 9.3,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 10 }
        }).Insert(new InsertText
        {
            Data = 11.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 11 }
        }).Insert(new InsertText
        {
            Data = 13.4,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 12 }
        }).Insert(new InsertText
        {
            Data = 15.1,
            SheetName = "Stacked area chart",
            Style = cellStyles["FieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 13 }
        }).Insert(new InsertAggregateFunction
        {
            SheetName = "Stacked area chart",
            Aggegate =
                {
                    AggregateType = KnownAggregateType.Sum,
                    HasAutoFilter = YesNo.Yes,
                    Range = new XlsxRange
                    {
                        Start = {Column =   7, Row = 2},
                        End = {Column =   7, Row = 13}
                    }
                },
            Style = cellStyles["AggregateFieldValue"],
            Location = new XlsxPointRange { Column = 7, Row = 14 }
        });

        #endregion

        #endregion

        #region Sheet 1 > Insert Autofilter

        doc.Insert(new InsertAutoFilter
        {
            SheetName = "Stacked area chart",
            Location = new XlsxStringRange { Address = "A1:G1" }
        });

        #endregion

        #region Sheet 1 > Insert Chart(s)

        doc.Insert(new InsertChart
        {
            SheetName = "Stacked area chart",
            Location = new XlsxPointRange { Column = 10, Row = 1 },
            Chart = new XlsxChart
            {
                Name = "chart1",
                Size = { Width = 800, Height = 600 },
                Axes = { Primary = { Values = { GridLines = GridLine.Major } } },
                Legend = { Show = YesNo.Yes, Border = { Show = YesNo.Yes } },
                Plots =
                    {
                        new XlsxChartPlot
                        {
                            Name = "plot1",
                            Series =
                            {
                                new XlsxChartSerie
                                {
                                    Name = "Europe",
                                    Color = "#285A8F",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 2, Row = 2}, End = {Column = 2, Row = 13}}
                                },
                                new XlsxChartSerie
                                {
                                    Name = "AFRICA",
                                    Color = "#336EA9",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 3, Row = 2}, End = {Column = 3, Row = 13}}
                                },
                                new XlsxChartSerie
                                {
                                    Name = "ASIA",
                                    Color = "#3572B1",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 4, Row = 2}, End = {Column = 4, Row = 13}}
                                },
                                new XlsxChartSerie
                                {
                                    Name = "NORTHAMERICA",
                                    Color = "#628AC5",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 5, Row = 2}, End = {Column = 5, Row = 13}}
                                },
                                new XlsxChartSerie
                                {
                                    Name = "SOUTHAMERICA",
                                    Color = "#93ADCD",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 6, Row = 2}, End = {Column = 6, Row = 13}}
                                },
                                new XlsxChartSerie
                                {
                                    Name = "AUSTRALIA",
                                    Color = "#BCCCDE",
                                    ChartType = ChartType.AreaStacked,
                                    AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                    FieldRange = new XlsxRange {Start = {Column = 7, Row = 2}, End = {Column = 7, Row = 13}}
                                }
                            }
                        }
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

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-25/Sample-25" });

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
        logger.Info("     > Path: ~/Output/Sample-25/Sample-25.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
