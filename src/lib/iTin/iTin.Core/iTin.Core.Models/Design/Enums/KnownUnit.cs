
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Core.Models.Design.Enums;

/// <summary>
/// Specifies the measure units.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownUnit
{
    /// <summary>
    /// Measured in inches.
    /// </summary>
    Inches,

    /// <summary>
    /// Measured in millimeters.
    /// </summary>        
    Millimeters
}
