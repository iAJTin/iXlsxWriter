
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design.Borders;

namespace iTin.Core.Models.Design.Styles;

/// <summary>
/// A Specialization of <see cref="IStyle"/> interface.<br/>
/// Defines a generic style.
/// </summary>
public partial class BaseStyle : IStyle
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
    private BordersCollection _borders;

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default style.
    /// </summary>
    /// <value>
    /// A default style.
    /// </value>
    public static BaseStyle Default
    {
        get
        {
            var @default = Empty;
            @default.Name = NameOfDefaultStyle;

            return @default;
        }
    }

    /// <summary>
    /// Gets an empty style.
    /// </summary>
    /// <value>
    /// An empty style.
    /// </value>
    public static BaseStyle Empty => new();

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
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public virtual bool ContentSpecified => !Content.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the collection of border properties.
    /// </summary>
    /// <value>
    /// Collection of border properties. Each element defines a border.
    /// </value>
    [JsonProperty("borders")]
    [XmlArrayItem("Border", typeof(BaseBorder), IsNullable = false)]
    public BordersCollection Borders
    {
        get => _borders ??= new BordersCollection(this);
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
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private BaseStyle InheritStyle => Owner == null
        ? Empty
        : (BaseStyle)((IStyles)Owner).GetBy(Inherits);

    #endregion

    #region public static methods

    /// <summary>
    /// Returns a random style name.
    /// </summary>
    /// <returns>
    /// A new style name.
    /// </returns>
    public static string GenerateRandomStyleName() => 
        Path
            .ChangeExtension(IO.File.GetUniqueTempRandomFile().Segments.Last(), string.Empty)
            .Replace(".", string.Empty);
    #endregion
}
