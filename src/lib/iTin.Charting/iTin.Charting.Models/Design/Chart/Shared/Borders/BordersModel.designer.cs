
namespace iTin.Core.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using iTin.Core.Models.Collections;

    using Enums;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    public partial class BordersModel : BaseComplexModelCollection<BorderModel, object, KnownBorderPosition>
    {
    }
}