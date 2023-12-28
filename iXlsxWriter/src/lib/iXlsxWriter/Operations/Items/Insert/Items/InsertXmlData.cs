
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using OfficeOpenXml;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;
using System.Resources;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Utilities;
using System.Web.Services.Description;
using iTin.Core.Models.Design.Table;
using iTin.Utilities.Xlsx.Design.Styles;
using iXlsxWriter.ComponentModel;
using OfficeOpenXml.Style;

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
        Table = new TableDefinition();
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

    /// <summary>
    /// 
    /// </summary>
    public TableDefinition Table { get; set; }

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

        if (Table == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, File, Table);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, string file, TableDefinition table)
    {
        var outputStream = new MemoryStream();

        try
        {
            var resources = (Resources)table.Resources;
            var styles = (XlsxStylesCollection)resources.Styles;
            var fields = table.Fields;
            var filter = table.Filter;
            var locationAddress = location.ToEppExcelAddress();
            
            var allRows = LoadXmlFromFile(file, table.Name).ToList();
            var rows = (XElement[])allRows.ToArray().Clone();

            var hasDataFilter = !filter.IsEmpty;
            if (hasDataFilter && filter.Active == YesNo.Yes )
            {
                var expression = filter.BuildFilterExpression();
                rows = (XElement[])allRows.ToList().FindAll(item => expression.IsSatisfiedBy(item)).ToArray().Clone();
            }

            foreach (var style in styles)
            {
                package.CreateEmptyNamedStyle((XlsxCellStyle)style);
            }



            #region sets fields's width
            //if (table.AutoFitColumns == YesNo.No)
            //{
            //    for (var col = 0; col < items.Count; col++)
            //    {
            //        var field = items[col];
            //        var width = field.CalculateWidthValue();
            //        var column = worksheet.Column(x + col);
            //        var isBestFit = width.Equals(double.NaN);
            //        if (isBestFit)
            //        {
            //            column.BestFit = true;
            //        }
            //        else
            //        {
            //            column.Width = width;
            //        }
            //    }
            //}
            #endregion

            #region add top aggregates

            //var rowsCount = rows.Length;
            //var columnHeaders = table.Headers;
            //var hasColumnheaders = columnHeaders.Any();

            //var topAggregates = fields.GetRange(KnownAggregateLocation.Top).ToList();
            //var hasTopAggregates = topAggregates.Any();
            //if (hasTopAggregates)
            //{
            //    if (table.ShowDataValues == YesNo.Yes)
            //    {
            //        foreach (var field in topAggregates)
            //        {
            //            var aggregate = field.Aggregate;
            //            var formula = new XlsxFormulaResolver(aggregate)
            //            {
            //                StartRow = hasColumnheaders && table.ShowColumnHeaders == YesNo.Yes ? 3 : 2,
            //                EndRow = hasColumnheaders && table.ShowColumnHeaders == YesNo.Yes
            //                    ? rowsCount + 2
            //                    : rowsCount + 1,
            //                HasAutoFilter = table.AutoFilter,
            //            };

            //            var column = fields.IndexOf(field);
            //            var cell = worksheet.Cells[y, x + column];
            //            cell.StyleName = aggregate.Style ?? StyleModel.NameOfDefaultStyle;

            //            var type = aggregate.AggregateType;
            //            if (type == KnownAggregateType.Text)
            //            {
            //                cell.Value = formula.Resolve();
            //            }
            //            else
            //            {
            //                cell.FormulaR1C1 = formula.Resolve();
            //            }
            //        }
            //    }
            //}

            #endregion

            #region add column headers

            //if (table.ShowColumnHeaders == YesNo.Yes)
            //{
            //    if (hasTopAggregates)
            //    {
            //        y++;
            //    }

            //    foreach (var columnHeader in columnHeaders)
            //    {
            //        var cell = worksheet.GetRangeFromModel(y, columnHeader);
            //        cell.Merge = true;
            //        cell.StyleName = columnHeader.Style ?? StyleModel.NameOfDefaultStyle;
            //        cell.Merge = columnHeader.Show == YesNo.Yes;
            //        cell.Value = columnHeader.Show == YesNo.Yes ? columnHeader.Text : string.Empty;

            //        worksheet.AddColumnGroupFromModel(columnHeader);
            //    }
            //}

            #endregion

            #region add headers

            //if (hasColumnheaders)
            //{
            //    y++;
            //}

            //var fieldHeaders = fields.GetRange(YesNo.Yes).ToList();
            //var hasFieldHeaders = fieldHeaders.Any();
            //foreach (var field in fieldHeaders)
            //{
            //    var header = field.Header;
            //    var column = fields.IndexOf(field);

            //    var cell = worksheet.Cells[y, x + column];
            //    cell.Value = field.Alias;
            //    cell.StyleName = header.Style ?? StyleModel.NameOfDefaultStyle;

            //    var showHyperLink = header.HyperLink.Show == YesNo.Yes;
            //    if (!showHyperLink)
            //    {
            //        continue;
            //    }

            //    string tooltip;
            //    if (header.HyperLink.Tooltip.Equals(KnownHyperLinkTooltip.FieldName.ToString()))
            //    {
            //        tooltip = BaseDataField.GetFieldNameFrom(header.Parent);
            //    }
            //    else if (header.HyperLink.Tooltip.Equals(KnownHyperLinkTooltip.FieldAlias.ToString()))
            //    {
            //        tooltip = header.Parent.Alias;
            //    }
            //    else
            //    {
            //        tooltip = header.HyperLink.Tooltip;
            //    }

            //    var hyperLinkStyle = header.Style ?? StyleModel.NameOfDefaultStyle;
            //    if (!header.HyperLink.Style.Equals("Current"))
            //    {
            //        hyperLinkStyle = header.HyperLink.Style;
            //    }

            //    var hyperLinkType = header.HyperLink.Current.GetType().Name;
            //    switch (hyperLinkType)
            //    {
            //        case "WebHyperLink":
            //            var webHyperLink = (WebHyperLink)header.HyperLink.Current;
            //            cell.Hyperlink = new ExcelHyperLink(@"\\Mac\Dropbox\PhotoGrid_1513687137832.jpg"); // ssss!A1", "nando");
            //            cell.StyleName = hyperLinkStyle;

            //            break;
            //    }
            //}

            #endregion

            #region add data

            //if (hasFieldHeaders)
            //{
            //    y++;
            //}
            var y = locationAddress.Start.Row;
            var x = locationAddress.Start.Column;
            var fieldDictionary = new Dictionary<BaseDataField, int>();
            if (table.ShowDataValues == YesNo.Yes)
            {
                for (var row = 0; row < rows.Length; row++)
                {
                    var rowData = rows[row];

                    var currentRow = row; //Service.SetCurrentRow(row);
                    for (var col = 0; col < fields.Count; col++)
                    {
                        var currentCol = col; //Service.SetCurrentCol(col);

                        var field = fields[col];
                        field.DataSource = rowData;

                        var currentField = field; // Service.SetCurrentField(field);

                        var value = field.Value; //.GetValue(Provider.SpecialChars);
                        //var valueLenght = value.FormattedValue.Length;

                        var cell = worksheet.Cells[y + row, x + col];
                        cell.Value = "ss"; //value.Value;
                                           //cell.AddErrorComment(value);
                                           //cell.Style.WrapText = field.FieldType == KnownFieldType.Group;

                       var styleName = row.IsOdd()
                           ? $"{value.Style}_Alternate"
                            : value.Style ?? XlsxBaseStyle.NameOfDefaultStyle;
                       cell.StyleID = package.Workbook.Styles.GetNamedStyleId(styleName);
                       var a = styles.GetBy(styleName.Replace("_Alternate", string.Empty));
                       var b = (XlsxCellStyle)a;
                       cell.Style.FormatFromModel(b);


                       //cell.StyleName = row.IsOdd()
                       //    ? $"{value.Style.Name}_Alternate"
                       //    : value.Style.Name ?? StyleModel.NameOfDefaultStyle;

                       //if (!fieldDictionary.ContainsKey(field))
                       //{
                       //    fieldDictionary.Add(field, valueLenght);
                       //}
                       //else
                       //{
                       //    var entry = fieldDictionary[field];
                       //    if (valueLenght > entry)
                       //    {
                       //        fieldDictionary[field] = valueLenght;
                       //    }
                       //}
                    }
                }
            }

            #endregion

            #region add bottom aggregates

            //var fieldsWithBottomAggregates = fields.GetRange(KnownAggregateLocation.Bottom).ToList();
            //var hasBottomAggregates = fieldsWithBottomAggregates.Any();
            //if (table.ShowDataValues == YesNo.Yes)
            //{
            //    if (hasBottomAggregates)
            //    {
            //        foreach (var field in fieldsWithBottomAggregates)
            //        {
            //            var aggregate = field.Aggregate;
            //            var formula = new ExcelFormulaResolver(aggregate)
            //            {
            //                EndRow = -1,
            //                StartRow = -rowsCount,
            //                HasAutoFilter = Table.AutoFilter,
            //            };

            //            var column = items.IndexOf(field);
            //            var cell = worksheet.Cells[y + rowsCount, x + column];
            //            cell.StyleName = aggregate.Style ?? StyleModel.NameOfDefaultStyle;

            //            var type = aggregate.AggregateType;
            //            if (type == KnownAggregateType.Text)
            //            {
            //                cell.Value = formula.Resolve();
            //            }
            //            else
            //            {
            //                cell.FormulaR1C1 = formula.Resolve();
            //            }
            //        }
            //    }
            //}

            #endregion

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
