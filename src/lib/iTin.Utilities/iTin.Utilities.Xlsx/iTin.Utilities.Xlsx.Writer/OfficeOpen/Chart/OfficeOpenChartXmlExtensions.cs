
using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml;

using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Helpers;

using iTin.Charting.Models.Design;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Writer;

namespace OfficeOpenXml.Drawing
{
    static class OfficeOpenChartXmlExtensions
    {
        #region public static methods

        #region [public] {static} (void) AddAxisGridLinesMode(this XmlNode, GridLine, IXmlHelper): Adds major, minor or both grid lines to the specified axis. Not supported in EPPlus library
        /// <summary>
        /// Adds major, minor or both grid lines to the specified axis. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="axis"><c>Xml</c> node than represent an axis definition.</param>
        /// <param name="model">A <see cref="GridLine"/> value from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="axis" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.InvalidOperationException">If <paramref name="axis" /> is not an axis.</exception>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static void AddAxisGridLinesMode(this XmlNode axis, GridLine model, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(axis, nameof(axis));
            SentinelHelper.IsEnumValid(model);
            SentinelHelper.IsFalse(axis.Name.Contains("catAx") || axis.Name.Contains("valAx") || axis.Name.Contains("dateAx"), "Imposible extraer tipo. el nodo no es de tipo eje");

            var existMajorGridLinesNode = documentHelper.TryGetElementFrom(axis, "c:majorGridlines", out var majorGridLinesElement);
            if (existMajorGridLinesNode)
            {
                var parent = majorGridLinesElement.ParentNode;
                parent.RemoveChild(majorGridLinesElement);
            }

            var existMinorGridLinesNode = documentHelper.TryGetElementFrom(axis, "c:minorGridlines", out var minorGridLinesElement);
            if (existMinorGridLinesNode)
            {
                var parent = minorGridLinesElement.ParentNode;
                parent.RemoveChild(minorGridLinesElement);
            }

            switch (model)
            {
                case GridLine.None:
                    break;

                case GridLine.Major:
                    axis.AppendChild(majorGridLinesElement);
                    break;

                case GridLine.Minor:
                    axis.AppendChild(minorGridLinesElement);
                    break;

                case GridLine.Both:
                    axis.AppendChild(majorGridLinesElement);
                    axis.AppendChild(minorGridLinesElement);
                    break;
            }
        }
        #endregion

        #region [public] {static} (void) AddAxisLabelAlignment(this XmlNode, KnownHorizontalAlignment, IXmlHelper): Adds the label alignment to the specified axis. Not supported in EPPlus library
        /// <summary>
        /// Adds the label alignment to the specified axis. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="axis"><b>Xml</b> node than represent an axis definition.</param>
        /// <param name="model">A <see cref="KnownHorizontalAlignment"/> value from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="axis"/> is <b>null</b>.</exception>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="axis"/> is not an axis.</exception>
        public static void AddAxisLabelAlignment(this XmlNode axis, KnownHorizontalAlignment model, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(axis, nameof(axis));
            SentinelHelper.IsEnumValid(model);
            SentinelHelper.IsFalse(axis.Name.Contains("catAx") || axis.Name.Contains("valAx") || axis.Name.Contains("dateAx"), "Imposible extraer tipo. el nodo no es de tipo eje");

            var axisType = axis.ExtractAxisType(documentHelper);
            switch (axisType)
            {
                case KnownAxisType.PrimaryCategoryAxis:
                case KnownAxisType.SecondaryCategoryAxis:

                    var valAttr = documentHelper.CreateAttribute("val");
                    valAttr.Value = model.ToEppLabelAlignmentString();

                    var lblAlignXmlNode = documentHelper.CreateOrDefaultAndAppendElementToNode(axis, "c:lblAlgn");
                    lblAlignXmlNode.Attributes.Append(valAttr);
                    break;

                case KnownAxisType.PrimaryValueAxis:
                case KnownAxisType.SecondaryValueAxis:
                    break;
            }
        }
        #endregion

        #region [public] {static} (void) AddAxisLabelProperties(this XmlNode, AxisDefinitionLabelsModel, IXmlHelper): Adds label properties (orientation, alignment, color and font) to the specified axis. Not supported in EPPlus library
        /// <summary>
        /// Adds label properties (orientation, alignment, color and font) to the specified axis. Not supported in <b>EPPlus</b> library.
        /// </summary> 
        /// <param name="axis"><b>Xml</b> node than represent an axis definition.</param>
        /// <param name="model">Axis from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="axis" /> is <b>null</b>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="model" /> is <b>null</b>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="axis" /> is not an axis.</exception>
        public static void AddAxisLabelProperties(this XmlNode axis, XlsxChartAxisDefinitionLabels model, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(axis, nameof(axis));
            SentinelHelper.ArgumentNull(model, nameof(model));
            SentinelHelper.IsFalse(axis.Name.Contains("catAx") || axis.Name.Contains("valAx") || axis.Name.Contains("dateAx"), "Imposible extraer tipo. el nodo no es de tipo eje");

            axis.AddTextPropertiesNode(model, documentHelper);
        }
        #endregion

        #region [public] {static} (void) AddShapePropertiesNode(this XmlNode, ChartSerieModel, IXmlHelper): Adds a spPr node (Shape properties) to the node of type ser (Area Chart Series) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>spPr</c> node (Shape properties) to the node of type <c>ser</c> (Area Chart Series) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>ser</c> node (Area Chart Series).</param>
        /// <param name="model">Serie from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-draw-chart_spPr-1.html">http://www.schemacentral.com/sc/ooxml/e-draw-chart_spPr-1.html</a>
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="node" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="model" /> is <c>null</c>.</exception>
        public static void AddShapePropertiesNode(this XmlNode node, XlsxChartSerie model, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(node, nameof(node));
            SentinelHelper.ArgumentNull(model, nameof(model));

            var shapePropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "c:spPr");
            shapePropertiesNode.AddSolidFillNode(model.GetColor(), documentHelper);

        }
        #endregion

        #region [public] {static} (KnownAxisType) ExtractAxisType(this XmlNode, IXmlHelper): Returns the type of axis than represents specified node. Not supported in EPPlus library
        /// <summary>
        /// Returns the type of axis than represents specified node. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="axis"><c>Xml</c> node than represent an axis definition.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <returns>
        /// A <see cref="KnownAxisType" /> value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="axis" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.InvalidOperationException">If <paramref name="axis" /> is not an axis.</exception>
        public static KnownAxisType ExtractAxisType(this XmlNode axis, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(axis, nameof(axis));
            SentinelHelper.IsFalse(axis.Name.Contains("catAx") || axis.Name.Contains("valAx") || axis.Name.Contains("dateAx"), "Imposible extraer tipo. el nodo no es de tipo eje");

            var idElement = documentHelper.GetXmlNode(axis, "c:axId");
            var valueAttr = idElement.Attributes["val"];

            var value = valueAttr.Value;
            switch (value)
            {
                case "2":
                    return KnownAxisType.PrimaryValueAxis;

                case "3":
                    return KnownAxisType.SecondaryCategoryAxis;

                case "4":
                    return KnownAxisType.SecondaryValueAxis;

                default:
                    return KnownAxisType.PrimaryCategoryAxis;
            }
        }
        #endregion

        #region [public] {static} (void) ModifyAxisCrosses(this XmlNode, IXmlHelper): Modifies crosses for the specified axis. Supported in EPPlus library but fails
        /// <summary>
        /// Modifies crosses for the specified axis. Supported in <c>EPPlus</c> library but fails.
        /// </summary>
        /// <param name="axis"><c>Xml</c> node than represent an axis definition.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <exception cref="T:System.ArgumentNullException">If <paramref name="axis" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.InvalidOperationException">If <paramref name="axis" /> is not an axis.</exception>
        public static void ModifyAxisCrosses(this XmlNode axis, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(axis, nameof(axis));
            SentinelHelper.IsFalse(axis.Name.Contains("catAx") || axis.Name.Contains("valAx") || axis.Name.Contains("dateAx"), "Imposible extraer tipo. el nodo no es de tipo eje");

            var axisType = axis.ExtractAxisType(documentHelper);
            if (axisType != KnownAxisType.SecondaryCategoryAxis)
            {
                return;
            }

            var valAttr = documentHelper.CreateAttribute("val");
            valAttr.Value = "max";

            var crossesXmlNode = documentHelper.CreateOrDefaultAndAppendElementToNode(axis, "c:crosses");
            crossesXmlNode.Attributes.Append(valAttr);
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (void) AddTextPropertiesNode(this XmlNode, AxisDefinitionLabelsModel, IXmlHelper): Adds a 'txPr' node (Text properties) to the node of type 'valAx' (Value Axis), 'catAx' (Category Axis Data), 'dateAx' (Date Axis), 'serAx' (Series Axis) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>txPr</c> node (Text properties) to the node of type <c>valAx</c> (Value Axis), <c>catAx</c> (Category Axis Data), <c>dateAx</c> (Date Axis), <c>serAx</c> (Series Axis) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node">Node of type <c>valAx</c> (Value Axis), <c>catAx</c> (Category Axis Data), <c>dateAx</c> (Date Axis), <c>serAx</c> (Series Axis).</param>
        /// <param name="model">Axis from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-draw-chart_txPr-1.html">http://www.schemacentral.com/sc/ooxml/e-draw-chart_txPr-1.html</a>
        /// </remarks>
        private static void AddTextPropertiesNode(this XmlNode node, XlsxChartAxisDefinitionLabels model, IXmlHelper documentHelper)
        {
            var textPropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "c", "txPr");

            textPropertiesNode.AddBodyPropertiesNode(model.Orientation, documentHelper);
            textPropertiesNode.AddTextListStylesNode(documentHelper);
            textPropertiesNode.AddTextParagraphsNode(model.Font, documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddBodyPropertiesNode(this XmlNode, KnownLabelOrientation, IXmlHelper): Adds a 'bodyPr' node (Body Properties) to the node of type 'txPr' (Text properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>bodyPr</c> node (Body Properties) to the node of type <c>txPr</c> (Text properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="textPropertiesNode"><c>txPr</c> node (Text properties).</param>
        /// <param name="orientation">A <see cref="KnownLabelOrientation" /> value from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_bodyPr-2.html">http://www.schemacentral.com/sc/ooxml/e-a_bodyPr-2.html</a>
        /// </remarks>
        private static void AddBodyPropertiesNode(this XmlNode textPropertiesNode, LabelOrientation orientation, IXmlHelper documentHelper)
        {
            var rotAttr = documentHelper.CreateAttribute("rot");
            rotAttr.Value = orientation.ToAngle().ToString(CultureInfo.InvariantCulture);

            var vertAttr = documentHelper.CreateAttribute("vert");
            vertAttr.Value = orientation == LabelOrientation.Vertical ? "wordArtVert" : "horz";

            var bodyPropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(textPropertiesNode, "a", "bodyPr");
            bodyPropertiesNode.Attributes.Append(rotAttr);
            bodyPropertiesNode.Attributes.Append(vertAttr);
        }
        #endregion

        #region [private] {static} (void) AddTextListStylesNode(this XmlNode, IXmlHelper): Adds a 'lstStyle' node (Text List Styles) to the node of type 'txPr' (Text properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>lstStyle</c> node (Text List Styles) to the node of type <c>txPr</c> (Text properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="textPropertiesNode"><c>txPr</c> node (Text properties).</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_lstStyle-2.html">http://www.schemacentral.com/sc/ooxml/e-a_lstStyle-2.html</a>
        /// </remarks>
        private static void AddTextListStylesNode(this XmlNode textPropertiesNode, IXmlHelper documentHelper)
        {
            documentHelper.CreateOrDefaultAndAppendElementToNode(textPropertiesNode, "a", "lstStyle");
        }
        #endregion

        #region [private] {static} (void) AddTextParagraphsNode(this XmlNode, FontModel, IXmlHelper): Adds a 'p' node (Text Paragraphs) to the node of type 'txPr' (Text properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>p</c> node (Text Paragraphs) to the node of type <c>txPr</c> (Text properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="textPropertiesNode"><c>txPr</c> node (Text properties).</param>
        /// <param name="model">Font from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_p-1.html">http://www.schemacentral.com/sc/ooxml/e-a_p-1.html</a>
        /// </remarks>
        private static void AddTextParagraphsNode(this XmlNode textPropertiesNode, FontModel model, IXmlHelper documentHelper)
        {
            var textParagraphsNode = documentHelper.CreateOrDefaultAndAppendElementToNode(textPropertiesNode, "a", "p");

            textParagraphsNode.AddTextParagraphPropertiesNode(model, documentHelper);
            textParagraphsNode.AddEndParagraphRunPropertiesNode(documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddEndParagraphRunPropertiesNode(this XmlNode, XmlDocument, IXmlHelper): Adds a 'endParaRPr' node (End Paragraph Run Properties) to the node of type 'p' (Text Paragraphs) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>endParaRPr</c> node (End Paragraph Run Properties) to the node of type <c>p</c> (Text Paragraphs) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="textParagraphsNode"><c>p</c> node (Text Paragraphs).</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_endParaRPr-1.html">http://www.schemacentral.com/sc/ooxml/e-a_endParaRPr-1.html</a>
        /// </remarks>
        private static void AddEndParagraphRunPropertiesNode(this XmlNode textParagraphsNode, IXmlHelper documentHelper)
        {
            var langAttr = documentHelper.CreateAttribute("lang");
            langAttr.Value = CultureInfo.CurrentCulture.Name;

            var endParagraphRunPropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(textParagraphsNode, "a", "endParaRPr");
            endParagraphRunPropertiesNode.Attributes.Append(langAttr);
        }
        #endregion

        #endregion
    }
}
