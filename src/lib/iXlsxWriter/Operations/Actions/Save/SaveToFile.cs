
using System.Diagnostics;

using iTin.Core.ComponentModel;

using iXlsxWriter.Abstractions.Writer.Operations.Actions;

namespace iXlsxWriter.Operations.Actions;

/// <summary>
/// Specialization of <see cref="IOutputAction"/> interface.<br/>
/// Defines allowed actions for output result data
/// </summary>
public partial class SaveToFile
{
    /// <summary>
    /// xlsx file extension.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal const string XlsxExtension = "xlsx";

    /// <summary>
    /// zip file extension.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal const string ZipExtension = "zip";


    /// <summary>
    /// Gets or sets the output path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.
    /// </summary>
    /// <value>
    /// The output path.
    /// </value>
    public string OutputPath { get; set; }

    /// <summary>
    /// Defines file save options. Allows defining if the directory is created automatically if it does not exist.
    /// </summary>
    /// <value>
    /// Save options reference.
    /// </value>
    public SaveOptions SaveOptions { get; set; }
}
