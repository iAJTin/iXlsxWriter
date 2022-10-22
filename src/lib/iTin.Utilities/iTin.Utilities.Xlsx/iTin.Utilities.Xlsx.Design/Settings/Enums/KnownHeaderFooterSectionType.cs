
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Settings
{
    /// <summary>
    /// Defines allowed for header and footer types.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownHeaderFooterSectionType
    {
        /// <summary>
        /// Odd
        /// </summary>
        Odd,

        /// <summary>
        /// Even
        /// </summary>        
        Even
    }
}
