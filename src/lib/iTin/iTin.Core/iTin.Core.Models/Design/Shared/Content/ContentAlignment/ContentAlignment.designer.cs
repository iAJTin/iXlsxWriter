
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design.Content
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class ContentAlignment : BaseModel<ContentAlignment>
    {
    }
}
