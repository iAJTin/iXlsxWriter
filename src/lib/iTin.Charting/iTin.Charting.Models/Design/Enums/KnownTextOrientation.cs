
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Specifies the alignment of a text string in relation to its container.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownTextOrientation
    {
        /// <summary>
        /// Text orientation is determined automatically.
        /// </summary>
        Auto,
        /// <summary>
        /// The text is horizontal.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The text is rotated 90 degrees and is oriented from top to bottom.
        /// </summary>
        Rotated90,

        /// <summary>
        /// The text is rotated 270 degrees and is oriented from bottom to top.
        /// </summary>
        Rotated270
    }
}
