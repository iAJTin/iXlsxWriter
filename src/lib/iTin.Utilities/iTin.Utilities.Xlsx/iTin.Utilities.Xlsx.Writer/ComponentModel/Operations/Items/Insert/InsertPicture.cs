
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.IO;
    using System.Linq;

    using OfficeOpenXml;
    using OfficeOpenXml.Drawing;
    using OfficeOpenXml.Helpers;

    using iTin.Core;
    using iTin.Core.Models.Design.Enums;

    using Design.Picture;
    using Design.Shared;

    using Result.Insert;

    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert a picture in the specified location
    /// </summary>
    public class InsertPicture : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertPicture(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertPicture"/> class.
        /// </summary>
        public InsertPicture()
        {
            Location = null;
            SheetName = string.Empty;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxPicture) Picture: Gets or sets a reference to picture configuration
        /// <summary>
        /// Gets or sets a reference to picture configuration.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPicture"/> reference to picture configuration.
        /// </value>
        public XlsxPicture Picture { get; set; }
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

            if (Picture == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (Picture.Show == YesNo.No)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return InsertImpl(context, input, SheetName, Location, Picture);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location, XlsxPicture xlsxPicture)
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

                    using (var image = xlsxPicture.GetImage())
                    {
                        if (image == null)
                        {
                            return InsertResult.CreateErroResult(
                                "The image could not be loaded, please check that the path is correct",
                                new InsertResultData
                                {
                                    Context = context,
                                    InputStream = input,
                                    OutputStream = input
                                });
                        }

                        var pictureName = xlsxPicture.Name.HasValue() ? xlsxPicture.Name : $"picture{ws.Drawings.Count}";
                        foreach (var item in ws.Drawings)
                        {
                            var pic = item as ExcelPicture;
                            if (pic == null)
                            {
                                continue;
                            }

                            var existPicture = pic.Name.Equals(pictureName, StringComparison.OrdinalIgnoreCase);
                            if (!existPicture)
                            {
                                continue;
                            }

                            return InsertResult.CreateErroResult(
                                $"There is already an image with the name '{pictureName}' in the collection, please rename the image.",
                                new InsertResultData
                                {
                                    Context = context,
                                    InputStream = input,
                                    OutputStream = input
                                });
                        }

                        ExcelPicture picture = ws.Drawings.AddPicture(pictureName, image);
                        var writer = new OfficeOpenPictureWriter(picture, ws);
                        writer.SetBorder(xlsxPicture.Border);
                        writer.SetContent(xlsxPicture.Content);
                        writer.SetPosition(location);
                        writer.SetSize(xlsxPicture.Size);
                        writer.SetShapeEffects(xlsxPicture.ShapeEffects, pictureName);
                    }

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
