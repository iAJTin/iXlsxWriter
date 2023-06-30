
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    [XmlRoot("Chart", Namespace = "http://schemas.iTin.com/charting/chart/v1.0", IsNullable = false)]
    public sealed partial class ChartModel : BaseModel<ChartModel>
    {
    }
}
