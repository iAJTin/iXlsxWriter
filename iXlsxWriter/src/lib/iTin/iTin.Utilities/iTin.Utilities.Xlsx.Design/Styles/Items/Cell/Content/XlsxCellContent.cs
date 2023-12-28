
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// A Specialization of <see cref="BaseBasicContent"/> class.<br/>
/// Defines a <b>xlsx</b> cell content.
/// </summary>
public partial class XlsxCellContent
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxCellMerge _merge;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private BaseDataType _dataType;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxCellPattern _pattern;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxCellContentAlignment _alignment;

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
    public bool DataTypeSpecified => !DataType.IsDefault;

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
    public bool MergeSpecified => !Merge.IsDefault;

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
    public bool PatternSpecified => !Pattern.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets content data type.
    /// </summary>
    /// <value>
    /// Reference to content data type.
    /// </value>
    [XmlElement("Currency", typeof(CurrencyDataType))]
    [XmlElement("DateTime", typeof(DateTimeDataType))]
    [XmlElement("Number", typeof(NumberDataType))]
    [XmlElement("Percentage", typeof(PercentageDataType))]
    [XmlElement("Scientific", typeof(ScientificDataType))]
    [XmlElement("Text", typeof(TextDataType))]
    [JsonProperty("datatype")]
    public BaseDataType DataType
    {
        get
        {
            if (_dataType != null)
            {
                _dataType.SetParent(this);
            }
            else
            {
                if (((XlsxCellStyle)Parent).Inherits == null)
                {
                    _dataType = new TextDataType();
                }
                else
                {
                    var inheritStyle = ((XlsxCellStyle) Parent).TryGetInheritStyle();
                    _dataType = inheritStyle.Content.DataType;
                }
            }

            return _dataType;
        }
        set
        {
            if (value != null)
            {
                _dataType = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the merge content cells definition.
    /// </summary>
    /// <value>
    /// Reference that contains the merge content cells definition.
    /// </value>
    [XmlElement]
    [JsonProperty("merge")]
    public XlsxCellMerge Merge
    {
        get => _merge ??= new XlsxCellMerge();
        set => _merge = value;
    }

    /// <summary>
    /// Gets or sets a reference to cell pattern.
    /// </summary>
    /// <value>
    /// A <see cref="Pattern"/> reference.
    /// </value>
    [XmlElement]
    [JsonProperty("pattern")]
    public XlsxCellPattern Pattern
    {
        get => _pattern ??= new XlsxCellPattern();
        set => _pattern = value;
    }

    #endregion

    #region public new properties

    /// <summary>
    /// Gets or sets content distribution.
    /// </summary>
    /// <value>
    /// Reference for content distribution.
    /// </value>
    [XmlElement]
    [JsonProperty("alignment")]
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public new XlsxCellContentAlignment Alignment
    {
        get
        {
            _alignment ??= XlsxCellContentAlignment.Default;
            _alignment.SetParent(this);

            return _alignment;
        }
        set
        {
            if (value != null)
            {
                _alignment = value;
            }
        }
    }

    #endregion
}
