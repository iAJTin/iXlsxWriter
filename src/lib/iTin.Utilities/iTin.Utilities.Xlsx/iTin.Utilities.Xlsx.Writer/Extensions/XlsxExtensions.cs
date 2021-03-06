﻿
namespace iTin.Utilities.Xlsx.Writer
{
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
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Styling;

    using Design.Charts;
    using Design.Shared;
    using Design.Settings;
    using Design.Settings.Sheets;
    using Design.Styles;

    /// <summary>
    /// Contains common extensions for data model objects.
    /// </summary>
    internal static class XlsxExtensions
    {
        #region public static methods

        #region [public] {static} (XlsxCellStyle) CreateStyle(this ExcelPackage, XlsxCellStyle): Returns a new excel style from cell style model
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

        #endregion

        #region [public] {static} (ExcelCellBase) Expand(this XlsxBaseRange, XlsxMiniChartSize): Returns a new ExcelCellBase reference containig the initial range expanded by minichart size
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
            int offsetY = size.VerticalCells == 1 ? 0 : size.VerticalCells - 1;
            int offsetX = size.HorizontalCells == 1 ? 0 : size.HorizontalCells - 1;

            var targetAddress = range.ToEppExcelAddress();
            var address = ExcelCellBase.GetAddress(targetAddress.Start.Row, targetAddress.Start.Column, targetAddress.End.Row + offsetY, targetAddress.End.Column + offsetX);

            return new ExcelAddressBase(address);
        }
        #endregion

        #region [public] {static} (Color) GetMiniChartSerieColor(this XlsxMiniChartChartType): Returns mini chart serie color
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
            SentinelHelper.ArgumentNull(model, nameof(model));

            var result = Color.Transparent;
            switch (model.Active)
            {
                case MiniChartType.Column:
                    return model.Column.Serie.GetColor();

                case MiniChartType.Line:
                    return model.Line.Serie.GetColor();

                case MiniChartType.WinLoss:
                    return model.WinLoss.Serie.GetColor();
            }

            return result;
        }
        #endregion

        #region [public] {static} (ExcelPrinterSettings) SetMarginsFromModel(this ExcelPrinterSettings, XlsxDocumentMargins): Sets the margins of document from model
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
            SentinelHelper.ArgumentNull(settings, nameof(settings));
            SentinelHelper.ArgumentNull(margins, nameof(margins));

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
        #endregion

        #region [public] {static} (ExcelHeaderFooter) SetSheetHeader(this ExcelHeaderFooter, XlsxDocumentHeaderFooter): Updates the sheet header from model
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
            SentinelHelper.ArgumentNull(reference, nameof(reference));
            SentinelHelper.ArgumentNull(header, nameof(header));

            bool hasSections = header.Sections.Any();
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
        #endregion

        #region [public] {static} (OfficeProperties) SetSheetFooter(this ExcelHeaderFooter, XlsxDocumentHeaderFooter): Updates the sheet footer from model
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
            SentinelHelper.ArgumentNull(reference, nameof(reference));
            SentinelHelper.ArgumentNull(footer, nameof(footer));

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
        #endregion

        #region [public] {static} (string) ToEppLabelAlignmentString(this KnownHorizontalAlignment): Converter for KnownHorizontalAlignment enumeration type to string representation
        /// <summary>
        /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to string representation.
        /// </summary>
        /// <param name="alignment">Alignment from model.</param>
        /// <returns>
        /// Alignment as string.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static string ToEppLabelAlignmentString(this KnownHorizontalAlignment alignment)
        {
            SentinelHelper.IsEnumValid(alignment);

            switch (alignment)
            {
                case KnownHorizontalAlignment.Left:
                    return "l";

                case KnownHorizontalAlignment.Right:
                    return "r";

                default:
                    return "ctr";
            }
        }
        #endregion

        #region [public] {static} (string) ToEppDataFormat(this string, BaseDataType): Gets data format from model
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
            SentinelHelper.ArgumentNull(modelDataType, nameof(modelDataType));

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
        #endregion

        #region [public] {static} (eDispBlanksAs) ToEppeDispBlanksAs(this MiniChartEmptyValuesAs): Converter for MiniChartEmptyValuesAs enumeration type to eDispBlanksAs
        /// <summary>
        /// Converter for <see cref="MiniChartEmptyValuesAs"/> enumeration type to <see cref="eDispBlanksAs" />.
        /// </summary>
        /// <param name="reference">How to draw an empty values.</param>
        /// <returns>
        /// A <see cref="eDispBlanksAs"/> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static eDispBlanksAs ToEppeDisplayBlanksAs(this MiniChartEmptyValuesAs reference)
        {
            SentinelHelper.IsEnumValid(reference);

            switch (reference)
            {
                case MiniChartEmptyValuesAs.Connect:
                    return eDispBlanksAs.Span;

                case MiniChartEmptyValuesAs.Zero:
                    return eDispBlanksAs.Zero;

                default:
                    return eDispBlanksAs.Gap;
            }
        }
        #endregion

        #region [public] {static} (ExcelAddressBase) ToEppExcelAddress(thisXlsxBaseRange): Returns range address
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

            KnownRangeType rangeType = range.Type;
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
        #endregion

        #region [public] {static} (eTextAlignment) ToEppTextHorizontalAlignment(this KnownHorizontalAlignment): Converter for KnownHorizontalAlignment enumeration type to eTextAlignment
        /// <summary>
        /// Converter for <see cref="KnownHorizontalAlignment"/> enumeration type to <see cref="eTextAlignment"/>.
        /// </summary>
        /// <param name="alignment">Horizontal alignment.</param>
        /// <returns>
        /// A <see cref="eTextAlignment"/> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static eTextAlignment ToEppTextHorizontalAlignment(this KnownHorizontalAlignment alignment)
        {
            SentinelHelper.IsEnumValid(alignment);

            switch (alignment)
            {
                case KnownHorizontalAlignment.Left:
                    return eTextAlignment.Left;

                case KnownHorizontalAlignment.Center:
                    return eTextAlignment.Center;

                case KnownHorizontalAlignment.Right:
                    return eTextAlignment.Right;

                default:
                    return eTextAlignment.Left;
            }
        }
        #endregion

        #region [public] {static} (eLineStyle) ToEppLineStyle(this KnownLineStyle): Converter for KnownLineStyle enumeration type to eLineStyle
        /// <summary>
        /// Converter for <see cref="KnownLineStyle"/> enumeration type to <see cref="eLineStyle"/>.
        /// </summary>
        /// <param name="style">Line style from model.</param>
        /// <returns>
        /// A <see cref="eLineStyle"/> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static eLineStyle ToEppLineStyle(this KnownLineStyle style)
        {
            SentinelHelper.IsEnumValid(style);

            switch (style)
            {
                case KnownLineStyle.Dash:
                    return eLineStyle.Dash;

                case KnownLineStyle.DashDot:
                    return eLineStyle.DashDot;

                case KnownLineStyle.DashDotDot:
                    return eLineStyle.SystemDashDotDot;

                case KnownLineStyle.Dot:
                    return eLineStyle.Dot;

                default:
                    return eLineStyle.Solid;
            }
        }
        #endregion

        #region [public] {static} (eOrientation) ToEppOrientation(this KnownDocumentOrientation): Converter for KnownDocumentOrientation enumeration type to eOrientation.
        /// <summary>
        /// Converter for <see cref="KnownDocumentOrientation"/> enumeration type to <see cref="eOrientation"/>.
        /// </summary>
        /// <param name="orientation">Orientation value from model.</param>
        /// <returns>
        /// A <see cref="eOrientation" /> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static eOrientation ToEppOrientation(this KnownDocumentOrientation orientation)
        {
            SentinelHelper.IsEnumValid(orientation);

            return orientation == KnownDocumentOrientation.Portrait ? eOrientation.Portrait : eOrientation.Landscape;
        }
        #endregion

        #region [public] {static} (ePaperSize) ToEppPaperSize(this KnownDocumentSize): Converter for KnownDocumentSize enumeration type to ePaperSize.
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
            SentinelHelper.IsEnumValid(paper);

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
        #endregion

        #region [public] {static} (ExcelWorksheetView) ToEppSheetView(this ExcelWorksheetView, KnownDocumentView): Sets the appropiate sheet view
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
            SentinelHelper.ArgumentNull(reference, nameof(reference));

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
        #endregion

        #region [public] {static} (eSparklineType) ToEppeSparklineType(this MiniChartType): Converter for MiniChartType enumeration type to eSparklineType
        /// <summary>
        /// Converter for <see cref="MiniChartType" /> enumeration type to <see cref="eSparklineType"/>.
        /// </summary>
        /// <param name="type">Mini-chart type.</param>
        /// <returns>
        /// A <see cref="eSparklineType" /> value.
        /// </returns>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        public static eSparklineType ToEppeSparklineType(this MiniChartType type)
        {
            SentinelHelper.IsEnumValid(type);

            switch (type)
            {

                case MiniChartType.Line:
                    return eSparklineType.Line;

                case MiniChartType.WinLoss:
                    return eSparklineType.Stacked;

                default:
                    return eSparklineType.Column;
            }
        }
        #endregion

        #endregion

        #region private static methods

        #region [private] {static} (ExcelHeaderFooter) SetSheetHeaderSection(this ExcelHeaderFooter, DocumentHeaderFooterModel): Sets the sheet header section from model
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
            SentinelHelper.ArgumentNull(reference, nameof(reference));
            SentinelHelper.ArgumentNull(section, nameof(section));

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
        #endregion

        #region [private] {static} (ExcelHeaderFooter) SetSheetFooterSection(this ExcelHeaderFooter, DocumentHeaderFooterModel): Sets the sheet footer from model
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
            SentinelHelper.ArgumentNull(reference, nameof(reference));
            SentinelHelper.ArgumentNull(section, nameof(section));

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

        #endregion
    }
}
