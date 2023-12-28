
namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContent
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxCellContent Clone()
    {
        var cloned = (XlsxCellContent)base.Clone();
        cloned.Merge = Merge?.Clone();
        cloned.Pattern = Pattern?.Clone();
        cloned.DataType = DataType?.Clone();
        cloned.Alignment = Alignment?.Clone();
        cloned.Properties = Properties?.Clone();

        return cloned;
    }
}
