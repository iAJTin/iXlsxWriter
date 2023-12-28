
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Settings;

/// <summary>
/// Defines the allowed orientations for an xlsx document.
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownDocumentOrientation
{
    /// <summary>
    /// Portrait orientation
    /// </summary>
    Portrait,

    /// <summary>
    /// Landscape orientation 
    /// </summary>
    Landscape
}
