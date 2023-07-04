
using System;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace iTin.Core.Models.Design.Enums;

/// <summary>
/// Specifies the known element location.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownElementLocation
{
    /// <summary>
    /// Defines element location by coordenates system, please see <see cref="iTin.Core.Models.Design.ByCoordenates" /> for more information.
    /// </summary>
    ByCoordenates,

    /// <summary>
    /// Defines element location by alignment, please see <see cref="iTin.Core.Models.Design.ByAlignment" /> for more information.
    /// </summary>
    ByAlignment
}
