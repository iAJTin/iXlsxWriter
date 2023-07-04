
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContentOptions : BaseOptions
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Show == null &&
        Color == null &&
        Merge == null &&
        Pattern == null &&
        Alignment == null;
}
