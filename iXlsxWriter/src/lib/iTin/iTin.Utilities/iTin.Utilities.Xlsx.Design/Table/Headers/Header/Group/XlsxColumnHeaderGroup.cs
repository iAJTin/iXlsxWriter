
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Utilities.Xlsx.Design.Table.Headers;

namespace iTin.Core.Models.Design.Table.Headers.Header;

/// <summary>
/// 
/// </summary>
public partial class XlsxColumnHeaderGroup
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultCollapsed = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.No;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const int DefaultLevel = 1;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _collapsed;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int _level;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxColumnHeaderGroup"/> class.
    /// </summary>
    public XlsxColumnHeaderGroup()
    {
        Show = DefaultShow;
        Level = DefaultLevel;
        Collapsed = DefaultCollapsed;
    }

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element of the element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of the element.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    public IXlsxColumnHeader Parent { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a value indicating whether group its show as collapsed.
    /// </summary>
    /// <value>
    ///
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultCollapsed)]
    public YesNo Collapsed
    {
        get => GetStaticBindingValue(_collapsed.ToString()).ToUpperInvariant() == "NO" ? YesNo.No : YesNo.Yes;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _collapsed = value;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether show column header.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> displays group column header; Otherwise, <see cref="YesNo.No"/>. The default is <see cref="YesNo.No"/>.
    /// </value>
    /// <exception cref="InvalidEnumArgumentException">
    /// <paramref name="value"/> is not part of the enumeration.
    /// 
    /// -or-
    /// 
    /// <paramref name="value"/> is not an enumerated type.
    /// </exception>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => GetStaticBindingValue(_show.ToString()).ToUpperInvariant() == "NO" ? YesNo.No : YesNo.Yes;
        set
        {
            SentinelHelper.IsEnumValid(value);

            _show = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public int Level
    {
        get => _level;
        set => _level = value;
    }

    #endregion

    #region internal methods

    internal void SetParent(IXlsxColumnHeader parent)
    {
        Parent = parent;
    }

    #endregion
}
