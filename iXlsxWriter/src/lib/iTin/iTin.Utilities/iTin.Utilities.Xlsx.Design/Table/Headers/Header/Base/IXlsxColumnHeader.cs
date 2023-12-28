
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Table.Headers.Header;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

/// <summary>
/// Defines a xlsx column header
/// </summary>
public interface IXlsxColumnHeader : IColumnHeader
{
    /// <summary>
    /// 
    /// </summary>
    public XlsxColumnHeaderGroup Group { get; set; }
}
