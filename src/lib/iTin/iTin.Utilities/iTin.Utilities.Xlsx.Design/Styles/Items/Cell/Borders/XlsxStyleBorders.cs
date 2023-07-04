
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Defines the <b>xlsx</b> header or footer sections.
/// </summary>
public partial class XlsxStyleBorders : IBorders
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStyleBorders"/> class.
    /// </summary>
    public XlsxStyleBorders() : base(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStyleBorders"/> class.
    /// </summary>
    public XlsxStyleBorders(XlsxBaseStyle parent) : base(parent)
    {
    }
}
