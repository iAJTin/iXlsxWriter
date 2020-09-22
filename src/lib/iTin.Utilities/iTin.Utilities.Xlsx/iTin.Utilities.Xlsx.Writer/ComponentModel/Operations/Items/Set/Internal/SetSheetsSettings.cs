
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;

    using Design.Settings;
    using Design.Settings.Document;
    using Design.Settings.Sheets;

    using Result.Set;

    /// <summary>
    /// A Specialization of <see cref="SetBase"/> class.<br/>
    /// Sets sheets settings. Allows to set the sheet margins, header, footer, default view, size and orientation.
    /// </summary>
    internal class SetSheetsSettings : SetBase
    {
        #region constructor/s

        #region [public] SetSheetsSettings(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SetSheetsSettings"/> class.
        /// </summary>
        public SetSheetsSettings()
        {
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxSheetsSettingsCollection) Settings: ets or sets a reference to sheets settings collection
        /// <summary>
        /// Gets or sets a reference to sheets settings collection.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxDocumentMetadataSettings"/> reference to sheets settings collection.
        /// </value>
        public XlsxSheetsSettingsCollection Settings { get; set; }
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (SetResult) SetImpl(Stream, IInput): Implementation to execute when set action
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

        #endregion

        #region private static methods

        private static SetResult SetImpl(IInput context, Stream input, XlsxSheetsSettingsCollection settings)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    var settingsSheetsNames = settings.Select(sheet => sheet.SheetName).ToList();
                    var settingsSheetsCount = settingsSheetsNames.Count();

                    int i = 0;
                    var sheets = excel.Workbook.Worksheets;
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

                        ExcelRange printAreaRange = sheet.Cells[sheet.Dimension.Address];
                        sheet.PrinterSettings.PrintArea = printAreaRange;
                        //sheet.PrinterSettings.RepeatRows = sheetSettings.Cells[repeatRowsRange];

                        #endregion

                        i++;
                    }

                    excel.SaveAs(outputStream);

                    return SetResult.CreateSuccessResult(new SetResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = outputStream
                    });
                }
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
}
