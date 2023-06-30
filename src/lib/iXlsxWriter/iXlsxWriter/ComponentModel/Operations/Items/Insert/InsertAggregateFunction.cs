
using System;
using System.IO;
using System.Linq;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

using OfficeOpenXml;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.ComponentModel.Result.Insert;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert an aggregate function applied to specified data range in the specified location.
    /// </summary>
    public class InsertAggregateFunction : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertAggregateFunction(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertAggregateFunction"/> class.
        /// </summary>
        public InsertAggregateFunction()
        {
            SheetName = string.Empty;
            Style = XlsxCellStyle.Default;
            Aggegate = new QualifiedAggregateDefinition();
            Location = new XlsxPointRange { Column = 1, Row = 1 };
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (QualifiedAggregateDefinition) Aggegate: Gets or sets a reference to aggregate definition
        /// <summary>
        /// Gets or sets a reference to aggregate definition.
        /// </summary>
        /// <value>
        /// A <see cref="QualifiedAggregateDefinition"/> reference to aggregate definition.
        /// </value>
        public QualifiedAggregateDefinition Aggegate { get; set; }
        #endregion

        #region [public] (XlsxCellStyle) Style: Gets or sets a reference to datatable to insert
        /// <summary>
        /// Gets or sets a reference to datatable to insert.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxCellStyle"/> reference to insert.
        /// </value>
        public XlsxCellStyle Style { get; set; }
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (InsertResult) InsertImpl(Stream, IInput): Implementation to execute when insert action
        /// <summary>
        /// Implementation to execute when insert action.
        /// </summary>
        /// <param name="input">stream input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        protected override InsertResult InsertImpl(Stream input, IInput context)
        {
            if (string.IsNullOrEmpty(SheetName))
            {
                return InsertResult.CreateErroResult(
                    "Sheet name can not be null or empty",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            if (Location == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Aggegate == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Style == null)
            {
                Style = XlsxCellStyle.Default;
            }

            return InsertImpl(context, input, SheetName, Location, Aggegate, Style);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location, QualifiedAggregateDefinition aggregate, XlsxCellStyle style)
        {
            var outputStream = new MemoryStream();

            try
            {
                using var excel = new ExcelPackage(input);
                var ws = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
                if (ws == null)
                {
                    return InsertResult.CreateErroResult(
                        $"Sheet '{sheetName}' not found",
                        new InsertResultData
                        {
                            Context = context,
                            InputStream = input,
                            OutputStream = input
                        });
                }

                string aggregateWorksheetName = aggregate.WorkSheet;
                if (string.IsNullOrEmpty(aggregate.WorkSheet))
                {
                    aggregateWorksheetName = sheetName;
                }

                var aggregateWorksheet = ws;
                bool sameSheetName = aggregateWorksheetName.Equals(sheetName, StringComparison.OrdinalIgnoreCase);
                if (!sameSheetName)
                {
                    aggregateWorksheet = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(aggregateWorksheetName, StringComparison.OrdinalIgnoreCase));
                }

                if (aggregateWorksheet == null)
                {
                    return InsertResult.CreateErroResult(
                        $"Aggregate sheet '{aggregateWorksheetName}' not found",
                        new InsertResultData
                        {
                            Context = context,
                            InputStream = input,
                            OutputStream = input
                        });
                }

                ExcelAddressBase locationAddress = location.ToEppExcelAddress();
                XlsxCellStyle safeStyle = excel.CreateStyle(style);
                XlsxCellMerge merge = safeStyle.Content.Merge;
                string range = merge.Cells == 1
                    ? locationAddress.ToString()
                    : merge.Orientation == KnownMergeOrientation.Horizontal
                        ? ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row, locationAddress.Start.Column + merge.Cells - 1)
                        : ExcelCellBase.GetAddress(locationAddress.Start.Row, locationAddress.Start.Column, locationAddress.Start.Row + merge.Cells - 1, locationAddress.Start.Column);

                ExcelRange cell = aggregateWorksheet.Cells[range];
                cell.StyleName = cell.StyleName = locationAddress.End.Row.IsOdd()
                    ? $"{safeStyle.Name}_Alternate"
                    : safeStyle.Name ?? XlsxBaseStyle.NameOfDefaultStyle;

                if (style.Content.Show == YesNo.Yes)
                {
                    var formula = new XlsxFormulaResolver(aggregate) { HasAutoFilter = aggregate.HasAutoFilter, WorkSheet = sheetName };
                    cell.Formula = formula.Resolve();

                    if (merge.Cells > 1)
                    {
                        cell.Merge = true;
                    }
                }

                excel.SaveAs(outputStream);

                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = outputStream
                });
            }
            catch (Exception ex)
            {
                return InsertResult.FromException(
                    ex,
                    new InsertResultData
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
