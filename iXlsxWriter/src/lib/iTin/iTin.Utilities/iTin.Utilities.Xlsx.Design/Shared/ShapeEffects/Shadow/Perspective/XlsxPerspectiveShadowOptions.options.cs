
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPerspectiveShadowOptions : XlsxBaseShadowOptions
{
    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxPerspectiveShadow"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static XlsxPerspectiveShadowOptions Default => new();


    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => 
        base.IsDefault && 
        Size == null;
}
