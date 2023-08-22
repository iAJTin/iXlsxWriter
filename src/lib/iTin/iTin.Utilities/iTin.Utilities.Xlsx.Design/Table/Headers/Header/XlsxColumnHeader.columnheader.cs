
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

public partial class XlsxColumnHeader
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultText = "";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultStyle = "Default";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _from;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _to;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _style;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _text;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets begin column name.
    /// </summary>
    /// <value>
    /// Begin column name.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string From
    {
        get => _from;
        set => _from = value;
    }

    /// <summary>
    /// Gets or sets end column name.
    /// </summary>
    /// <value>
    /// End column name.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string To
    {
        get => _to;
        set => _to = value;
    }

    /// <summary>
    /// Gets or sets style name.
    /// </summary>
    /// <value>
    /// Style name.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    public string Style
    {
        get => _style;
        set => _style = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether show column header.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> displays column header; Otherwise, <see cref="YesNo.No"/>. The default is <see cref="YesNo.Yes"/>.
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
    /// Gets or sets text of column header.
    /// </summary>
    /// <value>
    /// Text of column header.
    /// </value>
    [JsonProperty]
    [XmlAttribute]
    [DefaultValue(DefaultText)]
    public string Text
    {
        get => _text;
        set => _text = value;
    }

    ///// <summary>
    ///// Gets or sets the group header information.
    ///// </summary>
    ///// <value>
    ///// The group header information.
    ///// </value>
    //[XmlElement]
    //public ColumnHeaderGroup Group
    //{
    //    get
    //    {
    //        if (_group != null)
    //        {
    //            return _group;
    //        }

    //        _group = new ColumnHeaderGroup();
    //        _group.SetParent(this);

    //        return _group;
    //    }
    //    set => _group = value;
    //}

    #endregion

    #region public methods

    /// <summary>
    /// Sets the element that owns this <see cref="XlsxColumnHeader"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    public void SetOwner(IColumnsHeaders reference)
    {
        Owner = reference;
    }

    #endregion
}
