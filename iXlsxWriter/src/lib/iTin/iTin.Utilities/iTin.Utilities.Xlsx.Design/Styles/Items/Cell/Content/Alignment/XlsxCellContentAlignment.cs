
using System.Diagnostics;

using iTin.Core.Models.Design.Content;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="ContentAlignment"/> class.<br/>
/// Defines a <b>xlsx</b> cell content alignment.
/// </summary>
public partial class XlsxCellContentAlignment
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const KnownVerticalAlignment DefaultVerticalAlignment = KnownVerticalAlignment.Center;


    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxCellContentAlignment"/> class.
    /// </summary>
    public XlsxCellContentAlignment()
    {
        Vertical = DefaultVerticalAlignment;
    }
}
