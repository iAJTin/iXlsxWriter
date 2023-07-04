
using System.Diagnostics;
using System.Xml.Serialization;
using iTin.Core.Models.Design.Content;
using Newtonsoft.Json;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="IBasicContent"/> interface.<br/>
/// Which acts as the base class for different contents.
/// </summary>
public partial class BaseBasicContent : IBasicContent
{
    #region public constants

    /// <summary>
    /// Defines default content color.
    /// </summary>
    public const string DefaultColor = "Transparent";

    #endregion

    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _color;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _alternateColor;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private ContentAlignment _alignment;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseBasicContent"/> class.
    /// </summary>
    public BaseBasicContent()
    {
        Show = DefaultShow;
        Color = DefaultColor;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default content.
    /// </summary>
    /// <value>
    /// A default content.
    /// </value>
    public static BaseBasicContent Default => Empty;

    /// <summary>
    /// Gets an empty content.
    /// </summary>
    /// <value>
    /// An empty content.
    /// </value>
    public static BaseBasicContent Empty => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool AlignmentSpecified => !Alignment.IsDefault;


    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference to content alignment.
    /// </summary>
    /// <value>
    /// A <see cref="ContentAlignment"/> reference.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ContentAlignment Alignment
    {
        get
        {
            _alignment ??= ContentAlignment.Default;
            _alignment.SetParent(this);

            return _alignment;
        }
        set => _alignment = value;
    }

    #endregion
}
