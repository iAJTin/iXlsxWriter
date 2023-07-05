
using System.Linq;

namespace iXlsxWriter;

public partial class XlsxObject
{
    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() => $"Count={Items.Count()}";
}
