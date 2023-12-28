
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Table.Headers.Header;

using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

/// <summary>
/// A Specialization of <see cref="IXlsxColumnHeader"/> interface.<br/>
/// Which acts as the base class for different column header configurations.
/// </summary>
public partial class XlsxColumnHeader : IXlsxColumnHeader
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxColumnHeaderGroup _group;

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxColumnHeader"/> class.
    /// </summary>
    public XlsxColumnHeader()
    {
        Show = DefaultShow;
        Text = DefaultText;
        Style = DefaultStyle;
    }


    /// <summary>
    /// Gets the group header information
    /// </summary>
    [XmlElement]
    public XlsxColumnHeaderGroup Group
    {
        get
        {
            if (_group != null)
            {
                return _group;
            }

            _group = new XlsxColumnHeaderGroup();
            _group.SetParent(this);

            return _group;
        }
        set => _group = value;
    }
}
