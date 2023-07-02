
using System.Diagnostics;
using System.IO;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.IO.Compression;

using iXlsxWriter.ComponentModel.Result.Action;

namespace iXlsxWriter.ComponentModel.Result.Output
{
    /// <summary>
    /// Represents configuration information for an object <see cref="OutputResult"/>.
    /// </summary>
    public class OutputResultData
    {
        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputResultData" /> class.
        /// </summary>
        public OutputResultData()
        {
            Zipped = false;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a value indicating whether output file has been zipped.
        /// </summary>
        /// <value>
        /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
        /// </value>
        public bool IsZipped => Zipped;

        /// <summary>
        /// Gets a value indicating type of output file.
        /// </summary>
        /// <value>
        /// One of the values of the <see cref="KnownOutputType"/> enumeration.
        /// </value>
        public KnownOutputType OutputType => Zipped ? KnownOutputType.Zip : KnownOutputType.Xlsx;

        #endregion

        #region internal properties

        /// <summary>
        /// Gets or sets the docx configuration settings to apply
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal IXlsxObjectConfig Configuration { get; set; }

        /// <summary>
        /// Gets a value that contains a reference to the output stream.
        /// </summary>
        /// <value>
        /// A <see cref="Stream"/> that contains a reference to the output stream.</value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal Stream OutputStream
            => Configuration == null
                ? UncompressOutputStream
                : Zipped
                    ? UncompressOutputStream.AsZipStream()
                    : UncompressOutputStream;

        /// <summary>
        /// Gets a value that contains a reference to the uncompressed output stream. If <see cref="OutputType"/> is <b>Xlsx</b> this value is equals to <see cref="OutputStream"/> value property.
        /// </summary>
        /// <value>
        /// A <see cref="Stream"/> that contains a reference to the uncompressed output stream.</value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal Stream UncompressOutputStream { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether output file has been zipped.
        /// </summary>
        /// <value>
        /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal bool Zipped { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// Executes specified action for this output result instance.
        /// </summary>
        /// <param name="output">Target output result.</param>
        /// <returns>
        /// <para>
        /// An instance which implements the <see cref="IResult"/> interface that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// </returns>
        public IResult Action(IOutputAction output) => ActionImplStrategy(output, this);

        /// <summary>
        /// Returns a reference to the output stream.
        /// </summary>
        /// <returns>
        /// A <see cref="Stream"/> that contains a reference to the output stream.
        /// </returns>
        public Stream GetOutputStream() => new MemoryStream(OutputStream.AsByteArray());

        /// <summary>
        /// Returns a reference to the uncompressed output stream. If <see cref="OutputType"/> is <b>Xlsx</b> this value is equals to <see cref="OutputStream"/> value property.
        /// </summary>
        /// <returns>Stream.</returns>
        public Stream GetUnCompressedOutputStream() => new MemoryStream(UncompressOutputStream.AsByteArray());

        #endregion

        #region public override methods

        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"IsZipped={IsZipped}, OutputType={OutputType}";

        #endregion

        #region private static methods

        private static IResult ActionImplStrategy(IOutputAction output, OutputResultData result)
            => output == null
                ? OutputResult.NullResult
                : output.Execute(result);

        #endregion
    }
}
