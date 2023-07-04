
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlInclude(typeof(RealDataType))]
    [XmlInclude(typeof(NumericDataType))]
    [XmlInclude(typeof(CurrencyDataType))]
    [XmlInclude(typeof(NumberDataType))]
    [XmlInclude(typeof(PercentageDataType))]
    [XmlInclude(typeof(DateTimeDataType))]
    [XmlInclude(typeof(TextDataType))]
    [GeneratedCode("System.Xml", "4.0.30319.18033")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    [XmlRoot(Namespace = "http://schemas.iTin.com/style/v1.0", IsNullable = true)]
    public abstract partial class BaseDataType : BaseModel<BaseDataType>
    {
    }
}
