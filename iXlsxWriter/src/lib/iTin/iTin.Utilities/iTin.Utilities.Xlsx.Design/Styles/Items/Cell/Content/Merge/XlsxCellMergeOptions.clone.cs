
using System;

namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellMergeOptions : ICloneable
{
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxCellMergeOptions Clone() => (XlsxCellMergeOptions)MemberwiseClone();
}
