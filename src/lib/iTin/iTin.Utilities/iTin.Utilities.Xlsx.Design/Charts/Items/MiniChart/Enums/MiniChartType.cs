
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Specifies mini-chart empty values
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MiniChartType
    {
        /// <summary>
        /// Column mini-chart type
        /// </summary>
        Column,

        /// <summary>
        /// Line mini-chart type
        /// </summary>        
        Line,

        /// <summary>
        /// Win-Loss mini-chart type
        /// </summary>        
        WinLoss
    }
}
