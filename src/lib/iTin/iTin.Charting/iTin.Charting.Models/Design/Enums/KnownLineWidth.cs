
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies width lines.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownLineWidth
{
    /// <summary>
    /// Hairline.
    /// </summary>
    Hairline,

    /// <summary>
    /// Thin line.
    /// </summary>
    Thin,

    /// <summary>
    /// Medium line.
    /// </summary>
    Medium,

    /// <summary>
    /// Thick line.
    /// </summary>
    Thick
}
