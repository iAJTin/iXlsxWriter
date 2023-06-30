
using System.Diagnostics;

using iXlsxWriter.ComponentModel;

namespace iXlsxWriter
{
    /// <summary>
    /// Specialization of <see cref="IXlsxObjectConfig"/> interface.<br/>
    /// Represents configuration information for an object <see cref="XlsxObject"/>.
    /// </summary>
    /// <seealso cref="IXlsxObjectConfig"/>
    public sealed partial class XlsxObjectConfig 
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
        public static readonly XlsxObjectConfig Default = new();

        #endregion

        #region constructor/s

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

        #region public properties

        /// <summary>
        /// Gets or sets a value indicating whether compression is allowed.
        /// </summary>
        /// <value>
        /// <b>true</b> if compression is allowed; otherwise, <b>false</b>.
        /// </value>
        public bool AllowCompression { get; set; }

        /// <summary>
        /// Gets or sets a value that establishes the threshold from which the output stream will be compressed, this value will be set to <b>MB</b>, remember that a <b>MB</b> equals 1.024 Bytes.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> that contains compression threshold in <b>MB</b>.
        /// </value>
        public float CompressionThreshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether delete physical files after merge.
        /// </summary>
        /// <value>
        /// <b>true</b> if delete physical files after merge; otherwise, <b>false</b>.
        /// </value>
        public bool DeletePhysicalFilesAfterMerge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use index.
        /// </summary>
        /// <value>
        /// <b>true</b> if uses index; otherwise, <b>false</b>.
        /// </value>
        public bool UseIndex { get; set; }

        #endregion
    }
}
