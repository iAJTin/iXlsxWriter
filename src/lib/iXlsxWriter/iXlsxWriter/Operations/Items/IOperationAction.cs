
using System.IO;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;

using OfficeOpenXml;

namespace iXlsxWriter.Operations;

/// <summary>
/// Defines allowed actions for an input object
/// </summary>
public interface IOperationAction
{
    /// <summary>
    /// Gets or sets the name of the sheet where it will be inserted.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the name of the sheet where it will be inserted.
    /// </value>
    string SheetName { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// </returns>
    ActionResult Execute(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet);
}
