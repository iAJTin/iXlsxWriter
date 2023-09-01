
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Xml.Serialization;

using iTin.Core.Models;

namespace iTin.Utilities.Xlsx.Design.Table.Headers
{
    [Serializable]
    //[DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("System.Xml", "4.0.30319.18033")]
    [XmlType(Namespace = "http://schemas.itin.com/models/core/v1.0")]
    public partial class XlsxColumnHeader : BaseModel<XlsxColumnHeader>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        [Browsable(false)]
        public override bool IsDefault =>
            Text.Equals(DefaultText) &&
            Show.Equals(DefaultShow) &&
            Style.Equals(DefaultStyle);
    }
}
