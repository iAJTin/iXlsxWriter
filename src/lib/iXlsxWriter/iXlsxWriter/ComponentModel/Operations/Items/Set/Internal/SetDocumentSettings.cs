﻿
using System;
using System.IO;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Settings.Document;
using iXlsxWriter.ComponentModel.Result.Set;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// A Specialization of <see cref="SetBase"/> class.<br/>
/// Set document metadata properties.
/// </summary>
internal class SetDocumentSettings : SetBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="SetDocumentSettings"/> class.
    /// </summary>
    public SetDocumentSettings()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to document settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMetadataSettings"/> reference to document settings.
    /// </value>
    public XlsxDocumentMetadataSettings Settings { get; set; }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when set action.
    /// </summary>
    /// <param name="input">stream input</param>
    /// <param name="context">Input context</param>
    /// <returns>
    /// <para>
    /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="SetResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    protected override SetResult SetImpl(Stream input, IInput context)
    {
        if (Settings == null)
        {
            return SetResult.CreateSuccessResult(new SetResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return SetImpl(context, input, Settings);
    }

    #endregion

    #region private static methods

    private static SetResult SetImpl(IInput context, Stream input, XlsxDocumentMetadataSettings settings)
    {
        var outputStream = new MemoryStream();

        try
        {
            using var excel = new ExcelPackage(input);
            excel.Workbook.Properties.SetDocumentMetadata(settings);
            excel.SaveAs(outputStream);

            return SetResult.CreateSuccessResult(new SetResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = outputStream
            });
        }
        catch (Exception ex)
        {
            return SetResult.FromException(
                ex,
                new SetResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }

    #endregion
}
