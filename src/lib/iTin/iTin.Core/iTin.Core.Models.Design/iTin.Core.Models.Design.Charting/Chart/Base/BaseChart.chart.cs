
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Charting;

public partial class BaseChart : IChart
{
    /// <summary>
    /// Sets the element that owns this <see cref="IChart"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void IChart.SetOwner(ICharts reference) => SetOwner(reference);

    /// <summary>
    /// Gets the element that owns this <see cref="IChart"/>.
    /// </summary>
    /// <value>
    /// The <see cref="ICharts"/> that owns this <see cref="IChart"/>.
    /// </value>
    [JsonIgnore]
    [XmlIgnore]
    [Browsable(false)]
    public ICharts Owner { get; private set; }

    /// <summary>
    /// Gets or sets the name of the chart.
    /// </summary>
    /// <value>
    /// The name of the chart.
    /// </value>
    [XmlAttribute]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value that determines whether to display the chart. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display the chart; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => _show;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _show = value;
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        Show.Equals(DefaultShow);
}
