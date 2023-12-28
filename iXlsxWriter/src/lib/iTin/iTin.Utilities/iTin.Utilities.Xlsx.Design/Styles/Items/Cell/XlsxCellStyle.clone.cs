
namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="XlsxBaseStyle"/> class.<br/>
/// Defines a <b>xlsx</b> cell style.
/// </summary>
public partial class XlsxCellStyle
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxCellStyle Clone()
    {
        var cloned = (XlsxCellStyle)base.Clone();
        cloned.Font = Font.Clone();
        cloned.Borders = Borders.Clone();
        cloned.Content = Content.Clone();
        cloned.Borders = Borders.Clone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }
}
