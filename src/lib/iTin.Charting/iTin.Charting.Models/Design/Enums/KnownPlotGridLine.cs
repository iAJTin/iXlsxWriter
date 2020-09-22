
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies the known plot grid lines.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownPlotGridLine
    {
        /// <summary>
        /// Do not draw major and minor grid lines.
        /// </summary>
        None,

        /// <summary>
        /// Draws major and minor grid lines.
        /// </summary>
        Both,

        /// <summary>
        /// Draws major grid lines.
        /// </summary>
        Major,

        /// <summary>
        /// Draws minor grid lines.
        /// </summary>
        Minor
    }
}
