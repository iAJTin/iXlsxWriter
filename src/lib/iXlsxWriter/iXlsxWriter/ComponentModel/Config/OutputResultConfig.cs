
using iTin.Utilities.Xlsx.Design.Settings;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// Specialization of <see cref="IXlsxObjectConfig"/> interface.<br/>
    /// Represents configuration information for an object <see cref="XlsxInput"/>.
    /// </summary>
    /// <seealso cref="IXlsxObjectConfig"/>
    public class OutputResultConfig : IXlsxObjectConfig
    {
        #region public static members
        /// <summary>
        /// Defaults configuration. Defaults no zipped output.
        /// </summary>
        public static readonly OutputResultConfig Default = new OutputResultConfig { Zipped = false, AutoFitColumns = true, GlobalSettings = XlsxSettings.Default };

        /// <summary>
        /// Zipped output configuration. This output has been zipped.
        /// </summary>
        public static readonly OutputResultConfig ZippedResult = new OutputResultConfig { Zipped = true, AutoFitColumns = true, GlobalSettings = XlsxSettings.Default };
        #endregion

        #region constructor/s

        #region [public] OutputResultConfig(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResultConfig"/> class.
        /// </summary>
        public OutputResultConfig()
        {
            Zipped = false;
            AutoFitColumns = true;
            GlobalSettings = XlsxSettings.Default;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (bool) AutoFitColumns: Gets or sets a value indicating whether autofit columns
        /// <summary>
        /// Gets or sets a value indicating whether autofit columns
        /// </summary>
        /// <value>
        /// <b>true</b> if autofit columns; otherwise, <b>false</b>.
        /// </value>
        public bool AutoFitColumns { get; set; }
        #endregion 

        #region [public] (bool) Filename: Gets or sets a value thats represents filename if is marked as zipped
        /// <summary>
        /// Gets or sets a value thats represents filename if is marked as zipped
        /// </summary>
        /// <value>
        /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
        /// </value>
        public string Filename { get; set; }
        #endregion 

        #region [public] (XlsxSettings) GlobalSettings: Gets or sets a value containing document settings
        /// <summary>
        /// Gets or sets a value containing document settings. Allows to set the document metadata.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSettings"/> reference containing the document settings.
        /// </value>
        public XlsxSettings GlobalSettings { get; set; }
        #endregion

        #region [public] (bool) Zipped: Gets or sets a value indicating whether compression is allowed
        /// <summary>
        /// Gets or sets a value indicating whether compression is allowed.
        /// </summary>
        /// <value>
        /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
        /// </value>
        public bool Zipped { get; set; }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string than represents the current object.
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

        #endregion
    }
}
