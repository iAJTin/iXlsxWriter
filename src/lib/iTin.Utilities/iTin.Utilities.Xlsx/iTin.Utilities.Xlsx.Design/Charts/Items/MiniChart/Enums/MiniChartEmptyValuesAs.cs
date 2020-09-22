
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies mini-chart empty values
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MiniChartEmptyValuesAs
    {
        /// <summary>
        /// Gap
        /// </summary>
        Gap,

        /// <summary>
        /// Zero
        /// </summary>
        Zero,

        /// <summary>
        /// Connect
        /// </summary>
        Connect
    }
}
