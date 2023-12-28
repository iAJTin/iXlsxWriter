
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
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Angle.Equals(DefaultAngle) &&
            Blur.Equals(DefaultBlur) &&
            Offset.Equals(DefaultOffset) &&
            Color.Equals(DefaultColor) &&
            Show.Equals(DefaultShow) &&
            Transparency.Equals(DefaultTransparency);
    }
}
