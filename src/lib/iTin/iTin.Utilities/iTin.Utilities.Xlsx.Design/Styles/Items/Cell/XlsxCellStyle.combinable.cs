
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellStyle : ICombinable<XlsxCellStyle>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<XlsxCellStyle>.Combine(XlsxCellStyle reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxCellStyle reference)
    {
        base.Combine(reference);

        Font.Combine(reference.Font);
        Content.Combine(reference.Content);
    }
}
