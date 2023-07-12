
using System;
using System.Collections.Generic;
using System.IO;

using OfficeOpenXml;

using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Input;
using iXlsxWriter.Operations.Result.Action;

namespace iXlsxWriter.Operations.Insert;

/// <summary>
/// A Specialization of <see cref="InsertBase"/> class.<br/>
/// Allows insert a <see cref="Dictionary{TKey,TValue}"/> reference.
/// TKey is <see cref="string"/>
/// TValue is <see cref="object"/>.
/// </summary>
public class InsertDictionary : InsertBase
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertDataTable"/> class.
    /// </summary>
    public InsertDictionary()
    {
        Data = null;
        SheetName = string.Empty;
        Location = new XlsxPointRange { Column = 1, Row = 1 };
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to dictionary to insert.
    /// </summary>
    /// <value>
    /// A <see cref="Dictionary{TKey, TValue}"/> reference to insert. TKey is <see cref="string"/>, TValue is <see cref="object"/>.
    /// </value>
    public Dictionary<string, object> Data { get; set; }

    /// <summary>
    /// Gets or sets a reference a <see cref="XlsxPointRange"/> which represents the insert location.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPointRange"/> object that contains the insert location.
    /// </value>
    public XlsxPointRange Location { get; set; }

    /// <summary>
    /// Gets or sets a reference containing the cell data and headers styles to use.
    /// </summary>
    /// <value>
    /// A <see cref="DataStyles"/> object that contains the cell styles to use
    /// </value>
    public DictionaryStyles Styles { get; set; }

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

        Location ??= new XlsxPointRange { Column = 1, Row = 1 };

        if (Data == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        if (Styles == null)
        {
            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = input
            });
        }

        return ExecuteImpl(context, input, package, worksheet, Location, Data, Styles);
    }

    #endregion

    #region private static methods

    private static ActionResult ExecuteImpl(IXlsxInput context, Stream input, ExcelPackage package, ExcelWorksheet worksheet, XlsxPointRange location, Dictionary<string, object> data, DictionaryStyles styles)
    {
        var outputStream = new MemoryStream();

        try
        {
            // cell styles > Headers
            var headerTextTextStyle = package.CreateStyle(styles.Headers.Text);

            // cell styles > Values
            var valueTextTextStyle = package.CreateStyle(styles.Values.Text);
            var valueDatetimeCellStyle = package.CreateStyle(styles.Values.DateTime);
            var valueDecimalCellStyle = package.CreateStyle(styles.Values.Decimal);

            var keys = data.Keys;
            foreach (var key in keys)
            {
                var isOdd = location.Row.IsOdd();

                var headerCell = worksheet.Cells[location.Row, location.Column];
                headerCell.StyleName = isOdd ? $"{headerTextTextStyle.Name}_Alternate" : headerTextTextStyle.Name ?? XlsxBaseStyle.NameOfDefaultStyle;
                headerCell.Value = key;

                var value = data[key];
                var valueCell = worksheet.Cells[location.Row, location.Column + 1];

                var styleToUse = value switch
                {
                    string => valueTextTextStyle,
                    float => valueDecimalCellStyle,
                    double => valueDecimalCellStyle,
                    DateTime => valueDatetimeCellStyle,
                    _ => valueTextTextStyle
                };

                valueCell.StyleName = isOdd ? $"{styleToUse.Name}_Alternate" : styleToUse.Name ?? XlsxBaseStyle.NameOfDefaultStyle;
                valueCell.Value = styleToUse.Content.DataType.GetFormattedDataValue(value.ToString()).FormattedValue;

                location.Offset(0, 1);
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
