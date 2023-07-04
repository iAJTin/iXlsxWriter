
using System.ComponentModel;
using System.Globalization;
using System.Xml;

using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;

using iTin.Core;
using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Charts;

namespace OfficeOpenXml.Helpers;

/// <summary>
/// Static class than contains common extension methods for objects of the namespace <see cref="N:OfficeOpenXml.Drawing.Chart"/>.
/// </summary>
internal static class OfficeOpenChartExtensions
{
    /// <summary>
    /// Fills a <see cref="ExcelChartAxis"/> object with model data. 
    /// </summary>
    /// <param name="axis"><see cref="ExcelChartAxis"/> object.</param>
    /// <param name="axisNodeAsXml"><b>XML</b> node than represent an axis definition.</param>
    /// <param name="model">Axis model definition.</param>
    /// <param name="documentHelper">Target xml document helper.</param>
    public static void SetAxis(this ExcelChartAxis axis, XmlNode axisNodeAsXml, XlsxChartAxisDefinition model, IXmlHelper documentHelper)
    {
        if (model.Values.HasMaximumValue)
        {
            axis.MaxValue = double.Parse(model.Values.Maximum, CultureInfo.InvariantCulture);
        }

        if (model.Values.HasMinimumValue)
        {
            axis.MinValue = double.Parse(model.Values.Minimum, CultureInfo.InvariantCulture);
        }

        axis.MajorTickMark = model.Marks.Major.AsEnumType<eAxisTickMark>();
        axis.MinorTickMark = model.Marks.Minor.AsEnumType<eAxisTickMark>();
        axis.LabelPosition = model.Labels.Position.AsEnumType<eTickLabelPosition>();
        axis.TickLabelPosition = model.Labels.Position.AsEnumType<eTickLabelPosition>();

        axisNodeAsXml.AddAxisGridLinesMode(model.GridLines, documentHelper);
        axisNodeAsXml.AddAxisLabelProperties(model.Labels, documentHelper);
        axisNodeAsXml.AddAxisLabelAlignment(model.Labels.Alignment, documentHelper);
        axisNodeAsXml.ModifyAxisCrosses(documentHelper);

        var axisType = axisNodeAsXml.ExtractAxisType(documentHelper);
        //axis.Title.SetTitle(.FormatFromModel(axisType.ToKnownChartElement(), model.Title);
    }

    /// <summary>
    /// Converter for <see cref="KnownAxisType"/> enumeration type to <see cref="KnownChartElement"/> enumeration.
    /// </summary>
    /// <param name="type">Axis type to converter.</param>
    /// <returns>
    /// A enumeration value than represents axis type.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static KnownChartElement ToKnownChartElement(this KnownAxisType type)
    {
        SentinelHelper.IsEnumValid(type);

        return type switch
        {
            KnownAxisType.PrimaryValueAxis => KnownChartElement.PrimaryValueAxisTitle,
            KnownAxisType.SecondaryCategoryAxis => KnownChartElement.SecondaryCategoryAxisTitle,
            KnownAxisType.SecondaryValueAxis => KnownChartElement.SecondaryValueAxisTitle,
            _ => KnownChartElement.PrimaryCategoryAxisTitle
        };
    }

    /// <summary>
    /// Converter for <see cref="ChartType"/> enumeration type to <see cref="eChartType"/>.
    /// </summary>
    /// <param name="chartType">Chart type.</param>
    /// <returns>
    /// A <see cref="eChartType"/> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eChartType ToEppChartType(this ChartType chartType)
    {
        SentinelHelper.IsEnumValid(chartType);

        return chartType switch
        {
            ChartType.XYScatter => eChartType.XYScatter,
            ChartType.Radar => eChartType.Radar,
            ChartType.Doughnut => eChartType.Doughnut,
            ChartType.Pie3D => eChartType.Pie3D,
            ChartType.Line3D => eChartType.Line3D,
            ChartType.Column3D => eChartType.Column3D,
            ChartType.Area3D => eChartType.Area3D,
            ChartType.Area => eChartType.Area,
            ChartType.Line => eChartType.Line,
            ChartType.Pie => eChartType.Pie,
            ChartType.Bubble => eChartType.Bubble,
            ChartType.ColumnClustered => eChartType.ColumnClustered,
            ChartType.ColumnStacked => eChartType.ColumnStacked,
            ChartType.ColumnStacked100 => eChartType.ColumnStacked100,
            ChartType.ColumnClustered3D => eChartType.ColumnClustered3D,
            ChartType.ColumnStacked3D => eChartType.ColumnStacked3D,
            ChartType.ColumnStacked1003D => eChartType.ColumnStacked1003D,
            ChartType.BarClustered => eChartType.BarClustered,
            ChartType.BarStacked => eChartType.BarStacked,
            ChartType.BarStacked100 => eChartType.BarStacked100,
            ChartType.BarClustered3D => eChartType.BarClustered3D,
            ChartType.BarStacked3D => eChartType.BarStacked3D,
            ChartType.BarStacked1003D => eChartType.BarStacked1003D,
            ChartType.LineStacked => eChartType.LineStacked,
            ChartType.LineStacked100 => eChartType.LineStacked100,
            ChartType.LineMarkers => eChartType.LineMarkers,
            ChartType.LineMarkersStacked => eChartType.LineMarkersStacked,
            ChartType.LineMarkersStacked100 => eChartType.LineMarkersStacked100,
            ChartType.PieOfPie => eChartType.PieOfPie,
            ChartType.PieExploded => eChartType.PieExploded,
            ChartType.PieExploded3D => eChartType.PieExploded3D,
            ChartType.BarOfPie => eChartType.BarOfPie,
            ChartType.XYScatterSmooth => eChartType.XYScatterSmooth,
            ChartType.XYScatterSmoothNoMarkers => eChartType.XYScatterSmoothNoMarkers,
            ChartType.XYScatterLines => eChartType.XYScatterSmoothNoMarkers,
            ChartType.XYScatterLinesNoMarkers => eChartType.XYScatterSmoothNoMarkers,
            ChartType.AreaStacked => eChartType.AreaStacked,
            ChartType.AreaStacked100 => eChartType.AreaStacked100,
            ChartType.AreaStacked3D => eChartType.AreaStacked3D,
            ChartType.AreaStacked1003D => eChartType.AreaStacked1003D,
            ChartType.DoughnutExploded => eChartType.DoughnutExploded,
            ChartType.RadarMarkers => eChartType.RadarMarkers,
            ChartType.RadarFilled => eChartType.RadarFilled,
            ChartType.Surface => eChartType.Surface,
            ChartType.SurfaceWireframe => eChartType.SurfaceWireframe,
            ChartType.SurfaceTopView => eChartType.SurfaceTopView,
            ChartType.SurfaceTopViewWireframe => eChartType.SurfaceTopViewWireframe,
            ChartType.Bubble3DEffect => eChartType.Bubble3DEffect,
            ChartType.StockHLC => eChartType.StockHLC,
            ChartType.StockOHLC => eChartType.StockOHLC,
            ChartType.StockVHLC => eChartType.StockVHLC,
            ChartType.StockVOHLC => eChartType.StockVOHLC,
            ChartType.CylinderColClustered => eChartType.CylinderColClustered,
            ChartType.CylinderColStacked => eChartType.CylinderColStacked,
            ChartType.CylinderColStacked100 => eChartType.CylinderColStacked100,
            ChartType.CylinderBarClustered => eChartType.CylinderBarClustered,
            ChartType.CylinderBarStacked => eChartType.CylinderBarStacked,
            ChartType.CylinderBarStacked100 => eChartType.CylinderBarStacked100,
            ChartType.CylinderCol => eChartType.CylinderCol,
            ChartType.ConeColClustered => eChartType.ConeColClustered,
            ChartType.ConeColStacked => eChartType.ConeColStacked,
            ChartType.ConeColStacked100 => eChartType.ConeColStacked100,
            ChartType.ConeBarClustered => eChartType.ConeBarClustered,
            ChartType.ConeBarStacked => eChartType.ConeBarStacked,
            ChartType.ConeBarStacked100 => eChartType.ConeBarStacked100,
            ChartType.ConeCol => eChartType.ConeCol,
            ChartType.PyramidColClustered => eChartType.PyramidColClustered,
            ChartType.PyramidColStacked => eChartType.PyramidColStacked,
            ChartType.PyramidColStacked100 => eChartType.PyramidColStacked100,
            ChartType.PyramidBarClustered => eChartType.PyramidBarClustered,
            ChartType.PyramidBarStacked => eChartType.PyramidBarStacked,
            ChartType.PyramidBarStacked100 => eChartType.PyramidBarStacked100,
            ChartType.PyramidCol => eChartType.PyramidCol,
            _ => eChartType.Line
        };
    }
}
