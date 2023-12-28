
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContentAlignmentOptions : BaseOptions
{
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Vertical == null && Horizontal == null;
}
