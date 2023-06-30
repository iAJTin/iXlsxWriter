
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models.Collections;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class XlsxStylesCollection : BaseComplexModelCollection<XlsxBaseStyle, object, string>
    {
    }
}
