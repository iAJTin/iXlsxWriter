
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellPattern : ICombinable<XlsxCellPattern>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference pattern</param>
    void ICombinable<IPattern>.Combine(IPattern reference) => Combine((XlsxCellPattern)reference);


    /// <summary>
    /// Combines this instance with reference pattern.
    /// </summary>
    public virtual void Combine(XlsxCellPattern reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Color.Equals(DefaultColor))
        {
            Color = reference.Color;
        }

        if (PatternType.Equals(DefaultPatternType))
        {
            PatternType = reference.PatternType;
        }
    }
}
