
using System.IO;

using iXlsxWriter.Abstractions.Writer.Operations.Results;

namespace iXlsxWriter.Operations.Result.Action;

public partial class ActionResultData : IResultData
{
    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    public Stream InputStream { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    public Stream OutputStream { get; set; }
}
