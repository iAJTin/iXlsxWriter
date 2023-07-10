
using System;
using System.IO;

using OfficeOpenXml;
using OfficeOpenXml.Sparkline;

using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a <see cref="XlsxMiniChart"/>.
/// </summary>
public class InsertMiniChart : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertMiniChart"/> class.
    /// </summary>
    public InsertMiniChart()
    {
        SheetName = string.Empty;
        Location = new XlsxStringRange { Address = "A1:A1" };
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to minichart configuration.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxMiniChart"/> reference to minichart configuration.
    /// </value>
    public XlsxMiniChart MiniChart { get; set; }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when insert action.
    /// </summary>
    /// <param name="context">Input context</param>
    /// <param name="input"></param>
    /// <param name="package"></param>
    /// <param name="worksheet"></param>
    /// <returns>
    /// <para>
    /// A <see cref="ActionResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="ActionResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public override ActionResult Execute(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet)
    {
        if (string.IsNullOrEmpty(SheetName))
        {
            return ActionResult.CreateErrorResult(
                "Sheet name can not be null or empty",
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }

        if (Location == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (MiniChart == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (MiniChart.Show == YesNo.No)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, MiniChart);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, XlsxMiniChart miniChart)
    {
        var outputStream = new MemoryStream();

        try
        {
            // Create Minichart
            var locationAddress = location.ToEppExcelAddress();
            var dataddress = miniChart.ChartRanges.Data.ToEppExcelAddress();

            var sparkline = worksheet.SparklineGroups.Add(miniChart.ChartType.Active.ToEppeSparklineType(), worksheet.Cells[locationAddress.ToString()], worksheet.Cells[dataddress.ToString()]);
            sparkline.DisplayHidden = miniChart.DisplayHidden == YesNo.Yes;
            sparkline.ColorSeries.SetColor(miniChart.ChartType.GetMiniChartSerieColor());
            sparkline.DisplayEmptyCellsAs = miniChart.EmptyValueAs.ToEppeDisplayBlanksAs();

            // Minichart Size
            int offsetY = miniChart.ChartSize.VerticalCells == 1 ? 0 : miniChart.ChartSize.VerticalCells - 1;
            int offsetX = miniChart.ChartSize.HorizontalCells == 1 ? 0 : miniChart.ChartSize.HorizontalCells - 1;
            var miniChartSizeAddress = location.Expand(miniChart.ChartSize);
            var miniChartCell = worksheet.Cells[miniChartSizeAddress.ToString()];
            if (offsetX >= 1 || offsetY >= 1)
            {
                miniChartCell.Merge = true;
            }

            // Axes
            // Horizontal axis
            sparkline.DateAxisRange = null;
            if (miniChart.ChartAxes.Horizontal.Type == MiniChartHorizontalAxisType.Date)
            {
                var axisRangeType = miniChart.ChartRanges.Axis.ToEppExcelAddress();
                sparkline.DateAxisRange = worksheet.Cells[axisRangeType.ToString()];
            }

            sparkline.RightToLeft = miniChart.ChartAxes.Horizontal.RightToLeft == YesNo.Yes;
            if (miniChart.ChartAxes.Horizontal.Show == YesNo.Yes)
            {
                sparkline.DisplayXAxis = true;
                sparkline.ColorAxis.SetColor(miniChart.ChartAxes.Horizontal.GetColor());
            }

            // Vertical axis
            bool maxVerticalAxisIsAuto = string.IsNullOrEmpty(miniChart.ChartAxes.Vertical.Max) || miniChart.ChartAxes.Vertical.Max.Equals("Automatic", StringComparison.OrdinalIgnoreCase);
            sparkline.MaxAxisType = maxVerticalAxisIsAuto
                ? eSparklineAxisMinMax.Individual
                : eSparklineAxisMinMax.Custom;

            bool minVerticalAxisIsAuto = string.IsNullOrEmpty(miniChart.ChartAxes.Vertical.Min) || miniChart.ChartAxes.Vertical.Min.Equals("Automatic", StringComparison.OrdinalIgnoreCase);
            sparkline.MinAxisType = minVerticalAxisIsAuto
                ? eSparklineAxisMinMax.Individual
                : eSparklineAxisMinMax.Custom;

            if (!maxVerticalAxisIsAuto)
            {
                sparkline.ManualMax = double.Parse(miniChart.ChartAxes.Vertical.Max);
            }

            if (!minVerticalAxisIsAuto)
            {
                sparkline.ManualMin = double.Parse(miniChart.ChartAxes.Vertical.Min);
            }

            // Points
            switch (miniChart.ChartType.Active)
            {
                case MiniChartType.Column:
                    if (!miniChart.ChartType.Column.Points.Low.IsDefault)
                    {
                        sparkline.Low = true;
                        sparkline.ColorLow.SetColor(miniChart.ChartType.Column.Points.Low.GetColor());
                    }

                    if (!miniChart.ChartType.Column.Points.First.IsDefault)
                    {
                        sparkline.First = true;
                        sparkline.ColorFirst.SetColor(miniChart.ChartType.Column.Points.First.GetColor());
                    }

                    if (!miniChart.ChartType.Column.Points.High.IsDefault)
                    {
                        sparkline.High = true;
                        sparkline.ColorHigh.SetColor(miniChart.ChartType.Column.Points.High.GetColor());
                    }

                    if (!miniChart.ChartType.Column.Points.Last.IsDefault)
                    {
                        sparkline.Last = true;
                        sparkline.ColorLast.SetColor(miniChart.ChartType.Column.Points.Last.GetColor());
                    }

                    if (!miniChart.ChartType.Column.Points.Negative.IsDefault)
                    {
                        sparkline.Negative = true;
                        sparkline.ColorNegative.SetColor(miniChart.ChartType.Column.Points.Negative.GetColor());
                    }

                    break;

                case MiniChartType.Line:
                    sparkline.LineWidth = double.Parse(miniChart.ChartType.Line.Serie.Width);

                    if (!miniChart.ChartType.Line.Points.Low.IsDefault)
                    {
                        sparkline.Low = true;
                        sparkline.ColorLow.SetColor(miniChart.ChartType.Line.Points.Low.GetColor());
                    }

                    if (!miniChart.ChartType.Line.Points.First.IsDefault)
                    {
                        sparkline.First = true;
                        sparkline.ColorFirst.SetColor(miniChart.ChartType.Line.Points.First.GetColor());
                    }

                    if (!miniChart.ChartType.Line.Points.High.IsDefault)
                    {
                        sparkline.High = true;
                        sparkline.ColorHigh.SetColor(miniChart.ChartType.Line.Points.High.GetColor());
                    }

                    if (!miniChart.ChartType.Line.Points.Last.IsDefault)
                    {
                        sparkline.Last = true;
                        sparkline.ColorLast.SetColor(miniChart.ChartType.Line.Points.Last.GetColor());
                    }

                    if (!miniChart.ChartType.Line.Points.Negative.IsDefault)
                    {
                        sparkline.Negative = true;
                        sparkline.ColorNegative.SetColor(
                            miniChart.ChartType.Line.Points.Negative.GetColor());
                    }

                    if (!miniChart.ChartType.Line.Points.Markers.IsDefault)
                    {
                        sparkline.Markers = true;
                        sparkline.ColorNegative.SetColor(miniChart.ChartType.Line.Points.Markers.GetColor());
                    }

                    break;

                case MiniChartType.WinLoss:
                    if (!miniChart.ChartType.WinLoss.Points.Low.IsDefault)
                    {
                        sparkline.Low = true;
                        sparkline.ColorLow.SetColor(miniChart.ChartType.WinLoss.Points.Low.GetColor());
                    }

                    if (!miniChart.ChartType.WinLoss.Points.First.IsDefault)
                    {
                        sparkline.First = true;
                        sparkline.ColorFirst.SetColor(miniChart.ChartType.WinLoss.Points.First.GetColor());
                    }

                    if (!miniChart.ChartType.WinLoss.Points.High.IsDefault)
                    {
                        sparkline.High = true;
                        sparkline.ColorHigh.SetColor(miniChart.ChartType.WinLoss.Points.High.GetColor());
                    }

                    if (!miniChart.ChartType.WinLoss.Points.Last.IsDefault)
                    {
                        sparkline.Last = true;
                        sparkline.ColorLast.SetColor(miniChart.ChartType.WinLoss.Points.Last.GetColor());
                    }

                    if (!miniChart.ChartType.WinLoss.Points.Negative.IsDefault)
                    {
                        sparkline.Negative = true;
                        sparkline.ColorNegative.SetColor(miniChart.ChartType.WinLoss.Points.Negative.GetColor());
                    }

                    break;
            }

            package.SaveAs(outputStream);

            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = outputStream
            });
        }
        catch (Exception ex)
        {
            return ActionResult.FromException(
                ex,
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }

    #endregion
}
