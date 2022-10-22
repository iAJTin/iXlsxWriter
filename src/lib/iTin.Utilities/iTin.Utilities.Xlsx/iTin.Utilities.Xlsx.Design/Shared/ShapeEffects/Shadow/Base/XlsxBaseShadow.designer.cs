﻿
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlInclude(typeof(XlsxInnerShadow))]
    [XmlInclude(typeof(XlsxOuterShadow))]
    [XmlInclude(typeof(XlsxPerspectiveShadow))]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shared/v1.0")]
    public partial class XlsxBaseShadow : BaseModel<XlsxBaseShadow>
    {
    }
}
