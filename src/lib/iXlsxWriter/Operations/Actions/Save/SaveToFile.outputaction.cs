
using System;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.IO;
using iTin.Core.IO.Compression;

using iXlsxWriter.Abstractions.Writer.Operations.Actions;
using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.ComponentModel.Result.Output;

using NativeIO = System.IO;

namespace iXlsxWriter.Operations.Actions;

public partial class SaveToFile : IOutputAction
{
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
    public IResult Execute(IOutputResultData data) => ExecuteImpl(data);


    private IResult ExecuteImpl(IOutputResultData data)
    {
        if (data == null)
        {
            return BooleanResult.NullResult;
        }

        var xlsxOutputResultData = (XlsxOutputResultData)data;
        var safeOptions = SaveOptions ?? SaveOptions.Default;
        var outputExtension = xlsxOutputResultData.Zipped ? ZipExtension : XlsxExtension;
        var normalizedPath = Path.PathResolver(OutputPath);
        var directoryName = NativeIO.Path.GetDirectoryName(normalizedPath);
        var filename = NativeIO.Path.GetFileName(normalizedPath);
        var filenameWithoutExtension = NativeIO.Path.GetFileNameWithoutExtension(filename);
        var filenameWithExtension = $"{filenameWithoutExtension}.{outputExtension}";
        var outPath = NativeIO.Path.Combine(directoryName, filenameWithExtension);

        try
        {
            var actionResult = BooleanResult.SuccessResult;
            bool isMergedFile = xlsxOutputResultData.Configuration is XlsxObjectConfig;
            if (isMergedFile)
            {
                var streamIsZipped = ((XlsxObjectConfig)xlsxOutputResultData.Configuration).AllowCompression;
                actionResult.Success = xlsxOutputResultData.Zipped
                    ? streamIsZipped
                        ? xlsxOutputResultData.UncompressOutputStream.Clone().TrySaveAsZip(XlsxExtension, outPath).Success
                        : xlsxOutputResultData.UncompressOutputStream.Clone().SaveToFile(outPath, safeOptions).Success
                    : xlsxOutputResultData.OutputStream.Clone().SaveToFile(outPath, safeOptions).Success;
            }
            else
            {
                actionResult.Success = xlsxOutputResultData.Zipped
                    ? xlsxOutputResultData.UncompressOutputStream.Clone().SaveToFile(outPath, safeOptions).Success
                    : xlsxOutputResultData.OutputStream.Clone().SaveToFile(outPath, safeOptions).Success;
            }

            return actionResult;
        }
        catch (Exception ex)
        {
            return BooleanResult.FromException(ex);
        }
    }
}
