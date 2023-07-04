
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines the orientation of titles on the axis.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum TextOrientation
{
    /// <summary>
    /// The orientation is downward.
    /// </summary>
    Downward,

    /// <summary>
    /// The orientation is horizontal.
    /// </summary>
    Horizontal,

    /// <summary>
    /// The orientation is upward.
    /// </summary>
    Upward,

    /// <summary>
    /// The orientation is vertical.
    /// </summary>
    Vertical
}
