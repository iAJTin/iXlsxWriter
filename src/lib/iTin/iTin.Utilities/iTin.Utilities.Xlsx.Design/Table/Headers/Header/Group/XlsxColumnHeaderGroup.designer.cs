
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design.Table.Headers.Header
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("System.Xml", "4.0.30319.18033")]
    [XmlType(Namespace = "http://schemas.iTin.com/style/v1.0")]
    public partial class XlsxColumnHeaderGroup : BaseModel<XlsxColumnHeaderGroup>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [Browsable(false)]
        public override bool IsDefault =>
            base.IsDefault &&
            Collapsed.Equals(DefaultCollapsed) &&
            Level.Equals(DefaultLevel) &&
            Show.Equals(DefaultShow);
    }
}
