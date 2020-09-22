
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System.Drawing.Imaging;

    using iTin.Core.Drawing.ComponentModel;
    using iTin.Core.Drawing.Helpers;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseEffect"/> class.<br/>
    /// Represents gray-scale blue effect.
    /// </summary>
    public partial class XlsxGrayScaleBlueEffect
    {
        /// <summary>
        /// Returns the manipulation of the colors in an image to an effect.
        /// </summary>
        /// <returns>
        /// A <see cref="ImageAttributes"/> object that contains the information about how bitmap colors are manipulated. 
        /// </returns>
        public override ImageAttributes Apply() => ImageHelper.GetImageAttributesFromEffect(EffectType.GrayScaleBlue);
    }
}
