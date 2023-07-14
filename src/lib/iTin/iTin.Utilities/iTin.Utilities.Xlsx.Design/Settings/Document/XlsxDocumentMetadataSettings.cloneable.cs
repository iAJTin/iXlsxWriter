
using System;
namespace iTin.Utilities.Xlsx.Design.Settings.Document;

public partial class XlsxDocumentMetadataSettings : ICloneable
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
    public XlsxDocumentMetadataSettings Clone()
    {
        var cloned = (XlsxDocumentMetadataSettings) MemberwiseClone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }
}
