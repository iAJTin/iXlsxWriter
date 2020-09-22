
namespace iTin.Charting.Models.Design
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using ComponentModel;

    /// <summary>
    /// Defines chart resolution
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownChartResolution
    {
        /// <summary>
        /// Represents a custom resolution defined by user
        /// </summary>
        [ScreenResolution(Name = "Custom Resolution", Width = 0, Height = 0, AspectRatio = "By user", AspectRatioNormalized = "By user")]
        Custom,

        /// <summary>
        /// Represents an <b>CGA (Color Graphics Adapter)</b> resolution. The size is <b>(320, 200)</b>.
        /// </summary>
        [ScreenResolution(Name = "Color Graphics Adapter", Width = 320, Height = 200, AspectRatio = "16:10", AspectRatioNormalized = "1.6:1")]
        CGA,

        /// <summary>
        /// Represents an <b>JBCGenericDisplay (JBC JTSE-2A)</b> resolution. The size is <b>(800, 400)</b>.
        /// </summary>
        [ScreenResolution(Name = "JBC JTSE-2A", Width = 800, Height = 400, AspectRatio = "2:1", AspectRatioNormalized = "2:1")]
        JBCGenericDisplay,

        /// <summary>
        /// Represents an <b>QVGA (Quarter Video Graphics Array)</b> resolution. The size is <b>(320, 240)</b>.
        /// </summary>
        [ScreenResolution(Name = "Quarter Video Graphics Array", Width = 320, Height = 240, AspectRatio = "4:3", AspectRatioNormalized = "1.33:1")]
        QVGA,

        /// <summary>
        /// Represents an <b>EGA (Enhanced Graphics Adapter)</b> resolution. The size is <b>(640, 350)</b>.
        /// </summary>
        [ScreenResolution(Name = "Enhanced Graphics Adapter", Width = 640, Height = 350, AspectRatio = "11:6", AspectRatioNormalized = "1.83:1")]
        EGA,

        /// <summary>
        /// Represents a <b>VGA (Enhanced Graphics Adapter)</b> resolution. The size is <b>(640, 480)</b>.
        /// </summary>
        [ScreenResolution(Name = "Video Graphics Array", Width = 640, Height = 480, AspectRatio = "4:3", AspectRatioNormalized = "1.33:1")]
        VGA,

        /// <summary>
        /// Represents a <b>HGC (Hercules Graphics Card)</b> resolution. The size is <b>(720, 348)</b>.
        /// </summary>
        [ScreenResolution(Name = "Hercules Graphics Card", Width = 720, Height = 348, AspectRatio = "60:29", AspectRatioNormalized = "2.07:1")]
        HGC,

        /// <summary>
        /// Represents a <b>Lisa (Apple Lisa)</b> resolution. The size is <b>(720, 360)</b>.
        /// </summary>
        [ScreenResolution(Name = "Apple Lisa", Width = 720, Height = 360, AspectRatio = "2:1", AspectRatioNormalized = "2:1")]
        Lisa,

        /// <summary>
        /// Represents a <b>SVGA (Super Video Graphics Array)</b> resolution. The size is <b>(800, 600)</b>.
        /// </summary>
        [ScreenResolution(Name = "Super Video Graphics Array", Width = 800, Height = 600, AspectRatio = "4:3", AspectRatioNormalized = "1.33:1")]
        SVGA,

        /// <summary>
        /// Represents a <b>WVGA (Wide Video Graphics Array)</b> resolution. The size is <b>(850, 480)</b>.
        /// </summary>
        [ScreenResolution(Name = "Wide Video Graphics Array", Width = 850, Height = 480, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        WVGA,

        /// <summary>
        /// Represents a <b>XGA (Extended Graphics Array)</b> resolution. The size is <b>(1024, 768)</b>.
        /// </summary>
        [ScreenResolution(Name = "Extended Graphics Array", Width = 1024, Height = 768, AspectRatio = "4:3", AspectRatioNormalized = "1.33:1")]
        XGA,

        /// <summary>
        /// Represents a <b>HDReady (HD Ready)</b> resolution. The size is <b>(1280, 720)</b>.
        /// </summary>
        [ScreenResolution(Name = "Extended Graphics Array", Width = 1280, Height = 720, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        HDReady,

        /// <summary>
        /// Represents an <b>WXGA (Wide Extended Graphics Array)</b> resolution. The size is <b>(1366, 768)</b>.
        /// </summary>
        [ScreenResolution(Name = "Wide Extended Graphics Array", Width = 1366, Height = 768, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        WXGA,

        /// <summary>
        /// Represents a <b>SXGA (Super Extendes Graphics Array)</b> resolution. The size is <b>(1280, 1024)</b>.
        /// </summary>
        [ScreenResolution(Name = "Super Extendes Graphics Array", Width = 1280, Height = 1024, AspectRatio = "5:4", AspectRatioNormalized = "1.25:1")]
        SXGA,

        /// <summary>
        /// Represents a <b>WSXGA (Wide Screen Super Extendes Graphics Array)</b> resolution. The size is <b>(1600, 900)</b>.
        /// </summary>
        [ScreenResolution(Name = "Wide Screen Super Extendes Graphics Array", Width = 1600, Height = 900, AspectRatio = "16:9", AspectRatioNormalized = "1.56:1")]
        WSXGA,

        /// <summary>
        /// Represents an <b>UXGA (Ultra eXtended Graphics Array)</b> resolution. The size is <b>(1600, 1200)</b>.
        /// </summary>
        [ScreenResolution(Name = "Ultra eXtended Graphics Array", Width = 1600, Height = 1200, AspectRatio = "4:3", AspectRatioNormalized = "1.33:1")]
        UXGA,

        /// <summary>
        /// Represents a <b>FHD (Full HD)</b> resolution. The size is <b>(1920, 1080)</b>.
        /// </summary>
        [ScreenResolution(Name = "Full HD", Width = 1920, Height = 1080, AspectRatio = "16:9", AspectRatioNormalized = "1.56:1")]
        FHD,

        /// <summary>
        /// Represents a <b>WUXGA (Wide Ultra eXtended Graphics Array)</b> resolution. The size is <b>(1920, 1200)</b>.
        /// </summary>
        [ScreenResolution(Name = "Wide Ultra eXtended Graphics Array", Width = 1920, Height = 1200, AspectRatio = "16:10", AspectRatioNormalized = "1.6:1")]
        WUXGA,

        /// <summary>
        /// Represents a <b>Retina (Apple Retina Display)</b> resolution. The size is <b>(2880, 1800)</b>.
        /// </summary>
        [ScreenResolution(Name = "Apple Retina Display", Width = 2880, Height = 1800, AspectRatio = "16:10", AspectRatioNormalized = "1.6:1")]
        Retina,

        /// <summary>
        /// Represents a <b>Retina (Apple Retina 16inch Display)</b> resolution. The size is <b>(3072, 1920)</b>.
        /// </summary>
        [ScreenResolution(Name = "Apple Retina 16inch Display", Width = 3072, Height = 1920, AspectRatio = "16:10", AspectRatioNormalized = "1.6:1")]
        Retina16inch,

        /// <summary>
        /// Represents an <b>UHDV (Ultra High Definition TeleVision)</b> resolution. The size is <b>(3840, 2160)</b>.
        /// </summary>
        [ScreenResolution(Name = "Ultra High Definition TeleVision", Width = 3840, Height = 2160, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        UHDV,

        /// <summary>
        /// Represents an <b>Cinema4K (4K)</b> resolution. The size is <b>(4096, 2160)</b>.
        /// </summary>
        [ScreenResolution(Name = "4K", Width = 4096, Height = 2160, AspectRatio = "17:9", AspectRatioNormalized = "1.80:1")]
        Cinema4K,

        /// <summary>
        /// Represents a <b>Retina5K (Apple Retina 5K Display)</b> resolution. The size is <b>(5120, 2880)</b>.
        /// </summary>
        [ScreenResolution(Name = "Apple Retina 5K Display", Width = 5120, Height = 2880, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        Retina5K,

        /// <summary>
        /// Represents a <b>Retina6K (Apple Retina 6K Display)</b> resolution. The size is <b>(6016, 3384)</b>.
        /// </summary>
        [ScreenResolution(Name = "Apple Retina 6K Display", Width = 6016, Height = 3384, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        Retina6K,

        /// <summary>
        /// Represents an <b>UHDV8k (Ultra High Definition TeleVision 8K)</b> resolution. The size is <b>(3840, 2160)</b>.
        /// </summary>
        [ScreenResolution(Name = "Ultra High Definition TeleVision 8K", Width = 7680, Height = 4320, AspectRatio = "16:9", AspectRatioNormalized = "1.78:1")]
        UHDV8k,

        /// <summary>
        /// Represents a <b>Cinema8K (8K)</b> resolution. The size is <b>(4096, 4320)</b>.
        /// </summary>
        [ScreenResolution(Name = "8K", Width = 8192, Height = 4320, AspectRatio = "17:9", AspectRatioNormalized = "1.80:1")]
        Cinema8K,
    }
}
