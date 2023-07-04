
using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic horizonal content alignment.
/// </summary>
public interface IHorizontalAlignment
{
    /// <summary>
    /// Gets or sets preferred horizontal alignment.
    /// </summary>
    /// <value>
    /// Preferred horizontal alignment.
    /// </value>
    [JsonProperty("horizontal")]
    KnownHorizontalAlignment Horizontal { get; set; }
}
