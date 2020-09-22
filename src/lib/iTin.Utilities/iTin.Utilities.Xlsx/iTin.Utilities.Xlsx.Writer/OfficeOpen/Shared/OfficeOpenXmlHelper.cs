
namespace OfficeOpenXml
{
    /// <summary>
    /// Static class than contains helper methods.
    /// </summary>
    internal static class OfficeOpenXmlHelper
    {
        /// <summary>
        /// The percentage precision is measured in 1000th of a percent (1/1000%)
        /// </summary>
        public const int ST_PERCENTAGE = 1000;

        /// <summary>
        /// The angle in degree can be expressed as an integer number by multiplying it with 60000
        /// </summary>
        public const int ST_POSITIVE_FIXED_ANGLE = 60000;


        /// <summary>
        /// The key measurement unit of Open XML (specifically DrawingML) is English Metric Unit or EMU. EMU is defined as 1/360000 cm.<br/>
        /// This is EMU value for cm.<br/>
        /// 1 EMU = 1/360000 cm => 1 cm = 360000 EMUs
        /// </summary>
        public const int EMU_PER_CM = 360000;

        /// <summary>
        /// The key measurement unit of Open XML (specifically DrawingML) is English Metric Unit or EMU. EMU is defined as 1/360000 cm.<br/>
        /// This is EMU value for inch.<br/>
        /// 1 inch = 2.54 cm = 2.54 * 360000 EMUs = 914400 EMUs
        /// </summary>
        public const int EMU_PER_INCH = 914400;

        /// <summary>
        /// The key measurement unit of Open XML (specifically DrawingML) is English Metric Unit or EMU. EMU is defined as 1/360000 cm.<br/>
        /// This is EMU value for pixel.<br/>
        /// 96 ppi (pixels per inch) => 96 pixels = 1 inch = 914400 EMUs => 1 pixel = 914400 / 96 EMUs = 9525 EMUs
        /// </summary>
        public const int EMU_PER_PIXEL = 9525;

        /// <summary>
        /// The key measurement unit of Open XML (specifically DrawingML) is English Metric Unit or EMU. EMU is defined as 1/360000 cm.<br/>
        /// This is EMU value for point.<br/>
        /// 72 dpi (dots per inch) => 72 points = 1 inch = 914400 EMUs => 1 point = 914400 / 72 EMUs = 12700 EMUs
        /// </summary>
        public const int EMU_PER_POINT = 12700;

        
        /// <summary>
        /// Returns header/footer parsed text 
        /// </summary>
        /// <param name="text">Text to parse.</param>
        /// <returns>
        /// Parsed header/footer text.
        /// </returns>
        public static string GetHeaderFooterParsedText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text
                .Replace(KnownHeaderFooterConstants.PageNumber, ExcelHeaderFooter.PageNumber)
                .Replace(KnownHeaderFooterConstants.NumberOfPages, ExcelHeaderFooter.NumberOfPages)
                .Replace(KnownHeaderFooterConstants.FontColor, ExcelHeaderFooter.FontColor)
                .Replace(KnownHeaderFooterConstants.SheetName, ExcelHeaderFooter.SheetName)
                .Replace(KnownHeaderFooterConstants.FilePath, ExcelHeaderFooter.FilePath)
                .Replace(KnownHeaderFooterConstants.FileName, ExcelHeaderFooter.FileName)
                .Replace(KnownHeaderFooterConstants.CurrentDate, ExcelHeaderFooter.CurrentDate)
                .Replace(KnownHeaderFooterConstants.CurrentTime, ExcelHeaderFooter.CurrentTime)
                .Replace(KnownHeaderFooterConstants.Image, ExcelHeaderFooter.Image)
                .Replace(KnownHeaderFooterConstants.OutlineStyle, ExcelHeaderFooter.OutlineStyle)
                .Replace(KnownHeaderFooterConstants.ShadowStyle, ExcelHeaderFooter.ShadowStyle);
        }
    }
}
