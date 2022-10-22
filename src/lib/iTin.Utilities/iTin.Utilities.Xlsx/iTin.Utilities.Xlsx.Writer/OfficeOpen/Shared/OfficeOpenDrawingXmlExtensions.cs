
using System;
using System.Drawing;
using System.Globalization;
using System.Xml;

using OfficeOpenXml.Helpers;

using iTin.Core.Drawing.Helpers;
using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace OfficeOpenXml.Drawing
{
    /// <summary>
    ///   <para>Static class than contains extension methods for objects of type <see cref="XmlNode"/>.</para>
    ///   <para>This class adds new <c>XML</c> functionality using extension methods directly in drawing xml tree of EPPlus library.</para>
    ///   <para>For example:</para>
    ///   <list type="bullet">
    ///     ///     <item>
    ///       <description>Add shadow to excel chart. For more information, please see <a href="http://officeopenxml.com/drwPic.php">http://officeopenxml.com/drwPic.php</a></description>
    ///     </item>
    ///     <item>
    ///       <description>Add shadow to excel picture. For more information, please see <a href="http://officeopenxml.com/drwPic.php">http://officeopenxml.com/drwPic.php</a></description>
    ///     </item>
    ///     <item>
    ///       <description>Add shadow to excel shape. For more information, please see <a href="http://officeopenxml.com/drwShape.php">http://officeopenxml.com/drwShape.php</a></description>
    ///     </item>
    ///   </list>
    /// </summary>
    internal static class OfficeOpenDrawingXmlExtensions
    {
        #region public static methods

        #region [public] {static} (void) AddEffectContainerNode(this XmlNode, XlsxBaseShadow, IXmlHelper): Adds an effectLst node (Effect Container) to the node of type spPr (Shape properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds an <b>effectLst</b> node (Effect Container) to the node of type <b>spPr</b> (Shape properties) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="node"><c>spPr</c> node (Shape properties).</param>
        /// <param name="shadow">Shadow from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html">http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html</a>
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="node"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="shadow"/> is <b>null</b>.</exception>
        public static void AddEffectContainerNode(this XmlNode node, XlsxBaseShadow shadow, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(node, nameof(node));
            SentinelHelper.ArgumentNull(shadow, nameof(shadow));

            var effectContainerNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "effectLst");;

            switch (shadow.Type)
            {
                case KnownShadowType.Inner:
                    effectContainerNode.AddInnerShadowNode((XlsxInnerShadow)shadow, documentHelper);
                    break;

                case KnownShadowType.Outer:
                    effectContainerNode.AddOuterShadowNode((XlsxOuterShadow)shadow, documentHelper);
                    break;

                case KnownShadowType.Perspective:
                    effectContainerNode.AddPerspectiveShadowNode((XlsxPerspectiveShadow)shadow, documentHelper);
                    break;
            }
        }
        #endregion

        #region [public] {static} (void) AddEffectContainerNode(this XmlNode, XlsxIlluminationShapeEffect, IXmlHelper): Adds an effectLst node (Effect Container) to the node of type spPr (Shape properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds an <b>effectLst</b> node (Effect Container) to the node of type <b>spPr</b> (Shape properties) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="node"><c>spPr</c> node (Shape properties).</param>
        /// <param name="illumination">Illumination from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html">http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html</a>
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="node"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="illumination"/> is <b>null</b>.</exception>
        public static void AddEffectContainerNode(this XmlNode node, XlsxIlluminationShapeEffect illumination, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(node, nameof(node));
            SentinelHelper.ArgumentNull(illumination, nameof(illumination));

            var effectContainerNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "effectLst"); ;
            effectContainerNode.AddGlowNode(illumination, documentHelper);
        }
        #endregion

        #region [public] {static} (void) AddEffectContainerNode(this XmlNode, XlsxReflectionShapeEffect, IXmlHelper): Adds an effectLst node (Effect Container) to the node of type spPr (Shape properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds an <b>effectLst</b> node (Effect Container) to the node of type <b>spPr</b> (Shape properties) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="node"><c>spPr</c> node (Shape properties).</param>
        /// <param name="reflection">Reflection from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html">http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html</a>
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="node"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="reflection"/> is <b>null</b>.</exception>
        public static void AddEffectContainerNode(this XmlNode node, XlsxReflectionShapeEffect reflection, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(node, nameof(node));
            SentinelHelper.ArgumentNull(reflection, nameof(reflection));

            var effectContainerNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "effectLst"); ;
            effectContainerNode.AddReflectionNode(reflection, documentHelper);
        }
        #endregion

        #region [public] {static} (void) AddEffectContainerNode(this XmlNode, XlsxSoftEdgeShapeEffect, IXmlHelper): Adds an effectLst node (Effect Container) to the node of type spPr (Shape properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds an <b>effectLst</b> node (Effect Container) to the node of type <b>spPr</b> (Shape properties) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="node"><c>spPr</c> node (Shape properties).</param>
        /// <param name="softEdge">Soft edge from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html">http://www.schemacentral.com/sc/ooxml/e-a_effectLst-1.html</a>
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="node"/> is <b>null</b>.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="softEdge"/> is <b>null</b>.</exception>
        public static void AddEffectContainerNode(this XmlNode node, XlsxSoftEdgeShapeEffect softEdge, IXmlHelper documentHelper)
        {
            SentinelHelper.ArgumentNull(node, nameof(node));
            SentinelHelper.ArgumentNull(softEdge, nameof(softEdge));

            var effectContainerNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "effectLst"); ;
            effectContainerNode.AddSoftEdgeNode(softEdge, documentHelper);
        }
        #endregion

        #region [public] {static} (void) AddSolidFillNode(this XmlNode, Color, IXmlHelper): Adds a 'solidFill' node (Solid Fill Properties) to the node of type 'spPr' (Shape properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>solidFill</c> node (Solid Fill Properties) to the node of type <c>spPr</c> (Shape properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="shapePropertiesNode"><c>spPr</c> node (Shape Properties).</param>
        /// <param name="color">Fill color.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_solidFill-1.html">http://www.schemacentral.com/sc/ooxml/e-a_solidFill-1.html</a>
        /// </remarks>
        public static void AddSolidFillNode(this XmlNode shapePropertiesNode, Color color, IXmlHelper documentHelper)
        {
            var solidFillNode = documentHelper.CreateOrDefaultAndAppendElementToNode(shapePropertiesNode, "a", "solidFill");

            var valAttr = documentHelper.CreateAttribute("val");
            valAttr.Value = ColorHelper.ToHex(color).Replace("#", string.Empty);

            var srgbClrNode = documentHelper.CreateOrDefaultAndAppendElementToNode(solidFillNode, "a", "srgbClr");
            srgbClrNode.Attributes.Append(valAttr);
        }
        #endregion

        #region [public] {static} (void) AddTextParagraphPropertiesNode(this XmlNode, FontModel, IXmlHelper): Adds a 'pPr' node (Text Paragraph Properties) to the node of type 'p' (Text Paragraphs) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>pPr</c> node (Text Paragraph Properties) to the node of type <c>p</c> (Text Paragraphs) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>p</c> node (Text Paragraphs).</param>
        /// <param name="model">Font from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_pPr-1.html">http://www.schemacentral.com/sc/ooxml/e-a_pPr-1.html</a>
        /// </remarks>
        public static void AddTextParagraphPropertiesNode(this XmlNode node, FontModel model, IXmlHelper documentHelper)
        {
            var textParagraphPropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "pPr");
            textParagraphPropertiesNode.AddDefaultTextRunPropertiesNode(model, documentHelper);
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (void) AddDefaultTextRunPropertiesNode(this XmlNode, FontModel, IXmlHelper): Adds a 'defRPr' node (Default Text Run Properties) to the node of type 'pPr' (Text Paragraph Properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>defRPr</c> node (Default Text Run Properties) to the node of type <c>pPr</c> (Text Paragraph Properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>pPr</c> node (Text Paragraph Properties).</param>
        /// <param name="model">Font from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_defRPr-1.html">http://www.schemacentral.com/sc/ooxml/e-a_defRPr-1.html</a>
        /// </remarks>
        private static void AddDefaultTextRunPropertiesNode(this XmlNode node, FontModel model, IXmlHelper documentHelper)
        {
            var sizeAttr = documentHelper.CreateAttribute("sz");
            sizeAttr.Value = (model.Size * 100).ToString(CultureInfo.InvariantCulture);

            var boldAttr = documentHelper.CreateAttribute("b");
            boldAttr.Value = model.Bold == YesNo.Yes ? "1" : "0";

            var italicAttr = documentHelper.CreateAttribute("i");
            italicAttr.Value = model.Italic == YesNo.Yes ? "1" : "0";

            var underlineAttr = documentHelper.CreateAttribute("u");
            underlineAttr.Value = model.Underline == YesNo.Yes ? "sng" : "none";

            var defaultTextRunPropertiesNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "defRPr");
            defaultTextRunPropertiesNode.Attributes.Append(boldAttr);
            defaultTextRunPropertiesNode.Attributes.Append(sizeAttr);
            defaultTextRunPropertiesNode.Attributes.Append(italicAttr);
            defaultTextRunPropertiesNode.Attributes.Append(underlineAttr);

            defaultTextRunPropertiesNode.AddSolidFillNode(model.GetColor(), documentHelper);
            defaultTextRunPropertiesNode.AddLatinFontNode(model.Name, documentHelper);
            defaultTextRunPropertiesNode.AddEastAsianFontNode(model.Name, documentHelper);
            defaultTextRunPropertiesNode.AddComplexScriptFontNode(model.Name, documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddComplexScriptFontNode(this XmlNode, string, IXmlHelper): Adds a 'cs' node (Complex Script Font) to the node of type 'defRPr' (Default Text Run Properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>cs</c> node (Complex Script Font) to the node of type <c>defRPr</c> (Default Text Run Properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>defRPr</c> node (Shape Properties).</param>
        /// <param name="fontname">Font name.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_cs-1.html">http://www.schemacentral.com/sc/ooxml/e-a_cs-1.html</a>
        /// </remarks>
        private static void AddComplexScriptFontNode(this XmlNode node, string fontname, IXmlHelper documentHelper)
        {
            var typefaceAttr = documentHelper.CreateAttribute("typeface");
            typefaceAttr.Value = fontname;

            var complexScriptFontNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "cs");
            complexScriptFontNode.Attributes.Append(typefaceAttr);
        }
        #endregion

        #region [private] {static} (void) AddLatinFontNode(this XmlNode, string, IXmlHelper): Adds a 'latin' node (Latin Font) to the node of type 'defRPr' (Default Text Run Properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>latin</c> node (Latin Font) to the node of type <c>defRPr</c> (Default Text Run Properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>defRPr</c> node (Shape Properties).</param>
        /// <param name="fontname">Font name.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_latin-1.html">http://www.schemacentral.com/sc/ooxml/e-a_latin-1.html</a>
        /// </remarks>
        private static void AddLatinFontNode(this XmlNode node, string fontname, IXmlHelper documentHelper)
        {
            var typefaceAttr = documentHelper.CreateAttribute("typeface");
            typefaceAttr.Value = fontname;

            var latinFontNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "latin");
            latinFontNode.Attributes.Append(typefaceAttr);
        }
        #endregion

        #region [private] {static} (void) AddEastAsianFontNode(this XmlNode, string, IXmlHelper): Adds a 'ea' node (East Asian Font) to the node of type 'defRPr' (Default Text Run Properties) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <c>ea</c> node (East Asian Font) to the node of type <c>defRPr</c> (Default Text Run Properties) specified. Not supported in <c>EPPlus</c> library.
        /// </summary>
        /// <param name="node"><c>defRPr</c> node (Shape Properties).</param>
        /// <param name="fontname">Font name.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_ea-1.html">http://www.schemacentral.com/sc/ooxml/e-a_ea-1.html</a>
        /// </remarks>
        private static void AddEastAsianFontNode(this XmlNode node, string fontname, IXmlHelper documentHelper)
        {
            var typefaceAttr = documentHelper.CreateAttribute("typeface");
            typefaceAttr.Value = fontname;

            var eastAsianFontNode = documentHelper.CreateOrDefaultAndAppendElementToNode(node, "a", "ea");
            eastAsianFontNode.Attributes.Append(typefaceAttr);
        }
        #endregion

        #region [private] {static} (void) AddInnerShadowNode(this XmlNode, XlsxBaseShadow, IXmlHelper): Adds a 'outerShdw' node (Outer Shadow) to the node of type 'effectLst' (Effect Container) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <b>innerShdw</b> node (Inner Shadow) to the node of type <b>effectLst</b> (Effect Container) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectContainerNode"><b>effectLst</b> node (Effect Container).</param>
        /// <param name="shadow">Shadow from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html">http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html</a>
        /// </remarks>
        private static void AddInnerShadowNode(this XmlNode effectContainerNode, XlsxBaseShadow shadow, IXmlHelper documentHelper)
        {
            var blurRadAttr = documentHelper.CreateAttribute("blurRad");
            blurRadAttr.Value = $"{shadow.Blur * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var distAttr = documentHelper.CreateAttribute("dist");
            distAttr.Value = $"{shadow.Offset * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var dirAttr = documentHelper.CreateAttribute("dir");
            dirAttr.Value = $"{shadow.Angle * OfficeOpenXmlHelper.ST_POSITIVE_FIXED_ANGLE}";

            var rotWithShapeAttr = documentHelper.CreateAttribute("rotWithShape");
            rotWithShapeAttr.Value = "0";

            var outerShadowNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectContainerNode, "a", "innerShdw");
            if (outerShadowNode.Attributes == null)
            {
                return;
            }

            outerShadowNode.Attributes.Append(blurRadAttr);
            outerShadowNode.Attributes.Append(distAttr);
            outerShadowNode.Attributes.Append(dirAttr);
            outerShadowNode.Attributes.Append(rotWithShapeAttr);

            outerShadowNode.AddRgbColorModelPercentageVariantNode(shadow, documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddOuterShadowNode(this XmlNode, Shadow, IXmlHelper): Adds a 'outerShdw' node (Outer Shadow) to the node of type 'effectLst' (Effect Container) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <b>outerShdw</b> node (Outer Shadow) to the node of type <b>effectLst</b> (Effect Container) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectContainerNode"><b>effectLst</b> node (Effect Container).</param>
        /// <param name="shadow">Shadow from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html">http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html</a>
        /// </remarks>
        private static void AddOuterShadowNode(this XmlNode effectContainerNode, XlsxOuterShadow shadow, IXmlHelper documentHelper)
        {
            var blurRadAttr = documentHelper.CreateAttribute("blurRad");
            blurRadAttr.Value = $"{shadow.Blur * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var distAttr = documentHelper.CreateAttribute("dist");
            distAttr.Value = $"{shadow.Offset * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var dirAttr = documentHelper.CreateAttribute("dir");
            dirAttr.Value = $"{shadow.Angle * OfficeOpenXmlHelper.ST_POSITIVE_FIXED_ANGLE}";

            var sxAttr = documentHelper.CreateAttribute("sx");
            var syAttr = documentHelper.CreateAttribute("sy");
            if (shadow.Size != 100)
            {
                sxAttr.Value = $"{shadow.Size * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                syAttr.Value = $"{shadow.Size * OfficeOpenXmlHelper.ST_PERCENTAGE}";
            }

            var rotWithShapeAttr = documentHelper.CreateAttribute("rotWithShape");
            rotWithShapeAttr.Value = "0";

            var outerShadowNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectContainerNode, "a", "outerShdw");
            if (outerShadowNode.Attributes == null)
            {
                return;
            }

            outerShadowNode.Attributes.Append(blurRadAttr);
            outerShadowNode.Attributes.Append(distAttr);
            outerShadowNode.Attributes.Append(dirAttr);
            outerShadowNode.Attributes.Append(rotWithShapeAttr);

            if (shadow.Size != 100)
            {
                outerShadowNode.Attributes.Append(sxAttr);
                outerShadowNode.Attributes.Append(syAttr);
            }


            outerShadowNode.AddRgbColorModelPercentageVariantNode(shadow, documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddPerspectiveShadowNode(this XmlNode, XlsxPerspectiveShadow, IXmlHelper): Adds a 'outerShdw' node (Outer Shadow) to the node of type 'effectLst' (Effect Container) specified. Not supported in EPPlus library
        /// <summary>
        /// Adds a <b>outerShdw</b> node (Outer Shadow) to the node of type <b>effectLst</b> (Effect Container) specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectContainerNode"><b>effectLst</b> node (Effect Container).</param>
        /// <param name="shadow">Shadow from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html">http://www.schemacentral.com/sc/ooxml/e-a_outerShdw-2.html</a>
        /// </remarks>
        private static void AddPerspectiveShadowNode(this XmlNode effectContainerNode, XlsxPerspectiveShadow shadow, IXmlHelper documentHelper)
        {
            var blurRadAttr = documentHelper.CreateAttribute("blurRad");
            blurRadAttr.Value = $"{shadow.Blur * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var distAttr = documentHelper.CreateAttribute("dist");
            distAttr.Value = $"{shadow.Offset * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var dirAttr = documentHelper.CreateAttribute("dir");
            dirAttr.Value = $"{shadow.Angle * OfficeOpenXmlHelper.ST_POSITIVE_FIXED_ANGLE}";

            var sxAttr = documentHelper.CreateAttribute("sx");
            var syAttr = documentHelper.CreateAttribute("sy");
            var kxAttr = documentHelper.CreateAttribute("kx");
            var algnAttr = documentHelper.CreateAttribute("algn");
            switch (shadow.Angle)
            {
                case 225:
                    sxAttr.Value = null;
                    syAttr.Value = $"{23 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    kxAttr.Value = $"{1200 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    algnAttr.Value = "br";
                    break;

                case 315:
                    sxAttr.Value = null;
                    syAttr.Value = $"{23 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    kxAttr.Value = $"{-1200 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    algnAttr.Value = "bl";
                    break;

                case 135:
                    sxAttr.Value = null;
                    syAttr.Value = $"{-23 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    kxAttr.Value = "800400";
                    algnAttr.Value = "br";
                    break;

                case 45:
                    sxAttr.Value = null;
                    syAttr.Value = $"{-23 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    kxAttr.Value = "-800400";
                    algnAttr.Value = "bl";
                    break;

                case 90:
                    sxAttr.Value = $"{90 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    syAttr.Value = $"{-19 * OfficeOpenXmlHelper.ST_PERCENTAGE}";
                    kxAttr.Value = null;
                    algnAttr.Value = null;
                    break;
            }

            var rotWithShapeAttr = documentHelper.CreateAttribute("rotWithShape");
            rotWithShapeAttr.Value = "0";

            var outerShadowNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectContainerNode, "a", "outerShdw");
            if (outerShadowNode.Attributes == null)
            {
                return;
            }

            outerShadowNode.Attributes.Append(blurRadAttr);
            outerShadowNode.Attributes.Append(distAttr);
            outerShadowNode.Attributes.Append(dirAttr);

            if (!string.IsNullOrEmpty(sxAttr.Value))
            {
                outerShadowNode.Attributes.Append(sxAttr);
            }

            outerShadowNode.Attributes.Append(syAttr);

            if (!string.IsNullOrEmpty(kxAttr.Value))
            {
                outerShadowNode.Attributes.Append(kxAttr);
            }

            if (!string.IsNullOrEmpty(algnAttr.Value))
            {
                outerShadowNode.Attributes.Append(algnAttr);
            }

            outerShadowNode.Attributes.Append(rotWithShapeAttr);

            outerShadowNode.AddRgbColorModelPercentageVariantNode(shadow, documentHelper);
        }
        #endregion

        #region [private] {static} (void) AddRgbColorModelPercentageVariantNode(this XmlNode, XlsxBaseShadow, IXmlHelper): Adds a 'scrgbClr' node (Rgb Color Model Percentage Variant) to the node of type 'outerShdw' (Outer Shadow), 'innerShdw' (Inner Shadow) specified
        /// <summary>
        /// Adds a <b>scrgbClr</b> node (Rgb Color Model Percentage Variant) to the nodes of type <b>outerShdw</b> (Outer Shadow), <b>innerShdw</b> (Inner Shadow), specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="outerShadowNode"><b>outerShdw</b> node (Outer Shadow).</param>
        /// <param name="shadow">Shadow from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_scrgbClr-1.html">http://www.schemacentral.com/sc/ooxml/e-a_scrgbClr-1.html</a>
        /// </remarks>
        private static void AddRgbColorModelPercentageVariantNode(this XmlNode outerShadowNode, XlsxBaseShadow shadow, IXmlHelper documentHelper)
        {
            var valueAttr = documentHelper.CreateAttribute("val");
            valueAttr.Value = ColorHelper.ToHex(shadow.GetColor()).Replace("#", string.Empty);

            var rgbColorModelPercentageVariantNode = documentHelper.CreateOrDefaultAndAppendElementToNode(outerShadowNode, "a", "srgbClr");
            rgbColorModelPercentageVariantNode.Attributes?.Append(valueAttr);

            var alphaValueAttr = documentHelper.CreateAttribute("val");
            alphaValueAttr.Value = $"{(100 - shadow.Transparency) * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var alphaNode = documentHelper.CreateOrDefaultAndAppendElementToNode(rgbColorModelPercentageVariantNode, "a", "alpha");
            alphaNode.Attributes?.Append(alphaValueAttr);
        }
        #endregion

        #region [private] {static} (void) AddGlowNode(this XmlNode, XlsxIlluminationShapeEffect, IXmlHelper): Adds a 'glow' node to the node of type 'effectLst' specified
        /// <summary>
        /// Adds a <b>glow</b> node to the nodes of type <b>effectLst</b> specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectLstNode"><b>outerShdw</b> node (glow).</param>
        /// <param name="illumination">Illumination from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://www.schemacentral.com/sc/ooxml/e-a_scrgbClr-1.html">http://www.schemacentral.com/sc/ooxml/e-a_scrgbClr-1.html</a>
        /// </remarks>
        private static void AddGlowNode(this XmlNode effectLstNode, XlsxIlluminationShapeEffect illumination, IXmlHelper documentHelper)
        {
            var radAttr = documentHelper.CreateAttribute("rad");
            radAttr.Value = $"{illumination.Size * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var glowNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectLstNode, "a", "glow");
            glowNode.Attributes?.Append(radAttr);

            var clrValAttr = documentHelper.CreateAttribute("val");
            clrValAttr.Value = ColorHelper.ToHex(illumination.GetColor()).Replace("#", string.Empty);

            var rgbColorModelPercentageVariantNode = documentHelper.CreateOrDefaultAndAppendElementToNode(glowNode, "a", "srgbClr");
            rgbColorModelPercentageVariantNode.Attributes?.Append(clrValAttr);
            
            var alphaValueAttr = documentHelper.CreateAttribute("val");
            alphaValueAttr.Value = $"{(100 - illumination.Transparency) * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var alphaNode = documentHelper.CreateOrDefaultAndAppendElementToNode(rgbColorModelPercentageVariantNode, "a", "alpha");
            alphaNode.Attributes?.Append(alphaValueAttr);
        }
        #endregion

        #region [private] {static} (void) AddReflectionNode(this XmlNode, XlsxReflectionShapeEffect, IXmlHelper): Adds a 'reflection' node to the node of type 'effectLst' specified
        /// <summary>
        /// Adds a <b>reflection</b> node to the nodes of type <b>effectLst</b> specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectLstNode"><b>outerShdw</b> node (glow).</param>
        /// <param name="reflection">Reflection from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://officeopenxml.com/drwSp-effects.phpl">http://officeopenxml.com/drwSp-effects.php</a>
        /// </remarks>
        private static void AddReflectionNode(this XmlNode effectLstNode, XlsxReflectionShapeEffect reflection, IXmlHelper documentHelper)
        {
            var blurRadAttr = documentHelper.CreateAttribute("blurRad");
            blurRadAttr.Value = $"{reflection.Blur * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var staAttr = documentHelper.CreateAttribute("stA");
            staAttr.Value = $"{reflection.Transparency * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var endaAttr = documentHelper.CreateAttribute("endA");
            endaAttr.Value = $"{0.3 * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var endPosAttr = documentHelper.CreateAttribute("endPos");
            endPosAttr.Value = $"{reflection.Size * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var distAttr = documentHelper.CreateAttribute("dist");
            distAttr.Value = $"{reflection.Offset * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var dirAttr = documentHelper.CreateAttribute("dir");
            dirAttr.Value = $"{90 * OfficeOpenXmlHelper.ST_POSITIVE_FIXED_ANGLE}";

            var syAttr = documentHelper.CreateAttribute("sy");
            syAttr.Value = $"{-100 * OfficeOpenXmlHelper.ST_PERCENTAGE}";

            var algnAttr = documentHelper.CreateAttribute("algn");
            algnAttr.Value = "bl";

            var rotWithShapeAttr = documentHelper.CreateAttribute("rotWithShape");
            rotWithShapeAttr.Value = "0";

            var reflectionNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectLstNode, "a", "reflection");
            reflectionNode.Attributes?.Append(blurRadAttr);
            reflectionNode.Attributes?.Append(staAttr);
            reflectionNode.Attributes?.Append(endaAttr);
            reflectionNode.Attributes?.Append(endPosAttr);

            if (reflection.Offset != 0.0f)
            {
                reflectionNode.Attributes?.Append(distAttr);
            }

            reflectionNode.Attributes?.Append(dirAttr);
            reflectionNode.Attributes?.Append(syAttr);
            reflectionNode.Attributes?.Append(algnAttr);
            reflectionNode.Attributes?.Append(rotWithShapeAttr);
        }
        #endregion

        #region [private] {static} (void) AddSoftEdgeNode(this XmlNode, XlsxSoftEdgeShapeEffect, IXmlHelper): Adds a 'sofedge' node to the node of type 'effectLst' specified
        /// <summary>
        /// Adds a <b>softEdge</b> node to the nodes of type <b>effectLst</b> specified. Not supported in <b>EPPlus</b> library.
        /// </summary>
        /// <param name="effectLstNode"><b>outerShdw</b> node (glow).</param>
        /// <param name="softEdge">Soft edge from model.</param>
        /// <param name="documentHelper">Target xml document helper.</param>
        /// <remarks>
        /// For more information please see <a href="http://officeopenxml.com/drwSp-effects.php">http://officeopenxml.com/drwSp-effects.php</a>
        /// </remarks>
        private static void AddSoftEdgeNode(this XmlNode effectLstNode, XlsxSoftEdgeShapeEffect softEdge, IXmlHelper documentHelper)
        {
            var radAttr = documentHelper.CreateAttribute("rad");
            radAttr.Value = $"{softEdge.Size * OfficeOpenXmlHelper.EMU_PER_POINT}";

            var reflectionNode = documentHelper.CreateOrDefaultAndAppendElementToNode(effectLstNode, "a", "softEdge");
            reflectionNode.Attributes?.Append(radAttr);
        }
        #endregion

        #endregion
    }
}
