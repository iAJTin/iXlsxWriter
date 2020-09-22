
namespace OfficeOpenXml.Helpers
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Xml;

    using iTin.Core;
    using iTin.Core.Helpers;
    
    using iTin.Utilities.Xlsx.Design.Charts;

    using Drawing;
    using Drawing.Chart;

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

            switch (type)
            {
                case KnownAxisType.PrimaryValueAxis:
                    return KnownChartElement.PrimaryValueAxisTitle;

                case KnownAxisType.SecondaryCategoryAxis:
                    return KnownChartElement.SecondaryCategoryAxisTitle;

                case KnownAxisType.SecondaryValueAxis:
                    return KnownChartElement.SecondaryValueAxisTitle;

                default:
                    return KnownChartElement.PrimaryCategoryAxisTitle;
            }
        }

        /// <summary>
        /// Converter for <see cref="ChartType"/> enumeration type to <see cref="eChartType"/>.
        /// </summary>
        /// <param name="chartType">Chart type.</param>
        /// <returns>
        /// A <see cref="eChartType"/> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static eChartType ToEppChartType(this ChartType chartType)
        {
            SentinelHelper.IsEnumValid(chartType);

            switch (chartType)
            {
                case ChartType.XYScatter:
                    return eChartType.XYScatter;

                case ChartType.Radar:
                    return eChartType.Radar;

                case ChartType.Doughnut:
                    return eChartType.Doughnut;

                case ChartType.Pie3D:
                    return eChartType.Pie3D;

                case ChartType.Line3D:
                    return eChartType.Line3D;

                case ChartType.Column3D:
                    return eChartType.Column3D;

                case ChartType.Area3D:
                    return eChartType.Area3D;

                case ChartType.Area:
                    return eChartType.Area;

                case ChartType.Line:
                    return eChartType.Line;

                case ChartType.Pie:
                    return eChartType.Pie;

                case ChartType.Bubble:
                    return eChartType.Bubble;

                case ChartType.ColumnClustered:
                    return eChartType.ColumnClustered;

                case ChartType.ColumnStacked:
                    return eChartType.ColumnStacked;

                case ChartType.ColumnStacked100:
                    return eChartType.ColumnStacked100;

                case ChartType.ColumnClustered3D:
                    return eChartType.ColumnClustered3D;

                case ChartType.ColumnStacked3D:
                    return eChartType.ColumnStacked3D;

                case ChartType.ColumnStacked1003D:
                    return eChartType.ColumnStacked1003D;

                case ChartType.BarClustered:
                    return eChartType.BarClustered;

                case ChartType.BarStacked:
                    return eChartType.BarStacked;

                case ChartType.BarStacked100:
                    return eChartType.BarStacked100;

                case ChartType.BarClustered3D:
                    return eChartType.BarClustered3D;

                case ChartType.BarStacked3D:
                    return eChartType.BarStacked3D;

                case ChartType.BarStacked1003D:
                    return eChartType.BarStacked1003D;

                case ChartType.LineStacked:
                    return eChartType.LineStacked;

                case ChartType.LineStacked100:
                    return eChartType.LineStacked100;

                case ChartType.LineMarkers:
                    return eChartType.LineMarkers;

                case ChartType.LineMarkersStacked:
                    return eChartType.LineMarkersStacked;

                case ChartType.LineMarkersStacked100:
                    return eChartType.LineMarkersStacked100;

                case ChartType.PieOfPie:
                    return eChartType.PieOfPie;

                case ChartType.PieExploded:
                    return eChartType.PieExploded;

                case ChartType.PieExploded3D:
                    return eChartType.PieExploded3D;

                case ChartType.BarOfPie:
                    return eChartType.BarOfPie;

                case ChartType.XYScatterSmooth:
                    return eChartType.XYScatterSmooth;

                case ChartType.XYScatterSmoothNoMarkers:
                    return eChartType.XYScatterSmoothNoMarkers;

                case ChartType.XYScatterLines:
                    return eChartType.XYScatterSmoothNoMarkers;

                case ChartType.XYScatterLinesNoMarkers:
                    return eChartType.XYScatterSmoothNoMarkers;

                case ChartType.AreaStacked:
                    return eChartType.AreaStacked;

                case ChartType.AreaStacked100:
                    return eChartType.AreaStacked100;

                case ChartType.AreaStacked3D:
                    return eChartType.AreaStacked3D;

                case ChartType.AreaStacked1003D:
                    return eChartType.AreaStacked1003D;

                case ChartType.DoughnutExploded:
                    return eChartType.DoughnutExploded;

                case ChartType.RadarMarkers:
                    return eChartType.RadarMarkers;

                case ChartType.RadarFilled:
                    return eChartType.RadarFilled;

                case ChartType.Surface:
                    return eChartType.Surface;

                case ChartType.SurfaceWireframe:
                    return eChartType.SurfaceWireframe;

                case ChartType.SurfaceTopView:
                    return eChartType.SurfaceTopView;

                case ChartType.SurfaceTopViewWireframe:
                    return eChartType.SurfaceTopViewWireframe;

                case ChartType.Bubble3DEffect:
                    return eChartType.Bubble3DEffect;

                case ChartType.StockHLC:
                    return eChartType.StockHLC;

                case ChartType.StockOHLC:
                    return eChartType.StockOHLC;

                case ChartType.StockVHLC:
                    return eChartType.StockVHLC;

                case ChartType.StockVOHLC:
                    return eChartType.StockVOHLC;

                case ChartType.CylinderColClustered:
                    return eChartType.CylinderColClustered;

                case ChartType.CylinderColStacked:
                    return eChartType.CylinderColStacked;

                case ChartType.CylinderColStacked100:
                    return eChartType.CylinderColStacked100;

                case ChartType.CylinderBarClustered:
                    return eChartType.CylinderBarClustered;

                case ChartType.CylinderBarStacked:
                    return eChartType.CylinderBarStacked;

                case ChartType.CylinderBarStacked100:
                    return eChartType.CylinderBarStacked100;

                case ChartType.CylinderCol:
                    return eChartType.CylinderCol;

                case ChartType.ConeColClustered:
                    return eChartType.ConeColClustered;

                case ChartType.ConeColStacked:
                    return eChartType.ConeColStacked;

                case ChartType.ConeColStacked100:
                    return eChartType.ConeColStacked100;

                case ChartType.ConeBarClustered:
                    return eChartType.ConeBarClustered;

                case ChartType.ConeBarStacked:
                    return eChartType.ConeBarStacked;

                case ChartType.ConeBarStacked100:
                    return eChartType.ConeBarStacked100;

                case ChartType.ConeCol:
                    return eChartType.ConeCol;

                case ChartType.PyramidColClustered:
                    return eChartType.PyramidColClustered;

                case ChartType.PyramidColStacked:
                    return eChartType.PyramidColStacked;

                case ChartType.PyramidColStacked100:
                    return eChartType.PyramidColStacked100;

                case ChartType.PyramidBarClustered:
                    return eChartType.PyramidBarClustered;

                case ChartType.PyramidBarStacked:
                    return eChartType.PyramidBarStacked;

                case ChartType.PyramidBarStacked100:
                    return eChartType.PyramidBarStacked100;

                case ChartType.PyramidCol:
                    return eChartType.PyramidCol;

                default:
                    return eChartType.Line;
            }
        }
    }
}
