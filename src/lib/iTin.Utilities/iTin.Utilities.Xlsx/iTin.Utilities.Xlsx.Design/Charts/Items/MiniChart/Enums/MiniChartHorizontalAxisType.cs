
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines mini-chart horizontal axis types
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MiniChartHorizontalAxisType
    {
        /// <summary>
        /// General
        /// </summary>
        General,

        /// <summary>
        /// Date
        /// </summary>
        Date
    }
}
