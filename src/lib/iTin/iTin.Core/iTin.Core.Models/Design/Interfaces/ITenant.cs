
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic interface that defines an element can be owner another reference.
/// </summary>
public interface ITenant
{
    /// <summary>
    /// Gets the element that owns this instance.
    /// </summary>
    /// <value>
    /// The reference that owns this instance.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    IOwner Owner { get; }

    /// <summary>
    /// Sets the element that owns this instance.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void SetOwner(IOwner reference);
}
