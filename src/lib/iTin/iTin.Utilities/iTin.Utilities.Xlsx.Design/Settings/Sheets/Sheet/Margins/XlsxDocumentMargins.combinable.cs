
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxDocumentMargins : ICombinable<XlsxDocumentMargins>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxDocumentMargins>.Combine(XlsxDocumentMargins reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentMargins reference)
    {
        if (reference == null)
        {
            return;
        }

        if (Bottom.Equals(DefaultBottom))
        {
            Bottom = reference.Bottom;
        }

        if (Left.Equals(DefaultLeft))
        {
            Left = reference.Left;
        }

        if (Right.Equals(DefaultRight))
        {
            Right = reference.Right;
        }

        if (Top.Equals(DefaultTop))
        {
            Top = reference.Top;
        }

        if (Units.Equals(DefaultUnits))
        {
            Units = reference.Units;
        }
    }
}
