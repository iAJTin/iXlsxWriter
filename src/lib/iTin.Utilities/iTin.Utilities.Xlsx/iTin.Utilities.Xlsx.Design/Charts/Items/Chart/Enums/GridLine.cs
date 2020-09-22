
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the plot grid lines.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GridLine
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
