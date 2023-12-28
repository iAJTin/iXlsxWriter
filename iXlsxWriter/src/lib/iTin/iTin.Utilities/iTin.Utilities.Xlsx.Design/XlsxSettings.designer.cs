
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/settings/v1.0")]
    public partial class XlsxSettings : BaseModel<XlsxSettings>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public override bool IsDefault =>
            base.IsDefault &&
            DocumentSettings.IsDefault &&
            SheetsSettings.IsDefault;
    }
}
