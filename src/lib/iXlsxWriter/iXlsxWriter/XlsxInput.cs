
using System;
using System.Diagnostics;

using OfficeOpenXml;

using iXlsxWriter.ComponentModel;
using iXlsxWriter.ComponentModel.Result.Insert;
using iXlsxWriter.ComponentModel.Result.Replace;
using iXlsxWriter.ComponentModel.Result.Set;

using NativeIO = System.IO;

namespace iXlsxWriter;

/// <summary>
/// Represents a xlsx file.
/// </summary>
/// <seealso cref="IInput"/>
/// <seealso cref="ICloneable"/>
public partial class XlsxInput
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
        AutoUpdateChanges = true;
        DeletePhysicalFilesAfterMerge = true;
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

    #region private methods

    private InsertResult InsertImplStrategy(IInsert data, XlsxInput context)
        => data == null ? InsertResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    private ReplaceResult ReplaceImplStrategy(IReplace data, IInput context)
        => data == null ? ReplaceResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    private SetResult SetImplStrategy(ISet data, XlsxInput context)
        => data == null ? SetResult.CreateErrorResult("Missing data") : data.Apply(ToStream(), context);

    #endregion
}
