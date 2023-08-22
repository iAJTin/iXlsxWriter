
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxRange : ICombinable<XlsxRange>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxRange>.Combine(XlsxRange reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxRange reference)
    {
        if (reference == null)
        {
            return;
        }

        End.Combine(reference.End);
        Start.Combine(reference.Start);
    }
}
