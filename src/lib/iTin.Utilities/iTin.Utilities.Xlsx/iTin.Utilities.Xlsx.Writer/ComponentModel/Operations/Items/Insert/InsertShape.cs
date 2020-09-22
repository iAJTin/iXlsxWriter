
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;
    using OfficeOpenXml.Helpers;

    using iTin.Core;
    using iTin.Core.Models.Design.Enums;

    using Design.Shape;
    using Design.Shared;

    using Result.Insert;

    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert a <b>xlsx</b> shape.
    /// </summary>
    public class InsertShape : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertShape(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertShape"/> class.
        /// </summary>
        public InsertShape()
        {
            Location = null;
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxShape) Shape: Gets or sets a reference to shape configuration
        /// <summary>
        /// Gets or sets a reference to shape configuration.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShape"/> reference to shape configuration.
        /// </value>
        public XlsxShape Shape { get; set; }
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

            if (Shape == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Shape.Show == YesNo.No)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return InsertImpl(context, input, SheetName, Location, Shape);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location, XlsxShape xlsxShape)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
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

                    var shapeName = xlsxShape.Name.HasValue() ? xlsxShape.Name : $"shape{ws.Drawings.Count}";
                    var shape = ws.Drawings.AddShape(shapeName, eShapeStyle.Rect);

                    var writer = new OfficeOpenShapeWriter(shape, ws);
                    writer.SetBorder(xlsxShape.Border);
                    writer.SetContent(xlsxShape.Content);
                    writer.SetFont(xlsxShape.Content.Font);
                    writer.SetPosition(location);
                    writer.SetSize(xlsxShape.Size);
                    writer.SetShapeEffects(xlsxShape.ShapeEffects, shapeName);
                    writer.SetShapeStyle(xlsxShape.ShapeType);
                    writer.SetText(xlsxShape.Content.Text);

                    excel.SaveAs(outputStream);

                    return InsertResult.CreateSuccessResult(new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = outputStream
                    });
                }
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
