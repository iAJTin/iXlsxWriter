
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    ///Defines availables size types.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownSizeType
    {
        /// <summary>
        /// Size
        /// </summary>
        Size,

        /// <summary>
        /// Nullable size
        /// </summary>
        NullableSize,

        /// <summary>
        /// Percent
        /// </summary>
        Percent,
    }
}