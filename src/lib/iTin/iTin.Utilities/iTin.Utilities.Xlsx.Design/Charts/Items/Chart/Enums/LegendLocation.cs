
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines known locations for a legend.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LegendLocation
    {
        /// <summary>
        /// The top
        /// </summary>
        Top,

        /// <summary>
        /// The left
        /// </summary>
        Left,

        /// <summary>
        /// The right
        /// </summary>
        Right,

        /// <summary>
        /// The bottom
        /// </summary>
        Bottom,

        /// <summary>
        /// The top right
        /// </summary>
        TopRight,
    }
}
