
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the allowed document view modes.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownDocumentView
    {
        /// <summary>
        /// 
        /// </summary>
        Normal,

        /// <summary>
        /// 
        /// </summary>
        Design,

        /// <summary>
        /// 
        /// </summary>
        Print,
    }
}
