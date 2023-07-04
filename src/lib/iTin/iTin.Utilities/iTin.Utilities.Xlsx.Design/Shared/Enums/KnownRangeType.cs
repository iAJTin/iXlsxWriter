
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
///Defines availables range types.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownRangeType
{
    /// <summary>
    /// String range
    /// </summary>
    String,

    /// <summary>
    /// Excel range
    /// </summary>
    Range,

    /// <summary>
    /// Excel cell range
    /// </summary>
    Point
}
