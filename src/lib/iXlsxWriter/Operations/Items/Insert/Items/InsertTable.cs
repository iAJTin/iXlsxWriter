
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using iTin.Core.Helpers;
using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table;
using iTin.Core.Models.Design.Table.Fields;

using iTin.Utilities.Xlsx.Design;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Design.Table.Headers;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
/// Allows insert a <b>XML</b> data file.
/// </summary>
public class InsertTable : InsertLocationBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertTable"/> class.
    /// </summary>
    public InsertTable()
    {
        Data = null;
        Table = new XlsxTable();
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
    public IDataInput Data { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public XlsxTable Table { get; set; }

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

        if (Data == null)
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

        return ExecuteImpl(context, input, package, worksheet, Location, Data, Table);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxBaseRange location, IDataInput dataInput, XlsxTable table)
    {
        var outputStream = new MemoryStream();

        try
        {
            #region create model service

            var inputModel = new InputDataModel { Model = table, DataInput = dataInput, References = table.References, CurrentFilter = table.Filter};
            var service = inputModel.CreateService();
            
            #endregion

            #region initialize

            var fields = table.Fields;
            var resources = (Resources)table.Resources;
            var locationAddress = location.ToEppExcelAddress();
            var x = locationAddress.Start.Column;
            var y = locationAddress.Start.Row;

            #endregion

            #region get target data

            var rows = service.RawDataFiltered;

            #endregion

            #region sets fields's width

            if (table.AutoFitColumns == YesNo.No)
            {
                for (var col = 0; col < fields.Count; col++)
                {
                    var field = fields[col];
                    var width = field.CalculateWidthValue();
                    var column = worksheet.Column(x + col);
                    var isBestFit = width.Equals(double.NaN);
                    if (isBestFit)
                    {
                        column.BestFit = true;
                    }
                    else
                    {
                        column.Width = width;
                    }
                }
            }

            #endregion

            #region add styles

            var styles = (XlsxStylesCollection)resources.Styles;
            foreach (var style in styles)
            {
                package.CreateEmptyNamedStyle((XlsxCellStyle)style);
            }

            #endregion

            #region add top aggregates

            var rowsCount = rows.Length;
            var columnHeaders = table.Headers;
            var hasColumnheaders = columnHeaders.Any();

            var topAggregates = fields.GetRange(KnownAggregateLocation.Top).ToList();
            var hasTopAggregates = topAggregates.Any();
            if (hasTopAggregates)
            {
                if (table.ShowDataValues == YesNo.Yes)
                {
                    foreach (var field in topAggregates)
                    {
                        //var aggregate = field.Aggregate;
                        //var formula = new XlsxFormulaResolver(aggregate)
                        //{
                        //    StartRow = hasColumnheaders && table.ShowColumnHeaders == YesNo.Yes ? 3 : 2,
                        //    EndRow = hasColumnheaders && table.ShowColumnHeaders == YesNo.Yes
                        //        ? rowsCount + 2
                        //        : rowsCount + 1,
                        //    HasAutoFilter = table.AutoFilter,
                        //};

                        //var column = fields.IndexOf(field);
                        //var cell = worksheet.Cells[y, x + column];
                        //cell.StyleName = aggregate.Style ?? StyleModel.NameOfDefaultStyle;

                        //var type = aggregate.AggregateType;
                        //if (type == KnownAggregateType.Text)
                        //{
                        //    cell.Value = formula.Resolve();
                        //}
                        //else
                        //{
                        //    cell.FormulaR1C1 = formula.Resolve();
                        //}
                    }
                }
            }

            #endregion

            #region add column headers

            if (table.ShowColumnHeaders == YesNo.Yes)
            {
                if (hasTopAggregates)
                {
                    y++;
                }

                foreach (var columnHeader in columnHeaders)
                {
                    var cell = worksheet.CreateRangeFromModel(y, (XlsxColumnHeader)columnHeader);
                    cell.Merge = true;
                    cell.Style.FormatFromModel((XlsxCellStyle)styles.GetBy(columnHeader.Style ?? XlsxBaseStyle.NameOfDefaultStyle));
                    cell.Merge = columnHeader.Show == YesNo.Yes;
                    cell.Value = columnHeader.Show == YesNo.Yes ? columnHeader.Text : string.Empty;

                    worksheet.AddColumnGroupFromModel((XlsxColumnHeader)columnHeader);
                }
            }

            #endregion

            #region add headers

            if (hasColumnheaders)
            {
                y++;
            }

            var fieldHeaders = fields.GetRange(YesNo.Yes).ToList();
            var hasFieldHeaders = fieldHeaders.Any();
            foreach (var field in fieldHeaders)
            {
                var header = field.Header;
                var column = fields.IndexOf(field);

                var cell = worksheet.Cells[y, x + column];
                cell.Value = field.Alias;
                cell.Style.FormatFromModel((XlsxCellStyle)styles.GetBy(header.Style ?? XlsxBaseStyle.NameOfDefaultStyle));
                //cell.StyleName = header.Style ?? XlsxBaseStyle.NameOfDefaultStyle;

                //var showHyperLink = header.HyperLink.Show == YesNo.Yes;
                //if (!showHyperLink)
                //{
                //    continue;
                //}

                //string tooltip;
                //if (header.HyperLink.Tooltip.Equals(KnownHyperLinkTooltip.FieldName.ToString()))
                //{
                //    tooltip = BaseDataField.GetFieldNameFrom(header.Parent);
                //}
                //else if (header.HyperLink.Tooltip.Equals(KnownHyperLinkTooltip.FieldAlias.ToString()))
                //{
                //    tooltip = header.Parent.Alias;
                //}
                //else
                //{
                //    tooltip = header.HyperLink.Tooltip;
                //}

                //var hyperLinkStyle = header.Style ?? StyleModel.NameOfDefaultStyle;
                //if (!header.HyperLink.Style.Equals("Current"))
                //{
                //    hyperLinkStyle = header.HyperLink.Style;
                //}

                //var hyperLinkType = header.HyperLink.Current.GetType().Name;
                //switch (hyperLinkType)
                //{
                //    case "WebHyperLink":
                //        var webHyperLink = (WebHyperLink)header.HyperLink.Current;
                //        cell.Hyperlink = new ExcelHyperLink(@"\\Mac\Dropbox\PhotoGrid_1513687137832.jpg"); // ssss!A1", "nando");
                //        cell.StyleName = hyperLinkStyle;

                //        break;
                //}
            }

            #endregion

            #region add data

            if (hasFieldHeaders)
            {
                y++;
            }

            var fieldDictionary = new Dictionary<BaseDataField, int>();
            if (table.ShowDataValues == YesNo.Yes)
            {
                for (var row = 0; row < rows.Length; row++)
                {
                    var rowData = rows[row];

                    service.SetCurrentRow(row);
                    for (var col = 0; col < fields.Count; col++)
                    {
                        service.SetCurrentCol(col);

                        var field = fields[col];
                        field.DataSource = rowData;

                        service.SetCurrentField(field);
                        var valueStyle = (XlsxCellStyle)styles.GetBy(field.Value.Style);
                        var cellValue = field.Value.GetValue(service.CurrentProvider.SpecialChars);
                        var valueInformation = valueStyle.Content.DataType.GetFormattedDataValue(cellValue);

                        var cell = worksheet.Cells[y + row, x + col];
                        cell.Value = valueInformation.Value;
                        cell.AddErrorComment(valueInformation);
                        cell.Style.WrapText = field.FieldType == KnownFieldType.Group;

                        var styleName = row.IsOdd()
                            ? $"{field.Value.Style}_Alternate"
                            : field.Value.Style ?? XlsxBaseStyle.NameOfDefaultStyle;

                        cell.Style.FormatFromModel((XlsxCellStyle)styles.GetBy(field.Value.Style));
                    }
                }
            }

            #endregion

            #region add bottom aggregates

            var fieldsWithBottomAggregates = fields.GetRange(KnownAggregateLocation.Bottom).ToList();
            var hasBottomAggregates = fieldsWithBottomAggregates.Any();
            if (table.ShowDataValues == YesNo.Yes)
            {
                if (hasBottomAggregates)
                {
                    foreach (var field in fieldsWithBottomAggregates)
                    {
                        var aggregate = field.Aggregate;
                        //var formula = new ExcelFormulaResolver(aggregate)
                        //{
                        //    EndRow = -1,
                        //    StartRow = -rowsCount,
                        //    HasAutoFilter = Table.AutoFilter,
                        //};

                        var column = fields.IndexOf(field);
                        var cell = worksheet.Cells[y + rowsCount, x + column];
                        cell.StyleName = aggregate.Style ?? XlsxBaseStyle.NameOfDefaultStyle;

                        //var type = aggregate.AggregateType;
                        //if (type == KnownAggregateType.Text)
                        //{
                        //    cell.Value = formula.Resolve();
                        //}
                        //else
                        //{
                        //    cell.FormulaR1C1 = formula.Resolve();
                        //}
                    }
                }
            }

            #endregion

            #region autofitcolumns

            if (table.AutoFitColumns == YesNo.Yes)
            {
                try
                {
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                }
                catch
                {
                    //worksheet.AutoFitGroupColumns(fieldDictionary, this);
                }
            }

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

    #endregion
}
