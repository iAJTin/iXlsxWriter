
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading;

    using iTin.Core;
    using iTin.Core.Drawing;
    using iTin.Core.Drawing.ComponentModel;
    using iTin.Core.Helpers;

    using iTinIO = iTin.Core.IO;

    using Shared;

    /// <summary>
    /// Defines a <b>xlsx</b> image object.
    /// </summary>
    public class XlsxImage : IEquatable<XlsxImage>, IDisposable
    {
        #region public static readonly members

        #region [public] {static} (XlsxImage) Null: Gets a reference indicating that this instance is not valid
        /// <summary>
        /// Gets a reference indicating that this instance is not valid.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxImage"/> reference.
        /// </value>
        public static readonly XlsxImage Null = new XlsxImage { IsValid = false };
        #endregion

        #endregion

        #region private field members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isDisposed;

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

        #region [internal] XlsxImage(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxImage"/> class.
        /// </summary>
        internal XlsxImage()
        {
        }
        #endregion

        #region [internal] XlsxImage(string, XlsxImageConfig = null): Initializes a new instance of the class with a image path and optional image configuration
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxImage"/> class with a image path and optional image configuration.
        /// </summary>
        /// <param name="imagePath">A reference to image path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
        /// <param name="configuration">Image configuration reference.</param>
        internal XlsxImage(string imagePath, XlsxImageConfig configuration = null) : this(Image.FromFile(iTinIO.Path.PathResolver(imagePath)), configuration)
        {
            Path = iTinIO.File.ToUri(iTinIO.Path.PathResolver(imagePath));
        }
        #endregion

        #region [internal] XlsxImage(Image, DocXImageConfig = null): Initializes a new instance of the class from image with optional image configuration
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxImage"/> class with a image path and optional image configuration.
        /// </summary>
        /// <param name="image">A reference to image object.</param>
        /// <param name="configuration">Image configuration reference.</param>
        internal XlsxImage(Image image, XlsxImageConfig configuration = null)
        {
            var safeConfiguration = configuration;
            if (configuration == null)
            {
                safeConfiguration = XlsxImageConfig.Default;
            }

            Path = null;
            Configuration = safeConfiguration.Clone();
            OriginalImage = (Image)image.Clone();

            var concreteOriginalImage = (Bitmap)image.Clone();
            if (Configuration.UseTransparentBackground)
            {
                if (Configuration.TransparentColor.Equals(XlsxImageConfig.DefaultColor, StringComparison.OrdinalIgnoreCase))
                {
                    Configuration.SetParentImage(concreteOriginalImage);
                }

                concreteOriginalImage.MakeTransparent(Configuration.GetColor());
            }

            Image processedImage = (Image)concreteOriginalImage.Clone();
            if (Configuration.Effects != null)
            {
                processedImage = (Image)concreteOriginalImage.ApplyEffects(Configuration.Effects).Clone();
            }

            ProcessedImage = (Image)processedImage.Clone();
            ScaledHeight = processedImage.Height;
            ScaledWidth = processedImage.Width;

            Image = (Image) ProcessedImage.Clone();

            IsValid = true;
        }
        #endregion

        #endregion

        #region finalizer

        #region [~] XlsxImage(): Finalizer
        /// <summary>
        /// Finalizer
        /// </summary>
        ~XlsxImage()
        {
            Dispose(false);
        }
        #endregion

        #endregion

        #region interfaces

        #region IDisposable

        #region public methods

        #region [public] (void) Dispose(): Clean managed resources
        /// <summary>
        /// Clean managed resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

        #endregion

        #region IEquatable

        #region public methods

        #region [public] (bool) Equals(XlsxImage): Indicates whether the current object is equal to another object of the same type
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <b>true</b> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(XlsxImage other) => other.Equals((object)this);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static operators

        #region [public] {static} (bool) operator ==(XlsxImage, XlsxImage): Implements the equality operator (==). Check if two objects XlsxImage are equal
        /// <summary>
        /// Implements the equality operator (==). Check if two objects <see cref="XlsxImage"/> are equal.
        /// </summary>
        /// <param name="left">Left part of equality. </param>
        /// <param name="right">Right part of equality. </param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(XlsxImage left, XlsxImage right) => left.Equals(right);
        #endregion

        #region [public] {static} (bool) operator !=(XlsxImage, XlsxImage): Implements the inequality operator (==). Check if two objects XlsxImage are not equal
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

        #endregion

        #region public readonly properties

        #region [public] (XlsxImageConfig) Configuration: Gets a reference to image configuration information
        /// <summary>
        /// Gets a reference to image configuration information.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxImageConfig"/> that contains the configuration information.
        /// </value>
        public XlsxImageConfig Configuration { get; }
        #endregion

        #region [public] (Image) Image: Gets a reference to pdf image object
        /// <summary>
        /// Gets a reference to pdf image object.
        /// </summary>
        /// <value>A <see cref="T:System.Drawing.Image"/> object that contains a reference to image object.</value>
        public Image Image { get; private set; }
        #endregion

        #region [public] (bool) IsValid: Gets or sets a value indicating whether the current instance is valid
        /// <summary>
        /// Gets or sets a value indicating whether the current instance is valid.
        /// </summary>
        /// <value>
        /// <b>true</b> if current instance is valid; otherwise <b>false</b>.
        /// </value>
        public bool IsValid { get; private set; }
        #endregion

        #region [public] (Image) OriginalImage: Gets a reference to original image
        /// <summary>
        /// Gets a reference to original image.
        /// </summary>
        /// <value>
        /// A <see cref="Image"/> object that contains a reference to pdf image object.
        /// </value>
        public Image OriginalImage { get; }
        #endregion

        #region [public] (Uri) Path: Gets a reference to image uri
        /// <summary>
        /// Gets a reference to image uri.
        /// </summary>
        /// <value>A <see cref="T:System.Uri"/> that contains the image uri.</value>
        public Uri Path { get; }
        #endregion

        #region [public] (Image) ProcessedImage: Gets a reference to the original image after it has been processed
        /// <summary>
        /// Gets a reference to the original image after it has been processed.
        /// </summary>
        /// <value>
        /// A <see cref="System.Drawing.Image"/> object that contains a reference to pdf image object.
        /// </value>
        public Image ProcessedImage { get; private set; }
        #endregion

        #region [public] (float) ScaledHeight: Gets a value containing scaled height of this image
        /// <summary>
        /// Gets a value containing scaled height of this image.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> containing scaled height of this image.
        /// </value>
        public float ScaledHeight { get; }
        #endregion

        #region [public] (float) ScaledWidth: Gets a value containing scaled width of this image
        /// <summary>
        /// Gets a value containing scaled width of this image.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> containing scaled width of this image.
        /// </value>
        public float ScaledWidth { get; }
        #endregion

        #endregion

        #region public methods

        #region [public] (PdfImage) ApplyEffects(EffectType[]): Apply effects image to this instance
        /// <summary>
        /// Apply effects image to this instance.
        /// </summary>
        /// <param name="effects">the dimensions to fit</param>
        /// <returns>
        /// Returns this instance with effects.
        /// </returns>
        public XlsxImage ApplyEffects(EffectType[] effects)
        {
            if (this.Equals(XlsxImage.Null))
            {
                return this;
            }

            if (Image == null)
            {
                return this;
            }

            Image image =
                Configuration.Effects == null
                    ? Image.FromStream(OriginalImage.AsStream())
                    : Image.FromStream(OriginalImage.ApplyEffects(Configuration.Effects).AsStream());

            ProcessedImage = (Image)image.ApplyEffects(effects).Clone();
            Image = (Image)ProcessedImage.Clone();

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
        #endregion

        #region [public] (XlsxImage) ScalePercent(float): Scale the image to a certain percentage
        /// <summary>
        /// Scale the image to a certain percentage.
        /// </summary>
        /// <param name="percent">the scaling percentage</param>
        /// <returns>
        /// Returns this instance scaled to percent value.
        /// </returns>
        public XlsxImage ScalePercent(float percent) => ScalePercent(percent, percent);
        #endregion

        #region [public] (XlsxImage) ScalePercent(SizeF): Scale the width and height of an image to a certain percentage
        /// <summary>
        /// Scale the width and height of an image to a certain percentage.
        /// </summary>
        /// <param name="size">the scaling percentage of the width and height</param>
        /// <returns>
        /// Returns this instance scaled to percent value.
        /// </returns>
        public XlsxImage ScalePercent(SizeF size) => ScalePercent(size.Width, size.Height);
        #endregion

        #region [public] (XlsxImage) ScalePercent(float, float): Scale the width and height of an image to a certain percentage
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
        #endregion

        #region [public] (XlsxImage) ScaleToFit(NativePdfRectangle): Scales this image so to the dimensions of the rectangle
        /// <summary>
        /// Scales the images to the dimensions of the rectangle.
        /// </summary>
        /// <param name="rectangle">the dimensions to fit</param>
        /// <returns>
        /// Returns this instance scaled.
        /// </returns>
        public XlsxImage ScaleToFit(Rectangle rectangle) => ScaleToFit(rectangle.Width, rectangle.Height);
        #endregion

        #region [public] (XlsxImage) ScaleToFit(SizeF): Scales this image so to the dimensions of the size
        /// <summary>
        /// Scales the images to the dimensions of the size.
        /// </summary>
        /// <param name="size">the scaling percentage of the size</param>
        /// <returns>
        /// Returns this instance scaled to percent value.
        /// </returns>
        public XlsxImage ScaleToFit(SizeF size) => ScaleToFit(size.Width, size.Height);
        #endregion

        #region [public] (XlsxImage) ScaleToFit(float, float): Scales this image so that it fits a certain width and height
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

            var original = (Image)OriginalImage.Clone();
            var originalWithEffects = original;
            if (Configuration.Effects != null)
            {
                originalWithEffects = original.ApplyEffects(Configuration.Effects);
            }

            ProcessedImage = (Image)originalWithEffects.ScaleToFit(width, height).Clone();

            return this;
        }
        #endregion

        #region [public] (XlsxPicture) AsPicture(string, XlsxBaseSize = null, XlsxBorder = null, XlsxPictureContent = null, XlsxShapeEffects = null): Creates a new XlsxPicture instance from this image
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
            new XlsxPicture
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

        #endregion

        #region public static methods

        #region [public] {static} (XlsxImage) FromByteArray(byte[], XlsxImageConfig = null): Creates a new XlsxImage object from specified byte array, format and optional image effect collection
        /// <summary>
        /// Creates a new <see cref="XlsxImage"/> object from specified byte array, format and optional image effect collection.
        /// </summary>
        /// <param name="array">Image as byte array.</param>
        /// <param name="configuration">An image configuration to apply.</param>
        /// <returns>
        /// A new <see cref="XlsxImage"/> reference represents image.
        /// </returns>
        public static XlsxImage FromByteArray(byte[] array, XlsxImageConfig configuration = null) => FromStream(array.ToMemoryStream(), configuration);
        #endregion

        #region [public] {static} (XlsxImage) FromFile(string, XlsxImageConfig = null) Creates a new XlsxImage object from specified image path and optional image configuration
        /// <summary>
        /// Creates a new <see cref="XlsxImage"/> object from specified image path and optional image configuration.
        /// </summary>
        /// <param name="imagePath">Image path. The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path.</param>
        /// <param name="configuration">An image configuration to apply.</param>
        /// <returns>
        /// A new <see cref="XlsxImage"/> reference represents image.
        /// </returns>
        public static XlsxImage FromFile(string imagePath, XlsxImageConfig configuration = null) => new XlsxImage(imagePath, configuration);
        #endregion

        #region [public] {static} (XlsxImage) FromImage(Image, XlsxImageConfig = null): Creates a new XlsxImage object from specified image and optional image effect collection
        /// <summary>
        /// Creates a new <see cref="XlsxImage"/> object from specified image and optional image effect collection.
        /// </summary>
        /// <param name="image">Image reference.</param>
        /// <param name="configuration">An image effects collection to apply.</param>
        /// <returns>
        /// A new <see cref="XlsxImage"/> reference represents image.
        /// </returns>
        public static XlsxImage FromImage(Image image, XlsxImageConfig configuration = null) => new XlsxImage(image, configuration);
        #endregion

        #region [public] {static} (XlsxImage) FromStream(Stream, XlsxImageConfig = null): Creates a new XlsxImage object from specified stream, format and optional image effect collection
        /// <summary>
        /// Creates a new <see cref="XlsxImage"/> object from specified stream, format and optional image effect collection.
        /// </summary>
        /// <param name="stream">Image as stream.</param>
        /// <param name="configuration">An image configuration to apply.</param>
        /// <returns>
        /// A new <see cref="XlsxImage"/> reference represents image.
        /// </returns>
        public static XlsxImage FromStream(Stream stream, XlsxImageConfig configuration = null) => FromImage(Image.FromStream(stream), configuration);

        #endregion

        #region [public] {static} (XlsxImage) FromUri(Uri imageUri, XlsxImageConfig = null, int = 5000): Creates a new XlsxImage object from specified uri with the specified format, optionally you can also specify a collection of effects to apply to the image
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

            bool uriIsAccesible = imageUri.IsAccessible();
            if (!uriIsAccesible)
            {
                return result;
            }

            try
            {
                XlsxImage docximage;
                using (var response = GetResponse(imageUri, timeout))
                {
                    docximage = FromStream(response.GetResponseStream(), configuration);
                }

                if (docximage == XlsxImage.Null)
                {
                    Thread.Sleep(300);
                    using (var response = GetResponse(imageUri, timeout))
                    {
                        docximage = FromStream(response.GetResponseStream(), configuration);
                    }

                    if (docximage == XlsxImage.Null)
                    {
                        Thread.Sleep(500);
                        docximage = GetDocXImageByWebClient(imageUri);
                    }
                }

                result = docximage;
            }
            catch
            {
                return result;
            }

            return result;
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (bool) Equals(object): Returns a value that indicates whether this class is equal to another
        /// <summary>
        /// Returns a value that indicates whether this class is equal to another
        /// </summary>
        /// <param name="obj">Class with which to compare.</param>
        /// <returns>
        /// Results equality comparison.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is XlsxImage))
            {
                return false;
            }

            var other = (XlsxImage)obj;

            return
                other.Path == Path &&
                other.IsValid == IsValid &&
                other.ToString().Equals(ToString());
        }
        #endregion

        #region [public] {override} (int) GetHashCode(): Returns a value that represents the hash code for this class
        /// <summary>
        /// Returns a value that represents the hash code for this class.
        /// </summary>
        /// <returns>
        /// Hash code for this class.
        /// </returns>
        public override int GetHashCode() => ToString().GetHashCode();
        #endregion

        #region [public] {override} (string) ToString(): Returns a string than represents the current object.
        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString() => Image == null ? string.Empty : Image.ToString();
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) Dispose(bool): Cleans managed and unmanaged resources
        /// <summary>
        /// Cleans managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// If it is <b>true</b>, the method is invoked directly or indirectly from the user code.
        /// If it is <b>false</b>, the method is called the finalizer and only unmanaged resources are finalized.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            // free managed resources
            if (disposing)
            {
                Image = null;
                OriginalImage?.Dispose();
                ProcessedImage?.Dispose();
            }

            // free native resources

            // avoid seconds calls 
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region private static methods

        private static HttpWebResponse GetResponse(Uri imageUri, int timeout = 15000)
        {
            var request = (HttpWebRequest)WebRequest.Create(imageUri);
            request.Timeout = timeout;
            request.ReadWriteTimeout = timeout;

            return (HttpWebResponse)request.GetResponse();
        }

        private static XlsxImage GetDocXImageByWebClient(Uri imageUri)
        {
            XlsxImage result = XlsxImage.Null;

            try
            {
                Image bmp;
                using (var webClient = new WebClient())
                using (var ms = new MemoryStream(webClient.DownloadData(imageUri)))
                {
                    bmp = Image.FromStream(ms);
                }

                return XlsxImage.FromImage(bmp);
            }
            catch
            {
                return result;
            }
        }

        #endregion
    }
}
