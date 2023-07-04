
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class Alignment : BaseModel<Alignment>
    {
    }
}
