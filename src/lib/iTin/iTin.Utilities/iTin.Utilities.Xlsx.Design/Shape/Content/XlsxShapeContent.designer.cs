
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Shape
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shape/v1.0")]
    public partial class XlsxShapeContent : BaseContent
    {
    }
}
