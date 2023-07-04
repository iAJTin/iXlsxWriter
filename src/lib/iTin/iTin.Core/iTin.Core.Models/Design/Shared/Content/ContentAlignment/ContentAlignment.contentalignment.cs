
using System.ComponentModel;
using System.Xml.Serialization;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Content;

public partial class ContentAlignment : IContentAlignment
{
    /// <summary>
    /// Gets or sets preferred horizontal content alignemnt. The default is <see cref="KnownHorizontalAlignment.Left"/>.
    /// </summary>
    /// <value>
    /// Preferred horizontal content alignemnt.
    /// </value>
    [XmlAttribute]
    [DefaultValue(DefaultHorizontalAlignment)]
    public KnownHorizontalAlignment Horizontal
    {
        get => _horizontal;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _horizontal = value;
        }
    }

    /// <summary>
    /// Gets or sets preferred vertical alignemnt. The default is <see cref="KnownVerticalAlignment.Center"/>.
    /// </summary>
    /// <value>
    /// Preferred vertical alignemnt.
    /// </value>
    [XmlAttribute]
    [DefaultValue(DefaultVerticalAlignment)]
    public KnownVerticalAlignment Vertical
    {
        get => _vertical;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _vertical = value;
        }
    }
}
