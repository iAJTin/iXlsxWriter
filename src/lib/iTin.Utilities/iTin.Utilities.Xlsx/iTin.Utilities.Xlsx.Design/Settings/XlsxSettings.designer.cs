
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/settings/v1.0")]
    public partial class XlsxSettings : BaseModel<XlsxSettings>
    {
    }
}
