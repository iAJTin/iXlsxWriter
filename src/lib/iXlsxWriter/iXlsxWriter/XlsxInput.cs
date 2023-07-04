
using System;
using System.Diagnostics;
using System.Linq;

using OfficeOpenXml;

using iTin.Core;
using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.Helpers;
using iTin.Core.IO;

using iTin.Logging;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.ComponentModel.Result.Insert;
using iXlsxWriter.ComponentModel.Result.Output;
using iXlsxWriter.ComponentModel.Result.Replace;
using iXlsxWriter.ComponentModel.Result.Set;

using NativeIO = System.IO;

namespace iXlsxWriter;

/// <summary>
/// Represents a xlsx file.
/// </summary>
/// <seealso cref="IInput"/>
/// <seealso cref="ICloneable"/>
public class XlsxInput : IInput, ICloneable
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string XlsxExtension = "xlsx";

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxInput"/> class.
    /// </summary>
    public XlsxInput()
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Utilities.Xlsx, Namespace: iTin.Utilities.Xlsx.ComponentModel, Class: XlsxInput");
        Logger.Instance.Debug($" Initializes a new instance of the {typeof(XlsxInput)} class");
        Logger.Instance.Debug(" > Signature: #ctor()");

        AutoUpdateChanges = true;
        DeletePhysicalFilesAfterMerge = true;

        Logger.Instance.Debug($"   -> AutoUpdateChanges: {AutoUpdateChanges}");
        Logger.Instance.Debug($"   -> DeletePhysicalFilesAfterMerge: {DeletePhysicalFilesAfterMerge}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxInput"/> class.
    /// </summary>
    private XlsxInput(string[] workSheetNames)
    {
        var stream = new NativeIO.MemoryStream();

        try
        {
            using var excel = new ExcelPackage(stream);

            #region destroy stream
            stream = null;
            #endregion

            #region add worksheet

            int i = 0;
            foreach (var workSheetName in workSheetNames)
            {
                var worksheet = excel.Workbook.Worksheets.Add(string.IsNullOrEmpty(workSheetName) ? $"Sheet{i}" : workSheetName);
                worksheet.View.ShowGridLines = true;
                i++;
            }

            #endregion

            #region create input
            Input = (byte[]) excel.GetAsByteArray().Clone();
            #endregion
        }
        finally
        {
            stream?.Dispose();
        }

        AutoUpdateChanges = true;
        DeletePhysicalFilesAfterMerge = true;
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc/>
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #region IInput

    /// <summary>
    /// Gets or sets a Result indicating whether automatic updates for changes.
    /// </summary>
    /// <Result>
    /// <b>true</b> if automatic update changes; otherwise, <b>false</b>.
    /// </Result>
    public bool AutoUpdateChanges { get; set; }

    /// <summary>
    /// Gets or sets a Result indicating whether delete physical files after merge.
    /// </summary>
    /// <Result>
    /// <b>true</b> if delete physical files after merge; otherwise, <b>false</b>.
    /// </Result>
    public bool DeletePhysicalFilesAfterMerge { get; set; }

    /// <summary>
    /// Gets or sets the input object.
    /// </summary>
    /// <Result>
    /// The input.
    /// </Result>
    public object Input { get; set; }

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
            Type inputType = Input.GetType();

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
    /// The type of the return Result is <see cref="OutputResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public OutputResult CreateResult(OutputResultConfig config = null)
    {
        OutputResultConfig configToApply = OutputResultConfig.Default;
        if (config != null)
        {
            configToApply = config;
            configToApply.Filename = NativeIO.Path.ChangeExtension(
                string.IsNullOrEmpty(config.Filename)
                    ? File.GetUniqueTempRandomFile().Segments.LastOrDefault()
                    : config.Filename,
                XlsxExtension);
        }

        try
        {
            if (configToApply.AutoFitColumns)
            {
                Set( new SetAutoFitColumns());
            }

            Set(new SetSheetsSettings { Settings = configToApply.GlobalSettings.SheetsSettings });
            Set(new SetDocumentSettings { Settings = configToApply.GlobalSettings.DocumentSettings });

            if (!configToApply.Zipped)
            {
                return OutputResult.CreateSuccessResult(
                    new OutputResultData
                    {
                        Zipped = false,
                        Configuration = configToApply,
                        UncompressOutputStream = Clone().ToStream()
                    });
            }

            OutputResult zippedOutputResult = OutputResult.CreateSuccessResult(null); // new[] { Clone() }.CreateJoinResult(new[] { configToApply.Filename });
            //zippedOutputResult.Result.Configuration = configToApply;

            return zippedOutputResult;
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
    /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="InsertResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public InsertResult Insert(IInsert data)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Utilities.Xlsx.Writer, Namespace: iTin.Utilities.Xlsx.Writer, Class: XlsxInput");
        Logger.Instance.Debug(" Try to insert an element in this input");
        Logger.Instance.Debug($" > Signature: ({typeof(InsertResult)}) Insert({typeof(IInsert)})");
        Logger.Instance.Debug($"   > data: {data}");

        InsertResult result = InsertImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

        Logger.Instance.Debug($" > Output: Inserted = {result.Success}");

        return result;
    }

    /// <summary>
    /// Try to replace an element in this input.
    /// </summary>
    /// <param name="data">Reference to replacement object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="ReplaceResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="ReplaceResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public ReplaceResult Replace(IReplace data)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Utilities.Pdf.Writer, Namespace: iTin.Utilities.Pdf.Writer, Class: PdfInput");
        Logger.Instance.Debug(" Try to replace an element in this input");
        Logger.Instance.Debug($" > Signature: ({typeof(ReplaceResult)}) Replace({typeof(IReplace)})");
        Logger.Instance.Debug($"   > data: {data}");

        ReplaceResult result = ReplaceImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

        Logger.Instance.Debug($" > Output: Replacement = {result.Success}");

        return result;
    }

    /// <summary>
    /// Try to set an element in this input.
    /// </summary>
    /// <param name="data">Reference to seteable object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="SetResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public SetResult Set(ISet data)
    {
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Utilities.Xlsx.Writer, Namespace: iTin.Utilities.Xlsx.Writer, Class: XlsxInput");
        Logger.Instance.Debug(" Try to set an element in this input");
        Logger.Instance.Debug($" > Signature: ({typeof(SetResult)}) Set({typeof(ISet)})");
        Logger.Instance.Debug($"   > data: {data}");

        SetResult result = SetImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

        Logger.Instance.Debug($" > Output: Setted = {result.Success}");

        return result;
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
                return TypeHelper.ToType<XlsxInput>(Input).CreateResult().Result.UncompressOutputStream;

            case KnownInputType.Stream:
                NativeIO.Stream stream = TypeHelper.ToType<NativeIO.Stream>(Input);
                stream.Position = 0;
                return stream;

            default:
            case KnownInputType.NotSupported:
                return null;
        }
    }

    #endregion

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
    public static XlsxInput Create(string[] workSheetNames = null) => new XlsxInput(workSheetNames);

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
        Logger.Instance.Debug("");
        Logger.Instance.Debug(" Assembly: iTin.Utilities.Xlsx, Namespace: iTin.Utilities.Xlsx.ComponentModel, Class: XlsxInput");
        Logger.Instance.Debug(" Create a new object that is a copy of the current instance");
        Logger.Instance.Debug($" > Signature: ({typeof(XlsxInput)}) Clone()");

        XlsxInput clonned = (XlsxInput)MemberwiseClone();

        NativeIO.Stream innerStream = ToStream().Clone();
        clonned.Input = innerStream;

        Logger.Instance.Debug($" > Output: Cloned correctly");

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
            KnownInputType.Filename => $"Input='{Input}', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.XlsxInput => $"Input='XlsxInput', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.Stream => $"Input='Stream', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.ByteArray => $"Input='Byte[]', Type={InputType}, Updatable={AutoUpdateChanges}",
            KnownInputType.NotSupported => "Input type not supported",
            _ => $"Type={InputType}, Updatable={AutoUpdateChanges}",
        };

    #endregion

    #region private methods

    private InsertResult InsertImplStrategy(IInsert data, XlsxInput context)
        => data == null ? InsertResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    private ReplaceResult ReplaceImplStrategy(IReplace data, IInput context)
        => data == null ? ReplaceResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    private SetResult SetImplStrategy(ISet data, XlsxInput context)
        => data == null ? SetResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    #endregion
}
