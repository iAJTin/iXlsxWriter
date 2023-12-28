
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="XlsxBaseStyle"/> class.<br/>
/// Defines a <b>xlsx</b> cell style.
/// </summary>
public partial class XlsxCellStyle
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private FontModel _font;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxCellContent _content;

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
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool FontSpecified => !Font.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the font model.
    /// </summary>
    /// <value>
    /// Reference that contains the definition of a font.            
    /// </value>
    [XmlElement]
    [JsonProperty("font")]
    public FontModel Font
    {
        get => _font ??= FontModel.DefaultFont;
        set => _font = value;
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
    private XlsxCellStyle InheritStyle => Owner == null ? new XlsxCellStyle() : (XlsxCellStyle) Owner.GetBy(Inherits);

    #endregion
}
