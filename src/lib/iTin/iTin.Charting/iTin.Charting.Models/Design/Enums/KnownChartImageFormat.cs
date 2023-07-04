
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Charting.Models.Design;

/// <summary>
/// Specifies the type of graphic image
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum KnownChartImageFormat
{
    /// <summary>
    /// Jpeg file format
    /// </summary>
    Jpeg,

    /// <summary>
    /// Png file format
    /// </summary>
    Png,

    /// <summary>
    /// Bmp file format
    /// </summary>
    Bmp,

    /// <summary>
    /// Tiff file format
    /// </summary>
    Tiff,

    /// <summary>
    /// Gif file format
    /// </summary>
    Gif,

    /// <summary>
    /// Emf file format
    /// </summary>
    Emf
}
