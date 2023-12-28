
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContentAlignment : ICombinable<XlsxCellContentAlignment>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxCellContentAlignment reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);

        if (Vertical.Equals(DefaultVerticalAlignment))
        {
            Vertical = reference.Vertical;
        }
    }
}
