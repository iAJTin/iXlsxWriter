
using iXlsxWriter.Abstractions.Writer.Operations.Results;

namespace iXlsxWriter.ComponentModel.Result.Output;

/// <summary>
/// Represents configuration information for an object <see cref="XlsxOutputResultData"/>.
/// </summary>
public interface IXlsxOutputResultData : IOutputResultData
{
    /// <summary>
    /// Gets a value indicating type of output file.
    /// </summary>
    /// <value>
    /// One of the values of the <see cref="KnownOutputType"/> enumeration.
    /// </value>
    new KnownOutputType OutputType { get; }
}
