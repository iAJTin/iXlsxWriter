
using System.ComponentModel;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design;

public partial class BaseDataType : IParent
{
    ///// <summary>
    ///// Creates a new object that is a copy of the current instance.
    ///// </summary>
    ///// <returns>
    ///// A new object that is a copy of this instance.
    ///// </returns>
    //IParent IParent.Parent => Parent;

    ///// <summary>
    ///// Sets the parent element of the element.
    ///// </summary>
    ///// <param name="reference">Reference to parent.</param>
    //void IParent.SetParent(IParent reference) => SetParent((IContent)reference);


    /// <summary>
    /// Gets the parent container of this element
    /// </summary>
    /// <value>
    /// A <see cref="IContent"/> reference that acts as parent of this element.
    /// </value>
    [XmlIgnore]
    [Browsable(false)]
    public IContent Parent { get; private set; }

    /// <summary>
    /// Sets the parent element of the element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    public void SetParent(IContent reference)
    {
        Parent = reference;
    }
}
