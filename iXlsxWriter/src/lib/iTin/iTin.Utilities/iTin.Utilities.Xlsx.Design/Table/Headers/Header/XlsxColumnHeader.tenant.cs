
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

public partial class XlsxColumnHeader
{
    /// <summary>
    /// Sets the element that owns this <see cref="IColumnHeader"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void ITenant.SetOwner(IOwner reference) => SetOwner(reference);


    /// <summary>
    /// Gets the element that owns this <see cref="IColumnHeader"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IOwner"/> that owns this <see cref="IColumnsHeaders"/>.
    /// </value>
    public IOwner Owner { get; private set; }


    /// <summary>
    /// Sets the element that owns this <see cref="IColumnHeader"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(IOwner reference)
    {
        Owner = reference;
    }
}
