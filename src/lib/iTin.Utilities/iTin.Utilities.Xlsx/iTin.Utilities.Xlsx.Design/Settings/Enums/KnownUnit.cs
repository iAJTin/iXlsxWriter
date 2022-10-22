
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Settings
{
    /// <summary>
    /// Defines allowed measure units for <b>xlsx</b> documents.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownUnit
    {
        /// <summary>
        /// Measured in inches.
        /// </summary>
        Inches,

        /// <summary>
        /// Measured in millimeters.
        /// </summary>        
        Millimeters
    }
}
