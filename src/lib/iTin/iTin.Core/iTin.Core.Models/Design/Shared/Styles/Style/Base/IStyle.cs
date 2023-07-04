
using System;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic style
/// </summary>
public interface IStyle : ICombinable<IStyle>, ICloneable, ITenant, IParent
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    bool IsDefault { get; }

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    [JsonIgnore]
    [XmlIgnore]
    bool IsEmpty { get; }


    /// <summary>
    /// Gets or sets the collection of border properties.
    /// </summary>
    /// <value>
    /// Collection of border properties. Each element defines a border.
    /// </value>
    [JsonProperty("borders")]
    IBorders Borders { get; set; }

    /// <summary>
    /// Gets or sets a reference to the content model.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of as shown the content.
    /// </value>
    [XmlElement]
    [JsonProperty("content")]
    IContent Content { get; set; }

    /// <summary>
    /// Gets or sets the name of parent style.
    /// </summary>
    /// <value>
    /// The name of parent style.
    /// </value>
    [JsonProperty("inherits")]
    string Inherits { get; set; }

    /// <summary>
    /// Gets or sets the name of the style.
    /// </summary>
    /// <value>
    /// The name of the style.
    /// </value>
    [JsonProperty("name")]
    string Name { get; set; }
        

    /// <summary>
    /// Try gets a reference to inherit model.
    /// </summary>
    /// <returns>
    /// An inherit style.
    /// </returns>
    IStyle TryGetInheritStyle();
}