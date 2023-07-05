
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using iTin.Core;
using iTin.Core.Helpers;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.ComponentModel.Result.Output;

namespace iXlsxWriter;

/// <summary>
/// Represents a generic xlsx object, this allows add docx files to <see cref="XlsxObject.Items"/> property and specify a user custom configuration.
/// </summary>
public partial class XlsxObject
{
    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxObject"/> class with default configuration.
    /// </summary>
    public XlsxObject() : this(XlsxObjectConfig.Default)
    {     
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxObject"/> class with specified configuration
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public XlsxObject(XlsxObjectConfig configuration)
    {
        Configuration = configuration;
        Items = new List<XlsxInput>();
    }

    #endregion

    #region finalizer

    /// <summary>
    /// Finalizer
    /// </summary>
    ~XlsxObject()
    {
        Dispose(false);
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the xlsx input list.
    /// </summary>
    /// <value>
    /// The items.
    /// </value>
    public IEnumerable<XlsxInput> Items { get; set; }

    /// <summary>
    /// Gets the configuration settings.
    /// </summary>
    /// <value>
    /// The object configuration.
    /// </value>
    public XlsxObjectConfig Configuration { get; }

    #endregion

    #region public methods

    /// <summary>
    /// Merges all <see cref="XlsxInput"/> entries.
    /// </summary>
    /// <returns>
    /// <para>
    /// A <see cref="OutputResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="OutputResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public OutputResult TryMergeInputs()
    {
        var items = Items.ToList();

        //if (Configuration.UseIndex)
        //{
        //    items = items.OrderBy(i => i.Index).ToList();
        //}

        try
        {
            MemoryStream outStream = new MemoryStream(); //MergeFiles(items.Select(item => item.ToStream()));

            if (Configuration.DeletePhysicalFilesAfterMerge)
            {
                foreach (var item in items)
                {
                    var inputType = item.InputType;
                    if (inputType != KnownInputType.Filename)
                    {
                        continue;
                    }

                    if (item.DeletePhysicalFilesAfterMerge)
                    {
                        File.Delete(TypeHelper.ToType<string>(item.Input));
                    }
                }
            }

            var safeOutAsByteArray = outStream.GetBuffer();
            var outputInMegaBytes = (float)safeOutAsByteArray.Length / XlsxObjectConfig.OneMegaByte;
            var generateOutputAsZip = outputInMegaBytes > Configuration.CompressionThreshold;
            var zipped = Configuration.AllowCompression && generateOutputAsZip;

            return
                OutputResult.CreateSuccessResult(
                    new OutputResultData
                    {
                        Zipped = zipped,
                        Configuration = Configuration,
                        UncompressOutputStream = safeOutAsByteArray.ToMemoryStream()
                    });
        }    
        catch (Exception ex)
        {
            return OutputResult.FromException(ex);
        }
    }

    #endregion
}
