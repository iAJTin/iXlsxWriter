
using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;

namespace iXlsxWriter.Operations.Result.Action;

/// <summary>
/// Represents insert data for an object <see cref="ActionResult"/>.
/// </summary>
public partial class ActionResultData
{
    /// <summary>
    /// Gets or sets a value indicating whether output file has been zipped.
    /// </summary>
    /// <value>
    /// <b>true</b> if output file has been zipped; otherwise, <b>false</b>.
    /// </value>
    internal IXlsxInput Context { get; set; }
}
