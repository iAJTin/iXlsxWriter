
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies merge orientation 
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownMergeOrientation
    {
        /// <summary>
        /// Indicates a horizontal cell merge.
        /// </summary>
        Horizontal,

        /// <summary>
        /// Indicates a vertical cell merge.
        /// </summary>
        Vertical,
    }
}
