
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Styles;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="IXlsxStyle"/> interface.<br/>
/// Defines a generic <b>xlsx</b> style.
/// </summary>
public partial class XlsxBaseStyle : IXlsxStyle
{
    #region public constants

    /// <summary>
    /// The name of default style. Always is '_Default_'.
    /// </summary>
    public const string NameOfDefaultStyle = "_Default_";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private BaseContent _content;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxStyleBorders _borders;

    #endregion

    #region interfaces

    #region IStyle

    /// <summary>
    /// Gets or sets the collection of border properties.
    /// </summary>
    /// <value>
    /// Collection of border properties. Each element defines a border.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IBorders IStyle.Borders
    {
        get => _borders;
        set => _borders = (XlsxStyleBorders)value;
    }

    /// <summary>
    /// Gets or sets the content of style
    /// </summary>
    /// <value>
    /// Content
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IContent IStyle.Content
    {
        get => _content;
        set => _content = (BaseContent)value;
    }

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    bool IStyle.IsEmpty => IsDefault;

    /// <summary>
    /// Sets the element that owns this <see cref="IStyle"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void ITenant.SetOwner(IOwner reference) => SetOwner((IXlsxStyles)reference);

    /// <summary>
    /// Gets or sets the name of the style.
    /// </summary>
    /// <value>
    /// The name of the style.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    string IStyle.Name { get => Name; set => Name = value; }

    /// <summary>
    /// Gets or sets the name of parent style.
    /// </summary>
    /// <value>
    /// The name of parent style.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    string IStyle.Inherits { get => Inherits; set => Inherits = value; }

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    bool IStyle.IsDefault => IsDefault;

    /// <summary>
    /// Try gets a reference to inherit model.
    /// </summary>
    /// <returns>
    /// An inherit style.
    /// </returns>
    public IStyle TryGetInheritStyle() => InheritStyle;

    #endregion

    #region IXlsxStyle

    /// <summary>
    /// Gets the element that owns this <see cref="IXlsxStyle"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IXlsxStyles"/> that owns this <see cref="IXlsxStyle"/>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IXlsxStyles IXlsxStyle.Owner => Owner;

    /// <summary>
    /// Sets the element that owns this <see cref="IXlsxStyle"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void IXlsxStyle.SetOwner(IXlsxStyles reference) => SetOwner(reference);

    /// <summary>
    /// Gets the element that owns this <see cref="IXlsxStyle"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IXlsxStyles"/> that owns this <see cref="IXlsxStyle"/>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public IXlsxStyles Owner { get; private set; }

    /// <summary>
    /// Gets or sets the name of the style.
    /// </summary>
    /// <value>
    /// The name of the style.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the name of parent style.
    /// </summary>
    /// <value>
    /// The name of parent style.
    /// </value>
    [DefaultValue("")]
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public string Inherits { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Content.IsDefault &&
        Borders.IsDefault &&
        string.IsNullOrEmpty(Inherits);

    #endregion

    #region ITenant

    /// <summary>
    /// Gets the element that owns this <see cref="IStyle"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IOwner"/> that owns this <see cref="IStyles"/>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IOwner ITenant.Owner => Owner;

    #endregion

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default style.
    /// </summary>
    /// <value>
    /// A default style.
    /// </value>
    public static XlsxBaseStyle Default
    {
        get
        {
            var @default = Empty;
            @default.Name = BaseStyle.NameOfDefaultStyle;

            return @default;
        }
    }

    /// <summary>
    /// Gets an empty style.
    /// </summary>
    /// <value>
    /// An empty style.
    /// </value>
    public static XlsxBaseStyle Empty => new();

    #endregion

    #region public virtual readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public virtual bool BordersSpecified => !Borders.IsDefault;

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public virtual bool ContentSpecified => !Content.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets cell borders styles.
    /// </summary>
    /// <value>
    /// Reference to cell borders styles.
    /// </value>
    [JsonProperty("borders")]
    [XmlArrayItem("Border", typeof(XlsxStyleBorder), IsNullable = false)]
    public XlsxStyleBorders Borders
    {
        get => _borders ??= new XlsxStyleBorders(this);
        set => _borders = value;
    }

    /// <summary>
    /// Gets or sets a reference to the content model.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of as shown the content.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public BaseContent Content
    {
        get => _content ??= new BaseContent();
        set => _content = value;
    }

    #endregion

    #region private properties

    /// <summary>
    /// Gets a reference to inherit model.
    /// </summary>
    /// <value>
    /// A inherit style.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBaseStyle InheritStyle => Owner == null ? Empty : (XlsxBaseStyle)Owner.GetBy(Inherits);

    #endregion

    #region public static methods

    /// <summary>
    /// Returns a random style name.
    /// </summary>
    /// <returns>
    /// A new style name.
    /// </returns>
    public static string GenerateRandomStyleName() => BaseStyle.GenerateRandomStyleName();

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="IXlsxStyle"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(IXlsxStyles reference)
    {
        Owner = reference;
    }

    #endregion
}
