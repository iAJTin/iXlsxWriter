
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
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Picture;

/// <summary>
/// Defines a <b>xlsx</b> picture.
/// </summary>
public partial class XlsxPicture
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

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxPicture"/> class.
    /// </summary>
    public XlsxPicture()
    {
        Show = DefaultShow;
        UnderliyingImage = XlsxImage.Null;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default picture settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxPicture"/> reference containing the default picture settings.
    /// </value>
    public static XlsxPicture Default => new();

    #endregion

    #region public readonly properties

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

    /// <summary>
    /// Gets a value that indicates if the path value corresponds to a uri address.
    /// </summary>
    /// <value>
    /// <b>true</b> if the path value corresponds to a uri address; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    public bool IsUriPath => Path.HasValue() && File.IsUrl(Path);

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

    #region public properties

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
        get => _border ??= new XlsxBorder();
        set => _border = value;
    }

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
        get => _content ??= new XlsxPictureContent();
        set => _content = value;
    }

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
        get => _effects ??= new XlsxEffectsCollection(this);
        set => _effects = value;
    }

    /// <summary>
    ///  Gets or sets the picture name
    /// </summary>
    /// <value>
    /// The picture name.
    /// </value>
    [XmlAttribute]
    [JsonProperty("name")]
    public string Name { get; set; }

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

    /// <summary>
    /// Gets or sets a value containing picture size.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBaseSize"/> reference containing picture size.
    /// </value>
    [XmlElement]
    [JsonProperty("size")]
    public XlsxBaseSize Size { get; set; }

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
        get => _shapeEffects ??= XlsxShapeEffects.Default;
        set => _shapeEffects = value;
    }
        
    #endregion

    #region internal properties

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

    #region public methods

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
}
