
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies the orientation of labels on the axis.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownLabelOrientation
{
    /// <summary>
    /// The orientation is automatic.
    /// </summary>
    Automatic,

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
