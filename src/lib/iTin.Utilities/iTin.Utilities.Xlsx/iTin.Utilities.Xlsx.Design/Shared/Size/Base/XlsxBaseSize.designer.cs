
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlInclude(typeof(XlsxSize))]
    [XmlInclude(typeof(XlsxPercentSize))]
    [XmlInclude(typeof(XlsxNullableSize))]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shared/v1.0")]
    public partial class XlsxBaseSize : BaseModel<XlsxBaseSize>
    {
    }
}
