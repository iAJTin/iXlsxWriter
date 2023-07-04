
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models;

/// <summary>
/// Defines a user custom property.
/// </summary>
public partial class Property
{
    /// <summary>
    /// Gets or sets the custom property name.
    /// </summary>
    /// <value>
    /// Property name
    /// </value>
    [XmlAttribute]
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the custom property value.
    /// </summary>
    /// <value>
    /// Property value
    /// </value>
    [XmlAttribute]
    [JsonProperty("value")]
    public string Value { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [XmlIgnore]
    [JsonIgnore]
    public Properties Owner { get; private set; }
}
