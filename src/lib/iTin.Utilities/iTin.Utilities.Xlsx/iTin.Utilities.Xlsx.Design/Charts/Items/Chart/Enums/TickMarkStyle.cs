
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    /// <summary>
    /// Defines the position of major and minor tick marks for an axis.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TickMarkStyle
    {
        /// <summary>
        /// No mark.
        /// </summary>
        None,

        /// <summary>
        /// Crosses the axis.
        /// </summary>
        Cross,

        /// <summary>
        /// Inside the axis.
        /// </summary>
        Inside,

        /// <summary>
        /// Outside the axis.
        /// </summary>
        Outside
    }
}
