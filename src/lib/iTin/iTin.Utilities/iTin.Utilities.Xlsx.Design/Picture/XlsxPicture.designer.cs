
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models;

    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/picture/v1.0")]
    public partial class XlsxPicture : BaseModel<XlsxPicture>
    {
    }
}
