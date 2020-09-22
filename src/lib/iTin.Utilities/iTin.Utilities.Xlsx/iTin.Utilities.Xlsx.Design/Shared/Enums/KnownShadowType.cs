
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///Defines availables shadow types.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownShadowType
    {
        /// <summary>
        /// Inner shadow
        /// </summary>
        Inner,

        /// <summary>
        /// Outer shadow
        /// </summary>
        Outer,

        /// <summary>
        /// Perspective shadow
        /// </summary>
        Perspective
    }
}
