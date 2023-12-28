
using System.IO;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;

using OfficeOpenXml;

namespace iXlsxWriter.Operations.Insert;

public abstract partial class InsertLocationBase
{
    /// <summary>
    /// Gets or sets the name of the sheet where it will be inserted.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the name of the sheet where it will be inserted.
    /// </value>
    public string SheetName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public abstract ActionResult Execute(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet);
}
