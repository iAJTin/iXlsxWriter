
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0")]
    [XmlRoot(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0", IsNullable = true)]
    public partial class NegativeModel : BaseModel<NegativeModel>
    {
    }
}
