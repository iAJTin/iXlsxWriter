
using System;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.Models.Design.Enums;

using OfficeOpenXml.Drawing;

using iTin.Utilities.Xlsx.Design.Picture;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

namespace OfficeOpenXml.Helpers
{
    /// <summary>
    /// Allows manipulate an <see cref="ExcelPicture"/> instance.
    /// </summary>
    internal class OfficeOpenPictureWriter
    {
        #region constructor/s

        public OfficeOpenPictureWriter(ExcelPicture picture, ExcelWorksheet worksheet)
        {
            Picture = picture;
            XmlWriter = new XmlDrawingHelper { XmlDocument = worksheet.Drawings.DrawingXml};
        }

        #endregion

        #region public readonly methods

        public ExcelPicture Picture { get; }

        public ExcelWorksheet Worksheet { get; }

        public XmlDrawingHelper XmlWriter { get; }

        #endregion

        #region public methods

        #region [public] (IResult) SetBorder(XlsxBorder): Try to modify the chart size settings
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
                var element = Picture.Border;
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

        #region [public] (IResult) SetContent(XlsxPictureContent): Try to modify the picture content settings
        /// <summary>
        /// Try to modify the picture content settings.
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
        public IResult SetContent(XlsxPictureContent content)
        {
            if (content == null)
            {
                return BooleanResult.CreateErrorResult("border can not be null");
            }

            if (content.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            try
            {
                var element = Picture.Fill;
                element.Style = eFillStyle.SolidFill;
                element.Color = content.GetColor();
                //element.Transparancy = content.Transparency;

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetPosition(XlsxBaseRange): Try to modify the picture position settings
        /// <summary>
        /// Try to modify the picture position settings.
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
                return BooleanResult.CreateErrorResult("border can not be null");
            }

            try
            {
                ExcelAddressBase positionAddress = range.ToEppExcelAddress();
                Picture.SetPosition(positionAddress.Start.Row - 1, 0, positionAddress.Start.Column - 1, 0);

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetSize(XlsxBaseSize): Try to modify the picture size settings
        /// <summary>
        /// Try to modify the picture size settings.
        /// </summary>
        /// <param name="size">Reference to picture size settings to apply</param>
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
        public IResult SetSize(XlsxBaseSize size)
        {
            if (size == null)
            {
                return BooleanResult.CreateErrorResult("size can not be null");
            }

            try
            {
                switch (size.Type)
                {
                    case KnownSizeType.Percent:
                        Picture.SetSize((int)((XlsxPercentSize)size).Value);
                        break;

                    case KnownSizeType.NullableSize:
                        var nullableSize = (XlsxNullableSize)size;
                        var hasWidth = nullableSize.Width.HasValue;
                        var hasHeight = nullableSize.Height.HasValue;

                        if (!hasWidth && hasHeight)
                        {
                            Picture.SetSize(Picture.Image.Width, nullableSize.Height.Value);
                        }
                        else if (hasWidth && !hasHeight)
                        {
                            Picture.SetSize(nullableSize.Width.Value, Picture.Image.Height);
                        }
                        else if (hasWidth && hasHeight)
                        {
                            Picture.SetSize(nullableSize.Width.Value, nullableSize.Height.Value);
                        }

                        break;

                    default:
                    case KnownSizeType.Size:
                        Picture.SetSize(((XlsxSize)size).Width, ((XlsxSize)size).Height);
                        break;
                }

                return BooleanResult.SuccessResult;
            }
            catch (Exception e)
            {
                return BooleanResult.FromException(e);
            }
        }
        #endregion

        #region [public] (IResult) SetShapeEffects(XlsxShapeEffects, string): Try to modify the picture shape effects settings
        /// <summary>
        /// Try to modify the picture shape effects settings.
        /// </summary>
        /// <param name="effects">Reference to chart shape effects settings to apply</param>
        /// <param name="pictureName">Target picture name</param>
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
        public IResult SetShapeEffects(XlsxShapeEffects effects, string pictureName)
        {
            if (effects == null)
            {
                return BooleanResult.CreateErrorResult("size can not be null");
            }

            try
            {
                SetIlluminationEffect(effects.Illumination, pictureName);
                SetShadowEffect(effects.Shadow, pictureName);
                SetReflectionEffect(effects.Reflection, pictureName);
                SetSoftEdgeEffect(effects.SoftEdge, pictureName);

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
        
        private IResult SetIlluminationEffect(XlsxIlluminationShapeEffect illumination, string pictureName)
        {
            if (illumination.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var pictureNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:pic/xdr:nvPicPr/xdr:cNvPr[@name='{pictureName}']");
            var root = pictureNode?.ParentNode?.ParentNode;
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

        private IResult SetReflectionEffect(XlsxReflectionShapeEffect reflection, string pictureName)
        {
            if (reflection.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var pictureNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:pic/xdr:nvPicPr/xdr:cNvPr[@name='{pictureName}']");
            var root = pictureNode?.ParentNode?.ParentNode;
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

        private IResult SetSoftEdgeEffect(XlsxSoftEdgeShapeEffect softEdge, string pictureName)
        {
            if (softEdge.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var pictureNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:pic/xdr:nvPicPr/xdr:cNvPr[@name='{pictureName}']");
            var root = pictureNode?.ParentNode?.ParentNode;
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

        private IResult SetShadowEffect(XlsxBaseShadow shadow, string pictureName)
        {
            if (shadow.Show == YesNo.No)
            {
                return BooleanResult.SuccessResult;
            }

            var pictureNode = XmlWriter.GetXmlNode($"xdr:wsDr/xdr:twoCellAnchor/xdr:pic/xdr:nvPicPr/xdr:cNvPr[@name='{pictureName}']");
            var root = pictureNode?.ParentNode?.ParentNode;
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
