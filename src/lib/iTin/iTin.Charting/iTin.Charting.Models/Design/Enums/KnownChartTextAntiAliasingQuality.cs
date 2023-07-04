
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies the level of smoothing quality that will be used with the TextAntiAliasingQuality property.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownChartTextAntiAliasingQuality
{
    /// <summary>
    /// Normal smoothing quality.
    /// </summary>
    Normal,

    /// <summary>
    /// High quality smoothing.
    /// </summary>
    High,

    /// <summary>
    /// Default system smoothing quality.
    /// </summary>
    SystemDefault,
}
