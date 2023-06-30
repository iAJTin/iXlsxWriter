
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies width lines.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownLineWidth
    {
        /// <summary>
        /// Hairline.
        /// </summary>
        Hairline,

        /// <summary>
        /// Thin line.
        /// </summary>
        Thin,

        /// <summary>
        /// Medium line.
        /// </summary>
        Medium,

        /// <summary>
        /// Thick line.
        /// </summary>
        Thick
    }
}
