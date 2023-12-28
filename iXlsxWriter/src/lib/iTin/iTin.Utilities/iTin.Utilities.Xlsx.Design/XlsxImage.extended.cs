
namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> image object.
/// </summary>
public partial class XlsxImage
{
    /// <summary>
    /// Returns a <see cref="string"/> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> that represents this instance.
    /// </returns>
    public override string ToString() => Image == null ? string.Empty : Image.ToString();
}
