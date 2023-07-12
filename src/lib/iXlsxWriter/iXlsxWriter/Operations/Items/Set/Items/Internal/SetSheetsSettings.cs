
using System;
using System.IO;
using System.Linq;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Settings;
using iTin.Utilities.Xlsx.Design.Settings.Document;
using iTin.Utilities.Xlsx.Design.Settings.Sheets;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Set;

/// <summary>
/// A Specialization of <see cref="SetBase"/> class.<br/>
/// Sets sheets settings. Allows to set the sheet margins, header, footer, default view, size and orientation.
/// </summary>
internal class SetSheetsSettings : SetBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="SetSheetsSettings"/> class.
    /// </summary>
    public SetSheetsSettings()
    {
        SheetName = string.Empty;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to sheets settings collection.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentMetadataSettings"/> reference to sheets settings collection.
    /// </value>
    public XlsxSheetsSettingsCollection Settings { get; set; }

    #endregion

    #region protected override methods

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

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxSheetsSettingsCollection settings)
    {
        var outputStream = new MemoryStream();

        try
        {
            var settingsSheetsNames = settings.Select(sheet => sheet.SheetName).ToList();
            var settingsSheetsCount = settingsSheetsNames.Count;

            var i = 0;
            var sheets = package.Workbook.Worksheets;
            foreach (var sheet in sheets)
            {
                #region Select appropiate sheet settings

                var sheetMatch = settingsSheetsNames.Contains(sheet.Name);
                var sheetSettings = XlsxSheetSettings.Default;
                if (i <= settingsSheetsCount - 1)
                {
                    sheetSettings = sheetMatch ? settings.FirstOrDefault(s => s.SheetName == sheet.Name) : settings[i];
                }

                if (sheetSettings == null)
                {
                    continue;
                }

                #endregion

                #region Updates sheet view

                sheet.View.ToEppSheetView(sheetSettings.View);

                if (sheetSettings.View == KnownDocumentView.Normal)
                {
                    if (sheetSettings.FreezePanesPoint.Column != 1 && sheetSettings.FreezePanesPoint.Row != 1)
                    {
                        sheet.View.FreezePanes(sheetSettings.FreezePanesPoint.Row, sheetSettings.FreezePanesPoint.Column);
                    }
                }

                #endregion

                #region Updates sheet header

                sheet.HeaderFooter.SetSheetHeader(sheetSettings.Header);

                #endregion

                #region Updates sheet footer

                sheet.HeaderFooter.SetSheetFooter(sheetSettings.Footer);

                #endregion

                #region Updates page orientation, margins and size

                sheet.PrinterSettings.PaperSize = sheetSettings.Size.ToEppPaperSize();
                sheet.PrinterSettings.Orientation = sheetSettings.Orientation.ToEppOrientation();
                sheet.PrinterSettings.SetMarginsFromModel(sheetSettings.Margins);

                var hasDimension = sheet.Dimension != null;
                if (!hasDimension)
                {
                    continue;
                }

                var printAreaRange = sheet.Cells[sheet.Dimension.Address];
                sheet.PrinterSettings.PrintArea = printAreaRange;
                //sheet.PrinterSettings.RepeatRows = sheetSettings.Cells[repeatRowsRange];

                #endregion

                i++;
            }

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
