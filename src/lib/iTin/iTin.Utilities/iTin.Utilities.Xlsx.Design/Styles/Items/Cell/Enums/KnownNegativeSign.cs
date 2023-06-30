
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    /// <summary>
    /// Specifies content data type.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownNegativeSign
    {
        /// <summary>
        /// -value
        /// </summary>
        Standard,

        /// <summary>
        /// value
        /// </summary>
        None,

        /// <summary>
        /// (value)
        /// </summary>
        Parenthesis,

        /// <summary>
        /// [value]
        /// </summary>
        Brackets
    }
}
