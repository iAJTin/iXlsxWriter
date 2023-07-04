
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies the level of smoothing quality that will be used with the TextAntiAliasingQuality property.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownChartGraphicsQuality
{
    /// <summary>
    /// Do not use smoothing.
    /// </summary>
    None,

    /// <summary>
    /// Use smoothing when drawing to graphic primitives such as circles or rectangles.
    /// </summary>
    UseAntiAliasing
}
