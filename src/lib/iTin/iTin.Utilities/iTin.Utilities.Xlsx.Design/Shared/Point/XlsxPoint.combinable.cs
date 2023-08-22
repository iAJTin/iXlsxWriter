
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// Represents a <b>xlsx</b> point.
/// </summary>
public partial class XlsxPoint : ICombinable<XlsxPoint>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference to combine with this instance</param>
    void ICombinable<XlsxPoint>.Combine(XlsxPoint reference) => Combine(reference);

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxPoint reference)
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
