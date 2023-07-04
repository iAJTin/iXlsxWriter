
using System;
using System.Diagnostics;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.IO;
using iTin.Core.IO.Compression;

using iXlsxWriter.ComponentModel.Result.Output;

using NativeIO = System.IO;
using iTinIO = iTin.Core.IO;

namespace iXlsxWriter.ComponentModel.Result.Action.Save;

/// <summary>
/// Specialization of <see cref="IOutputAction"/> interface.<br/>
/// Defines allowed actions for output result data
/// </summary>
public class SaveToFile : IOutputAction
{
    #region interna constants

    /// <summary>
    /// xlsx file extension.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal const string DefaultXlsxExtension = "xlsx";

    /// <summary>
    /// zip file extension.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal const string DefaultZipExtension = "zip";

    #endregion

    #region interfaces

    #region IOutputAction

    /// <summary>
    /// Execute action for specified output result data.
    /// </summary>
    /// <param name="data">Target output result data.</param>
    /// <returns>
    /// <para>
    /// An instance which implements the <see cref="IResult"/> interface that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// </returns>
    public IResult Execute(OutputResultData data) => ExecuteImpl(data);

    #endregion

    #endregion

    #region public properties   

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

    #endregion

    #region private methods   

    private IResult ExecuteImpl(OutputResultData data)
    {
        if (data == null)
        {
            return BooleanResult.NullResult;
        }

        var safeOptions = SaveOptions ?? SaveOptions.Default;
        var outputExtension = data.Zipped ? DefaultZipExtension : DefaultXlsxExtension;
        var normalizedPath = iTinIO.Path.PathResolver(OutputPath);
        var directoryName = NativeIO.Path.GetDirectoryName(normalizedPath);
        var filename = NativeIO.Path.GetFileName(normalizedPath);
        var filenameWithoutExtension = NativeIO.Path.GetFileNameWithoutExtension(filename);
        var filenameWithExtension = $"{filenameWithoutExtension}.{outputExtension}";
        var outPath = NativeIO.Path.Combine(directoryName, filenameWithExtension);

        try
        {
            var actionResult = BooleanResult.SuccessResult;
            bool isMergedFile = data.Configuration is XlsxObjectConfig;
            if (isMergedFile)
            {
                var streamIsZipped = ((XlsxObjectConfig)data.Configuration).AllowCompression;
                actionResult.Success = data.Zipped
                    ? streamIsZipped
                        ? data.UncompressOutputStream.Clone().TrySaveAsZip(DefaultXlsxExtension, outPath).Success
                        : data.UncompressOutputStream.Clone().SaveToFile(outPath, safeOptions).Success
                    : data.OutputStream.Clone().SaveToFile(outPath, safeOptions).Success;
            }
            else
            {
                actionResult.Success = data.Zipped
                    ? data.UncompressOutputStream.Clone().SaveToFile(outPath, safeOptions).Success
                    : data.OutputStream.Clone().SaveToFile(outPath, safeOptions).Success;
            }

            return actionResult;
        }
        catch (Exception ex)
        {
            return BooleanResult.FromException(ex);
        }
    }

    #endregion
}
