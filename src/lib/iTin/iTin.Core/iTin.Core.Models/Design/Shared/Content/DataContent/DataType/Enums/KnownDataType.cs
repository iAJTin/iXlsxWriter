
using System;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    /// <summary>
    /// Specifies content data type.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownDataType
    {
        /// <summary>
        /// Numeric data type, please see <see cref="NumericDataType"/> for more information.
        /// </summary>
        Numeric,

        /// <summary>
        /// Text data type, please see <see cref="TextDataType"/> for more information.
        /// </summary>
        Text,

        /// <summary>
        /// Text data type, please see <see cref="PercentageDataType"/> for more information.
        /// </summary>
        Percentage,

        /// <summary>
        /// Scientific data type, please see <see cref="ScientificDataType"/> for more information.
        /// </summary>
        Scientific,

        /// <summary>
        /// Currency data type, please see <see cref="CurrencyDataType"/> for more information.
        /// </summary>
        Currency,

        /// <summary>
        /// Date time data type, please see <see cref="DateTimeDataType" /> for more information.
        /// </summary>
        DateTime,

        /// <summary>
        /// Special data type, please see <see cref="SpecialDataType"/> for more information.
        /// </summary>
        Special
    }
}
