
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPointRange : ICombinable<XlsxPointRange>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxPointRange>.Combine(XlsxPointRange reference) => Combine(reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxPointRange reference)
    {
        if (reference == null)
        {
            return;
        }

        if (AbsoluteStrategy.Equals(DefaultAbsolute))
        {
            AbsoluteStrategy = reference.AbsoluteStrategy;
        }

        if (Column.Equals(DefaultColumn))
        {
            Column = reference.Column;
        }

        if (Row.Equals(DefaultRow))
        {
            Row = reference.Row;
        }
    }
}
