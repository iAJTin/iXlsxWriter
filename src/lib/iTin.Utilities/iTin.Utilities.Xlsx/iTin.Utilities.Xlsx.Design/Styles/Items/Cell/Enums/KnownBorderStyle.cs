
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines known cell border styles.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownBorderStyle
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Hair
        /// </summary>
        Hair,

        /// <summary>
        /// Dotted
        /// </summary>
        Dotted,

        /// <summary>
        /// DashDot
        /// </summary>
        DashDot,

        /// <summary>
        /// Thin
        /// </summary>
        Thin,

        /// <summary>
        /// DashDotDot
        /// </summary>
        DashDotDot,

        /// <summary>
        /// Dashed
        /// </summary>
        Dashed,

        /// <summary>
        /// MediumDashDotDot
        /// </summary>
        MediumDashDotDot,

        /// <summary>
        /// MediumDashed
        /// </summary>
        MediumDashed,

        /// <summary>
        /// MediumDashDot
        /// </summary>
        MediumDashDot,

        /// <summary>
        /// Thick
        /// </summary>
        Thick,

        /// <summary>
        /// Medium
        /// </summary>
        Medium,

        /// <summary>
        /// Double
        /// </summary>
        Double,
    }
}
