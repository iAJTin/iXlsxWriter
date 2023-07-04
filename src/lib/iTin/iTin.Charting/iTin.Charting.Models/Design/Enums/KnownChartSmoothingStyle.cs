
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies the definition quality of the graph
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownChartSmoothingStyle
{
    /// <summary>
    /// Use custom smoothing when drawing text and graphic primitives such as circles or rectangles.
    /// </summary>
    Custom,

    /// <summary>
    /// Use smoothing when drawing text and graphic primitives such as circles or rectangles.
    /// </summary>
    High,

    /// <summary>
    /// It does not use smoothing when drawing graphic primitives such as circles or rectangles, but allows you to specify the quality of text smoothing in the 'dfdfdf' property of a 'chart' object
    /// </summary>
    Low
}
