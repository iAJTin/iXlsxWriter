
using iTin.Core.Models.Design.Options;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxReflectionShapeEffectOptions : BaseOptions
{
    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Blur == null &&
        Offset == null &&
        Size == null &&
        Show == null &&
        Transparency == null;
}
