
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Utilities.Xlsx.Design.Charts
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/chart/minichart/v1.0")]
    public partial class XlsxMiniChartLinePoints : XlsxMiniChartPoints
    {
    }
}
