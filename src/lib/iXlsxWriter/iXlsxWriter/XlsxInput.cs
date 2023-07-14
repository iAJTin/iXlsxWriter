
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using OfficeOpenXml;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.Helpers;
using iTin.Core.IO;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

using iXlsxWriter.Abstractions.Writer;
using iXlsxWriter.Abstractions.Writer.Input;
using iXlsxWriter.Abstractions.Writer.Config;
using iXlsxWriter.ComponentModel;
using iXlsxWriter.ComponentModel.Result.Output;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Replace;
using iXlsxWriter.Operations.Set;

using NativeIO = System.IO;
using iTin.Core.IO.Compression;

namespace iXlsxWriter;

/// <summary>
/// Represents a xlsx file.
/// </summary>
/// <seealso cref="IXlsxInput"/>
/// <seealso cref="ICloneable"/>
public class XlsxInput : IXlsxInput, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string XlsxExtension = "xlsx";

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool _isDisposed;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxInput"/> class.
    /// </summary>
    private XlsxInput(IEnumerable<string> workSheetNames)
    {
        var stream = new NativeIO.MemoryStream();

        try
        {
            Package = new ExcelPackage(stream);

            #region destroy stream

            stream = null;
            
            #endregion

            #region add worksheet

            var i = 0;
            foreach (var workSheetName in workSheetNames)
            {
                var worksheet = Package.Workbook.Worksheets.Add(string.IsNullOrEmpty(workSheetName) ? $"Sheet{i}" : workSheetName);
                worksheet.View.ShowGridLines = true;
                i++;
            }

            #endregion

            #region create input

            Input = (byte[])Package.GetAsByteArray().Clone();

            Package = new ExcelPackage(ToStream());
            #endregion
        }
        finally
        {
            stream?.Dispose();
        }
    }

    #endregion

    #region finalizer

    /// <summary>
    /// Finalizer
    /// </summary>
    ~XlsxInput()
    {
        Dispose(false);
    }

    #endregion

    #region interfaces

    #region ICloneable

    #region explicit

    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region IDisposable

    #region public methods

    /// <summary>
    /// Clean managed resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    #endregion

    #endregion

    #region IXlsxInput

    #region explicit

    /// <summary>
    /// Gets input type.
    /// </summary>
    /// <Result>
    /// An Result of enumeration <see cref="KnownInputType"/> indicating type of the input.
    /// </Result>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    KnownInputType IInput.InputType => InputType;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the input object.
    /// </summary>
    /// <Result>
    /// The input.
    /// </Result>
    public object Input { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Returns a new reference <see cref="OutputResult"/> that complies with what is indicated in its configuration object. By default, this <see cref="XlsxInput"/> will not be zipped.
    /// </summary>
    /// <param name="config">The output result configuration.</param>
    /// <returns>
    /// <para>
    /// A <see cref="OutputResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="XlsxOutputResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public OutputResult CreateResult(IOutputResultConfig config = null)
    {
        IOutputResultConfig safeConfig = XlsxOutputResultConfig.Default;
        if (config != null)
        {
            safeConfig = config;
            safeConfig.Filename = NativeIO.Path.ChangeExtension(
                string.IsNullOrEmpty(config.Filename)
                    ? File.GetUniqueTempRandomFile().Segments.LastOrDefault()
                    : config.Filename,
                XlsxExtension);
        }

        try
        {
            var concreteSettings = (XlsxOutputResultConfig)safeConfig;
            var globalSetting = concreteSettings.GlobalSettings;
            Set(new SetSheetsSettings { Settings = globalSetting.SheetsSettings });
            Set(new SetDocumentSettings { Settings = globalSetting.DocumentSettings });

            if (safeConfig.AutoFitColumns)
            {
                Set(new SetAutoFitColumns());
            }

            var processResult = ProcessInput();
            if (!processResult.Success)
            {
                return OutputResult.CreateErrorResult(processResult.Errors.ToArray());
            }

            if (!safeConfig.Zipped)
            {
                return OutputResult.CreateSuccessResult(
                    new XlsxOutputResultData
                    {
                        Zipped = false,
                        Configuration = (IXlsxObjectConfig)safeConfig,
                        UncompressOutputStream = Clone().ToStream()
                    });
            }

            return CreateZippedResult(this, safeConfig.Filename);
        }
        catch (Exception e)
        {
            return OutputResult.FromException(e);
        }
    }

    /// <summary>
    /// Try to insert an element in this input.
    /// </summary>
    /// <param name="data">Reference to insertable object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="ActionResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="ActionResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IXlsxInputAction Insert(IInsert data)
    {
        XlsxInputCache.Cache.AddInsert(this, data);

        return new XlsxInputAction(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">Reference to seteable object information</param>
    /// <returns>
    /// </returns>
    public IXlsxInputAction Replace(IReplace data)
    {
        XlsxInputCache.Cache.AddReplacement(this, data);

        return new XlsxInputAction(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">Reference to seteable object information</param>
    /// <returns>
    /// </returns>
    public IXlsxInputAction Set(ISet data)
    {
        XlsxInputCache.Cache.AddSet(this, data);

        return new XlsxInputAction(this);
    }

    /// <summary>
    /// Saves this input into a file.
    /// </summary>
    /// <param name="outputPath">The output path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
    /// <param name="options">Save options</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> which implements the <see cref="IResult"/> interface reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="bool"/>, which contains the operation result
    /// </para>
    /// </returns>
    public IResult SaveToFile(string outputPath, SaveOptions options = null)
    {
        try
        {
            return ToStream().SaveToFile(Path.PathResolver(outputPath), options ?? SaveOptions.Default);
        }
        catch (Exception ex)
        {
            return BooleanResult.FromException(ex);
        }
    }

    /// <summary>
    /// Convert this input into a stream object.
    /// </summary>
    /// <returns>
    /// A <see cref="NativeIO.Stream"/> that represents this input file.
    /// </returns>
    public NativeIO.Stream ToStream()
    {
        switch (InputType)
        {
            case KnownInputType.Filename:
                return new NativeIO.MemoryStream(NativeIO.File.ReadAllBytes(Path.PathResolver(TypeHelper.ToType<string>(Input))));

            case KnownInputType.ByteArray:
                return new NativeIO.MemoryStream(TypeHelper.ToType<byte[]>(Input));

            case KnownInputType.XlsxInput:
                return ((XlsxOutputResultData)TypeHelper.ToType<XlsxInput>(Input).CreateResult().Result).UncompressOutputStream;

            case KnownInputType.Stream:
                var stream = TypeHelper.ToType<NativeIO.Stream>(Input);
                stream.Position = 0;
                return stream;

            default:
            case KnownInputType.NotSupported:
                return null;
        }
    }

    #endregion

    #region public async methods

    /// <summary>
    /// Returns a new reference <see cref="OutputResult"/> that complies with what is indicated in its configuration object. By default, this <see cref="XlsxInput"/> will not be zipped.
    /// </summary>
    /// <param name="config">The output result configuration.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// <para>
    /// A <see cref="OutputResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="XlsxOutputResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public async Task<OutputResult> CreateResultAsync(IOutputResultConfig config = null, CancellationToken cancellationToken = default)
    {
        IOutputResultConfig safeConfig = XlsxOutputResultConfig.Default;
        if (config != null)
        {
            safeConfig = config;
            safeConfig.Filename = NativeIO.Path.ChangeExtension(
                string.IsNullOrEmpty(config.Filename)
                    ? File.GetUniqueTempRandomFile().Segments.LastOrDefault()
                    : config.Filename,
                XlsxExtension);
        }

        try
        {
            var concreteSettings = (XlsxOutputResultConfig)safeConfig;
            var globalSetting = concreteSettings.GlobalSettings;
            Set(new SetSheetsSettings { Settings = globalSetting.SheetsSettings });
            Set(new SetDocumentSettings { Settings = globalSetting.DocumentSettings });

            if (safeConfig.AutoFitColumns)
            {
                Set(new SetAutoFitColumns());
            }

            var processResult = await ProcessInputAsync(cancellationToken).ConfigureAwait(false);
            if (!processResult.Success)
            {
                return OutputResult.CreateErrorResult(processResult.Errors.ToArray());
            }

            if (!safeConfig.Zipped)
            {
                return OutputResult.CreateSuccessResult(
                    new XlsxOutputResultData
                    {
                        Zipped = false,
                        Configuration = (IXlsxObjectConfig)safeConfig,
                        UncompressOutputStream = await (await CloneAsync(cancellationToken).ConfigureAwait(false)).ToStreamAsync(cancellationToken).ConfigureAwait(false)
                    });
            }

            return await CreateZippedResultAsync(this, safeConfig.Filename, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            return OutputResult.FromException(e);
        }
    }

    /// <summary>
    /// Saves this input into a file asynchronously.
    /// </summary>
    /// <param name="outputPath">The output path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
    /// <param name="options">Save options</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// <para>
    /// A <see cref="BooleanResult"/> which implements the <see cref="IResult"/> interface reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="bool"/>, which contains the operation result
    /// </para>
    /// </returns>
    public async Task<IResult> SaveToFileAsync(string outputPath, SaveOptions options = null, CancellationToken cancellationToken = default)
    {
        try
        {
            return await 
                (await ToStreamAsync(cancellationToken).ConfigureAwait(false))
                .SaveToFileAsync(Path.PathResolver(outputPath), options ?? SaveOptions.Default, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return BooleanResult.FromException(ex);
        }
    }

    /// <summary>
    /// Convert this input into a stream object.
    /// </summary>
    /// <returns>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// A <see cref="NativeIO.Stream"/> that represents this input file.
    /// </returns>
    public async Task<NativeIO.Stream> ToStreamAsync(CancellationToken cancellationToken = default)
    {
        switch (InputType)
        {
            case KnownInputType.Filename:
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

                return new NativeIO.MemoryStream(await NativeIO.File.ReadAllBytesAsync(Path.PathResolver(TypeHelper.ToType<string>(Input)), cancellationToken).ConfigureAwait(false));
#elif NETCOREAPP3_1
                    return new NativeIO.MemoryStream(await NativeIO.File.ReadAllBytesAsync(Path.PathResolver(TypeHelper.ToType<string>(Input)), cancellationToken).ConfigureAwait(false));
#else
                return await Task.FromResult(new NativeIO.MemoryStream(NativeIO.File.ReadAllBytes(Path.PathResolver(TypeHelper.ToType<string>(Input))))).ConfigureAwait(false);
#endif
            case KnownInputType.ByteArray:
                return await Task.FromResult(new NativeIO.MemoryStream(TypeHelper.ToType<byte[]>(Input))).ConfigureAwait(false);

            case KnownInputType.XlsxInput:
                return ((XlsxOutputResultData)(await TypeHelper.ToType<XlsxInput>(Input).CreateResultAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Result).UncompressOutputStream;

            case KnownInputType.Stream:
                var stream = TypeHelper.ToType<NativeIO.Stream>(Input);
                stream.Position = 0;
                return await Task.FromResult(stream).ConfigureAwait(false);

            default:
            case KnownInputType.NotSupported:
                return await Task.FromResult((NativeIO.Stream)null).ConfigureAwait(false);
        }
    }

    #endregion

    #endregion

    #endregion

    #region internal readonly properties

    /// <summary>
    /// Gets a <see cref="ExcelPackage"/> inner reference to package.
    /// </summary>
    /// <value>
    /// A <see cref="ExcelPackage"/> inner reference.
    /// </value>
    internal ExcelPackage Package { get; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets input type.
    /// </summary>
    /// <Result>
    /// An Result of enumeration <see cref="KnownInputType"/> indicating type of the input.
    /// </Result>
    public KnownInputType InputType
    {
        get
        {
            var inputType = Input.GetType();

            if (inputType == typeof(string))
            {
                return KnownInputType.Filename;
            }

            if (inputType == typeof(XlsxInput))
            {
                return KnownInputType.XlsxInput;
            }

            if (inputType == typeof(NativeIO.MemoryStream) || inputType == typeof(NativeIO.Stream))
            {
                return KnownInputType.Stream;
            }

            if (inputType == typeof(byte[]))
            {
                return KnownInputType.ByteArray;
            }

            return KnownInputType.NotSupported;

        }
    }

    #endregion

    #region public methods

    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="XlsxInput"/> that is a copy of this instance.
    /// </returns>
    public XlsxInput Clone()
    {
        var clonned = (XlsxInput)MemberwiseClone();
        clonned.Input = ToStream().Clone();

        return clonned;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() =>
        InputType switch
        {
            KnownInputType.Filename => $"Input='{Input}', Type={InputType}",
            KnownInputType.XlsxInput => $"Input='XlsxInput', Type={InputType}",
            KnownInputType.Stream => $"Input='Stream', Type={InputType}",
            KnownInputType.ByteArray => $"Input='Byte[]', Type={InputType}",
            KnownInputType.NotSupported => "Input type not supported",
            _ => $"Type={InputType}"
        };

    #endregion

    #region protected virtual methods

    /// <summary>
    /// Cleans managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">
    /// If it is <b>true</b>, the method is invoked directly or indirectly from the user code.
    /// If it is <b>false</b>, the method is called the finalizer and only unmanaged resources are finalized.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        // free managed resources
        if (disposing)
        {
            Package?.Dispose();
        }

        // free native resources

        // avoid seconds calls 
        _isDisposed = true;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// </returns>
    public static XlsxInput Create(string workSheetName = null) => Create(new[] {workSheetName});

    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// </returns>
    public static XlsxInput Create(string[] workSheetNames = null) => new(workSheetNames);

    #endregion

    #region internal static methods

    /// <summary>
    /// Returns a new <see cref="OutputResult"/> reference thats represents a one <b>unique zip stream</b> that contains the same entries in <param ref="items"/> 
    /// but compressed individually using the name in <param ref="filenames"/>.         
    /// </summary>
    /// <param name="input">Items</param>
    /// <param name="filename">Item filenames.</param>
    /// <returns>
    /// A <see cref="OutputResult"/> reference that contains action result.
    /// </returns>
    internal static OutputResult CreateZippedResult(XlsxInput input, string filename)
    {
        try
        {
            var zippedStream = input.ToStream().AsZipStream(filename);
            zippedStream.Position = 0;
            return
                OutputResult.CreateSuccessResult(
                    new XlsxOutputResultData
                    {
                        Zipped = true,
                        Configuration = null,
                        UncompressOutputStream = zippedStream
                    });
        }
        catch (Exception e)
        {
            return OutputResult.FromException(e);
        }
    }

    #endregion

    #region internal methods

    internal ActionResult ProcessInput()
    {
        ActionResult result;

        // Replacements
        var hasReplacementsItems = XlsxInputCache.Cache.AnyReplacements(this);
        if (hasReplacementsItems)
        {
            result = XlsxInputRender.Render<IReplace>(this);
            if (!result.Success)
            {
                return result;
            }

            Input = result.Result.OutputStream;

        }

        // Inserts
        var hasInsertItems = XlsxInputCache.Cache.AnyInserts(this);
        if (hasInsertItems)
        {
            result = XlsxInputRender.Render<IInsert>(this);
            if (!result.Success)
            {
                return result;
            }

            Input = result.Result.OutputStream;

        }

        // Sets
        var hasSetItems = XlsxInputCache.Cache.AnySets(this);
        if (hasSetItems)
        {
            var stream = ToStream();

            result = ActionResult.CreateSuccessResult(
                new ActionResultData
                {
                    Context = this,
                    InputStream = stream,
                    OutputStream = stream
                });
        }
        else
        {
            result = XlsxInputRender.Render<ISet>(this);
            Input = result.Result.OutputStream;
        }

        return result;
    }

    #endregion

    #region internal static async methods

    /// <summary>
    /// Returns a new <see cref="OutputResult"/> reference thats represents a one <b>unique zip stream</b> that contains the same entries in <param ref="items"/> 
    /// but compressed individually using the name in <param ref="filenames"/>.         
    /// </summary>
    /// <param name="input">Items</param>
    /// <param name="filename">Item filenames.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A <see cref="OutputResult"/> reference that contains action result.
    /// </returns>
    internal static async Task<OutputResult> CreateZippedResultAsync(XlsxInput input, string filename, CancellationToken cancellationToken = default)
    {
        try
        {
            var stream = await input
                .ToStreamAsync(cancellationToken)
                .ConfigureAwait(false);

            var zippedStream = await stream
                .AsZipStreamAsync(filename, cancellationToken)
                .ConfigureAwait(false);

            zippedStream.Position = 0;
            return
                OutputResult.CreateSuccessResult(
                    new XlsxOutputResultData
                    {
                        Zipped = true,
                        Configuration = null,
                        UncompressOutputStream = zippedStream
                    });
        }
        catch (Exception e)
        {
            return OutputResult.FromException(e);
        }
    }
    #endregion

    #region internal async methods

    internal async Task<XlsxInput> CloneAsync(CancellationToken cancellationToken = default)
    {
        var clonned = (XlsxInput)MemberwiseClone();

        var innerStream = await (await ToStreamAsync(cancellationToken).ConfigureAwait(false)).CloneAsync(cancellationToken).ConfigureAwait(false);
        clonned.Input = innerStream;

        return clonned;
    }

    internal async Task<ActionResult> ProcessInputAsync(CancellationToken cancellationToken = default)
    {
        ActionResult result;

        // Replacements
        var hasReplacementsItems = XlsxInputCache.Cache.AnyReplacements(this);
        if (hasReplacementsItems)
        {
            result = XlsxInputRender.Render<IReplace>(this);
            Input = result.Result.OutputStream;

            if (!result.Success)
            {
                return result;
            }
        }

        // Inserts
        var hasInsertItems = XlsxInputCache.Cache.AnyInserts(this);
        if (hasInsertItems)
        {
            result = XlsxInputRender.Render<IInsert>(this);
            Input = result.Result.OutputStream;

            if (!result.Success)
            {
                return result;
            }
        }

        // Sets
        var hasSetItems = XlsxInputCache.Cache.AnySets(this);
        if (hasSetItems)
        {
            var stream = await ToStreamAsync(cancellationToken);

            result = ActionResult.CreateSuccessResult(
                new ActionResultData
                {
                    Context = this,
                    InputStream = stream,
                    OutputStream = stream
                });
        }
        else
        {
            result = XlsxInputRender.Render<ISet>(this);
            Input = result.Result.OutputStream;
        }

        return result;
    }

    #endregion
}
