
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
