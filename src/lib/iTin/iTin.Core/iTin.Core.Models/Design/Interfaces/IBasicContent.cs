
using Newtonsoft.Json;

using iTin.Core.Models.Design.Content;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic content.
/// </summary>
public interface IBasicContent : IContent, ICombinable<IBasicContent>
{
    /// <summary>
    /// Gets or sets a reference to the content alignment.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of a content alignment.
    /// </value>
    [JsonProperty("alignment")]
    ContentAlignment Alignment { get; set; }
}
