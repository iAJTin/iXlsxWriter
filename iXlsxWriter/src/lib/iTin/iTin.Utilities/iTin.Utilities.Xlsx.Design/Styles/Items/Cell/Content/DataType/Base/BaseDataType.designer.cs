
namespace iTin.Utilities.Xlsx.Design.Styles
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using iTin.Core.Models;

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
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0")]
    [XmlRoot(Namespace = "http://schemas.iTin.com/xlsx/style/cell/v1.0", IsNullable = true)]
    public abstract partial class BaseDataType : BaseModel<BaseDataType>
    {
    }
}
