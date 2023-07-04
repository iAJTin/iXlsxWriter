
using System;

using iTin.Core;
using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

namespace OfficeOpenXml.Style;

/// <summary>
/// Static class than contains common extension methods for objects of the namespace <see cref="N:OfficeOpenXml.Style"/>.
/// </summary>
internal static class StyleExtensions
{
    #region public static methods

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
            case nameof(XlsxCellStyle):
            {
                var cellStyle = model;
                var hasInheritStyle = !string.IsNullOrEmpty(cellStyle.Inherits);
                if (hasInheritStyle)
                {
                    var inheritStyle = cellStyle.TryGetInheritStyle();
                    cellStyle.Combine(inheritStyle);
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
                    model.Combine(inheritStyle);
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

    #region private static methods

    /// <summary>
    /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to <see cref="ExcelHorizontalAlignment"/>.
    /// </summary>
    /// <param name="alignment">The alignment.</param>
    /// <returns>
    /// A <see cref="ExcelHorizontalAlignment"/> value.
    /// </returns>
    private static ExcelHorizontalAlignment ToEppHorizontalAlignment(this KnownHorizontalAlignment alignment)
    {
        return alignment switch
        {
            KnownHorizontalAlignment.Center => ExcelHorizontalAlignment.Center,
            KnownHorizontalAlignment.Right => ExcelHorizontalAlignment.Right,
            _ => ExcelHorizontalAlignment.Left
        };
    }

    /// <summary>
    /// Converter for <see cref="KnownPatternType"/> enumeration type to <see cref="ExcelFillStyle"/>.
    /// </summary>
    /// <param name="patternType">The pattern style.</param>
    /// <returns>
    /// A <see cref="ExcelFillStyle"/> value.
    /// </returns>
    private static ExcelFillStyle ToEppPatternFillStyle(this KnownPatternType patternType) =>
        patternType switch
        {
            KnownPatternType.Solid => ExcelFillStyle.Solid,
            KnownPatternType.Gray75 => ExcelFillStyle.DarkGray,
            KnownPatternType.Gray50 => ExcelFillStyle.MediumGray,
            KnownPatternType.Gray25 => ExcelFillStyle.LightGray,
            KnownPatternType.Gray125 => ExcelFillStyle.Gray125,
            KnownPatternType.Gray625 => ExcelFillStyle.Gray0625,
            KnownPatternType.HorzStripe => ExcelFillStyle.DarkHorizontal,
            KnownPatternType.VertStripe => ExcelFillStyle.DarkVertical,
            KnownPatternType.ReverseDiagStripe => ExcelFillStyle.DarkDown,
            KnownPatternType.DiagStripe => ExcelFillStyle.DarkUp,
            KnownPatternType.DiagCross => ExcelFillStyle.DarkGrid,
            KnownPatternType.ThickDiagCross => ExcelFillStyle.DarkTrellis,
            KnownPatternType.ThinDiagCross => ExcelFillStyle.LightTrellis,
            KnownPatternType.ThinDiagStripe => ExcelFillStyle.LightUp,
            KnownPatternType.ThinHorzCross => ExcelFillStyle.LightGrid,
            KnownPatternType.ThinHorzStripe => ExcelFillStyle.LightHorizontal,
            KnownPatternType.ThinReverseDiagStripe => ExcelFillStyle.LightDown,
            KnownPatternType.ThinVertStripe => ExcelFillStyle.LightVertical,
            _ => ExcelFillStyle.None
        };

    /// <summary>
    /// Converter for <see cref="KnownVerticalAlignment"/> enumeration type to <see cref="ExcelVerticalAlignment"/>.
    /// </summary>
    /// <param name="alignment">The alignment.</param>
    /// <returns>
    /// A <see cref="ExcelVerticalAlignment"/> value.
    /// </returns>
    private static ExcelVerticalAlignment ToEppVerticalAlignment(this KnownVerticalAlignment alignment) =>
        alignment switch
        {
            KnownVerticalAlignment.Bottom => ExcelVerticalAlignment.Bottom,
            KnownVerticalAlignment.Top => ExcelVerticalAlignment.Top,
            _ => ExcelVerticalAlignment.Center
        };

    #endregion
}
