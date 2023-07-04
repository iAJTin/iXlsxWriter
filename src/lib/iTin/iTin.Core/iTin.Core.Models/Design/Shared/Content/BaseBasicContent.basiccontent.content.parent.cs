
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design;

public partial class BaseBasicContent 
{
    ///// <summary>
    ///// Gets the parent element of the element.
    ///// </summary>
    ///// <value>
    ///// The element that represents the container element of the element.
    ///// </value>
    //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
    //IParent IParent.Parent => Parent;


    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public IParent Parent { get; private set; }


    /// <summary>
    /// Sets the parent element of the element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    public void SetParent(IParent reference)
    {
        Parent = reference;
    }
}
