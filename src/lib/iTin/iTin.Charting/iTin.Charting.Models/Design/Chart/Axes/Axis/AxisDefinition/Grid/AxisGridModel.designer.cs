
using System;
using System.ComponentModel;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Charting.Models.Design
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    public partial class AxisGridModel : BaseModel<AxisGridModel>
    {
    }
}
