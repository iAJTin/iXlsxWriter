
using System.Globalization;
using System.Text;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// Base class for different data types supported.<br/>
/// Which acts as the base class for different data types.
/// </summary>
/// <remarks>
///   <para>The following table shows different data types.</para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="CurrencyDataType"/></term>
///       <description>Represents currency data type. The currency symbol appears right next to the first digit. You can specify the number of decimal places that you want to use and how you want to display negative numbers.</description>
///     </item>
///     <item>
///       <term><see cref="DateTimeDataType"/></term>
///       <description>Represents date time data field. Displays data field as datetime format. You can specify the output culture.</description>
///     </item>
///     <item>
///       <term><see cref="NumberDataType"/></term>
///       <description>Represents numeric data type. You can specify the number of decimal places that you want to use, whether you want to use a thousands separator, and how you want to display negative numbers.</description>
///     </item>
///     <item>
///       <term><see cref="PercentageDataType"/></term>
///       <description>Represents percentage data type. Displays the result with a percent sign (%). You can specify the number of decimal places to use.</description>
///     </item>
///     <item>
///       <term><see cref="ScientificDataType"/></term>
///       <description>Represents scientific data type. Displays a number in exponential notation, which replaces part of the number with E + n, where E (exponent) multiplies the preceding number by 10 to n. You can specify the number of decimal places you want to use.</description>
///     </item>
///     <item>
///       <term><see cref="SpecialDataType"/></term>
///       <description>Represents special data type. Displays a number as a short date or as a long date.</description>
///     </item>
///     <item>
///       <term><see cref="TextDataType"/></term>
///       <description>Represents text data type. Treats the content as text and displays the content exactly as written, even when numbers are typed.</description>
///     </item>
///   </list>
/// </remarks>
public partial class BaseDataType
{
    #region public readonly properties

    /// <summary>
    /// Gets a value indicating data type.
    /// </summary>
    /// <value>
    /// One of the <see cref="KnownDataType"/> values.
    /// </value>
    public KnownDataType Type
    {
        get
        {
            var dataFormatType = GetType().Name;

            return dataFormatType switch
            {
                nameof(CurrencyDataType) => KnownDataType.Currency,
                nameof(DateTimeDataType) => KnownDataType.DateTime,
                nameof(NumberDataType) => KnownDataType.Numeric,
                nameof(PercentageDataType) => KnownDataType.Percentage,
                nameof(ScientificDataType) => KnownDataType.Scientific,
                //nameof(SpecialDataType) => KnownDataType.Special,
                _ => KnownDataType.Text
            };
        }
    }

    #endregion

    #region public virtual methods
        
    /// <summary>
    /// Returns data format for a data type.
    /// </summary>
    /// <returns>
    /// Data format.
    /// </returns>
    public virtual string GetDataFormat()
    {
        var culture = CultureInfo.CurrentCulture;
        var formatBuilder = new StringBuilder();
        switch (Type)
        {
            #region Type: Numeric
            case KnownDataType.Numeric:
                var number = (NumberDataType)this;
                var numberDecimals = number.Decimals;

                var numberPositivePatternArray = new[] { "n" };
                var numberNegativePatternArray = new[] { "(n)", "-n", "- n", "n-", "n -" };

                var currentNumberPositivePattern = numberPositivePatternArray[0];
                var currentNumberNegativePattern = numberNegativePatternArray[culture.NumberFormat.NumberNegativePattern];

                var numberPositivePatternBuilder = new StringBuilder();
                numberPositivePatternBuilder.Append(number.Separator == YesNo.Yes ? "#,##0" : "##0");
                if (numberDecimals > 0)
                {
                    var digits = new string('0', numberDecimals);
                    numberPositivePatternBuilder.Append(".");
                    numberPositivePatternBuilder.Append(digits);
                }

                var numberPositivePattern = numberPositivePatternBuilder.ToString();
                currentNumberPositivePattern = currentNumberPositivePattern.Replace("n", numberPositivePattern);

                var numberNegativePatternWithSignBuilder = new StringBuilder();
                currentNumberNegativePattern = currentNumberNegativePattern.Replace("n", numberPositivePattern);
                switch (number.Negative.Sign)
                {
                    case KnownNegativeSign.None:
                        currentNumberNegativePattern = currentNumberNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        numberNegativePatternWithSignBuilder.Append(currentNumberNegativePattern);
                        break;

                    case KnownNegativeSign.Standard:
                        if (currentNumberNegativePattern.Contains("-"))
                        {
                            currentNumberNegativePattern = currentNumberNegativePattern.Replace("-", culture.NumberFormat.NegativeSign);
                        }

                        numberNegativePatternWithSignBuilder.Append(currentNumberNegativePattern);
                        break;

                    case KnownNegativeSign.Parenthesis:
                        currentNumberNegativePattern = currentNumberNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        numberNegativePatternWithSignBuilder.Append("(");
                        numberNegativePatternWithSignBuilder.Append(currentNumberNegativePattern);
                        numberNegativePatternWithSignBuilder.Append(")");
                        break;

                    case KnownNegativeSign.Brackets:
                        currentNumberNegativePattern = currentNumberNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        numberNegativePatternWithSignBuilder.Append("[");
                        numberNegativePatternWithSignBuilder.Append(currentNumberNegativePattern);
                        numberNegativePatternWithSignBuilder.Append("]");
                        break;
                }

                currentNumberNegativePattern = numberNegativePatternWithSignBuilder.ToString();

                formatBuilder.Append(currentNumberPositivePattern);
                formatBuilder.Append(";");
                formatBuilder.Append(currentNumberNegativePattern);

                return formatBuilder.ToString();
            #endregion

            #region Type: Currency
            case KnownDataType.Currency:
                var currency = (CurrencyDataType)this;
                var currencyDecimals = currency.Decimals;

                var currencyPositivePatternArray = new[] { "$n", "n$", "$n", "n$" };
                var currencyNegativePatternArray = new[] { "($n)", "-$n", "$-n", "$n-", "(n$)", "-n$", "n-$", "n$-", "-n $", "-$ n", "n $-", "$ n-", "$ -n", "n- $", "($ n)", "(n $)" };

                if (currency.Locale != KnownCulture.Current)
                {
                    //culture = CultureInfo.GetCultureInfo(ExportsModel.GetXmlEnumAttributeFromItem(currency.Locale));
                    culture = CultureInfo.GetCultureInfo(currency.Locale.GetDescription());
                }

                var currentCurrencyPositivePattern = currencyPositivePatternArray[culture.NumberFormat.CurrencyPositivePattern];
                var currentCurrencyNegativePattern = currencyNegativePatternArray[culture.NumberFormat.CurrencyNegativePattern];

                var currencyPositivePatternBuilder = new StringBuilder();
                currencyPositivePatternBuilder.Append("#,##0");
                if (currencyDecimals > 0)
                {
                    var digits = new string('0', currencyDecimals);
                    currencyPositivePatternBuilder.Append(".");
                    currencyPositivePatternBuilder.Append(digits);
                }

                var currencyPositivePattern = currencyPositivePatternBuilder.ToString();
                currentCurrencyPositivePattern = currentCurrencyPositivePattern
                    .Replace("$", culture.NumberFormat.CurrencySymbol)
                    .Replace("n", currencyPositivePattern);

                var currencyNegativePatternWithSign = new StringBuilder();
                currentCurrencyNegativePattern = currentCurrencyNegativePattern
                    .Replace("$", culture.NumberFormat.CurrencySymbol)
                    .Replace("n", currencyPositivePattern);

                switch (currency.Negative.Sign)
                {
                    case KnownNegativeSign.None:
                        currentCurrencyNegativePattern = currentCurrencyNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                        break;

                    case KnownNegativeSign.Standard:
                        if (currentCurrencyNegativePattern.Contains("-"))
                        {
                            currentCurrencyNegativePattern = currentCurrencyNegativePattern
                                .Replace("-", culture.NumberFormat.NegativeSign);
                        }

                        currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                        break;

                    case KnownNegativeSign.Parenthesis:
                        currentCurrencyNegativePattern = currentCurrencyNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        currencyNegativePatternWithSign.Append("(");
                        currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                        currencyNegativePatternWithSign.Append(")");
                        break;

                    case KnownNegativeSign.Brackets:
                        currentCurrencyNegativePattern = currentCurrencyNegativePattern
                            .Replace("-", string.Empty)
                            .Replace("(", string.Empty)
                            .Replace(")", string.Empty);
                        currencyNegativePatternWithSign.Append("[");
                        currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                        currencyNegativePatternWithSign.Append("]");
                        break;
                }

                currentCurrencyNegativePattern = currencyNegativePatternWithSign.ToString();

                formatBuilder.Append(currentCurrencyPositivePattern);
                formatBuilder.Append(";");
                formatBuilder.Append(currentCurrencyNegativePattern);

                return formatBuilder.ToString();
            #endregion

            #region Type: Percentage
            case KnownDataType.Percentage:
                var percent = (PercentageDataType)this;

                formatBuilder.Append("P");
                formatBuilder.Append(percent.Decimals);

                return formatBuilder.ToString();
            #endregion

            #region Type: Scientific
            case KnownDataType.Scientific:
                var scientific = (ScientificDataType)this;

                formatBuilder.Append("E");
                formatBuilder.Append(scientific.Decimals);

                return formatBuilder.ToString();
            #endregion

            #region Type: DateTime
            case KnownDataType.DateTime:
                var datetime = (DateTimeDataType)this;

                if (datetime.Locale != KnownCulture.Current)
                {
                    culture = CultureInfo.GetCultureInfo(datetime.Locale.GetDescription());
                }

                switch (datetime.Format)
                {
                    case KnownDateTimeFormat.GeneralDatePattern:
                        formatBuilder.Append(culture.DateTimeFormat.ShortDatePattern);
                        formatBuilder.Append(" ");
                        formatBuilder.Append(culture.DateTimeFormat.ShortTimePattern);
                        break;

                    case KnownDateTimeFormat.ShortDatePattern:
                        formatBuilder.Append(culture.DateTimeFormat.ShortDatePattern);
                        break;

                    case KnownDateTimeFormat.LongDatePattern:
                        formatBuilder.Append(culture.DateTimeFormat.LongDatePattern);
                        break;

                    case KnownDateTimeFormat.FullDatePattern:
                        formatBuilder.Append(culture.DateTimeFormat.FullDateTimePattern);
                        break;

                    case KnownDateTimeFormat.Rfc1123Pattern:
                        formatBuilder.Append(culture.DateTimeFormat.RFC1123Pattern);
                        break;

                    case KnownDateTimeFormat.ShortTimePattern:
                        formatBuilder.Append(culture.DateTimeFormat.ShortTimePattern);
                        break;

                    case KnownDateTimeFormat.LongTimePattern:
                        formatBuilder.Append(culture.DateTimeFormat.LongTimePattern);
                        break;

                    case KnownDateTimeFormat.MonthDayPattern:
                        formatBuilder.Append(culture.DateTimeFormat.MonthDayPattern);
                        break;

                    case KnownDateTimeFormat.YearMonthPattern:
                        formatBuilder.Append(culture.DateTimeFormat.YearMonthPattern);
                        break;
                }

                return formatBuilder.ToString();
            #endregion

            #region Type: Special
            ////case KnownDataType.Special:
            ////    var special = (SpecialDataTypeModel)this;
            ////    var format = special.Format;

            ////    return string.IsNullOrEmpty(format) 
            ////        ? "@" 
            ////        : format;
            #endregion

            #region Type: Text
            default:
            case KnownDataType.Text:
                return "@";

            #endregion
        }
    }
    #endregion
}
