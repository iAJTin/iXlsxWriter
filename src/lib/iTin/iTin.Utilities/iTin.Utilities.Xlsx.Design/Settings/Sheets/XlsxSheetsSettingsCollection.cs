
namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines sheets collection settings. Allows to set the document metadata, margins, header, footer, default view, size and orientation.
/// </summary>
public partial class XlsxSheetsSettingsCollection
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxSheetsSettingsCollection"/> class.
    /// </summary>
    public XlsxSheetsSettingsCollection() : base(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxSheetsSettingsCollection"/> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    public XlsxSheetsSettingsCollection(XlsxSettings parent) : base(parent)
    {
    }
}
