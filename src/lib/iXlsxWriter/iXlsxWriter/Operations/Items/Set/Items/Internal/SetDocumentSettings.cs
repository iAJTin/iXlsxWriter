
using System;
using System.IO;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Settings.Document;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Set;

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

    #region public override methods

    /// <summary>
    /// Implementation to execute when insert action.
    /// </summary>
    /// <param name="context">Input context</param>
    /// <param name="input">Input stream</param>
    /// <param name="package">Package reference</param>
    /// <param name="worksheet">Worksheet reference</param>
    /// <returns>
    /// <para>
    /// A <see cref="ActionResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="ActionResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public override ActionResult Execute(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet)
    {
        if (Settings == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Settings);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxDocumentMetadataSettings settings)
    {
        var outputStream = new MemoryStream();

        try
        {
            package.Workbook.Properties.SetDocumentMetadata(settings);
            package.SaveAs(outputStream);

            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = outputStream
            });
        }
        catch (Exception ex)
        {
            return ActionResult.FromException(
                ex,
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }

    #endregion
}
