
using System;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// Specifies the known output type.
    /// </summary>
    [Serializable]
    public enum KnownOutputType
    {
        /// <summary>
        /// Output file type as xlsx
        /// </summary>
        Xlsx,

        /// <summary>
        /// Output file type as zip
        /// </summary>
        Zip,
    }
}
