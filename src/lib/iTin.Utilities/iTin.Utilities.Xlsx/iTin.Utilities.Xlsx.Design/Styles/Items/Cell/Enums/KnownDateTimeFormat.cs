
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using iTin.Core.ComponentModel;

    /// <summary>
    /// Specifies content data type.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownDateTimeFormat
    {
        /// <summary>
        /// General date according to the locale specified.
        /// </summary>
        [EnumDescription("General Date")]
        GeneralDatePattern,

        /// <summary>
        /// Short date according to the locale specified.
        /// </summary>
        [EnumDescription("Short Date")]
        ShortDatePattern,

        /// <summary>
        /// Long date according to the locale specified.
        /// </summary>
        [EnumDescription("Long Date")]
        LongDatePattern,

        /// <summary>
        /// Full date according to the locale specified.
        /// </summary>
        [EnumDescription("Full Date")]
        FullDatePattern,

        /// <summary>
        /// RFC1123 date pattern according to the locale specified.
        /// </summary>
        [EnumDescription("RFC1123 Pattern")]
        Rfc1123Pattern,

        /// <summary>
        /// Short time according to the locale specified.
        /// </summary>
        [EnumDescription("Short Time")]
        ShortTimePattern,

        /// <summary>
        /// Long time according to the locale specified.
        /// </summary>
        [EnumDescription("Long Time")]
        LongTimePattern,

        /// <summary>
        /// Month-day according to the locale specified.
        /// </summary>
        [EnumDescription("Month-Day")]
        MonthDayPattern,

        /// <summary>
        /// Year-month according to the locale specified.
        /// </summary>
        [EnumDescription("Year-Month")]
        YearMonthPattern,

        /// <summary>
        /// Year-month short according to the locale specified.
        /// </summary>
        [EnumDescription("Year-Month Short")]
        YearMonthShortPattern
    }
}

