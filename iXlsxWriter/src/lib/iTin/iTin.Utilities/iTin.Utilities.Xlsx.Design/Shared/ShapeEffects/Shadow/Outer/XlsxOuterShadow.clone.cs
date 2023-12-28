
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxOuterShadow 
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxOuterShadow Clone()
    {
        var cloned = (XlsxOuterShadow)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
