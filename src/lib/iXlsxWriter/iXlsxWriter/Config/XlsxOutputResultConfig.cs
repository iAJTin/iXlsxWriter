
using iTin.Utilities.Xlsx.Design.Settings;

using iXlsxWriter.Abstractions.Writer.Config;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// Represents configuration information for an object <see cref="XlsxObject"/>.
/// </summary>
/// <seealso cref="IXlsxObjectConfig"/>
/// <seealso cref="IOutputResultConfig"/>
public class XlsxOutputResultConfig : IXlsxObjectConfig, IOutputResultConfig
{
    #region public static members

    /// <summary>
    /// Defaults configuration. Defaults no zipped output.
    /// </summary>
    public static readonly XlsxOutputResultConfig Default = new() { Zipped = false, AutoFitColumns = true, GlobalSettings = XlsxSettings.Default };

    /// <summary>
    /// Zipped output configuration. This output has been zipped.
    /// </summary>
    public static readonly XlsxOutputResultConfig ZippedResult = new() { Zipped = true, AutoFitColumns = true, GlobalSettings = XlsxSettings.Default };

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxOutputResultConfig"/> class.
    /// </summary>
    public XlsxOutputResultConfig()
    {
        Zipped = false;
        AutoFitColumns = true;
        GlobalSettings = XlsxSettings.Default;
    }

    #endregion

    #region interfaces

    #region IOutputResultConfig

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether autofit columns
    /// </summary>
    /// <value>
    /// <b>true</b> if autofit columns; otherwise, <b>false</b>.
    /// </value>
    public bool AutoFitColumns { get; set; }

    /// <summary>
    /// Gets or sets a value thats represents filename if is marked as zipped
    /// </summary>
    /// <value>
    /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
    /// </value>
    public string Filename { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether compression is allowed.
    /// </summary>
    /// <value>
    /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
    /// </value>
    public bool Zipped { get; set; }

    #endregion

    #endregion

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value containing document settings. Allows to set the document metadata.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSettings"/> reference containing the document settings.
    /// </value>
    public XlsxSettings GlobalSettings { get; set; }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString()
        => Zipped
            ? $"Zipped={Zipped}, Filename=\"{Filename}\", AutoFitColumns={AutoFitColumns}"
            : $"Zipped={Zipped}, AutoFitColumns={AutoFitColumns}";

    #endregion
}
