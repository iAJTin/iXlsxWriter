
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shape;
using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> shape.
/// </summary>
public partial class XlsxShape
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const ShapeType DefaultShapeType = ShapeType.Rect;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxSize _size;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private ShapeType _type;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBorder _border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxShapeContent _content;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxShapeEffects _shapeEffects;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxShape"/> class.
    /// </summary>
    public XlsxShape()
    {
        Show = DefaultShow;
        ShapeType = DefaultShapeType;
    }

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default shape settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShape"/> reference containing the default shape settings.
    /// </value>
    public static XlsxShape Default => new();

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
    /// Gets or sets a value containing border shape settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBorder"/> reference containing border shape settings.
    /// </value>
    [XmlElement]
    [JsonProperty("border")]
    public XlsxBorder Border
    {
        get => _border ??= new XlsxBorder();
        set => _border = value;
    }

    /// <summary>
    /// Gets or sets a value containing shape content settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShapeContent"/> reference containing shape content settings.
    /// </value>
    [XmlElement]
    [JsonProperty("content")]
    public XlsxShapeContent Content
    {
        get => _content ??= new XlsxShapeContent();
        set => _content = value;
    }

    /// <summary>
    ///  Gets or sets the shape name
    /// </summary>
    /// <value>
    /// The shape name.
    /// </value>
    [XmlAttribute]
    [JsonProperty("name")]
    public string Name { get; set; }

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
    /// Gets or sets a value containing shape size.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxSize"/> reference containing shape size.
    /// </value>
    [XmlElement]
    [JsonProperty("size")]
    public XlsxSize Size
    {
        get => _size ??= new XlsxSize();
        set => _size = value;
    }

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

    /// <summary>
    /// Gets or sets the preferred shape type. The default is <see cref="Shape.ShapeType.Rect"/>.
    /// </summary>
    /// <value>
    /// Preferred shape type.
    /// </value>
    [XmlAttribute]
    [JsonProperty("shape-type")]
    [DefaultValue(DefaultShapeType)]
    public ShapeType ShapeType
    {
        get => _type;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _type = value;
        }
    }

    #endregion
}
