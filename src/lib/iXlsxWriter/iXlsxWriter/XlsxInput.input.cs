
using System;
using System.Linq;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;
using iTin.Core.Helpers;
using iTin.Core.IO;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.ComponentModel.Result.Insert;
using iXlsxWriter.ComponentModel.Result.Output;
using iXlsxWriter.ComponentModel.Result.Replace;
using iXlsxWriter.ComponentModel.Result.Set;

using NativeIO = System.IO;

namespace iXlsxWriter;

public partial class XlsxInput : IInput
{
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
        var safeConfig = OutputResultConfig.Default;
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
            if (safeConfig.AutoFitColumns)
            {
                Set( new SetAutoFitColumns());
            }

            Set(new SetSheetsSettings { Settings = safeConfig.GlobalSettings.SheetsSettings });
            Set(new SetDocumentSettings { Settings = safeConfig.GlobalSettings.DocumentSettings });

            if (!safeConfig.Zipped)
            {
                return OutputResult.CreateSuccessResult(
                    new OutputResultData
                    {
                        Zipped = false,
                        Configuration = safeConfig,
                        UncompressOutputStream = Clone().ToStream()
                    });
            }

            OutputResult zippedOutputResult = OutputResult.CreateSuccessResult(null); // new[] { Clone() }.CreateJoinResult(new[] { safeConfig.Filename });
            //zippedOutputResult.Result.Configuration = safeConfig;

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
        var result = InsertImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

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
        var result = ReplaceImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

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
        var result = SetImplStrategy(data, this);

        if (AutoUpdateChanges)
        {
            Input = result.Result.OutputStream;
        }

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
}
