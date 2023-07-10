
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using OfficeOpenXml;

using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a <b>XML</b> data file.
/// </summary>
public class InsertXmlData : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertXmlData"/> class.
    /// </summary>
    public InsertXmlData()
    {
        File = null;
        SheetName = string.Empty;
        Location = new XlsxPointRange {Column = 1, Row = 1};
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to datatable to insert.
    /// </summary>
    /// <value>
    /// A <see cref="DataTable"/> reference to insert.
    /// </value>
    public string File { get; set; }

    #endregion

    #region protected override methods

    /// <summary>
    /// Implementation to execute when insert action.
    /// </summary>
    /// <param name="context">Input context</param>
    /// <param name="input"></param>
    /// <param name="package"></param>
    /// <param name="worksheet"></param>
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
        if (string.IsNullOrEmpty(SheetName))
        {
            return ActionResult.CreateErrorResult(
                "Sheet name can not be null or empty",
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }

        if (Location == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (string.IsNullOrEmpty(File))
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, File);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, string file)
    {
        var outputStream = new MemoryStream();

        try
        {
            var locationAddress = location.ToEppExcelAddress();
            //worksheet.Cells[locationAddress.ToString()].lo(data, true);

            var a = LoadXmlFromFile(file, "*");

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

    /// <summary>
    /// Retrieves <c>Xml</c> content of specified <paramref name="table" /> in a file.
    /// </summary>
    /// <param name="fileName">Target filename</param>
    /// <param name="table">Table to retrieve</param>
    /// <returns>
    /// A collection of <see cref="T:System.Xml.Linq.XElement"/> that contains the table content as <strong>XML</strong>.
    /// </returns>
    private static IEnumerable<XElement> LoadXmlFromFile(string fileName, string table)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(table));
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        IEnumerable<XElement> nodes = null;
        using var stream = new FileStream(iTin.Core.IO.Path.PathResolver(fileName), FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        var reader = new XmlTextReader(stream);
        var document = XDocument.Load(reader);
        var root = document.Root;
        if (root != null)
        {
            nodes = table == "*"
                ? root.Elements()
                : root.Elements(table);
        }

        ////var query = from element in root.Elements()
        ////            group element.Attributes().FirstOrDefault() by element.Name;
        ////var qq = from e in query let c = e.Count() where c > 1 select e.GetEnumerator();
        ////var vvvv = qq.Cast<XAttribute>().ToList();

        return nodes;
    }

    #endregion
}
