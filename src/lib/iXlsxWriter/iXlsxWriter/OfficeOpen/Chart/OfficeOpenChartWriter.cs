
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

namespace OfficeOpenXml.Helpers;

/// <summary>
/// Allows manipulate an <see cref="ExcelChart"/> instance.
/// </summary>
internal class OfficeOpenChartWriter
{
    #region constructor/s

    public OfficeOpenChartWriter(ExcelChart chart)
    {
        Chart = chart;
        XmlWriter = new XmlChartHelper {XmlDocument = chart.ChartXml};
    }

    #endregion

    #region public readonly methods

    public ExcelChart Chart { get; }

    public XmlChartHelper XmlWriter { get; }

    #endregion

    #region public methods

    /// <summary>
    /// Try to modify the chart axes settings.
    /// </summary>
    /// <param name="axes">Reference to axes settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetAxes(XlsxChartAxes axes)
    {
        if (axes == null)
        {
            return BooleanResult.CreateErrorResult("axes can not be null");
        }

        var chartAxes = Chart.Axis;

        var axesList = chartAxes.ToList();
        var hasAnyAxes = axesList.Any();
        if (!hasAnyAxes)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var axesListAsXml = GetXmlAxis().ToList();

            // Primary axis
            axesList[0].SetAxis(axesListAsXml[0], axes.Primary.Category, XmlWriter);
            axesList[1].SetAxis(axesListAsXml[1], axes.Primary.Values, XmlWriter);

            // Secondary axis
            if (axesList.Count <= 2)
            {
                return BooleanResult.SuccessResult;
            }

            axesList[2].SetAxis(axesListAsXml[2], axes.Secondary.Category, XmlWriter);
            axesList[3].SetAxis(axesListAsXml[3], axes.Secondary.Values, XmlWriter);

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart border settings.
    /// </summary>
    /// <param name="border">Reference to border settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetBorder(XlsxBorder border)
    {
        if (border == null)
        {
            return BooleanResult.CreateErrorResult("border can not be null");
        }

        if (border.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var chartBorder = Chart.Border;
            chartBorder.Fill.Style = eFillStyle.SolidFill;
            chartBorder.Fill.Color = border.GetColor();
            chartBorder.Fill.Transparancy = border.Transparency;
            chartBorder.LineStyle = border.Style.ToEppLineStyle();
            chartBorder.Width = border.Width;

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart content settings.
    /// </summary>
    /// <param name="content">Reference to chart settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetContent(XlsxChart content)
    {
        try
        {
            Chart.Fill.Color = content.GetBackColor();

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart legend settings.
    /// </summary>
    /// <param name="legend">Reference to legend settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetLegend(XlsxChartLegend legend)
    {
        if (legend == null)
        {
            return BooleanResult.CreateErrorResult("legend can not be null");
        }

        if (legend.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var chartLegend = Chart.Legend;
            chartLegend.Font.SetFromFont(legend.Font.ToFont());
            chartLegend.Font.Color = legend.Font.GetColor();
            chartLegend.Position = legend.Location.AsEnumType<eLegendPosition>();
            chartLegend.Border.SetBorder(legend.Border);

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart location settings.
    /// </summary>
    /// <param name="range">Reference to range location settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetPosition(XlsxBaseRange range)
    {
        if (range == null)
        {
            return BooleanResult.CreateErrorResult("border can not be null");
        }

        try
        {
            ExcelAddressBase locationAddress = range.ToEppExcelAddress();
            Chart.SetPosition(locationAddress.Start.Row - 1, 0, locationAddress.Start.Column - 1, 0);

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart plots settings.
    /// </summary>
    /// <param name="plots">Reference to chart plots settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetPlotArea(XlsxChartPlotsCollection plots)
    {
        if (plots == null)
        {
            return BooleanResult.CreateErrorResult("legend can not be null");
        }

        try
        {
            var chartPlots = Chart.PlotArea;
            chartPlots.Fill.Color = plots.Parent.GetBackColor();
            chartPlots.Border.SetBorder(plots.Border);

            var series = plots.SelectMany(plot => plot.Series);
            foreach (var serie in series)
            {
                AddColorToSerie(serie);
            }

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }


    }

    /// <summary>
    /// Try to modify the chart size settings.
    /// </summary>
    /// <param name="size">Reference to chart size settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetSize(XlsxSize size)
    {
        if (size == null)
        {
            return BooleanResult.CreateErrorResult("size can not be null");
        }

        try
        {
            Chart.SetSize(size.Width, size.Height);

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the shape effects settings.
    /// </summary>
    /// <param name="effects">Reference to chart shape effects settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetShapeEffects(XlsxShapeEffects effects)
    {
        if (effects == null)
        {
            return BooleanResult.CreateErrorResult("size can not be null");
        }

        try
        {
            SetIlluminationEffect(effects.Illumination);
            SetShadowEffect(effects.Shadow);
            SetReflectionEffect(effects.Reflection);
            SetSoftEdgeEffect(effects.SoftEdge);

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to modify the chart title settings.
    /// </summary>
    /// <param name="title">Reference to title settings to apply</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="BooleanResult"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SetTitle(XlsxChartTitle title)
    {
        if (title == null)
        {
            return BooleanResult.CreateErrorResult("title can not be null");
        }

        if (title.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var chartTitle = Chart.Title;
            chartTitle.Text = title.Text;
            chartTitle.Font.SetFromFont(title.Font.ToFont());
            chartTitle.Font.Color = title.Font.GetColor();

            chartTitle.Rotation = title.Orientation.ToAngle();
            chartTitle.TextVertical = title.Orientation == TextOrientation.Vertical ? eTextVerticalType.WordArtVertical : eTextVerticalType.Horizontal;

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    #endregion

    #region private methods
        
    private void AddColorToSerie(XlsxChartSerie serie)
    {
        var xmlSerieList = XmlWriter.GetElementsByTagName("c:v");
        var textNode = xmlSerieList.FirstOrDefault(n => n.ParentNode.ParentNode.Name.Equals("ser") && n.InnerText.Equals(serie.Name));
        if (textNode == null)
        {
            return;
        }

        var charType = serie.ChartType;
        switch (charType)
        {
            case ChartType.Pie3D:
                break;

            default:
                var areaChartSeriesNode = textNode.ParentNode?.ParentNode;
                areaChartSeriesNode.AddShapePropertiesNode(serie, XmlWriter);
                break;
        }
    }

    private IEnumerable<XmlNode> GetXmlAxis()
    {
        var xmlAxisNodeList = new List<XmlNode>
        {
            XmlWriter.FromKnownChartElement(KnownChartElement.PrimaryCategoryAxis),
            XmlWriter.FromKnownChartElement(KnownChartElement.PrimaryValueAxis),
        };

        var catAxisXmlNodes = XmlWriter.GetElementsByTagName("c:catAx");
        if (catAxisXmlNodes.Count() <= 1)
        {
            return xmlAxisNodeList;
        }

        xmlAxisNodeList.Add(XmlWriter.FromKnownChartElement(KnownChartElement.SecondaryCategoryAxis));
        xmlAxisNodeList.Add(XmlWriter.FromKnownChartElement(KnownChartElement.SecondaryValueAxis));

        return xmlAxisNodeList;
    }

    private IResult SetIlluminationEffect(XlsxIlluminationShapeEffect illumination)
    {
        if (illumination.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        var root = XmlWriter.GetXmlNode(XmlChartHelper.ChartSpaceRootNode);
        if (root == null)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var exist = XmlWriter.TryGetElementFrom(root, "c:spPr", out var shapePropertiesNode);
            shapePropertiesNode.AddEffectContainerNode(illumination, XmlWriter);
            if (!exist)
            {
                root.AppendChild(shapePropertiesNode);
            }

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    private IResult SetReflectionEffect(XlsxReflectionShapeEffect reflection)
    {
        if (reflection.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        var root = XmlWriter.GetXmlNode(XmlChartHelper.ChartSpaceRootNode);
        if (root == null)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var exist = XmlWriter.TryGetElementFrom(root, "c:spPr", out var shapePropertiesNode);
            shapePropertiesNode.AddEffectContainerNode(reflection, XmlWriter);
            if (!exist)
            {
                root.AppendChild(shapePropertiesNode);
            }

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    private IResult SetSoftEdgeEffect(XlsxSoftEdgeShapeEffect softEdge)
    {
        if (softEdge.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        var root = XmlWriter.GetXmlNode(XmlChartHelper.ChartSpaceRootNode);
        if (root == null)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var exist = XmlWriter.TryGetElementFrom(root, "c:spPr", out var shapePropertiesNode);
            shapePropertiesNode.AddEffectContainerNode(softEdge, XmlWriter);
            if (!exist)
            {
                root.AppendChild(shapePropertiesNode);
            }

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    private IResult SetShadowEffect(XlsxBaseShadow shadow)
    {
        if (shadow.Show == YesNo.No)
        {
            return BooleanResult.SuccessResult;
        }

        var root = XmlWriter.GetXmlNode(XmlChartHelper.ChartSpaceRootNode);
        if (root == null)
        {
            return BooleanResult.SuccessResult;
        }

        try
        {
            var exist = XmlWriter.TryGetElementFrom(root, "c:spPr", out var shapePropertiesNode);
            shapePropertiesNode.AddEffectContainerNode(shadow, XmlWriter);
            if (!exist)
            {
                root.AppendChild(shapePropertiesNode);
            }

            return BooleanResult.SuccessResult;
        }
        catch (Exception e)
        {
            return BooleanResult.FromException(e);
        }
    }

    #endregion
}
