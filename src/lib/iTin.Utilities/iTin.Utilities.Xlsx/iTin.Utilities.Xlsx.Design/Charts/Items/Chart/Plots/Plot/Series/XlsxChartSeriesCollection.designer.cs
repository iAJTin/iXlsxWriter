
namespace iTin.Utilities.Xlsx.Design.Charts
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models.Collections;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/chart/chart/v1.0")]
    public partial class XlsxChartSeriesCollection : BaseSimpleModelCollection<XlsxChartSerie, XlsxChartPlot>
    {
    }
}
