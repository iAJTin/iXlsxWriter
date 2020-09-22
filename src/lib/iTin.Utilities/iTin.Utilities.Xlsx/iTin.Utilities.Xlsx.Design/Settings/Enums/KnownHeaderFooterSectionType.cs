
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

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
