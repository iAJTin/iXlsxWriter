
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Sparkline;

using iTin.Core;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Styles;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Settings;
using iTin.Utilities.Xlsx.Design.Settings.Sheets;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

namespace iTin.Utilities.Xlsx.Writer;

/// <summary>
/// Contains common extensions for data model objects.
/// </summary>
internal static class XlsxExtensions
{
    #region public static methods

    /// <summary>
    /// Returns a new excel style from cell style model.<br/>
    /// If style is null returns a default instance.<br/>
    /// If style's name is null or empty returns same input style with random style name.
    /// </summary>
    /// <param name="excel">Excel package</param>
    /// <param name="style">Cell style to create</param>
    /// <returns>
    /// A new <see cref="XlsxCellStyle"/> reference.
    /// </returns>
    public static XlsxCellStyle CreateStyle(this ExcelPackage excel, XlsxCellStyle style)
    {
        var safeStyle = style;
        if (style == null)
        {
            safeStyle = XlsxCellStyle.Default;
            safeStyle.Name = BaseStyle.GenerateRandomStyleName();
        }
        else
        {
            safeStyle.Name = string.IsNullOrEmpty(style.Name) ? BaseStyle.GenerateRandomStyleName() : style.Name;
        }

        excel.Workbook.Styles.CreateFromModel(safeStyle);

        return safeStyle;
    }

    /// <summary>
    /// Returns a new <see cref="ExcelCellBase"/> reference containing the initial range expanded by minichart size.
    /// </summary>
    /// <param name="range">Target range</param>
    /// <param name="size">Minichart size</param>
    /// <returns>
    /// A <see cref="ExcelAddressBase"/> containing the range address.
    /// </returns>
    public static ExcelCellBase Expand(this XlsxBaseRange range, XlsxMiniChartSize size)
    {
        var offsetY = size.VerticalCells == 1 ? 0 : size.VerticalCells - 1;
        var offsetX = size.HorizontalCells == 1 ? 0 : size.HorizontalCells - 1;

        var targetAddress = range.ToEppExcelAddress();
        var address = ExcelCellBase.GetAddress(targetAddress.Start.Row, targetAddress.Start.Column, targetAddress.End.Row + offsetY, targetAddress.End.Column + offsetX);

        return new ExcelAddressBase(address);
    }

    /// <summary>
    /// Returns mini chart serie color.
    /// </summary>
    /// <param name="model">Model.</param>
    /// <returns>
    /// A <see cref="Color"/> structure.
    /// </returns>
    /// <exception cref="ArgumentNullException">The value specified is <c>null</c>.</exception>
    public static Color GetMiniChartSerieColor(this XlsxMiniChartChartType model)
    {
        var result = Color.Transparent;
        return model.Active switch
        {
            MiniChartType.Column => model.Column.Serie.GetColor(),
            MiniChartType.Line => model.Line.Serie.GetColor(),
            MiniChartType.WinLoss => model.WinLoss.Serie.GetColor(),
            _ => result
        };
    }

    /// <summary>
    /// Sets the margins of document from model.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="margins">The margins.</param>
    /// <returns>
    /// An <see cref="ExcelPrinterSettings"/> reference which contains the margins values.
    /// </returns>
    public static ExcelPrinterSettings SetMarginsFromModel(this ExcelPrinterSettings settings, XlsxDocumentMargins margins)
    {
        var units = margins.Units;
        if (units == KnownUnit.Millimeters)
        {
            settings.TopMargin = (decimal)margins.Top * 0.039370m;
            settings.LeftMargin = (decimal)margins.Left * 0.039370m;
            settings.RightMargin = (decimal)margins.Right * 0.039370m;
            settings.BottomMargin = (decimal)margins.Bottom * 0.039370m;
        }
        else
        {
            settings.TopMargin = (decimal)margins.Top;
            settings.LeftMargin = (decimal)margins.Left;
            settings.RightMargin = (decimal)margins.Right;
            settings.BottomMargin = (decimal)margins.Bottom;
        }

        return settings;
    }

    /// <summary>
    /// Updates the sheet header from model.
    /// </summary>
    /// <param name="reference">The sheet header properties.</param>
    /// <param name="header">Header model information.</param>
    /// <returns>
    /// An <see cref="ExcelHeaderFooter"/> reference containing the sheet header.
    /// </returns>
    public static ExcelHeaderFooter SetSheetHeader(this ExcelHeaderFooter reference, XlsxDocumentHeaderFooter header)
    {
        var hasSections = header.Sections.Any();
        if (!hasSections)
        {
            return reference;
        }

        var sections = header.Sections;
        foreach (var section in sections)
        {
            SetSheetHeaderSection(reference, section);
        }

        return reference;
    }

    /// <summary>
    /// Updates the sheet footer from model.
    /// </summary>
    /// <param name="reference">The sheet footer properties.</param>
    /// <param name="footer">Footer model information.</param>
    /// <returns>
    /// An <see cref="ExcelHeaderFooter"/> reference containing the sheet footer.
    /// </returns>
    public static ExcelHeaderFooter SetSheetFooter(this ExcelHeaderFooter reference, XlsxDocumentHeaderFooter footer)
    {
        bool hasSections = footer.Sections.Any();
        if (!hasSections)
        {
            return reference;
        }

        var sections = footer.Sections;
        foreach (var section in sections)
        {
            SetSheetFooterSection(reference, section);
        }

        return reference;
    }

    /// <summary>
    /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to string representation.
    /// </summary>
    /// <param name="alignment">Alignment from model.</param>
    /// <returns>
    /// Alignment as string.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static string ToEppLabelAlignmentString(this KnownHorizontalAlignment alignment) =>
        alignment switch
        {
            KnownHorizontalAlignment.Left => "l",
            KnownHorizontalAlignment.Right => "r",
            _ => "ctr"
        };

    /// <summary>
    /// Gets data format from model.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="modelDataType">Data model.</param>
    /// <returns>
    /// A <see cref="string"/> containing the data format.
    /// </returns>
    public static string ToEppDataFormat(this string format, BaseDataType modelDataType)
    {
        var formatBuilder = new StringBuilder();
        var culture = CultureInfo.CurrentCulture;
        var formatPatternsArray = format.Split(';');

        var dataFormat = modelDataType.Type;
        switch (dataFormat)
        {
            #region Type: Numeric
            case KnownDataType.Numeric:
                var number = (NumberDataType)modelDataType;

                var numberPositivePattern = formatPatternsArray[0];
                var numberNegativePattern = formatPatternsArray[1];

                var numberNegativeColor = number.Negative.GetColor().ToString().Split(' ')[1];
                formatBuilder.Append(numberPositivePattern);
                formatBuilder.Append(";");
                formatBuilder.Append(numberNegativeColor);
                formatBuilder.Append("\\");
                formatBuilder.Append(numberNegativePattern);
                return formatBuilder.ToString();
            #endregion

            #region Type: Currency
            case KnownDataType.Currency:
                var currency = (CurrencyDataType)modelDataType;
                var currencyPositivePattern = formatPatternsArray[0];

                var lcidBuilder = new StringBuilder();
                if (currency.Locale != KnownCulture.Current)
                {
                    culture = CultureInfo.GetCultureInfo(currency.Locale.GetDescription());
                    lcidBuilder.Append("[$-");
                    lcidBuilder.Append(culture.LCID.ToString("X", CultureInfo.InvariantCulture));
                    lcidBuilder.Append("]");
                }

                lcidBuilder.Append(currencyPositivePattern);

                var currencyPositiveFormatPattern = lcidBuilder.ToString().Replace(culture.NumberFormat.CurrencySymbol, culture.NumberFormat.CurrencySymbol);
                formatBuilder.Append(currencyPositiveFormatPattern);

                var color = currency.Negative.GetColor().ToString().Split(' ')[1];
                formatBuilder.Append(";");
                formatBuilder.Append(color);

                switch (currency.Negative.Sign)
                {
                    case KnownNegativeSign.None:
                        formatBuilder.Append(currencyPositiveFormatPattern);
                        break;

                    case KnownNegativeSign.Standard:
                        formatBuilder.Append("-");
                        formatBuilder.Append(currencyPositiveFormatPattern);
                        break;

                    case KnownNegativeSign.Parenthesis:
                        formatBuilder.Append(@"\");
                        formatBuilder.Append("(");
                        formatBuilder.Append(currencyPositiveFormatPattern);
                        formatBuilder.Append(@"\");
                        formatBuilder.Append(")");
                        break;

                    case KnownNegativeSign.Brackets:
                        formatBuilder.Append(@"\");
                        formatBuilder.Append("[");
                        formatBuilder.Append(currencyPositiveFormatPattern);
                        formatBuilder.Append(@"\");
                        formatBuilder.Append("]");
                        break;
                }

                return formatBuilder.ToString();
            #endregion

            #region Type: Percentage
            case KnownDataType.Percentage:
                var percent = (PercentageDataType)modelDataType;

                formatBuilder.Append("###0");
                var percentDecimals = percent.Decimals;
                if (percentDecimals > 0)
                {
                    var digits = new string('0', percentDecimals);
                    formatBuilder.Append(".");
                    formatBuilder.Append(digits);
                }

                formatBuilder.Append("%");

                return formatBuilder.ToString();
            #endregion

            #region Type: Scientific
            case KnownDataType.Scientific:
                var scientific = (ScientificDataType)modelDataType;

                formatBuilder.Append("0");
                var scientificDecimals = scientific.Decimals;
                if (scientificDecimals > 0)
                {
                    var digits = new string('0', scientificDecimals);
                    formatBuilder.Append(".");
                    formatBuilder.Append(digits);
                }

                formatBuilder.Append("E+00");

                return formatBuilder.ToString();
            #endregion

            #region Type: DateTime
            case KnownDataType.DateTime:
                var datetime = (DateTimeDataType)modelDataType;

                if (datetime.Locale != KnownCulture.Current)
                {
                    culture = CultureInfo.GetCultureInfo(datetime.Locale.GetDescription());
                    formatBuilder.Append("[$-");
                    formatBuilder.Append($"{culture.LCID:X}");
                    formatBuilder.Append("]");
                }

                formatBuilder.Append(format.Replace("'", "\""));
                return formatBuilder.ToString();
            #endregion

            #region Type: Text
            default:
                return format;
            #endregion
        }
    }

    /// <summary>
    /// Converter for <see cref="MiniChartEmptyValuesAs"/> enumeration type to <see cref="eDispBlanksAs" />.
    /// </summary>
    /// <param name="reference">How to draw an empty values.</param>
    /// <returns>
    /// A <see cref="eDispBlanksAs"/> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eDispBlanksAs ToEppeDisplayBlanksAs(this MiniChartEmptyValuesAs reference) =>
        reference switch
        {
            MiniChartEmptyValuesAs.Connect => eDispBlanksAs.Span,
            MiniChartEmptyValuesAs.Zero => eDispBlanksAs.Zero,
            _ => eDispBlanksAs.Gap
        };

    /// <summary>
    /// Returns range address.
    /// </summary>
    /// <param name="range">Target range</param>
    /// <returns>
    /// A <see cref="ExcelAddressBase"/> containing the range address.
    /// </returns>
    public static ExcelAddressBase ToEppExcelAddress(this XlsxBaseRange range)
    {
        ExcelAddressBase result = null;

        var rangeType = range.Type;
        switch (rangeType)
        {
            case KnownRangeType.String:
            {
                var target = (XlsxStringRange)range;
                var hasDataRange = !string.IsNullOrEmpty(target.Address);
                if (hasDataRange)
                {
                    result = new ExcelAddressBase(target.Address);
                }
            }
            break;

            case KnownRangeType.Range:
            {
                var target = (XlsxRange)range;
                var address = ExcelCellBase.GetAddress(
                    target.Start.Row,
                    target.Start.Column,
                    target.End.Row,
                    target.End.Column,
                    target.Start.AbsoluteStrategy == AbsoluteStrategy.Both && target.End.AbsoluteStrategy == AbsoluteStrategy.Both);
                result = new ExcelAddressBase(address);
            }
            break;

            case KnownRangeType.Point:
            {
                var target = (XlsxPointRange)range;
                var address = ExcelCellBase.GetAddress(
                    target.Row,
                    target.Column,
                    target.Row,
                    target.Column,
                    target.AbsoluteStrategy == AbsoluteStrategy.Both);

                result = new ExcelAddressBase(address);
            }
            break;
        }

        return result;
    }

    /// <summary>
    /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to <see cref="eTextAlignment"/>.
    /// </summary>
    /// <param name="alignment">Horizontal alignment.</param>
    /// <returns>
    /// A <see cref="eTextAlignment"/> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eTextAlignment ToEppTextHorizontalAlignment(this KnownHorizontalAlignment alignment) =>
        alignment switch
        {
            KnownHorizontalAlignment.Left => eTextAlignment.Left,
            KnownHorizontalAlignment.Center => eTextAlignment.Center,
            KnownHorizontalAlignment.Right => eTextAlignment.Right,
            _ => eTextAlignment.Left
        };

    /// <summary>
    /// Converter for <see cref="KnownLineStyle"/> enumeration type to <see cref="eLineStyle"/>.
    /// </summary>
    /// <param name="style">Line style from model.</param>
    /// <returns>
    /// A <see cref="eLineStyle"/> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eLineStyle ToEppLineStyle(this KnownLineStyle style) =>
        style switch
        {
            KnownLineStyle.Dash => eLineStyle.Dash,
            KnownLineStyle.DashDot => eLineStyle.DashDot,
            KnownLineStyle.DashDotDot => eLineStyle.SystemDashDotDot,
            KnownLineStyle.Dot => eLineStyle.Dot,
            _ => eLineStyle.Solid
        };

    /// <summary>
    /// Converter for <see cref="KnownDocumentOrientation"/> enumeration type to <see cref="eOrientation"/>.
    /// </summary>
    /// <param name="orientation">Orientation value from model.</param>
    /// <returns>
    /// A <see cref="eOrientation" /> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eOrientation ToEppOrientation(this KnownDocumentOrientation orientation) => 
        orientation == KnownDocumentOrientation.Portrait ? eOrientation.Portrait : eOrientation.Landscape;

    /// <summary>
    /// Converter for <see cref="KnownDocumentSize"/> enumeration type to <see cref="ePaperSize"/>.
    /// </summary>
    /// <param name="paper">Paper size value from model.</param>
    /// <returns>
    /// A <see cref="ePaperSize" /> value.
    /// </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static ePaperSize ToEppPaperSize(this KnownDocumentSize paper)
    {
        var paperSize = ePaperSize.A4;
        switch (paper)
        {
            case KnownDocumentSize.A0:
                break;

            case KnownDocumentSize.A1:
                break;

            case KnownDocumentSize.A2:
                paperSize = ePaperSize.A2;
                break;

            case KnownDocumentSize.A3:
                paperSize = ePaperSize.A3;
                break;

            case KnownDocumentSize.A5:
                paperSize = ePaperSize.A5;
                break;

            case KnownDocumentSize.A6:
                break;

            case KnownDocumentSize.A7:
                break;

            case KnownDocumentSize.A8:
                break;

            case KnownDocumentSize.A9:
                break;

            case KnownDocumentSize.A10:
                break;

            case KnownDocumentSize.Executive:
                break;

            case KnownDocumentSize.HalfLetter:
                break;

            case KnownDocumentSize.Letter:
                paperSize = ePaperSize.Letter;
                break;

            case KnownDocumentSize.Note:
                paperSize = ePaperSize.Note;
                break;

            case KnownDocumentSize.PostCard:
                break;
        }

        return paperSize;
    }

    /// <summary>
    /// Sets the appropiate sheet view.
    /// </summary>
    /// <param name="reference">The document view properties.</param>
    /// <param name="view">Document view.</param>
    /// <returns>
    /// An <see cref="ExcelWorksheetView"/> reference which contains the appropiate sheet view.
    /// </returns>
    public static ExcelWorksheetView ToEppSheetView(this ExcelWorksheetView reference, KnownDocumentView view)
    {
        switch (view)
        {
            case KnownDocumentView.Design:
                reference.PageLayoutView = true;
                break;

            case KnownDocumentView.Print:
                reference.PageBreakView = true;
                break;
        }

        return reference;
    }

    /// <summary>
    /// Converter for <see cref="MiniChartType" /> enumeration type to <see cref="eSparklineType"/>.
    /// </summary>
    /// <param name="type">Mini-chart type.</param>
    /// <returns>
    /// A <see cref="eSparklineType" /> value.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static eSparklineType ToEppeSparklineType(this MiniChartType type) =>
        type switch
        {
            MiniChartType.Line => eSparklineType.Line,
            MiniChartType.WinLoss => eSparklineType.Stacked,
            _ => eSparklineType.Column
        };

    #endregion

    #region private static methods

    /// <summary>
    /// Sets the sheet header section from model.
    /// </summary>
    /// <param name="reference">The header sheet properties.</param>
    /// <param name="section">Header section model information.</param>
    /// <returns>
    /// An <see cref="ExcelHeaderFooter"/> reference containing the sheet header section.
    /// </returns>
    private static ExcelHeaderFooter SetSheetHeaderSection(this ExcelHeaderFooter reference, XlsxDocumentHeaderFooterSection section)
    {
        if (string.IsNullOrEmpty(section.Text))
        {
            return reference;
        }

        var header =
            section.Type == KnownHeaderFooterSectionType.Odd
                ? reference.OddHeader
                : reference.EvenHeader;

        var parsedText = OfficeOpenXmlHelper.GetHeaderFooterParsedText(section.Text);

        switch (section.Alignment)
        {
            case KnownHeaderFooterAlignment.Right:
                header.RightAlignedText = parsedText;
                break;

            case KnownHeaderFooterAlignment.Left:
                header.LeftAlignedText = parsedText;
                break;

            default:
            case KnownHeaderFooterAlignment.Center:
                header.CenteredText = parsedText;
                break;
        }

        return reference;
    }

    /// <summary>
    /// Sets the sheet footer from model.
    /// </summary>
    /// <param name="reference">Sheet footer properties.</param>
    /// <param name="section">Footer section model information.</param>
    /// <returns>
    /// An <see cref="ExcelHeaderFooter"/> reference containing the sheet footer section.
    /// </returns>
    private static ExcelHeaderFooter SetSheetFooterSection(this ExcelHeaderFooter reference, XlsxDocumentHeaderFooterSection section)
    {
        if (string.IsNullOrEmpty(section.Text))
        {
            return reference;
        }

        var footer =
            section.Type == KnownHeaderFooterSectionType.Odd
                ? reference.OddFooter
                : reference.EvenFooter;

        var parsedText = OfficeOpenXmlHelper.GetHeaderFooterParsedText(section.Text);

        switch (section.Alignment)
        {
            case KnownHeaderFooterAlignment.Right:
                footer.RightAlignedText = parsedText;
                break;

            case KnownHeaderFooterAlignment.Left:
                footer.LeftAlignedText = parsedText;
                break;

            default:
            case KnownHeaderFooterAlignment.Center:
                footer.CenteredText = parsedText;
                break;
        }

        return reference;
    }

    #endregion
}
