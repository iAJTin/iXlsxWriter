
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.Models.Design.Enums;

    /// <summary>
    /// Base class for different data types supported.<br />
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
    public partial class BaseDataType : ICloneable
    {
        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (BaseContent) Parent: Parent: Gets the parent element of a element
        /// <summary>
        /// Gets the parent element of a element.
        /// </summary>
        /// <value>
        /// The element that represents the container element of a element.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public XlsxCellContent Parent { get; private set; }
        #endregion

        #region [public] (DataType) Type: Gets a value indicating data type
        /// <summary>
        /// Gets a value indicating data type.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownDataType"/> values.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public KnownDataType Type
        {
            get
            {
                var dataFormatType = GetType().Name;
                switch (dataFormatType)
                {
                    case "CurrencyDataType":
                        return KnownDataType.Currency;

                    case "DateTimeDataType":
                        return KnownDataType.DateTime;

                    case "NumberDataType":
                        return KnownDataType.Numeric;

                    case "PercentageDataType":
                        return KnownDataType.Percentage;

                    case "ScientificDataType":
                        return KnownDataType.Scientific;

                    case "SpecialDataType":
                        return KnownDataType.Special;

                    default:
                        return KnownDataType.Text;
                }
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (BaseDataType) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public BaseDataType Clone()
        {
            switch (Type)
            {
                case KnownDataType.Currency:
                    return ((CurrencyDataType)this).Clone();

                case KnownDataType.DateTime:
                    return ((DateTimeDataType)this).Clone();

                case KnownDataType.Numeric:
                    return ((NumericDataType)this).Clone();

                case KnownDataType.Percentage:
                    return ((PercentageDataType)this).Clone();

                case KnownDataType.Scientific:
                    return ((ScientificDataType)this).Clone();

                default:
                    return ((TextDataType)this).Clone();
            }
        }
        #endregion

        #region [public] (string) GetDataFormat(): Returns data format for a data type.
        /// <summary>
        /// Returns data format for a data type.
        /// </summary>
        /// <returns>
        /// Data format.
        /// </returns>
        public string GetDataFormat()
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
                            currentNumberNegativePattern =
                                currentNumberNegativePattern
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
                            currentNumberNegativePattern =
                                currentNumberNegativePattern
                                    .Replace("-", string.Empty)
                                    .Replace("(", string.Empty)
                                    .Replace(")", string.Empty);
                            numberNegativePatternWithSignBuilder.Append("(");
                            numberNegativePatternWithSignBuilder.Append(currentNumberNegativePattern);
                            numberNegativePatternWithSignBuilder.Append(")");
                            break;

                        case KnownNegativeSign.Brackets:
                            currentNumberNegativePattern =
                                currentNumberNegativePattern
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
                    currentCurrencyPositivePattern =
                        currentCurrencyPositivePattern
                            .Replace("$", culture.NumberFormat.CurrencySymbol)
                            .Replace("n", currencyPositivePattern);

                    var currencyNegativePatternWithSign = new StringBuilder();
                    currentCurrencyNegativePattern =
                        currentCurrencyNegativePattern
                            .Replace("$", culture.NumberFormat.CurrencySymbol)
                            .Replace("n", currencyPositivePattern);
                    switch (currency.Negative.Sign)
                    {
                        case KnownNegativeSign.None:
                            currentCurrencyNegativePattern =
                                currentCurrencyNegativePattern
                                    .Replace("-", string.Empty)
                                    .Replace("(", string.Empty)
                                    .Replace(")", string.Empty);
                            currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                            break;

                        case KnownNegativeSign.Standard:
                            if (currentCurrencyNegativePattern.Contains("-"))
                            {
                                currentCurrencyNegativePattern = currentCurrencyNegativePattern.Replace("-", culture.NumberFormat.NegativeSign);
                            }

                            currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                            break;

                        case KnownNegativeSign.Parenthesis:
                            currentCurrencyNegativePattern =
                                currentCurrencyNegativePattern
                                    .Replace("-", string.Empty)
                                    .Replace("(", string.Empty)
                                    .Replace(")", string.Empty);
                            currencyNegativePatternWithSign.Append("(");
                            currencyNegativePatternWithSign.Append(currentCurrencyNegativePattern);
                            currencyNegativePatternWithSign.Append(")");
                            break;

                        case KnownNegativeSign.Brackets:
                            currentCurrencyNegativePattern =
                                currentCurrencyNegativePattern
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
                        culture = CultureInfo.CreateSpecificCulture(datetime.Locale.GetDescription());
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

                        case KnownDateTimeFormat.YearMonthShortPattern:
                            formatBuilder.Append("MMM yyyy");
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
                    return "@";
                #endregion
            }
        }
        #endregion

        #region [public] (FieldValueInformation) GetFormattedDataValue(string): Returns data value for a data type
        /// <summary>
        /// Returns data format for a data type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Data format.
        /// </returns>
        public FieldValueInformation GetFormattedDataValue(string value)
        {
            var result = new FieldValueInformation
            {
                Value = value,
                Comment = null,
                IsText = false,
                IsNumeric = true,
                IsDateTime = false,
                IsNegative = false,
                IsErrorValue = false,
                FormattedValue = value,
                Style = (XlsxBaseStyle)Parent.Parent,
                NegativeColor = Color.Empty
            };

            var format = GetDataFormat();
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            switch (Type)
            {
                #region Type: Currency
                case KnownDataType.Currency:
                    var currency = (CurrencyDataType)this;

                    if (currency.Locale != KnownCulture.Current)
                    {
                        culture = CultureInfo.GetCultureInfo(currency.Locale.GetDescription());
                    }

                    var isValidNumberValue = decimal.TryParse(value.Replace('.', ','), NumberStyles.Any, culture, out var currencyValue);
                    if (isValidNumberValue)
                    {
                        result.Value = currencyValue;
                        result.FormattedValue = decimal.Parse(currencyValue.ToString(format, culture), culture);
                        if (currencyValue < 0)
                        {
                            result.IsNegative = true;
                            result.NegativeColor = currency.Negative.GetColor();
                        }
                    }
                    else
                    {
                        var error = currency.Error;
                        result.IsErrorValue = true;
                        result.Value = error.Value;
                        result.Comment = error.Comment;
                        result.FormattedValue = error.Value.ToString(format, culture);
                        if (error.Value < 0)
                        {
                            result.IsNegative = true;
                            result.NegativeColor = currency.Negative.GetColor();
                        }
                    }

                    break;
                #endregion

                #region Type: DateTime
                case KnownDataType.DateTime:
                    var datetime = (DateTimeDataType)this;

                    if (datetime.Locale != KnownCulture.Current)
                    {
                        culture = CultureInfo.CreateSpecificCulture(datetime.Locale.GetDescription());
                    }

                    result.IsDateTime = true;
                    result.IsNumeric = false;
                    var isValidDateTimeValue = DateTime.TryParse(value, out var datetimeValue);
                    if (isValidDateTimeValue)
                    {
                        result.Value = datetimeValue;
                        result.FormattedValue = DateTime.Parse(datetimeValue.ToString(format, culture), culture);
                    }
                    else
                    {
                        var error = datetime.Error;                        
                        result.IsErrorValue = true;
                        result.Value = error.Value;
                        result.Comment = error.Comment;
                        result.FormattedValue = error.Value;
                    }
                    break;
                #endregion

                #region Type: Numeric
                case KnownDataType.Numeric:
                    var numeric = (NumericDataType)this;

                    var isValidNumericValue = float.TryParse(value.Replace('.', ','), NumberStyles.Any, culture, out var numericValue);
                    if (isValidNumericValue)
                    {
                        result.Value = numericValue;
                        result.FormattedValue = float.Parse(numericValue.ToString(format, culture), culture);
                        if (numericValue < 0)
                        {
                            result.IsNegative = true;
                            result.NegativeColor = numeric.Negative.GetColor();
                        }
                    }
                    else
                    {
                        var error = numeric.Error;
                        result.IsErrorValue = true;
                        result.Value = error.Value;
                        result.Comment = error.Comment;
                        result.FormattedValue = error.Value.ToString(format, culture);
                        if (error.Value < 0)
                        {
                            result.IsNegative = true;
                            result.NegativeColor = numeric.Negative.GetColor();
                        }
                    }

                    break;
                #endregion

                #region Type: Percentage
                case KnownDataType.Percentage:
                    var percentage = (PercentageDataType)this;

                    var isValidPercentageValue = float.TryParse(value, NumberStyles.Any, culture, out var percentageValue);
                    if (isValidPercentageValue)
                    {
                        result.IsNegative = percentageValue < 0;
                        result.FormattedValue = percentageValue.ToString(format, culture);
                    }
                    else
                    {
                        var error = percentage.Error;
                        result.IsErrorValue = true;
                        result.Value = error.Value;
                        result.Comment = error.Comment;
                        result.FormattedValue = error.Value.ToString(format, culture);
                        if (error.Value < 0)
                        {
                            result.IsNegative = true;
                            ////result.NegativeColor = percentage.Negative.GetColor();
                        }
                    }

                    break;
                #endregion

                #region Type: Scientific
                case KnownDataType.Scientific:
                    var scientific = (ScientificDataType)this;

                    var isValidScientificValue = float.TryParse(value.Replace('.', ','), NumberStyles.Any, culture, out var scientificValue);
                    if (isValidScientificValue)
                    {
                        result.IsNegative = scientificValue < 0;
                        result.FormattedValue = scientificValue.ToString(format, culture);
                    }
                    else
                    {
                        var error = scientific.Error;
                        result.IsErrorValue = true;
                        result.Value = error.Value;
                        result.Comment = error.Comment;
                        result.FormattedValue = error.Value.ToString(format, culture);
                        if (error.Value < 0)
                        {
                            result.IsNegative = true;
                            ////result.NegativeColor = percentage.Negative.GetColor();
                        }
                    }

                    break;
                #endregion

                #region Type: Special
                ////case KnownDataType.Special:
                ////    var special = (SpecialDataTypeModel)this;

                ////    var isDateTimeValue = DateTime.TryParse(value, out datetimeValue);
                ////    if (isDateTimeValue)
                ////    {
                ////        result.Value = datetimeValue;
                ////        result.FormattedValue = datetimeValue.ToString(format);
                ////    }
                ////    else
                ////    {
                ////        var isNumericValue = float.TryParse(value.Replace('.', ','), NumberStyles.Any, culture, out numericValue);
                ////        if (isNumericValue)
                ////        {
                ////            result.Value = numericValue;
                ////            result.FormattedValue = numericValue.ToString(format); ////, culture);
                ////            if (numericValue < 0)
                ////            {
                ////                result.IsNegative = true;
                ////                //// result.NegativeColor = numeric.Negative.GetColor();
                ////            }
                ////        }
                ////    }

                ////    #region old
                ////////    var startWithYear = special.StartsWithYear == YesNo.Yes;

                ////////    var resultBuilder = new StringBuilder();
                ////////    resultBuilder.Clear();
                ////////    resultBuilder.Append(string.Empty);

                ////////    result.IsNumeric = false;
                ////////    switch (specialFormat)
                ////////    {
                ////////        #region Format: ShortDateFormat '99/99/99'
                ////////        case KnownSpecialFormat.ShortDateFormat:
                ////////            if (!string.IsNullOrEmpty(value) &&
                ////////                !value.IsNullOrWhiteSpace() &&
                ////////                !value.Trim().Equals("0"))
                ////////            {
                ////////                var adjustedValue = string.Concat(new string('0', 6), value);
                ////////                adjustedValue = adjustedValue.Substring(adjustedValue.Length - 6, 6);

                ////////                if (startWithYear)
                ////////                {
                ////////                    resultBuilder.Append(adjustedValue.Substring(0, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(2, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(4, 2));
                ////////                }
                ////////                else
                ////////                {
                ////////                    resultBuilder.Append(adjustedValue.Substring(4, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(0, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(2, 2));
                ////////                }
                ////////            }

                ////////            break;
                ////////        #endregion

                ////////        #region Format: LongDateFormat '99/99/9999'
                ////////        case KnownSpecialFormat.LongDateFormat:
                ////////            if (!string.IsNullOrEmpty(value) &&
                ////////                !value.IsNullOrWhiteSpace() &&
                ////////                !value.Trim().Equals("0"))
                ////////            {
                ////////                var adjustedValue = string.Concat(new string('0', 8), value);
                ////////                adjustedValue = adjustedValue.Substring(adjustedValue.Length - 8, 8);

                ////////                if (startWithYear)
                ////////                {
                ////////                    resultBuilder.Append(adjustedValue.Substring(0, 4));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(4, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(6, 2));
                ////////                }
                ////////                else
                ////////                {
                ////////                    resultBuilder.Append(adjustedValue.Substring(0, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(2, 2));
                ////////                    resultBuilder.Append('/');
                ////////                    resultBuilder.Append(adjustedValue.Substring(4, 4));
                ////////                }
                ////////            }

                ////////            break;
                ////////        #endregion
                ////////    }

                ////////    result.FormattedValue = resultBuilder.ToString();
                ////    #endregion

                ////    break;
                #endregion

                #region Type: Text
                case KnownDataType.Text:
                    result.IsText = true;
                    result.IsNumeric = false;
                    break;
                #endregion
            }

            return result;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(BaseDataType): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(BaseDataType reference)
        {
            if (reference == null)
            {
                return;
            }

            switch (Type)
            {
                case KnownDataType.Currency:
                    ((CurrencyDataType)this).Combine((CurrencyDataType)reference);
                    break;

                case KnownDataType.DateTime:
                    ((DateTimeDataType)this).Combine((DateTimeDataType)reference);
                    break;

                case KnownDataType.Numeric:
                    ((NumericDataType)this).Combine((NumericDataType)reference);
                    break;

                case KnownDataType.Percentage:
                    ((PercentageDataType)this).Combine((PercentageDataType)reference);
                    break;
                
                case KnownDataType.Scientific:
                    ((ScientificDataType)this).Combine((ScientificDataType)reference);
                    break;

                case KnownDataType.Text:
                    break;
            }
        }
        #endregion

        #endregion

        #region internal methods

        #region [internal] (void) SetParent(XlsxCellContent): Sets the parent element of the element
        /// <summary>
        /// Sets the parent element of the element.
        /// </summary>
        /// <param name="reference">Reference to parent.</param>
        public void SetParent(XlsxCellContent reference)
        {
            Parent = reference;
        }
        #endregion

        #endregion
    }
}
