
namespace OfficeOpenXml.Style
{
    using System;

    using iTin.Core;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Styling;

    using iTin.Utilities.Xlsx.Design.Styles;
    using iTin.Utilities.Xlsx.Writer;

    /// <summary>
    /// Static class than contains common extension methods for objects of the namespace <see cref="N:OfficeOpenXml.Style"/>.
    /// </summary>
    internal static class StyleExtensions
    {
        #region public static methods

        #region [public] {static} (void) CreateFromModel(this Border, BorderModel): Fills a Border object with model data
        /// <summary>
        /// Fills a <see cref="Border"/> object with model data.
        /// </summary>
        /// <param name="border"><see cref="Border"/> object.</param>
        /// <param name="model">Border model definition.</param>
        private static void CreateFromModel(this Border border, XlsxStyleBorder model)
        {
            if (model == null)
            {
                return;                               
            }

            switch (model.Position)
            {
                case KnownBorderPosition.Left:
                    border.Left.Style = model.Style.AsEnumType<ExcelBorderStyle>();
                    border.Left.Color.SetColor(model.GetColor());
                    break;

                case KnownBorderPosition.Top:
                    border.Top.Style = model.Style.AsEnumType<ExcelBorderStyle>();
                    border.Top.Color.SetColor(model.GetColor());
                    break;

                case KnownBorderPosition.Right:
                    border.Right.Style = model.Style.AsEnumType<ExcelBorderStyle>();
                    border.Right.Color.SetColor(model.GetColor());
                    break;

                case KnownBorderPosition.Bottom:
                    border.Bottom.Style = model.Style.AsEnumType<ExcelBorderStyle>();
                    border.Bottom.Color.SetColor(model.GetColor());
                    break;
            }
        }
        #endregion

        #region [public] {static} (void) FormatFromModel(this ExcelStyle, StyleModel): Fills a ExcelStyle object with model data
        /// <summary>
        /// Fills a <see cref="ExcelStyle"/> object with model data.
        /// </summary>
        /// <param name="style">A <see cref="ExcelStyle"/> reference.</param>
        /// <param name="model">Style model definition.</param>
        /// <param name="useAlternate"><b>true</b> for use alternate color; Otherwise <b>false</b>.</param>
        /// <exception cref="System.ArgumentNullException">If <paramref name="style"/> is <b>null</b>.</exception>
        /// <exception cref="System.ArgumentNullException">If <paramref name="model"/> is <b>null</b>.</exception>
        public static void FormatFromModel(this ExcelStyle style, XlsxCellStyle model, bool useAlternate = false)
        {
            SentinelHelper.ArgumentNull(style, nameof(style));
            SentinelHelper.ArgumentNull(model, nameof(model));
            
            string concreteStyle = model.GetType().Name;
            switch (concreteStyle)
            {
                case "XlsxCellStyle":
                {
                    var cellStyle = (XlsxCellStyle) model;
                    var hasInheritStyle = !string.IsNullOrEmpty(cellStyle.Inherits);
                    if (hasInheritStyle)
                    {
                        var inheritStyle = cellStyle.TryGetInheritStyle();
                        cellStyle.Combine((XlsxCellStyle)inheritStyle);
                    }

                    style.Font.SetFromFont(cellStyle.Font.ToFont());
                    style.Font.Color.SetColor(cellStyle.Font.GetColor());

                    XlsxCellContent cellContent = cellStyle.Content;
                    style.VerticalAlignment = cellContent.Alignment.Vertical.ToEppVerticalAlignment();
                    style.HorizontalAlignment = cellContent.Alignment.Horizontal.ToEppHorizontalAlignment();
                    style.Numberformat.Format = cellContent.DataType.GetDataFormat().ToEppDataFormat(cellContent.DataType);

                    if (cellContent.Color.Equals(BaseContent.DefaultColor, StringComparison.OrdinalIgnoreCase))
                    {
                        style.Fill.PatternType = ExcelFillStyle.None;
                    }
                    else
                    {
                        style.Fill.PatternType = cellContent.Pattern.PatternType.ToEppPatternFillStyle();
                        if (style.Fill.PatternType != ExcelFillStyle.None)
                        {
                            style.Fill.BackgroundColor.SetColor(useAlternate ? cellContent.GetAlternateColor() : cellContent.GetColor());
                            style.Fill.PatternColor.SetColor(cellContent.Pattern.GetColor());
                        }
                    }

                    foreach (var border in cellStyle.Borders)
                    {
                        style.Border.CreateFromModel(border);
                    }
                }
                break;

                default:
                {  
                    var hasInheritStyle = !string.IsNullOrEmpty(model.Inherits);
                    if (hasInheritStyle)
                    {
                        var inheritStyle = model.TryGetInheritStyle();
                        model.Combine((XlsxCellStyle)inheritStyle);
                    }

                    style.Font.SetFromFont(model.Font.ToFont());
                    style.Font.Color.SetColor(model.Font.GetColor());
                    style.HorizontalAlignment = model.Content.Alignment.Horizontal.ToEppHorizontalAlignment();

                    if (model.Content.Color.Equals(BaseContent.DefaultColor, StringComparison.OrdinalIgnoreCase))
                    {
                        style.Fill.PatternType = ExcelFillStyle.None;
                    }
                    else
                    {
                        style.Fill.BackgroundColor.SetColor(model.Content.GetColor());
                    }

                    foreach (var border in model.Borders)
                    {
                        style.Border.CreateFromModel(border);
                    }
                }
                break;
            }
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (ExcelHorizontalAlignment) ToEppHorizontalAlignment(this KnownHorizontalAlignment): Converter for KnownHorizontalAlignment enumeration type to ExcelHorizontalAlignment
        /// <summary>
        /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to <see cref="ExcelHorizontalAlignment"/>.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>
        /// A <see cref="ExcelHorizontalAlignment"/> value.
        /// </returns>
        private static ExcelHorizontalAlignment ToEppHorizontalAlignment(this KnownHorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case KnownHorizontalAlignment.Center:
                    return ExcelHorizontalAlignment.Center;

                case KnownHorizontalAlignment.Right:
                    return ExcelHorizontalAlignment.Right;

                default:
                    return ExcelHorizontalAlignment.Left;
            }
        }
        #endregion

        #region [private] {static} (ExcelFillStyle) ToEppPatternFillStyle(this KnownPatternType): Converter for KnownPatternType enumeration type to ExcelFillStyle
        /// <summary>
        /// Converter for <see cref="KnownPatternType"/> enumeration type to <see cref="ExcelFillStyle"/>.
        /// </summary>
        /// <param name="patternType">The pattern style.</param>
        /// <returns>
        /// A <see cref="ExcelFillStyle"/> value.
        /// </returns>
        private static ExcelFillStyle ToEppPatternFillStyle(this KnownPatternType patternType)
        {
            switch (patternType)
            {
                case KnownPatternType.Solid:
                    return ExcelFillStyle.Solid;

                case KnownPatternType.Gray75:
                    return ExcelFillStyle.DarkGray;

                case KnownPatternType.Gray50:
                    return ExcelFillStyle.MediumGray;

                case KnownPatternType.Gray25:
                    return ExcelFillStyle.LightGray;

                case KnownPatternType.Gray125:
                    return ExcelFillStyle.Gray125;

                case KnownPatternType.Gray625:
                    return ExcelFillStyle.Gray0625;

                case KnownPatternType.HorzStripe:
                    return ExcelFillStyle.DarkHorizontal;

                case KnownPatternType.VertStripe:
                    return ExcelFillStyle.DarkVertical;

                case KnownPatternType.ReverseDiagStripe:
                    return ExcelFillStyle.DarkDown;

                case KnownPatternType.DiagStripe:
                    return ExcelFillStyle.DarkUp;

                case KnownPatternType.DiagCross:
                    return ExcelFillStyle.DarkGrid;

                case KnownPatternType.ThickDiagCross:
                    return ExcelFillStyle.DarkTrellis;

                case KnownPatternType.ThinDiagCross:
                    return ExcelFillStyle.LightTrellis;

                case KnownPatternType.ThinDiagStripe:
                    return ExcelFillStyle.LightUp;

                case KnownPatternType.ThinHorzCross:
                    return ExcelFillStyle.LightGrid;

                case KnownPatternType.ThinHorzStripe:
                    return ExcelFillStyle.LightHorizontal;

                case KnownPatternType.ThinReverseDiagStripe:
                    return ExcelFillStyle.LightDown;

                case KnownPatternType.ThinVertStripe:
                    return ExcelFillStyle.LightVertical;

                default:
                    return ExcelFillStyle.None;
            }
        }
        #endregion

        #region [private] {static} (ExcelVerticalAlignment) ToEppVerticalAlignment(this KnownVerticalAlignment): Converter for KnownVerticalAlignment enumeration type to ExcelVerticalAlignment
        /// <summary>
        /// Converter for <see cref="KnownVerticalAlignment"/> enumeration type to <see cref="ExcelVerticalAlignment"/>.
        /// </summary>
        /// <param name="alignment">The alignment.</param>
        /// <returns>
        /// A <see cref="ExcelVerticalAlignment"/> value.
        /// </returns>
        private static ExcelVerticalAlignment ToEppVerticalAlignment(this KnownVerticalAlignment alignment)
        {
            switch (alignment)
            {
                case KnownVerticalAlignment.Bottom:
                    return ExcelVerticalAlignment.Bottom;

                case KnownVerticalAlignment.Top:
                    return ExcelVerticalAlignment.Top;

                default:
                    return ExcelVerticalAlignment.Center;
            }
        }
        #endregion

        #endregion
    }
}
