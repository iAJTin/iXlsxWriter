
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

using iTin.Core.ComponentModel;
using iTin.Core.IO.Compression;

using iXlsxWriter.Abstractions.Writer.Operations.Actions;
using iXlsxWriter.Abstractions.Writer.Operations.Results;

namespace iXlsxWriter.ComponentModel.Result.Output;

/// <summary>
/// Represents configuration information for an object <see cref="XlsxOutputResultData"/>.
/// </summary>
public partial class XlsxOutputResultData
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxOutputResultData" /> class.
    /// </summary>
    public XlsxOutputResultData()
    {
        Zipped = false;
    }

    #endregion

    #region internal properties

    /// <summary>
    /// Gets or sets the pdf configuration settings to apply.
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
    /// A <see cref="Stream"/> that contains a reference to the output stream.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal Stream OutputStream
    {
        get
        {
            if (Configuration == null)
            {
                return UncompressOutputStream;
            }

            return Zipped
                ? UncompressOutputStream.AsZipStream()
                : UncompressOutputStream;
        }
    }


    /// <summary>
    /// Gets a value that contains a reference to the uncompressed output stream. If <see cref="OutputType"/> is <b>Pdf</b> this value is equals to <see cref="OutputStream"/> value property.
    /// </summary>
    /// <value>
    /// A <see cref="Stream"/> that contains a reference to the uncompressed output stream.
    /// </value>
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

    #region private static methods

    private static IResult ActionImplStrategy(IOutputAction output, IOutputResultData result) =>
        output == null
            ? OutputResult.NullResult
            : output.Execute(result);

    #endregion

    #region private async static methods

    private static async Task<IResult> ActionImplStrategyAsync(IOutputActionAsync output, IOutputResultData result, CancellationToken cancellationToken) =>
        output == null
            ? await Task.FromResult(OutputResult.NullResult)
            : await output.ExecuteAsync(result, cancellationToken);

    #endregion
}
