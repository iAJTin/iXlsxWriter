
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Defines absoute strategy for <see cref="XlsxPoint"/> instances.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum AbsoluteStrategy
{
    /// <summary>
    /// Indicates column and row relatives.
    /// </summary>
    None,

    /// <summary>
    /// Indicates absoute column and row.
    /// </summary>
    Both,

    /// <summary>
    /// Indicates absoute column.
    /// </summary>
    Column,

    /// <summary>
    /// Indicates absoute row.
    /// </summary>
    Row
}
