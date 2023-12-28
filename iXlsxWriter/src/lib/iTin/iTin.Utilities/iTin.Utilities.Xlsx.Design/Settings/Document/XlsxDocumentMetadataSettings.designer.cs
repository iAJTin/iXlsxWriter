
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design.Settings.Document
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/settings/workbook/v1.0")]
    public partial class XlsxDocumentMetadataSettings : BaseModel<XlsxDocumentMetadataSettings>
    {
    }
}
