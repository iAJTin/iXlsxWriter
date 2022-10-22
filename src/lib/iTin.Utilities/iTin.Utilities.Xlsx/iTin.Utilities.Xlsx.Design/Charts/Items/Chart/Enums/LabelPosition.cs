
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines the position of labels on the axis.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LabelPosition
    {
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
        NextTo,

        /// <summary>
        /// No labels.
        /// </summary>
        None
    }
}
