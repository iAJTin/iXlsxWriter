
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Utilities.Xlsx.Design.Styles
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlInclude(typeof(NumericDataType))]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0")]
    public abstract partial class RealDataType : BaseDataType
    {
    }
}
