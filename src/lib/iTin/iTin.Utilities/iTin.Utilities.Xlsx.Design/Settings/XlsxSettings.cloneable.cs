
using System;

namespace iTin.Utilities.Xlsx.Design.Settings;

public partial class XlsxSettings : ICloneable
{
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxSettings Clone()
    {
        var cloned = (XlsxSettings)MemberwiseClone();
        cloned.DocumentSettings = DocumentSettings?.Clone();
        cloned.SheetsSettings = SheetsSettings?.Clone();
        cloned.Properties = Properties?.Clone();

        return cloned;
    }
}
