
using System;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

public partial class XlsxSheetsSettingsCollection : ICloneable
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
    public XlsxSheetsSettingsCollection Clone()
    {
        var cloned = new XlsxSheetsSettingsCollection(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (XlsxSheetSettings sheet in this)
        {
            cloned.Add(sheet.Clone());
        }

        return cloned;
    }
}
