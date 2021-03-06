﻿
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core;
    using iTin.Core.IO;
    using iTin.Core.Helpers;
    using iTin.Core.Models.Design;
    using iTin.Core.Models.Design.Enums;

    using Shared;

    /// <summary>
    /// Defines a <b>xlsx</b> picture.
    /// </summary>
    public partial class XlsxPicture : ICombinable<XlsxPicture>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxBorder _border;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxPictureContent _content;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxEffectsCollection _effects;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxShapeEffects _shapeEffects;
        #endregion

        #region constructor/s

        #region [public] XlsxPicture(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxPicture"/> class.
        /// </summary>
        public XlsxPicture()
        {
            Show = DefaultShow;
            UnderliyingImage = XlsxImage.Null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxPicture>.Combine(XlsxPicture): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference to combine with this instance</param>
        void ICombinable<XlsxPicture>.Combine(XlsxPicture reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxPicture) Default: Returns a new instance containing default picture settings
        /// <summary>
        /// Returns a new instance containing default picture settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPicture"/> reference containing the default picture settings.
        /// </value>
        public static XlsxPicture Default => new XlsxPicture();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) BorderSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool BorderSpecified => !Border.IsDefault;
        #endregion

        #region [public] (bool) ContentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ContentSpecified => !Content.IsDefault;
        #endregion

        #region [public] (bool) EffectsSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool EffectsSpecified => !Effects.IsDefault;
        #endregion

        #region [public] (bool) IsUriPath: Gets a value that indicates if the path value corresponds to a uri address
        /// <summary>
        /// Gets a value that indicates if the path value corresponds to a uri address.
        /// </summary>
        /// <value>
        /// <b>true</b> if the path value corresponds to a uri address; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public bool IsUriPath => Path.HasValue() && File.IsUrl(Path);
        #endregion

        #region [public] (bool) ShapeEffectsSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ShapeEffectsSpecified => !ShapeEffects.IsDefault;
        #endregion

        #region [public] (bool) SizeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool SizeSpecified => !Size.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxBorder) Border: Gets or sets a value containing border picture settings
        /// <summary>
        /// Gets or sets a value containing border picture settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBorder"/> reference containing border picture settings.
        /// </value>
        [XmlElement]
        [JsonProperty("border")]
        public XlsxBorder Border
        {
            get => _border ?? (_border = new XlsxBorder());
            set => _border = value;
        }
        #endregion

        #region [public] (XlsxPictureContent) Content: Gets or sets a value containing picture content settings
        /// <summary>
        /// Gets or sets a value containing picture content settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPictureContent"/> reference containing picture content settings.
        /// </value>
        [XmlElement]
        [JsonProperty("content")]
        public XlsxPictureContent Content
        {
            get => _content ?? (_content = new XlsxPictureContent());
            set => _content = value;
        }
        #endregion

        #region [public] (XlsxEffectsCollection) Effects: Gets or sets a value containing picture effects settings
        /// <summary>
        /// Gets or sets a value containing picture effects settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxEffectsCollection"/> reference containing picture effects settings.
        /// </value>
        [JsonProperty("effects")]
        [XmlArrayItem("Disabled", typeof(XlsxDisabledEffect))]
        [XmlArrayItem("GrayScale", typeof(XlsxGrayScaleEffect))]
        [XmlArrayItem("GrayScaleRed", typeof(XlsxGrayScaleRedEffect))]
        [XmlArrayItem("GrayScaleGreen", typeof(XlsxGrayScaleGreenEffect))]
        [XmlArrayItem("GrayScaleBlue", typeof(XlsxGrayScaleBlueEffect))]
        [XmlArrayItem("Brightness", typeof(XlsxBrightnessEffect))]
        [XmlArrayItem("MoreBrightness", typeof(XlsxMoreBrightnessEffect))]
        [XmlArrayItem("Dark", typeof(XlsxDarkEffect))]
        [XmlArrayItem("MoreDark", typeof(XlsxMoreDarkEffect))]
        [XmlArrayItem("Opacity", typeof(XlsxOpacityEffect))]
        public XlsxEffectsCollection Effects
        {
            get => _effects ?? (_effects = new XlsxEffectsCollection(this));
            set => _effects = value;
        }
        #endregion

        #region [public] (string) Name: Gets or sets the picture name
        /// <summary>
        ///  Gets or sets the picture name
        /// </summary>
        /// <value>
        /// The picture name.
        /// </value>
        [XmlAttribute]
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region [public] (string) Path: Gets or sets the a reference to image path
        /// <summary>
        /// Gets or sets the a reference to image url or path.<br/>
        /// The use of the <b>~</b> character is allowed to indicate relative paths, and you can also use <b>UNC</b> path
        /// </summary>
        /// <value>
        /// The image url or path.
        /// </value>
        [XmlAttribute]
        [JsonProperty("path")]
        public string Path { get; set; }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays this shape
        /// <summary>
        /// Gets or sets a value that determines whether displays this shape. The default is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> displays this shape; Otherwise, <see cref="YesNo.No"/>. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("show")]
        [DefaultValue(DefaultShow)]
        public YesNo Show
        {
            get => _show;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _show = value;
            }
        }
        #endregion

        #region [public] (XlsxBaseSize) Size: Gets or sets a value containing picture size
        /// <summary>
        /// Gets or sets a value containing picture size.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBaseSize"/> reference containing picture size.
        /// </value>
        [XmlElement]
        [JsonProperty("size")]
        public XlsxBaseSize Size { get; set; }
        #endregion

        #region [public] (XlsxShapeEffects) ShapeEffects: Gets or sets a value containing shape effects reference
        /// <summary>
        /// Gets or sets a value containing shape effects reference.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBaseShadow"/> reference containing shape effects reference.
        /// </value>
        [XmlElement]
        [JsonProperty("shape-effects")]
        public XlsxShapeEffects ShapeEffects
        {
            get => _shapeEffects ?? (_shapeEffects = XlsxShapeEffects.Default);
            set => _shapeEffects = value;
        }
        #endregion
        
        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Size.IsDefault &&
            Border.IsDefault &&
            Effects.IsDefault &&
            Content.IsDefault &&
            ShapeEffects.IsDefault &&
            string.IsNullOrEmpty(Name) &&
            Show.Equals(DefaultShow);
        #endregion

        #endregion

        #region internal properties

        #region [public] (XlsxImage) UnderliyingImage: Gets or sets a reference containing the underliying reference
        /// <summary>
        /// Gets or sets a reference containing the underliying reference.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxImage"/> reference containing the underliying reference.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        internal XlsxImage UnderliyingImage { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxPicture) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxPicture Clone()
        {
            var cloned = (XlsxPicture)MemberwiseClone();
            cloned.Border = Border.Clone();
            cloned.Content = Content.Clone();
            cloned.Effects = Effects.Clone();
            cloned.ShapeEffects = ShapeEffects.Clone();
            cloned.Properties = Properties.Clone();

            if (Size != null)
            {
                cloned.Size = Size.Clone();
            }

            return cloned;
        }
        #endregion

        #region [public] (Image) GetImage(): Returns an processed image instance
        /// <summary>
        /// Returns an processed image instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Drawing.Image"/> containing the processed image.
        /// </returns>
        public Image GetImage()
        {
            if (UnderliyingImage == XlsxImage.Null)
            {
                UnderliyingImage = IsUriPath
                    ? XlsxImage.FromUri(new Uri(Path), new XlsxImageConfig {Effects = Effects.ToEffectTypeCollection().ToArray()})
                    : XlsxImage.FromFile(Path, new XlsxImageConfig {Effects = Effects.ToEffectTypeCollection().ToArray()});
            }

            return UnderliyingImage == XlsxImage.Null ? null : UnderliyingImage.ProcessedImage;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxPicture): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxPicture reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Name == null)
            {
                Name = reference.Name;
            }

            Border.Combine(reference.Border);
            Content.Combine(reference.Content);
            ShapeEffects.Combine(reference.ShapeEffects);
            //Size.Combine(reference.Size);
            //Effects.Combine(reference.Effects);
        }
        #endregion

        #endregion
    }
}
