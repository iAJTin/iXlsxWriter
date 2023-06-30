
namespace iXlsxWriter.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using iTin.Core.ComponentModel;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Charts;
    using iTin.Utilities.Xlsx.Design.Shared;
    using iTin.Utilities.Xlsx.Design.Styles;

    using iTin.Utilities.Xlsx.Writer;
    using iXlsxWriter.ComponentModel;
    using iXlsxWriter.ComponentModel.Result.Action.Save;

    using ComponentModel;
    using ComponentModel.Models;

    /// <summary>
    /// Shows the use of how insert an autofilter.
    /// </summary>
    internal class Sample05
    {
        // Cell styles
        private static readonly Dictionary<string, XlsxCellStyle> CellStylesTable = new Dictionary<string, XlsxCellStyle>
        {
            {
                "ReportTitle",
                new XlsxCellStyle
                {
                    Font =
                    {
                        Size = 28.0f,
                        Bold = YesNo.Yes,
                    },
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes,
                            Position = KnownBorderPosition.Bottom
                        }
                    },
                    Content =
                    {
                        Merge =
                        {
                            Cells = 2
                        },
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Left
                        }
                    }
                }
            },
            {
                "SummaryLabel",
                new XlsxCellStyle
                {
                    Font =
                    {
                        Bold = YesNo.Yes,
                    },
                    Content =
                    {
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Left
                        }
                    }
                }
            },
            {
                "SummaryValue",
                new XlsxCellStyle
                {
                    Content =
                    {
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Left
                        }
                    }
                }
            },
            {
                "ParameterValue",
                new XlsxCellStyle
                {
                    Content =
                    {
                        DataType = new NumberDataType
                        {
                            Decimals = 1,
                            Separator = YesNo.Yes
                        },
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Center
                        }
                    }
                }
            },
            {
                "LocalHeader",
                new XlsxCellStyle
                {
                    Font =
                    {
                        Color = "White",
                        Bold = YesNo.Yes,
                    },
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Color = "Black",
                            Show = YesNo.Yes,
                            Position = KnownBorderPosition.Bottom
                        }
                    },
                    Content =
                    {
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Center
                        }
                    }
                }
            }
        };



        // Generates document
        public static void Generate(ILogger logger)
        {
            #region Retrieve report data

            //Informe reportData = BuildAverageByDaysReportData("EN");
            Informe reportData = BuildAverageByDaysReportData("ES");

            //Informe reportData = BuildSumByDaysReportData("EN");
            //Informe reportData = BuildSumByDaysReportData("ES");

            //Informe reportData = BuildAverageByMonthsReportData("EN");
            //Informe reportData = BuildAverageByMonthsReportData("ES");

            //Informe reportData = BuildSumByMonthsReportData("EN");
            //Informe reportData = BuildSumByMonthsReportData("ES");

            #endregion

            #region Add dynamic xlsx styles

            CellStylesTable.Add(
                "ShortDateValue",
                new XlsxCellStyle
                {
                    Font =
                    {
                        Bold = YesNo.Yes,
                    },
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes,
                            Position = KnownBorderPosition.Right
                        }
                    },
                    Content =
                    {
                        DataType = new DateTimeDataType
                        {
                            Locale = (KnownCulture)EnumHelper.CreateEnumTypeFromDescriptionAttribute<KnownCulture>(reportData.ConfiguracionInforme.IdiomaInforme)
                        },
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Right
                        }
                    }
                });

            // Add dynamic xlsx styles
            CellStylesTable.Add(
                "MonthYearDateValue",
                new XlsxCellStyle
                {
                    Font =
                    {
                        Bold = YesNo.Yes,
                    },
                    Borders =
                    {
                        new XlsxStyleBorder
                        {
                            Show = YesNo.Yes,
                            Position = KnownBorderPosition.Right
                        }
                    },
                    Content =
                    {
                        DataType = new DateTimeDataType
                        {
                            Format = KnownDateTimeFormat.YearMonthShortPattern,
                            Locale = (KnownCulture)EnumHelper.CreateEnumTypeFromDescriptionAttribute<KnownCulture>(reportData.ConfiguracionInforme.IdiomaInforme),
                        },
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Right
                        }
                    }
                });

            CellStylesTable.Add(
                "SummaryDateValue",
                new XlsxCellStyle
                {
                    Content =
                    {
                        DataType = new DateTimeDataType
                        {
                            Locale = (KnownCulture) EnumHelper.CreateEnumTypeFromDescriptionAttribute<KnownCulture>(reportData.ConfiguracionInforme.IdiomaInforme)
                        },
                        Alignment =
                        {
                            Horizontal = KnownHorizontalAlignment.Left
                        }
                    }
                });

            #endregion

            #region Defines custom styles to use

            XlsxCellStyle dateAxisStyle =
                reportData.ConfiguracionInforme.ValoresPor.Equals("DIA", StringComparison.OrdinalIgnoreCase)
                    ? CellStylesTable["ShortDateValue"]
                    : CellStylesTable["MonthYearDateValue"];

            #endregion

            #region Defines localized literals

            bool isSpanishLanguage = reportData.ConfiguracionInforme.IdiomaInforme.Equals("ES", StringComparison.OrdinalIgnoreCase);

            #region Summary Sheet

            string summarySheetName = "Hoja1";
            if (!isSpanishLanguage)
            {
                summarySheetName = "Sheet1";
            }

            string summaryParameterLiteral = "Parámetro";
            if (!isSpanishLanguage)
            {
                summaryParameterLiteral = "Parameter";
            }

            string summaryTypeLiteral = "Tipo";
            if (!isSpanishLanguage)
            {
                summaryTypeLiteral = "Type";
            }

            string summaryValuesByLiteral = "Valores Por";
            if (!isSpanishLanguage)
            {
                summaryValuesByLiteral = "Values By";
            }

            string summaryInitialDateLiteral = "Fecha Inicio";
            if (!isSpanishLanguage)
            {
                summaryInitialDateLiteral = "Initial Date";
            }

            string summaryEndDateLiteral = "Fecha Fin";
            if (!isSpanishLanguage)
            {
                summaryEndDateLiteral = "End Date";
            }

            #endregion

            #region Rawdata Sheet

            string rawDataSheetName = "Hoja2";
            if (!isSpanishLanguage)
            {
                rawDataSheetName = "Sheet2";
            }

            string averageLiteral = "Media";
            if (!isSpanishLanguage)
            {
                averageLiteral = "Average";
            }

            string sumLiteral = "Suma";
            if (!isSpanishLanguage)
            {
                sumLiteral = "Sum";
            }

            #endregion

            #endregion

            #region Report type to generate

            bool generateSumReport = reportData.ConfiguracionInforme.Tipo.Equals("SUMA", StringComparison.OrdinalIgnoreCase);

            #endregion

            #region Determines locals to include in report

            IEnumerable<Local> localsToPrint = generateSumReport
                ? reportData.Locales.Where(local => local.Nombre.Equals("Suma", StringComparison.OrdinalIgnoreCase))
                : reportData.Locales;

            #endregion

            #region Creates xlsx file reference

            XlsxInput doc = XlsxInput.Create(new[] { summarySheetName, rawDataSheetName });

            #endregion

            #region Sheet 1

            #region Sheet 1 > Populates configuration data

            doc.Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["ReportTitle"],
                Location = new XlsxPointRange {Column = 2, Row = 1},
                Data = reportData.ConfiguracionInforme.TituloInforme
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryLabel"],
                Location = new XlsxPointRange {Column = 2, Row = 3},
                Data = summaryParameterLiteral
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryValue"],
                Location = new XlsxPointRange {Column = 3, Row = 3},
                Data = reportData.ConfiguracionInforme.Parametro
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryLabel"],
                Location = new XlsxPointRange {Column = 2, Row = 4},
                Data = summaryTypeLiteral
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryValue"],
                Location = new XlsxPointRange {Column = 3, Row = 4},
                Data = reportData.ConfiguracionInforme.Tipo
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryLabel"],
                Location = new XlsxPointRange {Column = 2, Row = 5},
                Data = summaryValuesByLiteral
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryValue"],
                Location = new XlsxPointRange {Column = 3, Row = 5},
                Data = reportData.ConfiguracionInforme.ValoresPor
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryLabel"],
                Location = new XlsxPointRange {Column = 2, Row = 6},
                Data = summaryInitialDateLiteral
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryDateValue"],
                Location = new XlsxPointRange {Column = 3, Row = 6},
                Data = reportData.ConfiguracionInforme.FechaInicioPeriodo
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryLabel"],
                Location = new XlsxPointRange {Column = 2, Row = 7},
                Data = summaryEndDateLiteral
            }).Insert(new InsertText
            {
                SheetName = summarySheetName,
                Style = CellStylesTable["SummaryDateValue"],
                Location = new XlsxPointRange {Column = 3, Row = 7},
                Data = reportData.ConfiguracionInforme.FechaFinPeriodo
            });

            #endregion

            #endregion

            #region Sheet 2

            #region Sheet 2 > Populates data table

            var localId = -1;
            var headerLocation = new XlsxPointRange {Column = 3, Row = 2};
            var dateAxisLocation = new XlsxPointRange {Column = 2, Row = 3};
            var parameterValueLocation = new XlsxPointRange {Column = 3, Row = 3};
            var localHeaderStyle = CellStylesTable["LocalHeader"];
            foreach (var local in localsToPrint)
            {
                // Defines local header text
                string localName = local.Nombre;
                if (localName.Equals("Suma", StringComparison.OrdinalIgnoreCase))
                {
                    localName = sumLiteral;
                }
                else if (localName.Equals("Media", StringComparison.OrdinalIgnoreCase))
                {
                    localName = averageLiteral;
                }

                // Defines local style
                localHeaderStyle.Name = $"LocalHeader{localId}";
                localHeaderStyle.Content.Color = local.Color;

                doc.Insert(new InsertText
                {
                    SheetName = rawDataSheetName,
                    Data = localName,
                    Location = headerLocation,
                    Style = localHeaderStyle
                });

                headerLocation.Offset(1, 0);

                localId++;
                var series = local.Series;
                foreach (var serie in series)
                {
                    if (localId == 0)
                    {
                        doc.Insert(new InsertText
                        {
                            SheetName = rawDataSheetName,
                            Data = serie.Fecha,
                            Location = dateAxisLocation,
                            Style = dateAxisStyle
                        });
                    }

                    doc.Insert(new InsertText
                    {
                        SheetName = rawDataSheetName,
                        Data = serie.Valor,
                        Location = parameterValueLocation,
                        Style = CellStylesTable["ParameterValue"]
                    });

                    dateAxisLocation.Offset(0, 1);
                    parameterValueLocation.Offset(0, 1);
                }

                parameterValueLocation = new XlsxPointRange {Column = parameterValueLocation.Column + 1, Row = 3};
            }

            #endregion

            #region Sheet 2 > Insert autofilter

            doc.Insert(new InsertAutoFilter
            {
                SheetName = rawDataSheetName,
                Location = new XlsxStringRange { Address = "C2:E2" }
            });
            
            #endregion

            #region Sheet 2 > Insert Mini-Charts

            doc.Insert(new InsertMiniChart
            {
                SheetName = rawDataSheetName,
                Location = new XlsxPointRange { Column = 3, Row = 33}, // B3:B33
                MiniChart = new XlsxMiniChart
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
                        Axis = new XlsxRange { Start = {Column = 2, Row = 3}, End = {Column = 2, Row = 32}}, //B3:B32
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
                }
            });

            #endregion

            #endregion

            #region Create output result

            var result = doc.CreateResult(new OutputResultConfig { AutoFitColumns = true });
            if (!result.Success)
            {
                logger.Info("   > Error creating output result");
                logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Saves output result

            var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample05/Sample-05" });
            if (!saveResult.Success)
            {
                logger.Info("   > Error while saving to disk");
                logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            logger.Info("   > Saved to disk correctly");
            logger.Info("     > Path: ~/Output/Sample05/Sample-05.xlsx");

            #endregion
        }



        // Build Average samples (DIA / MES)
        private static Informe BuildAverageByDaysReportData(string language) => new Informe
        {
            ConfiguracionInforme = new Configuracion
            {
                TituloInforme = "Informe test",
                ColorMedia = "#888888",
                FechaFinPeriodo = new DateTime(2020, 6, 30),
                FechaInicioPeriodo = new DateTime(2020, 6, 1),
                HacerMedia = true,
                IdiomaInforme = language,
                Parametro = "PARTEINCIDENCIA - Incidencias comunes > Número de incidentes",
                Tipo = "COMPARATIVA",
                ValoresPor = "DIA"
            },
            Locales = new List<Local>
            {
                new Local
                {
                    Color = "#FF5733",
                    Nombre = "Ocean beach ibiza",
                    Series = new List<Serie>
                    {
                        new Serie {Fecha = new DateTime(2020, 6, 1), Valor = "4"},
                        new Serie {Fecha = new DateTime(2020, 6, 2), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 3), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 4), Valor = "6"},
                        new Serie {Fecha = new DateTime(2020, 6, 5), Valor = "21"},
                        new Serie {Fecha = new DateTime(2020, 6, 6), Valor = "12"},
                        new Serie {Fecha = new DateTime(2020, 6, 7), Valor = "12"},
                        new Serie {Fecha = new DateTime(2020, 6, 8), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 9), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 10), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 11), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 12), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 13), Valor = "12"},
                        new Serie {Fecha = new DateTime(2020, 6, 14), Valor = "12"},
                        new Serie {Fecha = new DateTime(2020, 6, 15), Valor = "12"},
                        new Serie {Fecha = new DateTime(2020, 6, 16), Valor = "10"},
                        new Serie {Fecha = new DateTime(2020, 6, 17), Valor = "8"},
                        new Serie {Fecha = new DateTime(2020, 6, 18), Valor = "9"},
                        new Serie {Fecha = new DateTime(2020, 6, 19), Valor = "6"},
                        new Serie {Fecha = new DateTime(2020, 6, 20), Valor = "23"},
                        new Serie {Fecha = new DateTime(2020, 6, 21), Valor = "11"},
                        new Serie {Fecha = new DateTime(2020, 6, 22), Valor = "22"},
                        new Serie {Fecha = new DateTime(2020, 6, 23), Valor = "18"},
                        new Serie {Fecha = new DateTime(2020, 6, 24), Valor = "16"},
                        new Serie {Fecha = new DateTime(2020, 6, 25), Valor = "16"},
                        new Serie {Fecha = new DateTime(2020, 6, 26), Valor = "2"},
                        new Serie {Fecha = new DateTime(2020, 6, 27), Valor = "5"},
                        new Serie {Fecha = new DateTime(2020, 6, 28), Valor = "5"},
                        new Serie {Fecha = new DateTime(2020, 6, 29), Valor = "1"},
                        new Serie {Fecha = new DateTime(2020, 6, 30), Valor = "2"},
                    }
                },
                new Local
                {
                    Color = "#333CFF",
                    Nombre = "local 2",
                    Series = new List<Serie>
                    {
                        new Serie {Fecha = new DateTime(2020, 6, 1), Valor = "8"},
                        new Serie {Fecha = new DateTime(2020, 6, 2), Valor = "5"},
                        new Serie {Fecha = new DateTime(2020, 6, 3), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 4), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 5), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 6), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 7), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 8), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 9), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 10), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 11), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 12), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 13), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 14), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 15), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 16), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 17), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 18), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 19), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 20), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 21), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 22), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 23), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 24), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 25), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 26), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 27), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 28), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 29), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 30), Valor = null}
                    }
                },
                new Local
                {
                    Color = "#FF33DA",
                    Nombre = "Media",
                    Series = new List<Serie>
                    {
                        new Serie {Fecha = new DateTime(2020, 6, 1), Valor = "6"},
                        new Serie {Fecha = new DateTime(2020, 6, 2), Valor = "3.5"},
                        new Serie {Fecha = new DateTime(2020, 6, 3), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 4), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 5), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 6), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 7), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 8), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 9), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 10), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 11), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 12), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 13), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 14), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 15), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 16), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 17), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 18), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 19), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 20), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 21), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 22), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 23), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 24), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 25), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 26), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 27), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 28), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 29), Valor = null},
                        new Serie {Fecha = new DateTime(2020, 6, 30), Valor = null}
                    }
                }
            }
        };
    }
}
