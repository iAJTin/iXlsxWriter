
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPerspectiveShadow
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxPerspectiveShadow Clone()
    {
        var cloned = (XlsxPerspectiveShadow)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
