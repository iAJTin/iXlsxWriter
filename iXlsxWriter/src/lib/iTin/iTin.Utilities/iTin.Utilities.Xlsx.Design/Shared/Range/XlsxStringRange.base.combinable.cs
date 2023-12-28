
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxStringRange : ICombinable<XlsxStringRange>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxStringRange>.Combine(XlsxStringRange reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxStringRange reference)
    {
        if (reference == null)
        {
            return;
        }

        Address = reference.Address;
    }
}
