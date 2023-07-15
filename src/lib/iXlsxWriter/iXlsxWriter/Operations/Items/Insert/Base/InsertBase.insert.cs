
using System.IO;

using OfficeOpenXml;

using iXlsxWriter.Abstractions.Writer.Operations.Results;

using iXlsxWriter.Input;

namespace iXlsxWriter.Operations.Insert;

public abstract partial class InsertBase : IInsert
{
    /// <summary>
    /// Gets a value indicating whether to check that the name is not null or empty.
    /// </summary>
    /// <value>
    /// <b>true</b> if check name; otherwise, <b>false</b>.
    /// </value>
    public virtual bool CheckSheetName => true;

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
