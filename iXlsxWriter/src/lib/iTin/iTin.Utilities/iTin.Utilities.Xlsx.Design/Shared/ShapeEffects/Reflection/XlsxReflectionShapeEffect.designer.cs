
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
    [XmlType(Namespace = "http://schemas.iTin.com/xlsx/shared/v1.0")]
    public partial class XlsxReflectionShapeEffect : BaseModel<XlsxReflectionShapeEffect>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Blur.Equals(DefaultBlur) &&
            Size.Equals(DefaultSize) &&
            Offset.Equals(DefaultOffset) &&
            Show.Equals(DefaultShow) &&
            Transparency.Equals(DefaultTransparency);
    }
}
