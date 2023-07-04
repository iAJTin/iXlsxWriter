
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="XlsxBaseStyle"/> class.<br/>
/// Defines a <b>xlsx</b> cell style.
/// </summary>
public partial class XlsxCellStyle
{
    #region public new readonly static properties

    /// <summary>
    /// Gets default cell style.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellStyle"/> reference containing the default cell style.
    /// </value>
    public new static XlsxCellStyle Default => new();

    #endregion

    #region public new properties

    /// <summary>
    /// Gets or sets cell content distribution.
    /// </summary>
    /// <value>
    /// Reference to cell content distribution.
    /// </value>
    [XmlElement]
    [JsonProperty("content")]
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public new XlsxCellContent Content
    {
        get
        {
            _content ??= XlsxCellContent.Default;
            _content.SetParent(this);

            return _content;
        }
        set
        {
            if (value != null)
            {
                _content = value;
            }
        }
    }

    #endregion

    #region public override readonly properties

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
    public override bool ContentSpecified => !Content.IsDefault;

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault => base.IsDefault && Content.IsDefault;

    #endregion

    #region public new methods

    /// <summary>
    /// Try gets a reference to inherit model.
    /// </summary>
    /// <returns>
    /// An inherit style.
    /// </returns>
    public new XlsxCellStyle TryGetInheritStyle() => InheritStyle;

    #endregion
}
