
using iTin.Utilities.Xlsx.Design.Styles;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Acts as base class for insert actions with style.
/// </summary>
public abstract class InsertWithStyleBase : InsertLocationBase
{
    /// <summary>
    /// Gets or sets a reference to data to insert.
    /// </summary>
    /// <value>
    /// A <see cref="object"/> object that contains a reference to data to insert.
    /// </value>
    public object Data { get; set; }

    /// <summary>
    /// Gets or sets a reference to cell style.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyle"/> object that contains a reference to cell style
    /// </value>
    public XlsxCellStyle Style { get; set; }
}
