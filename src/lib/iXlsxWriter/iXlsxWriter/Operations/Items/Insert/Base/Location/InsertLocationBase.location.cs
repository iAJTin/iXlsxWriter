
using iTin.Utilities.Xlsx.Design.Shared;

namespace iXlsxWriter.Operations.Insert;

public abstract partial class InsertLocationBase : ILocationInsert
{
    /// <summary>
    /// Gets or sets a reference a <see cref="XlsxBaseRange"/> which represents the insert location.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseRange"/> object that contains the insert location.
    /// </value>
    public XlsxBaseRange Location { get; set; }
}
