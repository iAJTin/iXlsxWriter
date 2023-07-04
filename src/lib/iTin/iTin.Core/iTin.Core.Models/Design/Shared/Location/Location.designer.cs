
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    [XmlRoot(Namespace = "http://schemas.iTin.com/charting/chart/v1.0", IsNullable = true)]
    public partial class Location : BaseModel<Location>
    {
    }
}
