
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines allowed for header and footer alignments.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownHeaderFooterAlignment
    {
        /// <summary>
        /// Right
        /// </summary>
        Right,

        /// <summary>
        /// Center
        /// </summary>
        Center,

        /// <summary>
        /// Left
        /// </summary>
        Left
    }
}
