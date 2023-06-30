
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///  Specifies the known location for legend.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownLegendLocation
    {
        /// <summary>
        /// At the top.
        /// </summary>
        Top,

        /// <summary>
        /// At the left.
        /// </summary>
        Left,

        /// <summary>
        /// At the right.
        /// </summary>
        Right,

        /// <summary>
        /// At the bottom.
        /// </summary>
        Bottom,
    }
}
