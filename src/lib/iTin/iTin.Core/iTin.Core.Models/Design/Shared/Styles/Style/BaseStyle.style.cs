
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design.Styles;

public partial class BaseStyle
{
    #region explicit

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
        set => _borders = (BordersCollection)value;
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

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value indicating whether this style is an empty style.
    /// </summary>
    /// <value>
    /// <b>true</b> if is an empty style; otherwise, <b>false</b>.
    /// </value>        
    public bool IsEmpty => IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the name of the style.
    /// </summary>
    /// <value>
    /// The name of the style.
    /// </value>
    [XmlElement]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the name of parent style.
    /// </summary>
    /// <value>
    /// The name of parent style.
    /// </value>
    [XmlElement]
    [DefaultValue("")]
    public string Inherits { get; set; }

    #endregion

    #region public override readonly properties

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

    #region public methods

    /// <summary>
    /// Try gets a reference to inherit model.
    /// </summary>
    /// <returns>
    /// An inherit style.
    /// </returns>
    public IStyle TryGetInheritStyle() => InheritStyle;

    #endregion
}
