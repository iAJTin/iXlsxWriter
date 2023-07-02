
using System.IO;

namespace iXlsxWriter.ComponentModel.Result.Set
{
    /// <summary>
    /// Represents set data for an object <see cref="SetResult"/>.
    /// </summary>
    public class SetResultData
    {
        #region internal properties

        /// <summary>
        /// Gets or sets a value containing context owner this action
        /// </summary>
        /// <value>
        /// <see cref="IInsert"/> reference containing context owner this action.
        /// </value>
        internal IInput Context { get; set; }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value containing input document.
        /// </summary>
        /// <value>
        /// Input document.
        /// </value>
        public Stream InputStream { get; set; }

        /// <summary>
        /// Gets or sets a value containing output document.
        /// </summary>
        /// <value>
        /// Output document.
        /// </value>
        public Stream OutputStream { get; set; }
        
        #endregion

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"{(OutputStream.Length > InputStream.Length ? "Modified" : "Default")}";

        #endregion
    }
}
