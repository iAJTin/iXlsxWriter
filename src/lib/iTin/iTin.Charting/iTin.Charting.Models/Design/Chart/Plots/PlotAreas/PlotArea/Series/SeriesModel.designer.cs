
namespace iTin.Charting.Models.Design
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using iTin.Core.Models.Collections;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/charting/chart/v1.0")]
    public partial class SeriesModel : BaseComplexModelCollection<SerieModel, PlotAreaModel, string>
    {
    }
}
