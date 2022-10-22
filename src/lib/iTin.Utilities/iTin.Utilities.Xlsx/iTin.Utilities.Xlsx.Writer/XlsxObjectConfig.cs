
using System.Diagnostics;

using iTin.Utilities.Xlsx.Writer.ComponentModel;

namespace iTin.Utilities.Xlsx.Writer
{
    /// <summary>
    /// Specialization of <see cref="IXlsxObjectConfig"/> interface.<br/>
    /// Represents configuration information for an object <see cref="XlsxObject"/>.
    /// </summary>
    /// <seealso cref="IXlsxObjectConfig"/>
    public sealed class XlsxObjectConfig : IXlsxObjectConfig
    {
        #region public constants
        /// <summary>
        /// Defines a one-megabyte in bytes.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public const long OneMegaByte = 1048576;
        #endregion

        #region public static members
        /// <summary>
        /// Defaults configuration. Use index and delete the physical files after merge.
        /// </summary>
        public static readonly XlsxObjectConfig Default = new XlsxObjectConfig();
        #endregion

        #region constructor/s

        #region [public] XlsxObjectConfig(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxObjectConfig"/> class.
        /// </summary>
        public XlsxObjectConfig()
        {
            UseIndex = true;
            AllowCompression = false;
            CompressionThreshold = int.MinValue;
            DeletePhysicalFilesAfterMerge = true;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (bool) AllowCompression: Gets or sets a value indicating whether compression is allowed
        /// <summary>
        /// Gets or sets a value indicating whether compression is allowed.
        /// </summary>
        /// <value>
        /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
        /// </value>
        public bool AllowCompression { get; set; }
        #endregion 

        #region [public] (float) CompressionThreshold: Gets or sets a value that establishes the threshold from which the output stream will be compressed, this value will be set to MB, remember that a MB equals 1.024 bytes
        /// <summary>
        /// Gets or sets a value that establishes the threshold from which the output stream will be compressed, this value will be set to <b>MB</b>, remember that a <b>MB</b> equals 1.024 Bytes.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> that contains compression threshold in <b>MB</b>.
        /// </value>
        public float CompressionThreshold { get; set; }
        #endregion

        #region [public] (bool) DeletePhysicalFilesAfterMerge: Gets or sets a value indicating whether delete physical files after merge
        /// <summary>
        /// Gets or sets a value indicating whether delete physical files after merge.
        /// </summary>
        /// <value>
        /// <b>true</b> if delete physical files after merge; otherwise, <b>false</b>.
        /// </value>
        public bool DeletePhysicalFilesAfterMerge { get; set; }
        #endregion

        #region [public] (bool) UseIndex: Gets or sets a value indicating whether use index
        /// <summary>
        /// Gets or sets a value indicating whether use index.
        /// </summary>
        /// <value>
        /// <b>true</b> if uses index; otherwise, <b>false</b>.
        /// </value>
        public bool UseIndex { get; set; }
        #endregion 

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string than represents the current object
        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"UseIndex={UseIndex}, DeletePhysicalFilesAfterMerge={DeletePhysicalFilesAfterMerge}";
        #endregion

        #endregion
    }
}
