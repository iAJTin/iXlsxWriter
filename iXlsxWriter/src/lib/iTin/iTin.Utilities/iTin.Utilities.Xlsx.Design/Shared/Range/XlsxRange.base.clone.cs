
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxRange
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxRange Clone()
    {
        var cloned = (XlsxRange) MemberwiseClone();
        cloned.End = End.Clone();
        cloned.Start = Start.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
