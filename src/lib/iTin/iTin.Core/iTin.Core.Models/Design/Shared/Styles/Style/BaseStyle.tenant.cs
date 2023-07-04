
namespace iTin.Core.Models.Design.Styles;

public partial class BaseStyle
{
    /// <summary>
    /// Sets the element that owns this <see cref="IStyle"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void ITenant.SetOwner(IOwner reference) => SetOwner(reference);


    /// <summary>
    /// Gets the element that owns this <see cref="IStyle"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IOwner"/> that owns this <see cref="IStyles"/>.
    /// </value>
    public IOwner Owner { get; private set; }


    /// <summary>
    /// Sets the element that owns this <see cref="IStyle"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(IOwner reference)
    {
        Owner = reference;
    }
}
