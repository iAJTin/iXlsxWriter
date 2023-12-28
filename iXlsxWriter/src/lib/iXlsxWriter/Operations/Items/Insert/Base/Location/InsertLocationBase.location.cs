
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

    /// <summary>
    /// Gets a value indicating whether to check that the name is not null or empty.
    /// </summary>
    /// <value>
    /// <b>true</b> if check name; otherwise, <b>false</b>.
    /// </value>
    public virtual bool CheckSheetName => true;
}
