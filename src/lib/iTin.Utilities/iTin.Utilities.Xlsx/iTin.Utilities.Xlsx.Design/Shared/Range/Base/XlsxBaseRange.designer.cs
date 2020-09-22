﻿
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
    [XmlInclude(typeof(XlsxRange))]
    [XmlInclude(typeof(XlsxPointRange))]
    [XmlInclude(typeof(XlsxStringRange))]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shared/v1.0")]
    public partial class XlsxBaseRange : BaseModel<XlsxBaseRange>
    {
    }
}
