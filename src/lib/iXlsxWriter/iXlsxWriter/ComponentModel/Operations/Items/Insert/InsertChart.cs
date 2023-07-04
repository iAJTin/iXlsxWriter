
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Helpers;

using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iXlsxWriter.ComponentModel.Result.Insert;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a <see cref="XlsxChart"/>.
/// </summary>
public class InsertChart : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertChart"/> class.
    /// </summary>
    public InsertChart()
    {
        SheetName = string.Empty;
        Location = new XlsxStringRange { Address = "A1:A1" };
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to chart configuration.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxChart"/> reference to chart configuration.
    /// </value>
    public XlsxChart Chart { get; set; }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when insert action.
    /// </summary>
    /// <param name="input">stream input</param>
    /// <param name="context">Input context</param>
    /// <returns>
    /// <para>
    /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    protected override InsertResult InsertImpl(Stream input, IInput context)
    {
        if (string.IsNullOrEmpty(SheetName))
        {
            return InsertResult.CreateErrorResult(
                "Sheet name can not be null or empty",
                new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }

        if (Location == null)
        {
            return InsertResult.CreateSuccessResult(new InsertResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (Chart == null)
        {
            return InsertResult.CreateSuccessResult(new InsertResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (Chart.Show == YesNo.No)
        {
            return InsertResult.CreateSuccessResult(new InsertResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return InsertImpl(context, input, SheetName, Location, Chart);
    }

    #endregion

    #region private static methods

    private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location, XlsxChart chart)
    {
        var outputStream = new MemoryStream();

        try
        {
            using var excel = new ExcelPackage(input);
            ExcelWorksheet ws = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
            if (ws == null)
            {
                return InsertResult.CreateErrorResult(
                    $"Sheet '{sheetName}' not found",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            // Create Chart
            ExcelChart mainchart = null;
            var plots = chart.Plots;
            foreach (var plot in plots)
            {
                var series = plot.Series;
                foreach (var serie in series)
                {
                    // Create chart
                    ExcelChart workchart;
                    if (plot.UseSecondaryAxis.Equals(YesNo.No))
                    {
                        if (mainchart == null)
                        {
                            mainchart = ws.Drawings.AddChart(serie.Name, serie.ChartType.ToEppChartType());
                            mainchart.Name = plot.Name;
                        }

                        workchart = mainchart;
                    }
                    else
                    {
                        workchart = mainchart.PlotArea.ChartTypes.Add(serie.ChartType.ToEppChartType());
                        workchart.UseSecondaryAxis = true;
                        workchart.XAxis.Deleted = false;
                    }

                    var sr = workchart.Series.Add(serie.FieldRange.ToString(), serie.AxisRange.ToString());
                    sr.Header = serie.Name;
                }
            }

            if (mainchart != null)
            {
                var writer = new OfficeOpenChartWriter(mainchart);
                writer.SetSize(chart.Size);
                writer.SetPosition(location);
                writer.SetContent(chart);
                writer.SetBorder(chart.Border);
                writer.SetTitle(chart.Title);
                writer.SetLegend(chart.Legend);
                writer.SetAxes(chart.Axes);
                writer.SetPlotArea(chart.Plots);
                writer.SetShapeEffects(chart.Effects);
            }

            excel.SaveAs(outputStream);

            return InsertResult.CreateSuccessResult(new InsertResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = outputStream
            });
        }
        catch (Exception ex)
        {
            return InsertResult.FromException(
                ex,
                new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }

    #endregion
}
