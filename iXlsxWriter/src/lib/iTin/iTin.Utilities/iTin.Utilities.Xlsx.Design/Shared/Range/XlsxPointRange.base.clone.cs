
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPointRange 
{ 
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxPointRange Clone()
    {
        var cloned = (XlsxPointRange)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
