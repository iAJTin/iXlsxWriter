
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxInnerShadow
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxInnerShadow Clone()
    {
        var cloned = (XlsxInnerShadow)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
