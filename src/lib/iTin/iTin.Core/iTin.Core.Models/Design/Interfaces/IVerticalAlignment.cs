
using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic vertical content alignment.
/// </summary>
public interface IVerticalAlignment
{
    /// <summary>
    /// Gets or sets preferred vertical alignment.
    /// </summary>
    /// <value>
    /// Preferred vertical alignment.
    /// </value>
    [JsonProperty("vertical")]
    KnownVerticalAlignment Vertical { get; set; }
}
