
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxStringRange
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxStringRange Clone()
    {
        var cloned = (XlsxStringRange)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
