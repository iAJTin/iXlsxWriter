
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

using iTin.Core.Models.Design.Helpers;

namespace iTin.Core.Models.Design.Charting;

public partial class BaseGenericChart : IGenericChart
{
    /// <summary>
    /// Gets or sets preferred back color for this chart. The default is <b>White</b>.
    /// </summary>
    /// <value>
    /// Preferred back color. 
    /// </value>
    [XmlAttribute]
    [DefaultValue(DefaultBackColor)]
    public string BackColor { get; set; }

    /// <summary>
    /// Gets a reference to the <see cref="Color"/> structure than represents back color for this chart.
    /// </summary>
    /// <returns>
    /// A <see cref="Color"/> structure that represents back color.
    /// </returns> 
    public Color GetBackColor() => ColorHelper.GetColorFromString(BackColor);
}
