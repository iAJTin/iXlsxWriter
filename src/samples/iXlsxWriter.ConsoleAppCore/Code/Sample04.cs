
using iTin.Core.Models.Design;

namespace iXlsxWriter.Samples
{
    using iTin.Core.ComponentModel;

    using iTin.Core.Models;
    using iTin.Core.Models.Design.Enums;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Charts;
    using iTin.Utilities.Xlsx.Design.Settings;
    using iTin.Utilities.Xlsx.Design.Settings.Sheets;
    using iTin.Utilities.Xlsx.Design.Picture;
    using iTin.Utilities.Xlsx.Design.Shape;
    using iTin.Utilities.Xlsx.Design.Shared;
    using iTin.Utilities.Xlsx.Design.Styles;

    /// <summary>
    /// Shows the use of how serialize and deserialize global settings, styles, pictures, shapes and mini-charts.
    /// </summary>
    internal class Sample04
    {
        // Generates document
        public static void Generate(ILogger logger)
        {
            #region global settings

            logger.Info("");
            logger.Info("   1) Working with global settings");

            var globalSettings = new XlsxSettings
            {
                DocumentSettings =
                {
                    Author = "iTin",
                    Company = "iTin",
                    Manager = "iTin",
                    Category = "Reports",
                    Subject = "Subject",
                    Url = "http://www.iTin.es",
                    Title = "Report Sample From Code",
                    Keywords = "Reports, Excel, Summary",
                    Comments = "Sample Report Sample"
                },
                SheetsSettings =
                {
                    new XlsxSheetSettings
                    {
                        Size = KnownDocumentSize.A3,
                        View = KnownDocumentView.Design,
                        Orientation = KnownDocumentOrientation.Landscape,
                        FreezePanesPoint =
                        {
                            Row = 3,
                            Column = 3, 
                        },
                        Margins =
                        {
                            Bottom = 25,
                            Left = 25,
                            Right = 25,
                            Top = 25,
                            Units = KnownUnit.Millimeters
                        },
                        Header =
                        {
                            Sections =
                            {
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample header",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample header",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Header text",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Right,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Header text",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Right,
                                }
                            }
                        },
                        Footer =
                        {
                            Sections =
                            {
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample footer",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample footer",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@PageNumber / @NumberOfPages",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Right
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@PageNumber / @NumberOfPages",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Right
                                },
                            }
                        }
                    },
                    new XlsxSheetSettings
                    {
                        Size = KnownDocumentSize.A3,
                        View = KnownDocumentView.Design,
                        Orientation = KnownDocumentOrientation.Landscape,
                        Margins =
                        {
                            Bottom = 25,
                            Left = 25,
                            Right = 25,
                            Top = 25,
                            Units = KnownUnit.Millimeters
                        },
                        Header =
                        {
                            Sections =
                            {
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample header",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample header",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@SheetName",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Right,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@SheetName",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Right,
                                }
                            }
                        },
                        Footer =
                        {
                            Sections =
                            {
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample footer",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "Sample footer",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Left,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "iTin",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Center,
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@PageNumber / @NumberOfPages",
                                    Type = KnownHeaderFooterSectionType.Odd,
                                    Alignment = KnownHeaderFooterAlignment.Right
                                },
                                new XlsxDocumentHeaderFooterSection
                                {
                                    Text = "@PageNumber / @NumberOfPages",
                                    Type = KnownHeaderFooterSectionType.Even,
                                    Alignment = KnownHeaderFooterAlignment.Right
                                },
                            }
                        }
                    }
                }
            };

            // Save global settings to disk
            logger.Info("      a) XML");
            var sheetsSettingsAsXmlResult = globalSettings.SaveToFile("~/Output/Sample04/GlobalSettings");
            if (!sheetsSettingsAsXmlResult.Success)
            {
                logger.Info("         > Error while saving global settings as xml to disk");
                logger.Info($"           > Error: {sheetsSettingsAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved global settings as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/GlobalSettings.xml");
            }

            // New global settings instances from disk
            logger.Info("         > Try to creates a new instance of XML global settings from disk");
            var globalSettingsFromXml = XlsxSettings.LoadFromFile("~/Output/Sample04/GlobalSettings.xml");
            logger.Info(globalSettingsFromXml == null
                ? "           > Error while loading global settings from xml file"
                : "           > Global settings loaded correctly from xml '~/Output/Sample04/GlobalSettings.xml' file");

            // Save global settings to disk
            logger.Info("");
            logger.Info("      b) json");
            var sheetsSettingsAsJsonResult = globalSettings.SaveToFile("~/Output/Sample04/GlobalSettings", KnownFileFormat.Json);
            if (!sheetsSettingsAsJsonResult.Success)
            {
                logger.Info("         > Error while saving sheet settings as json to disk");
                logger.Info($"           > Error: {sheetsSettingsAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved global settings as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample4/GlobalSettings.json");
            }

            // New global settings instances from disk
            logger.Info("         > Try to creates a new instance of json global settings from disk");
            var globalSettingsFromJson = XlsxSettings.LoadFromFile("~/Output/Sample04/GlobalSettings.json", KnownFileFormat.Json);
            logger.Info(globalSettingsFromJson == null
                ? "           > Error while loading global settings from json file"
                : "           > Global settings loaded correctly from json '~/Output/Sample04/GlobalSettings.json' file");

            #endregion

            #region style

            logger.Info("");
            logger.Info("   2) Working with styles");

            var style = new XlsxCellStyle
            {
                Font =
                {
                    Bold = YesNo.Yes,
                    Italic = YesNo.Yes,
                    Color = "Yellow",
                    Underline = YesNo.No
                },
                Borders =
                {
                    new XlsxStyleBorder {Color = "Red", Show = YesNo.Yes, Position = KnownBorderPosition.Right},
                    new XlsxStyleBorder {Color = "Yellow", Show = YesNo.Yes, Position = KnownBorderPosition.Top}
                },
                Content =
                {
                    DataType = new DateTimeDataType
                    {
                        Locale = KnownCulture.afZA,
                        Format = KnownDateTimeFormat.FullDatePattern,
                        Error =
                        {
                            Value = "MaxValue",
                            Comment =
                            {
                                Show = YesNo.No,
                                Text = "dfdfdfdf",
                                Font =
                                {
                                    Bold = YesNo.Yes,
                                    Color = "Red",
                                    Name = "Arial",
                                    IsScalable = YesNo.No
                                }
                            }
                        },
                        Properties = new Properties
                        {
                            new Property {Name = "p001", Value = "v001"},
                            new Property {Name = "p002", Value = "v002"}
                        }
                    },
                    Alignment = {Horizontal = KnownHorizontalAlignment.Right, Vertical = KnownVerticalAlignment.Top}
                }
            };

            // Save style to disk
            logger.Info("      a) XML");
            var styleAsXmlResult = style.SaveToFile("~/Output/Sample04/Style");
            if (!styleAsXmlResult.Success)
            {
                logger.Info("         > Error while saving style as xml to disk");
                logger.Info($"         > Error: {styleAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved style as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Style.xml");
            }

            // New style instances from disk
            logger.Info("         > Try to creates a new instance of XML style from disk");
            var styleFromXml = XlsxCellStyle.LoadFromFile("~/Output/Sample04/Style.xml");
            logger.Info(styleFromXml == null
                ? "           > Error while loading style from xml file"
                : "           > Style loaded correctly from xml '~/Output/Sample04/Style.xml' file");

            // Save style to disk
            logger.Info("");
            logger.Info("      b) json");
            var styleAsJsonResult = style.SaveToFile("~/Output/Sample04/Style", KnownFileFormat.Json);
            if (!styleAsJsonResult.Success)
            {
                logger.Info("         > Error while saving style as json to disk");
                logger.Info($"          > Error: {styleAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved style as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Style.json");
            }

            //// New style instances from disk
            //logger.Info("         > Try to creates a new instance of json style from disk");
            //var styleFromJson = XlsxCellStyle.LoadFromFile("~/Output/Sample04/Style.json", KnownFileFormat.Json);
            //logger.Info(styleFromJson == null
            //    ? "           > Error while loading style from json file"
            //    : "           > Style loaded correctly from json '~/Output/Sample04/Style.json' file");

            #endregion

            #region mini-chart

            logger.Info("");
            logger.Info("   3) Working with mini-charts");

            var minichart = new XlsxMiniChart
            {
                Name = "MiniChart1",
                EmptyValueAs = MiniChartEmptyValuesAs.Gap,
                ChartAxes =
                {
                    Horizontal = {Type = MiniChartHorizontalAxisType.Date}
                },
                ChartSize =
                {
                    VerticalCells = 3,
                    HorizontalCells = 3
                },
                ChartRanges =
                {
                    Axis = new XlsxRange {Start = {Column = 2, Row = 3}, End = {Column = 2, Row = 32}}, // B3:B32
                    Data = new XlsxStringRange {Address = "C3:C32"}
                },
                ChartType =
                {
                    Active = MiniChartType.Line,
                    Column =
                    {
                        Serie = {Color = "#FF5733"},
                        Points =
                        {
                            First = {Color = "Yellow"},
                            Last = {Color = "Black"},
                            High = {Color = "Blue"},
                            Low = {Color = "Green"},
                            Negative = {Color = "Red"}
                        }
                    },
                    Line =
                    {
                        Serie = {Color = "#FF5733"},
                        Points =
                        {
                            First = {Color = "Yellow"},
                            Last = {Color = "Black"},
                            High = {Color = "Blue"},
                            Low = {Color = "Green"},
                            Negative = {Color = "Red"}
                        }
                    },
                    WinLoss =
                    {
                        Serie = {Color = "#FF5733"},
                        Points =
                        {
                            First = {Color = "Yellow"},
                            Last = {Color = "Black"},
                            High = {Color = "Blue"},
                            Low = {Color = "Green"},
                            Negative = {Color = "Red"}
                        }
                    }
                }
            };

            // Save minichart to disk
            logger.Info("      a) XML");
            var minichartAsXmlResult = minichart.SaveToFile("~/Output/Sample04/MiniChart");
            if (!minichartAsXmlResult.Success)
            {
                logger.Info("         > Error while saving mini-chart as xml to disk");
                logger.Info($"         > Error: {minichartAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved mini-chart as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/MiniChart.xml");
            }

            // New minichart instances from disk
            logger.Info("         > Try to creates a new instance of XML mini-chart from disk");
            var minichartFromXml = (XlsxMiniChart)XlsxMiniChart.LoadFromFile("~/Output/Sample04/MiniChart.xml");
            logger.Info(minichartFromXml == null
                ? "           > Error while loading mini-chart from xml file"
                : "           > Mini-chart loaded correctly from xml '~/Output/Sample04/MiniChart.xml' file");

            // Save minichart to disk
            logger.Info("");
            logger.Info("      b) json");
            var minichartAsJsonResult = minichart.SaveToFile("~/Output/Sample04/MiniChart", KnownFileFormat.Json);
            if (!minichartAsJsonResult.Success)
            {
                logger.Info("         > Error while saving mini-chart as json to disk");
                logger.Info($"          > Error: {minichartAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved mini-chart as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/MiniChart.json");
            }

            // New minichart instances from disk
            logger.Info("         > Try to creates a new instance of json mini-chart from disk");
            var minichartFromJson = (XlsxMiniChart)XlsxMiniChart.LoadFromFile("~/Output/Sample04/MiniChart.json", KnownFileFormat.Json);
            logger.Info(minichartFromJson == null
                ? "           > Error while loading mini-chart from json file"
                : "           > Mini-chart loaded correctly from json '~/Output/Sample04/MiniChart.json' file");

            #endregion

            #region picture

            logger.Info("");
            logger.Info("   4) Working with pictures");

            var picture = new XlsxPicture
            {
                Show = YesNo.Yes,
                Name = "image",
                Path = "~/Resources/Sample-07/image-1.jpg",
                Size = new XlsxSize
                {
                    Width = 300,
                    Height = 300
                },
                Effects =
                {
                    new XlsxDarkEffect(),
                    new XlsxDisabledEffect(),
                    new XlsxOpacityEffect {Value = 50.0f}
                },
                Border =
                {
                    Width = 4,
                    Color = "Green",
                    Show = YesNo.Yes,
                    Transparency = 50,
                    Style = KnownLineStyle.DashDot
                },
                Content =
                {
                    Color = "Blue",
                    Show = YesNo.Yes,
                    Transparency = 50,
                },
                ShapeEffects =
                {
                    Shadow = new XlsxOuterShadow
                    {
                        Offset = 2,
                        Color = "Yellow",
                        Show = YesNo.Yes,
                    }
                }
            };

            // Save picture to disk
            logger.Info("      a) XML");
            var pictureAsXmlResult = picture.SaveToFile("~/Output/Sample04/Picture");
            if (!pictureAsXmlResult.Success)
            {
                logger.Info("         > Error while saving picture as xml to disk");
                logger.Info($"         > Error: {pictureAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved picture as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Picture.xml");
            }

            // New picture instances from disk
            logger.Info("         > Try to creates a new instance of XML picture from disk");
            var pictureFromXml = XlsxPicture.LoadFromFile("~/Output/Sample04/Picture.xml");
            logger.Info(pictureFromXml == null
                ? "           > Error while loading picture from xml file"
                : "           > Picture loaded correctly from xml '~/Output/Sample04/Picture.xml' file");

            // Save picture to disk
            logger.Info("");
            logger.Info("      b) json");
            var pictureAsJsonResult = picture.SaveToFile("~/Output/Sample04/Picture", KnownFileFormat.Json);
            if (!pictureAsJsonResult.Success)
            {
                logger.Info("         > Error while saving picture as json to disk");
                logger.Info($"          > Error: {minichartAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved picture as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Picture.json");
            }

            // New picture instances from disk
            logger.Info("         > Try to creates a new instance of json picture from disk");
            var pictureFromJson = XlsxPicture.LoadFromFile("~/Output/Sample04/Picture.json", KnownFileFormat.Json);
            logger.Info(pictureFromJson == null
                ? "           > Error while loading picture from json file"
                : "           > Picture loaded correctly from json '~/Output/Sample04/Picture.json' file");

            #endregion

            #region shape

            logger.Info("");
            logger.Info("   5) Working with shapes");

            var shape = new XlsxShape
            {
                Show = YesNo.Yes,
                Name = "shape",
                ShapeType = ShapeType.Rect,
                Size =
                {
                    Width = 300,
                    Height = 300
                },
                Border =
                {
                    Width = 2,
                    Color = "Yellow",
                    Show = YesNo.Yes,
                    Transparency = 50,
                    Style = KnownLineStyle.DashDot
                },
                Content =
                {
                    Text = "Text",
                    Show = YesNo.Yes,
                    Color = "Yellow",
                    Font =
                    {
                        Color = "Red",
                        Bold = YesNo.Yes,
                    },
                    Alignment =
                    {
                        Horizontal = KnownHorizontalAlignment.Center
                    }
                },
                ShapeEffects =
                {
                    Shadow = new XlsxOuterShadow
                    {
                        Offset = 2,
                        Color = "Yellow",
                        Show = YesNo.Yes,
                    }
                }
            };

            // Save shape to disk
            logger.Info("      a) XML");
            var shapeAsXmlResult = shape.SaveToFile("~/Output/Sample04/Shape");
            if (!shapeAsXmlResult.Success)
            {
                logger.Info("         > Error while saving shape as xml to disk");
                logger.Info($"         > Error: {shapeAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved shape as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Shape.xml");
            }

            // New shape instances from disk
            logger.Info("         > Try to creates a new instance of XML shape from disk");
            var shapeFromXml = XlsxShape.LoadFromFile("~/Output/Sample04/Shape.xml");
            logger.Info(shapeFromXml == null
                ? "           > Error while loading shape from xml file"
                : "           > Shape loaded correctly from xml '~/Output/Sample04/Shape.xml' file");

            // Save shape to disk
            logger.Info("");
            logger.Info("      b) json");
            var shapeAsJsonResult = shape.SaveToFile("~/Output/Sample04/Shape", KnownFileFormat.Json);
            if (!shapeAsJsonResult.Success)
            {
                logger.Info("         > Error while saving shape as json to disk");
                logger.Info($"          > Error: {shapeAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved shape as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Shape.json");
            }

            // New shape instances from disk
            logger.Info("         > Try to creates a new instance of json shape from disk");
            var shapeFromJson = XlsxShape.LoadFromFile("~/Output/Sample04/Shape.json", KnownFileFormat.Json);
            logger.Info(shapeFromJson == null
                ? "           > Error while loading shape from json file"
                : "           > Shape loaded correctly from json '~/Output/Sample04/Shape.json' file");

            #endregion

            #region chart

            logger.Info("");
            logger.Info("   6) Working with charts");

            var chart = new XlsxChart
            {
                Name = "chart1",
                Size = {Width = 800, Height = 600},
                Axes = {Primary = {Values = {GridLines = GridLine.Major}}},
                Legend =
                {
                    Show = YesNo.Yes,
                    Font = {Bold = YesNo.Yes},
                    Border = {Show = YesNo.Yes},
                    Location = LegendLocation.TopRight
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
            };

            // Save chart to disk
            logger.Info("      a) XML");
            var chartAsXmlResult = chart.SaveToFile("~/Output/Sample04/Chart");
            if (!chartAsXmlResult.Success)
            {
                logger.Info("         > Error while saving chart as xml to disk");
                logger.Info($"         > Error: {minichartAsXmlResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved chart as xml to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Chart.xml");
            }

            // New chart instances from disk
            logger.Info("         > Try to creates a new instance of XML chart from disk");
            var chartFromXml = (XlsxChart)XlsxChart.LoadFromFile("~/Output/Sample04/Chart.xml");
            logger.Info(chartFromXml == null
                ? "           > Error while loading chart from xml file"
                : "           > Chart loaded correctly from xml '~/Output/Sample04/Chart.xml' file");

            // Save chart to disk
            logger.Info("");
            logger.Info("      b) json");
            var chartAsJsonResult = chart.SaveToFile("~/Output/Sample04/Chart", KnownFileFormat.Json);
            if (!chartAsJsonResult.Success)
            {
                logger.Info("         > Error while saving chart as json to disk");
                logger.Info($"          > Error: {chartAsJsonResult.Errors.AsMessages().ToStringBuilder()}");
            }
            else
            {
                logger.Info("         > Saved chart as json to disk correctly");
                logger.Info("           > Path: ~/Output/Sample04/Chart.json");
            }

            // New minichart instances from disk
            logger.Info("         > Try to creates a new instance of json chart from disk");
            var chartFromJson = (XlsxChart)XlsxChart.LoadFromFile("~/Output/Sample04/Chart.json", KnownFileFormat.Json);
            logger.Info(chartFromJson == null
                ? "           > Error while loading chart from json file"
                : "           > Chart loaded correctly from json '~/Output/Sample04/Chart.json' file");

            #endregion
        }
    }
}
