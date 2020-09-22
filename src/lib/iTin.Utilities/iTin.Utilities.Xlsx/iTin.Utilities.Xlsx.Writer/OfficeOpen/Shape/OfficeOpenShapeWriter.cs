
namespace OfficeOpenXml.Helpers
{
    using System;

    using iTin.Core;
    using iTin.Core.ComponentModel;
    using iTin.Core.ComponentModel.Results;

    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;
    
    using iTin.Utilities.Xlsx.Design.Shared;
    using iTin.Utilities.Xlsx.Design.Shape;
    using iTin.Utilities.Xlsx.Writer;

    using Drawing;

    /// <summary>
    /// Allows manipulate an <see cref="ExcelShape"/> instance.
    /// </summary>
    internal class OfficeOpenShapeWriter
    {
        #region constructor/s

        public OfficeOpenShapeWriter(ExcelShape shape, ExcelWorksheet worksheet)
        {
            Shape = shape;
            XmlWriter = new XmlDrawingHelper { XmlDocument = worksheet.Drawings.DrawingXml};
        }

        #endregion

        #region public readonly methods

        public ExcelShape Shape { get; }

        public ExcelWorksheet Worksheet { get; }

        public XmlDrawingHelper XmlWriter { get; }

        #endregion

        #region public methods

        #region [public] (IResult) SetBorder(XlsxBorder): Try to modify the shape size settings
        /// <summary>
        /// Try to modify the shape border settings.
        /// </summary>
        /// <param name="border">Reference to shape settings to apply</param>
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
                return BooleanResult.CreateErroResult("border can not be null");
            }

            if (border.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var element = Shape.Border;
                element.Fill.Style = eFillStyle.SolidFill;
                element.Fill.Color = border.GetColor();
                element.Fill.Transparancy = border.Transparency;
                element.LineStyle = border.Style.ToEppLineStyle();
                element.Width = border.Width;

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetContent(XlsxShapeContent): Try to modify the shape content settings
        /// <summary>
        /// Try to modify the shape content settings.
        /// </summary>
        /// <param name="content">Reference to picture content settings to apply</param>
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
        public IResult SetContent(XlsxShapeContent content)
        {
            if (content == null)
            {
                return BooleanResult.CreateErroResult("border can not be null");
            }

            if (content.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var element = Shape.Fill;
                element.Style = eFillStyle.SolidFill;
                element.Color = content.GetColor();
                //element.Transparancy = content.Transparency;

                Shape.TextAlignment = content.Alignment.Horizontal.ToEppTextHorizontalAlignment();

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetFont(FontModel): Try to modify the shape font settings
        /// <summary>
        /// Try to modify the shape font settings.
        /// </summary>
        /// <param name="font">Reference to shape font settings to apply</param>
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
        public IResult SetFont(FontModel font)
        {
            if (font == null)
            {
                return BooleanResult.CreateErroResult("border can not be null");
            }

            try
            {
                Shape.Font.SetFromFont(font.ToFont());

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetPosition(XlsxBaseRange): Try to modify the shape position settings
        /// <summary>
        /// Try to modify the shape position settings.
        /// </summary>
        /// <param name="range">Reference to range position settings to apply</param>
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
                return BooleanResult.CreateErroResult("border can not be null");
            }

            try
            {
                ExcelAddressBase positionAddress = range.ToEppExcelAddress();
                Shape.SetPosition(positionAddress.Start.Row - 1, 0, positionAddress.Start.Column - 1, 0);

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetSize(XlsxBaseSize): Try to modify the shape size settings
        /// <summary>
        /// Try to modify the shape size settings.
        /// </summary>
        /// <param name="size">Reference to shape size settings to apply</param>
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
                return BooleanResult.CreateErroResult("size can not be null");
            }

            try
            {
                Shape.SetSize(size.Width, size.Height);

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetShapeEffects(XlsxShapeEffects, string): Try to modify the shape effects settings
        /// <summary>
        /// Try to modify the shape effects settings.
        /// </summary>
        /// <param name="effects">Reference to shape effects settings to apply</param>
        /// <param name="shapeName">Target shape name</param>
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
        public IResult SetShapeEffects(XlsxShapeEffects effects, string shapeName)
        {
            if (effects == null)
            {
                return BooleanResult.CreateErroResult("size can not be null");
            }

            try
            {
                SetIlluminationEffect(effects.Illumination, shapeName);
                SetShadowEffect(effects.Shadow, shapeName);
                SetReflectionEffect(effects.Reflection, shapeName);
                SetSoftEdgeEffect(effects.SoftEdge, shapeName);

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetShapeStyle(ShapeType): Try to modify the shape style
        /// <summary>
        /// Try to modify the shape style.
        /// </summary>
        /// <param name="style">Reference to shape style to apply</param>
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
        public IResult SetShapeStyle(ShapeType style)
        {
            try
            {
                Shape.Style = style.AsEnumType<eShapeStyle>();

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetText(string): Try to modify the shape text
        /// <summary>
        /// Try to modify the shape text.
        /// </summary>
        /// <param name="text">Reference to text shape to apply</param>
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
        public IResult SetText(string text)
        {
            try
            {
                Shape.Text = text;

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #endregion

        #region private methods

        private IResult SetIlluminationEffect(XlsxIlluminationShapeEffect illumination, string shapeName)
        {
            if (illumination.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var shapeNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:sp/xdr:nvSpPr/xdr:cNvPr[@name='{shapeName}']");
            var root = shapeNode?.ParentNode?.ParentNode;
            if (root == null)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var exist = XmlWriter.TryGetElementFrom(root, "xdr:spPr", out var shapePropertiesNode);
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

        private IResult SetReflectionEffect(XlsxReflectionShapeEffect reflection, string shapeName)
        {
            if (reflection.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var shapeNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:sp/xdr:nvSpPr/xdr:cNvPr[@name='{shapeName}']");
            var root = shapeNode?.ParentNode?.ParentNode;
            if (root == null)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var exist = XmlWriter.TryGetElementFrom(root, "xdr:spPr", out var shapePropertiesNode);
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

        private IResult SetSoftEdgeEffect(XlsxSoftEdgeShapeEffect softEdge, string shapeName)
        {
            if (softEdge.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var shapeNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:sp/xdr:nvSpPr/xdr:cNvPr[@name='{shapeName}']");
            var root = shapeNode?.ParentNode?.ParentNode;
            if (root == null)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var exist = XmlWriter.TryGetElementFrom(root, "xdr:spPr", out var shapePropertiesNode);
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

        private IResult SetShadowEffect(XlsxBaseShadow shadow, string shapeName)
        {
            if (shadow.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var shapeNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:sp/xdr:nvSpPr/xdr:cNvPr[@name='{shapeName}']");
            var root = shapeNode?.ParentNode?.ParentNode;
            if (root == null)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var exist = XmlWriter.TryGetElementFrom(root, "xdr:spPr", out var shapePropertiesNode);
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
}
