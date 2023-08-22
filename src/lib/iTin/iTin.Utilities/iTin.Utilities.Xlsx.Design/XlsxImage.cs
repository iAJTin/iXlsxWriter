
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using iTin.Core;
using iTin.Core.Drawing;
using iTin.Core.Drawing.ComponentModel;
using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Image;
using iTin.Utilities.Xlsx.Design.Picture;
using iTin.Utilities.Xlsx.Design.Shared;

using iTinIO = iTin.Core.IO;
using NativeImage = System.Drawing.Image;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> image object.
/// </summary>
public partial class XlsxImage
{
    #region public static readonly members

    /// <summary>
    /// Gets a reference indicating that this instance is not valid.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxImage"/> reference.
    /// </value>
    public static readonly XlsxImage Null = new() { IsValid = false };

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _scaleX;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private float _scaleY;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool _hasScaledFit;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool _hasScaledPercent;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxImage"/> class.
    /// </summary>
    internal XlsxImage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxImage"/> class with a image path and optional image configuration.
    /// </summary>
    /// <param name="imagePath">A reference to image path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
    /// <param name="configuration">Image configuration reference.</param>
    internal XlsxImage(string imagePath, XlsxImageConfig configuration = null) : this(NativeImage.FromFile(iTinIO.Path.PathResolver(imagePath)), configuration)
    {
        Path = iTinIO.File.ToUri(iTinIO.Path.PathResolver(imagePath));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxImage"/> class with a image path and optional image configuration.
    /// </summary>
    /// <param name="image">A reference to image object.</param>
    /// <param name="configuration">Image configuration reference.</param>
    internal XlsxImage(NativeImage image, XlsxImageConfig configuration = null)
    {
        var safeConfiguration = configuration;
        if (configuration == null)
        {
            safeConfiguration = XlsxImageConfig.Default;
        }

        Path = null;
        Configuration = safeConfiguration.Clone();
        OriginalImage = (NativeImage)image.Clone();

        var concreteOriginalImage = (Bitmap)image.Clone();
        if (Configuration.UseTransparentBackground)
        {
            if (Configuration.TransparentColor.Equals(XlsxImageConfig.DefaultColor, StringComparison.OrdinalIgnoreCase))
            {
                Configuration.SetParentImage(concreteOriginalImage);
            }

            concreteOriginalImage.MakeTransparent(Configuration.GetColor());
        }

        System.Drawing.Image processedImage = (System.Drawing.Image)concreteOriginalImage.Clone();
        if (Configuration.Effects != null)
        {
            processedImage = (System.Drawing.Image)concreteOriginalImage.ApplyEffects(Configuration.Effects).Clone();
        }

        ProcessedImage = (System.Drawing.Image)processedImage.Clone();
        ScaledHeight = processedImage.Height;
        ScaledWidth = processedImage.Width;

        Image = (System.Drawing.Image) ProcessedImage.Clone();

        IsValid = true;
    }

    #endregion

    #region finalizer

    /// <summary>
    /// Finalizer
    /// </summary>
    ~XlsxImage()
    {
        Dispose(false);
    }

    #endregion

    #region public static operators

    /// <summary>
    /// Implements the equality operator (==). Check if two objects <see cref="XlsxImage"/> are equal.
    /// </summary>
    /// <param name="left">Left part of equality. </param>
    /// <param name="right">Right part of equality. </param>
    /// <returns>
    /// <b>true</b> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <b>false</b>.
    /// </returns>
    public static bool operator ==(XlsxImage left, XlsxImage right) => left.Equals(right);

    /// <summary>
    /// Implements the inequality operator (!=). Check if two objects <see cref="XlsxImage"/> are not equal.
    /// </summary>
    /// <param name="left">Left part of equality. </param>
    /// <param name="right">Right part of equality. </param>
    /// <returns>
    /// <b>true</b> if <paramref name="left"/> not equal to <paramref name="right"/>; otherwise, <b>false</b>.
    /// </returns>
    public static bool operator !=(XlsxImage left, XlsxImage right) => !left.Equals(right);

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a reference to image configuration information.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxImageConfig"/> that contains the configuration information.
    /// </value>
    public XlsxImageConfig Configuration { get; }

    /// <summary>
    /// Gets a reference to pdf image object.
    /// </summary>
    /// <value>A <see cref="T:System.Drawing.Image"/> object that contains a reference to image object.</value>
    public NativeImage Image { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the current instance is valid.
    /// </summary>
    /// <value>
    /// <b>true</b> if current instance is valid; otherwise <b>false</b>.
    /// </value>
    public bool IsValid { get; private set; }

    /// <summary>
    /// Gets a reference to original image.
    /// </summary>
    /// <value>
    /// A <see cref="Image"/> object that contains a reference to pdf image object.
    /// </value>
    public NativeImage OriginalImage { get; }

    /// <summary>
    /// Gets a reference to image uri.
    /// </summary>
    /// <value>A <see cref="T:System.Uri"/> that contains the image uri.</value>
    public Uri Path { get; }

    /// <summary>
    /// Gets a reference to the original image after it has been processed.
    /// </summary>
    /// <value>
    /// A <see cref="System.Drawing.Image"/> object that contains a reference to pdf image object.
    /// </value>
    public NativeImage ProcessedImage { get; private set; }

    /// <summary>
    /// Gets a value containing scaled height of this image.
    /// </summary>
    /// <value>
    /// A <see cref="float"/> containing scaled height of this image.
    /// </value>
    public float ScaledHeight { get; }

    /// <summary>
    /// Gets a value containing scaled width of this image.
    /// </summary>
    /// <value>
    /// A <see cref="float"/> containing scaled width of this image.
    /// </value>
    public float ScaledWidth { get; }

    #endregion

    #region public methods

    /// <summary>
    /// Apply effects image to this instance.
    /// </summary>
    /// <param name="effects">the dimensions to fit</param>
    /// <returns>
    /// Returns this instance with effects.
    /// </returns>
    public XlsxImage ApplyEffects(EffectType[] effects)
    {
        if (Equals(Null))
        {
            return this;
        }

        if (Image == null)
        {
            return this;
        }

        var image = Configuration.Effects == null
            ? NativeImage.FromStream(OriginalImage.AsStream())
            : NativeImage.FromStream(OriginalImage.ApplyEffects(Configuration.Effects).AsStream());

        ProcessedImage = (NativeImage)image.ApplyEffects(effects).Clone();
        Image = (NativeImage)ProcessedImage.Clone();

        if (_hasScaledFit)
        {
            ScaleToFit(_scaleX, _scaleY);
        }

        if (_hasScaledPercent)
        {
            ScalePercent(_scaleX, _scaleY);
        }

        return this;
    }

    /// <summary>
    /// Scale the image to a certain percentage.
    /// </summary>
    /// <param name="percent">the scaling percentage</param>
    /// <returns>
    /// Returns this instance scaled to percent value.
    /// </returns>
    public XlsxImage ScalePercent(float percent) => ScalePercent(percent, percent);

    /// <summary>
    /// Scale the width and height of an image to a certain percentage.
    /// </summary>
    /// <param name="size">the scaling percentage of the width and height</param>
    /// <returns>
    /// Returns this instance scaled to percent value.
    /// </returns>
    public XlsxImage ScalePercent(SizeF size) => ScalePercent(size.Width, size.Height);

    /// <summary>
    /// Scale the width and height of an image to a certain percentage.
    /// </summary>
    /// <param name="percentX">the scaling percentage of the width</param>
    /// <param name="percentY">the scaling percentage of the height</param>
    /// <returns>
    /// Returns this instance scaled to percent value.
    /// </returns>
    public XlsxImage ScalePercent(float percentX, float percentY)
    {
        if (this.Equals(XlsxImage.Null))
        {
            return this;
        }

        if (Image == null)
        {
            return this;
        }

        _hasScaledFit = false;
        _hasScaledPercent = true;
        _scaleX = percentX;
        _scaleY = percentY;

        Image.ScalePercent(percentX, percentY);

        return this;
    }

    /// <summary>
    /// Scales the images to the dimensions of the rectangle.
    /// </summary>
    /// <param name="rectangle">the dimensions to fit</param>
    /// <returns>
    /// Returns this instance scaled.
    /// </returns>
    public XlsxImage ScaleToFit(Rectangle rectangle) => ScaleToFit(rectangle.Width, rectangle.Height);

    /// <summary>
    /// Scales the images to the dimensions of the size.
    /// </summary>
    /// <param name="size">the scaling percentage of the size</param>
    /// <returns>
    /// Returns this instance scaled to percent value.
    /// </returns>
    public XlsxImage ScaleToFit(SizeF size) => ScaleToFit(size.Width, size.Height);

    /// <summary>
    /// Scales this image so that it fits a certain width and height.
    /// </summary>
    /// <param name="width">the width to fit</param>
    /// <param name="height">the height to fit</param>
    /// <returns>
    /// Returns this instance scaled.
    /// </returns>
    public XlsxImage ScaleToFit(float width, float height)
    {
        if (this.Equals(XlsxImage.Null))
        {
            return this;
        }

        if (Image == null)
        {
            return this;
        }

        _hasScaledPercent = false;
        _hasScaledFit = true;
        _scaleX = width;
        _scaleY = height;

        var original = (NativeImage)OriginalImage.Clone();
        var originalWithEffects = original;
        if (Configuration.Effects != null)
        {
            originalWithEffects = original.ApplyEffects(Configuration.Effects);
        }

        ProcessedImage = (NativeImage)originalWithEffects.ScaleToFit(width, height).Clone();

        return this;
    }

    /// <summary>
    /// Creates a new <see cref="XlsxPicture"/> instance from this image.
    /// </summary>
    /// <param name="pictureName">Picture name</param>
    /// <param name="size">Picture size</param>
    /// <param name="border">Picture border</param>
    /// <param name="content">Picture content</param>
    /// <param name="shapeEffects">picture shape effects</param>
    /// <returns>
    /// A <see cref="XlsxPicture"/> reference from this image.
    /// </returns>
    public XlsxPicture AsPicture(string pictureName, XlsxBaseSize size = null, XlsxBorder border = null, XlsxPictureContent content = null, XlsxShapeEffects shapeEffects = null) =>
        new()
        {
            Name = pictureName,
            UnderliyingImage = this,
            Size = size ?? XlsxSize.Default,
            Border = border ?? XlsxBorder.Default,
            ShapeEffects = shapeEffects ?? XlsxShapeEffects.Default,
            Content = content ?? XlsxPictureContent.Default,
            Path = Path == null ? null : Path.AbsolutePath
        };

    #endregion

    #region public static methods

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from specified byte array, format and optional image effect collection.
    /// </summary>
    /// <param name="array">Image as byte array.</param>
    /// <param name="configuration">An image configuration to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static XlsxImage FromByteArray(byte[] array, XlsxImageConfig configuration = null) => FromStream(array.ToMemoryStream(), configuration);

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from specified image path and optional image configuration.
    /// </summary>
    /// <param name="imagePath">Image path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
    /// <param name="configuration">An image configuration to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static XlsxImage FromFile(string imagePath, XlsxImageConfig configuration = null) => new(imagePath, configuration);

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from specified image and optional image effect collection.
    /// </summary>
    /// <param name="image">Image reference.</param>
    /// <param name="configuration">An image effects collection to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static XlsxImage FromImage(NativeImage image, XlsxImageConfig configuration = null) => new(image, configuration);

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from specified stream, format and optional image effect collection.
    /// </summary>
    /// <param name="stream">Image as stream.</param>
    /// <param name="configuration">An image configuration to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static XlsxImage FromStream(Stream stream, XlsxImageConfig configuration = null) => FromImage(NativeImage.FromStream(stream), configuration);

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from the specified uri with the specified format, optionally you can also specify a collection of effects to apply to the image.
    /// If the process of getting the image fails or the uri is wrong, <b>null</b> is returned.
    /// </summary>
    /// <param name="imageUri">Uri to image resource.</param>
    /// <param name="configuration">An image configuration to apply.</param>
    /// <param name="timeout">An image effects collection to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static XlsxImage FromUri(Uri imageUri, XlsxImageConfig configuration = null, int timeout = 15000)
    {
        SentinelHelper.ArgumentNull(imageUri, nameof(imageUri));

        XlsxImage result = XlsxImage.Null;

        var uriIsAccesibleResult = imageUri.IsAccessible();
        if (!uriIsAccesibleResult.Success)
        {
            return result;
        }

        try
        {
            using var response = GetResponse(imageUri, timeout);
            var xlsxImage = FromStream(response.GetResponseStream(), configuration);
            if (xlsxImage.Equals(Null))
            {
                Task.Delay(300);

                using var responseAlternative = GetResponse(imageUri, timeout);
                xlsxImage = FromStream(response.GetResponseStream(), configuration);
                if (xlsxImage.Equals(Null))
                {
                    Task.Delay(500);
                    xlsxImage = GetXlsxImageByWebClient(imageUri);
                }
            }

            result = xlsxImage;
        }
        catch
        {
            return result;
        }

        return result;
    }

    #endregion

    #region public static async methods

    /// <summary>
    /// Creates a new <see cref="XlsxImage"/> object from the specified uri with the specified format, optionally you can also specify a collection of effects to apply to the image.
    /// If the process of getting the image fails or the uri is wrong, <b>null</b> is returned.
    /// </summary>
    /// <param name="imageUri">Uri to image resource.</param>
    /// <param name="configuration">An image configuration to apply.</param>
    /// <param name="timeout">An image effects collection to apply.</param>
    /// <returns>
    /// A new <see cref="XlsxImage"/> reference represents image.
    /// </returns>
    public static async Task<XlsxImage> FromUriAsync(Uri imageUri, XlsxImageConfig configuration = null, int timeout = 15000)
    {
        SentinelHelper.ArgumentNull(imageUri, nameof(imageUri));

        XlsxImage result = Null;

        var uriIsAccesibleResult = await imageUri.IsAccessibleAsync().ConfigureAwait(false);
        if (!uriIsAccesibleResult.Success)
        {
            return result;
        }

        try
        {
            using var response = await GetResponseAsync(imageUri, timeout).ConfigureAwait(false);

            var xlsxImage = FromStream(response.GetResponseStream(), configuration);
            if (xlsxImage.Equals(Null))
            {
                await Task.Delay(300).ConfigureAwait(false);

                using var responseAlternative = await GetResponseAsync(imageUri, timeout).ConfigureAwait(false);
                xlsxImage = FromStream(responseAlternative.GetResponseStream(), configuration);
                if (xlsxImage.Equals(Null))
                {
                    await Task.Delay(500).ConfigureAwait(false);
                    xlsxImage = await GetXlsxImageByWebClientAsync(imageUri).ConfigureAwait(false);
                }
            }

            result = xlsxImage;
        }
        catch
        {
            return result;
        }

        return result;
    }

    #endregion

    #region private static methods

    private static HttpWebResponse GetResponse(Uri imageUri, int timeout = 15000)
    {
        var request = (HttpWebRequest)WebRequest.Create(imageUri);
        request.Timeout = timeout;
        request.ReadWriteTimeout = timeout;

        return (HttpWebResponse)request.GetResponse();
    }

    private static XlsxImage GetXlsxImageByWebClient(Uri imageUri)
    {
        XlsxImage result = Null;

        try
        {
            using var webClient = new WebClient();
            using var ms = new MemoryStream(webClient.DownloadData(imageUri));
            var bmp = NativeImage.FromStream(ms);

            return FromImage(bmp);
        }
        catch
        {
            return result;
        }
    }

    #endregion

    #region private static async methods

    private static async Task<HttpWebResponse> GetResponseAsync(Uri imageUri, int timeout = 15000)
    {
        var request = (HttpWebRequest)WebRequest.Create(imageUri);
        request.Timeout = timeout;
        request.ReadWriteTimeout = timeout;

        return (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false);
    }

    private static async Task<XlsxImage> GetXlsxImageByWebClientAsync(Uri imageUri)
    {
        XlsxImage result = Null;

        try
        {
            using var webClient = new WebClient();
            using var ms = new MemoryStream(await webClient.DownloadDataTaskAsync(imageUri).ConfigureAwait(false));
            var bmp = NativeImage.FromStream(ms);

            return FromImage(bmp);
        }
        catch
        {
            return result;
        }
    }

    #endregion
}
