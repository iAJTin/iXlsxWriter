
using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    /// <summary>
    /// Output datetime formats.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    [GeneratedCode("System.Xml", "4.0.30319.17929")]
    public enum KnownDateTimeFormat
    {
        /// <summary>
        /// General date according to the locale specified.
        /// </summary>
        [XmlEnum("General Date")]
        GeneralDatePattern,

        /// <summary>
        /// Short date according to the locale specified.
        /// </summary>
        [XmlEnum("Short Date")]
        ShortDatePattern,

        /// <summary>
        /// Long date according to the locale specified.
        /// </summary>
        [XmlEnum("Long Date")]
        LongDatePattern,

        /// <summary>
        /// Full date according to the locale specified.
        /// </summary>
        [XmlEnum("Full Date")]
        FullDatePattern,

        /// <summary>
        /// RFC1123 date pattern according to the locale specified.
        /// </summary>
        [XmlEnum("RFC1123 Pattern")]
        Rfc1123Pattern,

        /// <summary>
        /// Short time according to the locale specified.
        /// </summary>
        [XmlEnum("Short Time")]
        ShortTimePattern,

        /// <summary>
        /// Long time according to the locale specified.
        /// </summary>
        [XmlEnum("Long Time")]
        LongTimePattern,

        /// <summary>
        /// Month-day according to the locale specified.
        /// </summary>
        [XmlEnum("Month-Day")]
        MonthDayPattern,

        /// <summary>
        /// Year-month according to the locale specified.
        /// </summary>
        [XmlEnum("Year-Month")]
        YearMonthPattern
    }
}
