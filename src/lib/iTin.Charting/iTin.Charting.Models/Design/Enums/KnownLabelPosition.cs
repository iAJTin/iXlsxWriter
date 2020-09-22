
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Describes the position of labels on the axis.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownLabelPosition
    {
        /// <summary>
        /// No labels.
        /// </summary>
        None,

        /// <summary>
        /// Top or right side of the chart.
        /// </summary>
        High,

        /// <summary>
        /// Bottom or left side of the chart.
        /// </summary>
        Low,

        /// <summary>
        /// Next to axis.
        /// </summary>
        NextToAxis
    }
}
