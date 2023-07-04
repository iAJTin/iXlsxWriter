
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design; 

/// <summary>
/// Specifies the alignment of a text string in relation to its container.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownTextAlignment
{
    /// <summary>
    /// Specifies that the text is aligned near the origin position of its container.
    /// </summary>
    Near,

    /// <summary>
    /// Specifies that the text is aligned in the center of its container.
    /// </summary>
    Center,

    /// <summary>
    /// Specifies that the text is aligned away from the source position of its container.
    /// </summary>
    Far
}
