
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

using iTin.Core;
using iTin.Core.ComponentModel;

using iXlsxWriter.Abstractions.Writer.Operations.Actions;
using iXlsxWriter.Abstractions.Writer.Operations.Results;

namespace iXlsxWriter.ComponentModel.Result.Output;

public partial class XlsxOutputResultData : IXlsxOutputResultData
{
    /// <summary>
    /// Gets a value indicating type of output file.
    /// </summary>
    /// <value>
    /// One of the values of the <see cref="KnownOutputType"/> enumeration.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    Enum IOutputResultData.OutputType => OutputType;

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
    public KnownOutputType OutputType =>
        Zipped
            ? KnownOutputType.Zip
            : KnownOutputType.Xlsx;


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
    /// Returns a reference to the uncompressed output stream. If <see cref="OutputType"/> is <b>Pdf</b> this value is equals to <see cref="OutputStream"/> value property.
    /// </summary>
    /// <returns>
    /// A <see cref="Stream"/> that contains the original outupt uncrompressed.
    /// </returns>
    public Stream GetUnCompressedOutputStream() => new MemoryStream(UncompressOutputStream.AsByteArray());


    /// <summary>
    /// Executes specified action for this output result instance asynchronously.
    /// </summary>
    /// <param name="output">Target output result.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// <para>
    /// An instance which implements the <see cref="IResult"/> interface that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// </returns>
    public async Task<IResult> Action(IOutputActionAsync output, CancellationToken cancellationToken = default) =>
        await ActionImplStrategyAsync(output, this, cancellationToken).ConfigureAwait(false);

    /// <summary>
    /// Returns a reference to the output stream asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// A <see cref="Stream"/> that contains a reference to the output stream.
    /// </returns>
    public async Task<Stream> GetOutputStreamAsync(CancellationToken cancellationToken = default) =>
        new MemoryStream(await OutputStream.AsByteArrayAsync(cancellationToken).ConfigureAwait(false));

    /// <summary>
    /// Returns a reference to the uncompressed output stream. If <see cref="OutputType"/> is <b>Pdf</b> this value is equals to <see cref="OutputStream"/> value property asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// A <see cref="Stream"/> that contains the original outupt uncrompressed.
    /// </returns>
    public async Task<Stream> GetUnCompressedOutputStreamAsync(CancellationToken cancellationToken = default) =>
        new MemoryStream(await UncompressOutputStream.AsByteArrayAsync(cancellationToken).ConfigureAwait(false));
}
